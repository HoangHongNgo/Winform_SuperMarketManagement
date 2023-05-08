using QLST.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLST
{
    public class QLSTBLL
    {
        private static QLSTBLL _Instance;
        public static QLSTBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QLSTBLL();
                }
                return _Instance;
            }
            private set { }
        }
        public List<DGVDisplay> GetAllSPs()
        {
            return QLSTDAL.Instance.GetAllSPs();
        }
        public SP GetSPBySTT(int stt)
        {
            return QLSTDAL.Instance.GetSPBySTT(stt);
        }
        public List<DGVDisplay> GetSPsByName(string name)
        {
            return QLSTDAL.Instance.GetSPsByName(name);
        }
        public List<NSX> GetAllNSXs()
        {
            return QLSTDAL.Instance.GetAllNSXs();
        }
        public List<MH> GetAllMHs()
        {
            return QLSTDAL.Instance.GetAllMHs();
        }
        public void updateSP(int stt, SP sp)
        {
            QLSTDAL.Instance.updateSP(stt, sp);
        }
        public void addSP(SP sp)
        {
            QLSTDAL.Instance.addSP(sp);
        }
        public void deleteSPBySTT(int stt)
        {
            QLSTDAL.Instance.deleteSPBySTT(stt);
        }
        public delegate bool compareType(DGVDisplay s1, DGVDisplay s2);

        //Sort
        public bool compareMSP(DGVDisplay sp1, DGVDisplay sp2)
        {
            return (string.Compare(sp1.msp, sp2.msp, StringComparison.Ordinal) >= 0 ? true : false);
        }
        public bool compareNameSP(DGVDisplay sp1, DGVDisplay sp2)
        {
            return (string.Compare(sp1.nameSP, sp2.nameSP, StringComparison.Ordinal) >= 0 ? false : true);
        }
        public bool compareNameMH(DGVDisplay sp1, DGVDisplay sp2)
        {
            return (string.Compare(sp1.MH, sp2.MH, StringComparison.Ordinal) >= 0 ? false : true);
        }
        public bool compareNgayNhap(DGVDisplay sp1, DGVDisplay sp2)
        {
            return (DateTime.Compare(sp1.ngaynhap, sp2.ngaynhap) >= 0 ? true : false);
        }
        public List<DGVDisplay> Sort(List<DGVDisplay> li, compareType d)
        {
            for (int j = 0; j <= li.Count - 2; j++)
            {
                DGVDisplay temp;
                for (int i = 0; i <= li.Count - 2; i++)
                {
                    if (d(li[i], li[i + 1]))
                    {
                        temp = li[i + 1];
                        li[i + 1] = li[i];
                        li[i] = temp;
                    }
                }
            }
            return li;
        }
        public List<DGVDisplay> sortDGV(List<DGVDisplay> li, string s)
        {
            MessageBox.Show("Sắp xếp theo: " + s);
            if (s == "Mã sản phẩm") return Sort(li, compareMSP);
            if (s == "Tên sản phẩm") return Sort(li, compareNameSP);
            if (s == "Tên mặt hàng") return Sort(li, compareNameMH);
            else return Sort(li, compareNgayNhap);
        }
    }
}
