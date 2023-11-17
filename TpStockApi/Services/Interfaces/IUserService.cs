using TpStockApi.Data.Entities;
using TpStockApi.Data.Models;

namespace TpStockApi.Services.Interfaces
{
    public interface IUserService
    {
        public BaseResponse ValidarUsuario(string username,string password);
        public User? GetUserByEmail(string UserName);
        public int CreateUser(User user);
        public void UpdateUser (User user);

    }
}
