using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL_QLBanHang
{
   public class DBConnect
    {
        
        protected SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-81VHF3A\SQLEXPRESS;Initial Catalog=qlbh;Integrated Security=True");
    }
}
