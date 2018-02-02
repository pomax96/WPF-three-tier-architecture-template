using System.Collections.Generic;

namespace WpfProjectTemplate.DAL.Entities
{
    public class User
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        virtual public Role Role { get; set; }
        
    }
}