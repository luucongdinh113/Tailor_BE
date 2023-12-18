using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Services.IServices;

namespace Tailor_Infrastructure.Services
{
    public class CreateNotify : ICreateNotify
    {
        private readonly TaiLorContext _context;
        public CreateNotify(TaiLorContext context)
        {
            _context = context;
        }

        public System.Threading.Tasks.Task CreateNotifyAsync(Tailor_Domain.Entities.Task task, string status, int? percent)
        {
            string content;
            Notify notify;
            if (task == null || task.UserId == null) throw new ArgumentNullException();
            if (!String.IsNullOrEmpty(status))
            {
                content = $"{task.Product.Name} đã thay đổi trạng thái từ {HandleStatus(task.Status)} sang {HandleStatus(status)}.";
                notify = new Notify()
                {
                    UserId = task.UserId ?? Guid.Empty,
                    TaskId = task.Id,
                    Content = content,
                    Type = "status",
                    LinkProduct = task.Product.Images,
                    Priority = 0,
                    IsRead = false
                };
            }

            else
            {
                content = $"{task.Product.Name} đã được thực hiện <strong class='high-light'>{percent}%</strong>.";
                notify = new Notify()
                {
                    UserId = task.UserId ?? Guid.Empty,
                    TaskId = task.Id,
                    Content = content,
                    Type = "percent",
                    LinkProduct = task.Product.Images,
                    Priority = 0,
                    IsRead = false
                };
            }
            _context.Add(notify);
            _context.SaveChanges();
            return System.Threading.Tasks.Task.CompletedTask;
        }
        private string HandleStatus(string status)
        {
            switch (status)
            {
                case "doing":
                    return "<strong class='high-light'>đang được thực hiện</strong>";
                case "done":
                    return "<strong class='high-light'>đã hoàn thành</strong>";
                case "todo":
                    return "<strong class='high-light'>chưa thực hiện</strong>";
            }
            return "<strong class='high-light'>đã nhận</strong>";
        }

        public System.Threading.Tasks.Task CreateNotifyAdminAsync(Tailor_Domain.Entities.Task task,Guid id)
        {
            string content;
            Notify notify;
            if (task == null || task.UserId == null) throw new ArgumentNullException();
            int count = CalculateDaysDifference(task.EndTime);
            if (count >=0)
            {
                content = $"{task.Product.Name} của {task.User.LastName} còn {count} ngày là tới hạn.";
                content += $"<br> Trạng thái hiện tại: {HandleStatus(task.Status)}";
                content += $"<br> <strong class=\"expire\">Thời gian kết thúc: {task.EndTime.ToString("dd-MM-yyyy")} </strong>";
                notify = new Notify()
                {
                    UserId = id,
                    TaskId = task.Id,
                    Content = content,
                    Type = "status",
                    LinkProduct = task.Product.Images,
                    Priority = 0,
                    IsRead = false
                };
            }
            else
            {
                content = $"{task.Product.Name} của {task.User.LastName} đã trễ {-count} ngày.";
                content += $"<br> Trạng thái hiện tại: {HandleStatus(task.Status)}";
                content += $"<br> <strong class=\"deadline\">Thời gian kết thúc: {task.EndTime.ToString("dd-MM-yyyy")}</strong> ";
                notify = new Notify()
                {
                    UserId = id,
                    TaskId = task.Id,
                    Content = content,
                    Type = "percent",
                    LinkProduct = task.Product.Images,
                    Priority = 0,
                    IsRead = false
                };
            }
            _context.Add(notify);
            _context.SaveChanges();
            return System.Threading.Tasks.Task.CompletedTask;
        }
        private int CalculateDaysDifference(DateTime startDate)
        {
            DateTime currentDate = DateTime.Now;

            TimeSpan timeDifference = startDate-currentDate;
            int daysDifference = (int)timeDifference.TotalDays;
            return daysDifference;
        }


        public System.Threading.Tasks.Task CheckAdmin()
        {
            var tasks = _context.Tasks.Include(c=>c.Product).Include(c=>c.User).OrderByDescending(c=>c.EndTime).ToList();
            var idUserAdmin= _context.Users.Where(c=>c.IsAdmin).Select(c=>c.Id).FirstOrDefault();
            foreach (var task in tasks)
            {
                if (task.Status != "complete" && task.Status != "done")
                {
                    int count = CalculateDaysDifference(task.EndTime);
                    if (count <= 3)
                    {
                        CreateNotifyAdminAsync(task, idUserAdmin).Wait();
                    }
                }
            }
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}