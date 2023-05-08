using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLST.DTO
{
    public class DGVDisplay
    {
        [DisplayName("STT")]
        public int STT { get; set; }
        [DisplayName("Mã sản phẩm")]
        public string msp { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string nameSP { get; set; }
        [DisplayName("Nhà SX")]
        public string NSX { get; set; }
        [DisplayName("Ngày nhập")]
        public DateTime ngaynhap { get; set; }
        [DisplayName("Mặt hàng")]
        public string MH { get; set; }
        [DisplayName("Tình trạng")]
        public bool status { get; set; }
    }
}
