using QLST.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLST
{
    public class CreateDB : CreateDatabaseIfNotExists<Model1>
    {
        protected override void Seed(Model1 context)
        {
            context.SPs.AddRange(new SP[]
            {
                new SP {msp = "0", nameSP = "Áo thun", ngaynhap = DateTime.Now, maNSX = "1", status = true, maMH = "1"},
                new SP {msp = "1", nameSP = "Quần", ngaynhap = DateTime.Now, maNSX = "0", status = true, maMH = "0"},
                new SP {msp = "2", nameSP = "Áo khoác", ngaynhap = DateTime.Now, maNSX = "1", status = true, maMH = "1"},
            });
            context.NSXs.AddRange(new NSX[]
            {
                new NSX {maNSX = "0", nameNSX = "Uniqlo"},
                new NSX {maNSX = "1", nameNSX = "Crocodile"}
            });
            context.MHs.AddRange(new MH[]
            {
                new MH {maMH = "0", nameMH = "Quần"},
                new MH {maMH = "1", nameMH = "Áo"},
            });
        }
    }
}
