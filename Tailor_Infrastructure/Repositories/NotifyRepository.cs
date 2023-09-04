using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Repositories.IRepositories;

namespace Tailor_Infrastructure.Repositories
{
    public class NotifyRepository : GenericRepository<Notify, int>, INotifyRepository
    {
        private IUnitOfWorkRepository _unitOfWorkRepository;
        public NotifyRepository(TaiLorContext context, IUnitOfWorkRepository unitOfWorkRepository) : base(context)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }
    }
}
