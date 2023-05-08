using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLST.DTO
{
    public class SP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }
        public string msp { get; set; }
        public string nameSP { get; set; }
        public DateTime ngaynhap { get; set; }
        public string maNSX { get; set; }
        [ForeignKey("maNSX")]
        public NSX NSX { get; set; }
        public bool status { get; set; }
        public string maMH { get; set; }
        [ForeignKey("maMH")]
        public MH MH { get; set; } 
    }
}
