using TpStockApi.Data;
using TpStockApi.Data.Entities;
using TpStockApi.Services.Interfaces;
using TpStockApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TpStockApi.Services.Implementatios
{
    public class UserService:IUserService
    {
        private readonly ConsultaContext _consultaContext;
        public UserService(ConsultaContext consultaContext)
        {
            _consultaContext = consultaContext;
        }
        public User? GetUserByEmail(string email)
        {
            return _consultaContext.Users.SingleOrDefault(u=>u.Email == email);
        }
        public BaseResponse ValidarUsuario(string email, string password)
        {
            BaseResponse response = new BaseResponse();
            User? userForLogin = _consultaContext.Users.SingleOrDefault(u => u.Email == email);
            if (userForLogin != null)
            {
                if (userForLogin.Password == password)
                {
                    response.Result = true;
                    response.Message = "loging Succesfull";
                }
                else
                {
                    response.Result = false;
                    response.Message = "wrong password";
                }
            }
            else
            {
                response.Result = false;
                response.Message = "wrong email";
            }
            return response;
        }
        public int CreateUser(User user)
        {
            _consultaContext.Add(user);
            _consultaContext.SaveChanges();
            return user.Id;
        }
        public void UpdateUser(User user)
        {
            _consultaContext.Update(user);
            _consultaContext.SaveChanges();

        }

    }
}
