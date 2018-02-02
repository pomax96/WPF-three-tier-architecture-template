using System.Collections.Generic;

namespace WpfProjectTemplate.DAL.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        virtual public ICollection<User> Users { get; set; }
    }
}