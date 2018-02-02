using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProjectTemplate.DAL.Entities;

namespace WpfProjectTemplate.DAL.EF
{
   public class ProjectContext : DbContext
    {
        public ProjectContext() : base("DataBase")
        {
        }
        static ProjectContext()
        {
            Database.SetInitializer<ProjectContext>(new ProjectInitializer());
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
