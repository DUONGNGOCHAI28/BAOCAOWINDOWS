using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUONGNGOCHAI_2121110109
{ 

    internal class SANPHAMDAO
    {
        QLBHDBContext db = new QLBHDBContext();
        public List<SANPHAM> LoadDSSP()
        {
            List<SANPHAM> list = db.SANPHAMs.ToList();
            return list;
        }
    }
}
