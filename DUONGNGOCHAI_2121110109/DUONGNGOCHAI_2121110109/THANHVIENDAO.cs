using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUONGNGOCHAI_2121110109
{
    class THANHVIENDAO
        
    {
        SqlDataAdapter dataAdapter;
        SqlConnection conn = new SqlConnection();
        QLBHDBContext db = null;
        public THANHVIENDAO()
        {
            db = new QLBHDBContext();
        }
        public List<THANHVIEN> getList()
        {
            List<THANHVIEN> list=db.THANHVIENs.ToList();
            return list;
        }
        public THANHVIEN getRow(string manv,string matkhau)
        {
            return db.THANHVIENs.Where(m => m.MANV == manv && m.MATKHAU == matkhau).FirstOrDefault();
        }
        public int getCount()
        {
            return db.THANHVIENs.Count();
        }
        public void Insert(THANHVIEN tv)
        {
            db.THANHVIENs.Add(tv);
            db.SaveChanges();
        }
        public void Update(THANHVIEN tv)
        {
            db.Entry(tv).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(THANHVIEN tv)
        {
            db.THANHVIENs.Remove(tv);
            db.SaveChanges();
        }
    }
}
