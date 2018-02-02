using System;
using System.CodeDom;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WpfProjectTemplate.BLL.Interface;
using WpfProjectTemplate.BLL.Interface.DAL;
using WpfProjectTemplate.BLL.Message;

namespace WpfProjectTemplate.BLL.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUnitOfWork _db;

        public AuthenticationService(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<MessageObj> Auth(string login, string password)
        {
            var users = await _db.Users.GetAllAsync();
            var isUser = users.FirstOrDefault(x => x.Password == EncryptedPassword(password) && x.Login == login) != null;
            if (isUser)
            {
                return new MessageObj(){Result = true};
            }
            else
            {
                return new MessageObj() { Result = false,Message = Message.Message.AuthError};
            }
            
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