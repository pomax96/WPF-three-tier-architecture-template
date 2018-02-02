using System.Threading.Tasks;
using WpfProjectTemplate.BLL.Message;

namespace WpfProjectTemplate.BLL.Interface
{
    public interface IAuthenticationService
    {
        Task<MessageObj> Auth(string login, string password);
    }
}