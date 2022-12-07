using STCAPI.Core.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace STCAPI.Core.Entities.SqlQueryValidation
{
    [Table("SqlQueryValidation")]
    public class SqlQueryValidationModel : BaseModel<int>
    {
        public string UserName { get; set; }
        public string SqlQuery { get; set; }
        public string Stream { get; set; }
        public string Report { get; set; }
        public string RuleName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ActionType { get; set; }
        public string AppName { get; set; }
        public string   QueryCondition { get; set; }
        public string MaxMonth { get; set; }
    }
}
