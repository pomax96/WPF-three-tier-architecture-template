using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WpfProjectTemplate.DAL.Entities;

namespace WpfProjectTemplate.DAL.EF
{
   public class ProjectInitializer : CreateDatabaseIfNotExists<ProjectContext>
    {
        protected override void Seed(ProjectContext db)
        {
            db.Roles.AddRange(new List<Role>()
            {
                new Role(){Name = "admin"},
                new Role(){Name = "user"},
                new Role(){Name = "storekeeper"}
            });
            db.SaveChanges();

            db.Users.AddRange(new List<User>()
            {
                new User() {Login = "admin", Password = EncryptedPassword("admin"),Role = db.Roles.First(x => x.Name=="admin")},
                new User() {Login = "user", Password = EncryptedPassword("user"),Role = db.Roles.First(x => x.Name=="user")},
                new User() {Login = "storage", Password = EncryptedPassword("storage"),Role = db.Roles.First(x => x.Name=="storekeeper")},


            });
            db.SaveChanges();

        }

        private string EncryptedPassword(string password)
        {
            var pass = System.Text.Encoding.UTF8.GetBytes(password);
            var salt = System.Text.Encoding.UTF8.GetBytes("PRsolution");
            var hmacMD5 = new HMACMD5(salt);
            var saltedHash = hmacMD5.ComputeHash(pass);
            var saltedHash1 = BitConverter.ToString(saltedHash);

            return saltedHash1;
        }
    }
}
