using QLST.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLST
{
    public class QLSTDAL
    {
        private static QLSTDAL _Instance;
        public static QLSTDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QLSTDAL();
                }
                return _Instance;
            }
            private set { }
        }
        public List<DGVDisplay> GetAllSPs()
        {
            Model1 db = new Model1();
            return (from p in db.SPs
                    select new DGVDisplay
                    {
                        STT = p.STT,
                        msp = p.msp,
                        nameSP = p.nameSP,
                        NSX = p.NSX.nameNSX,
                        ngaynhap = p.ngaynhap,
                        MH = p.MH.nameMH,
                        status = p.status,
                    }).ToList();
        }
        public SP GetSPBySTT(int stt)
        {
            Model1 db = new Model1();
            return (from p in db.SPs
                    where p.STT == stt
                    select p).First();
        }
        public List<DGVDisplay> GetSPsByName(string name)
        {
            Model1 db = new Model1();
            return (from p in db.SPs
                    where p.nameSP.Contains(name)
                    select new DGVDisplay
                    {
                        STT = p.STT,
                        msp = p.msp,
                        nameSP = p.nameSP,
                        NSX = p.NSX.nameNSX,
                        ngaynhap = p.ngaynhap,
                        MH = p.MH.nameMH,
                        status = p.status,
                    }).ToList();
        }
        public List<NSX> GetAllNSXs()
        {
            Model1 db = new Model1();
            return (from p in db.NSXs
                    select p).ToList();
        }
        public List<MH> GetAllMHs()
        {
            Model1 db = new Model1();
            return (from p in db.MHs
                    select p).ToList();
        }
        public void updateSP(int stt, SP sp)
        {
            Model1 db = new Model1();
            // Query for a specific sp.
            var cust =
                (from c in db.SPs
                 where c.STT == stt
                 select c).First();
            // Change the contact.
            cust.msp = sp.msp;
            cust.nameSP = sp.nameSP;
            cust.ngaynhap = sp.ngaynhap;
            cust.maMH = sp.maMH;
            cust.maNSX = sp.maNSX;
            cust.status = sp.status;
            db.SaveChanges();
        }
        public void addSP(SP sp)
        {
            Model1 db = new Model1();
            db.SPs.Add(sp);
            db.SaveChanges();
        }
        public void deleteSPBySTT(int stt)
        {
            Model1 db = new Model1();
            var sp = (from p in db.SPs
                     where p.STT == stt
                     select p).First();
            if(sp!= null)
            {
                db.SPs.Remove(sp);
            }
            db.SaveChanges();
        }
    }
}
