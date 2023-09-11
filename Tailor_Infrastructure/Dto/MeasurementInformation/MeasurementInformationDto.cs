using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Dto.MeasurementInformation
{
    public class MeasurementInformationDto
    {
        public  int Id { get; set; }
        public double NeckCircumference { get; set; }
        public double CheckCircumference { get; set; }
        public double WaistCircumference { get; set; }
        public double HipCircumference { get; set; }
        public double ShoulderWidth { get; set; }
        public double UnderamCircumference { get; set; }
        public double SleeveLength { get; set; }
        public double CuffCircumference { get; set; }
        public double ShirtLength { get; set; }
        public double ThighCircumference { get; set; }
        public double BottomCircumference { get; set; }
        public double InseamLength { get; set; }
        public double PantLength { get; set; }
        public double KneeHeight { get; set; }
        public double PantLegWidth { get; set; }
    }
}
