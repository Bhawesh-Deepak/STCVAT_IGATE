using STCAPI.Core.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace STCAPI.DataLayer.AdminPortal
{
    [Table("StageMaster")]
    public class StageMaster : BaseModel<int>
    {
        public string Name { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
    }
}
