using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aznews.Areas.Admin.Models;
using aznews.Models;

namespace aznew.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<tblMenu> Menus { get; set; }
        public DbSet<viewPostMenu> viewPostMenus { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<tblPost> Posts { get; set; }
    }
}