using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUONGNGOCHAI_2121110109
{
    class KetNoi
    {
        private static string str = @"Data Source=DESKTOP-965I83I\\NOVELS;Initial Catalog=QLBH;Persist Security Info=True;User ID=sa;Password=***********";
        public SqlConnection getConnection()
        {
            return new SqlConnection(str);
        }
    }
}
