using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tailor_Domain.Entities;
using Tailor_Infrastructure.Dto.MeasurementInformation;

namespace Tailor_Infrastructure.Repositories.IRepositories
{
    public interface IMeasurement_InformationRepository: IGenericRepository<MeasurementInformation, int>
    {
        int CreateMeasurement(CreateMeasurementInformation create);
    }
}
