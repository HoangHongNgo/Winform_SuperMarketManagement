using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLST.DTO
{
    public class MH
    {
        public MH()
        {
            this.SPs = new HashSet<SP>();
        }
        [Key]
        public string maMH { get; set; }
        public string nameMH { get; set; }
        public virtual ICollection<SP> SPs { get; set; }
    }
}
