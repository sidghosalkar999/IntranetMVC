﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Zns.Intranet.Web.Models
{
    public class DbContextZns : System.Data.Entity.DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DbContextZns() : base("name=DbContext")
        {
        }

        public System.Data.Entity.DbSet<Zns.Intranet.Web.Models.Employee> Employees { get; set; }
        public System.Data.Entity.DbSet<Zns.Intranet.Web.Models.Department> Departments { get; set; }
        public System.Data.Entity.DbSet<Zns.Intranet.Web.Models.User> Users { get; set; }

    }
}
