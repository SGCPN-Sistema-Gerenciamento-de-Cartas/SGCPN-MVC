using Microsoft.Extensions.Options;
using ObjectsSGCPN.Base;
using ObjectsSGCPN.Repository.SGCPN;
using SGCPN.Authorization;
using SGCPN.Controllers;
using SGCPN.Utils;
using Shared;

namespace SGCPN.Services
{
    public interface IUserService
    {
        public Task<bool> NewUserAsync(UsersDetail user);
    }
    public class UserService : IUserService
    {
        private readonly AppSettings _appSetting;
        private IUtils _utils;
        private IConfiguration _configuration;
        private ILogger _logger;

        public UserService(IOptions<AppSettings> appSettings, IUtils utils, IConfiguration iconfiguration, ILogger<UserService> logger)
        {
            _appSetting = appSettings.Value;
            _utils = utils;
            _configuration = iconfiguration;
            _logger = logger;
        }

        public async Task<bool> NewUserAsync(UsersDetail user)
        {
            ApplicationStatus applicationStatus;
            if (_configuration.GetSection("Provider").Value == "OleDb")
                applicationStatus = new ApplicationStatus(_configuration, Providers.OleDb);
            else
                applicationStatus = new ApplicationStatus(_configuration, Providers.SqlClient);

            if (string.IsNullOrEmpty(applicationStatus.connectionString))
            {
                _logger.LogInformation("Connection string not found!");
                return false;
            }

            User objUser;
            UsersDetail objDetUser;
            objDetUser = new UsersDetail();
            if (_configuration.GetSection("Provider").Value == "OleDb")
                objUser = new User(Providers.OleDb, applicationStatus.connectionString, objDetUser);
            else
                objUser = new User(Providers.SqlClient, applicationStatus.connectionString, objDetUser);

            //---Monta o Atalho dio Usuario
            UsersDetail objUserD = new UsersDetail();
            objDetUser.Name = user.Name;
            objDetUser.Email = user.Email;
            objDetUser.Password = user.Password;
            objDetUser.Email = user.Email;
            objDetUser.Cpf = user.Cpf;
            objDetUser.Sex = user.Sex;
            objDetUser.Telephone = user.Telephone;
            objDetUser.Celullar = user.Celullar;
            objDetUser.Cep = user.Cep;
            objDetUser.Address = user.Address;
            objDetUser.Number = user.Number;
            objDetUser.Country = user.Country;
            objDetUser.State =  user.State;
            objDetUser.AddressComplement = user.AddressComplement;

            if (!await objUser.GetUserAsync(objDetUser))
            {
       
                if (await objUser.SaveUserAsync(objDetUser))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
