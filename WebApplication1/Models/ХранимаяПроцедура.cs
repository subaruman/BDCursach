using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ХранимаяПроцедура
    {
        private SqlParameter sql;

        public void setQuanity(int id)
        {
            //System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@borrowerId", id);
            //var phones = Database.ExecuteSqlCommand("customProc @borrowerId", param);
            //System.Data.SqlClient.SqlParameter sql = new System.Data.SqlClient.SqlParameter();
            //var query = 0;
            //query = Database.ExecuteSqlCommand("exec TestAge()", null);
        }
    }
}