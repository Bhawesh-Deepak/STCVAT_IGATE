using STCAPI.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace STCAPI.Core.Entities.ValidationCreteria
{
    [Table("ValidationCreterialReportStream")]
    public  class ValidationCreterialReportStream: BaseModel<int>
    {
        public string ReportName { get; set; }
        public string StreamName { get; set; }
        public string ApiURL { get; set; }
    }
}
