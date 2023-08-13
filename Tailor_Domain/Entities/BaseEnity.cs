using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Domain.Entities
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public void Undo()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
    public interface IUserInform
    {
        public DateTimeOffset CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
    public class BaseEnity <TKey>: ISoftDelete,IUserInform
    {
        [Key]
        public TKey Id { get; set; } = default!;
        public DateTimeOffset CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
