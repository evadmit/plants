using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace plants.DAO
{
    
        public static class DaoFactory
        {
            public static T CreateDao<T>() where T : DAO, new()
            {
                return new T();
            }
        }
   
}