using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;

namespace Utilities
{
    public static class Configuration
    {

        public static string GetConnectionString(string name)
        {
            return "Data Source=.;Initial Catalog=HRDatabase;Integrated Security=True"; 
                //ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static string GetDefaultConnectionString()
        {
            return GetConnectionString("DefaultConnection");
        }
    }
}
