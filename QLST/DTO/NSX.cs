using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLST.DTO
{
    public class NSX
    {
        public NSX()
        {
            this.SPs = new HashSet<SP>();
        }
        [Key]
        public string maNSX { get; set; }
        public string nameNSX { get; set; }
        public virtual ICollection<SP> SPs { get; set; }
    }
}
