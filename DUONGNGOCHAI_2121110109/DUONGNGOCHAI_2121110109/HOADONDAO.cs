using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUONGNGOCHAI_2121110109
{
    internal class HOADONDAO
    {
        QLBHDBContext db = null;
        public HOADONDAO()
        {
            db = new QLBHDBContext();
        }
        public List<HOADON> getList()
        {
            return db.HOADONs.ToList();
        }
        public HOADON getRow(int SOHD)
        {
            return db.HOADONs.Find(SOHD);
        }
        public int getCount()
        {
            return db.HOADONs.Count();
        }
        public void Insert(HOADON hoadon)
        {
            db.HOADONs.Add(hoadon);
            db.SaveChanges();
        }
        public void Update(HOADON hoadon)
        {
            db.Entry(hoadon).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(HOADON hoadon) 
        {
            db.HOADONs.Remove(hoadon);
            db.SaveChanges();
        }
        public void Detele(int SOHD)
        {
            HOADON hoadon = db.HOADONs.Find(SOHD);
            db.HOADONs.Remove(hoadon);
            db.SaveChanges();
        }
        
    }
}
