using ObjectsSGCPN.Base;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsSGCPN.Repository.SGCPN
{
    public class User : GenericTable
    {
        public User(Providers objProvider, string connectionString, UsersDetail objUser) : base(objProvider, connectionString, objUser)
        { }


        public async Task<bool> GetUserAsync(UsersDetail objUser)
        {
            List<DbParameter> parameterList = new List<DbParameter>();


            DbParameter objParam = base.GetParameter("@Name", DbType.String, ((UsersDetail)objDetail).Name);
            parameterList.Add(objParam);

            bool Ok = false;
            using (DbDataReader objReader = await base.GetDataReaderAsync("spGetUser", parameterList, CommandType.StoredProcedure))
            {
                if (objReader != null && objReader.HasRows)
                {
                    while (objReader.Read())
                    {

                        if (!objReader.IsDBNull(0)) objUser.Id = objReader.GetInt32(0);
                        if (!objReader.IsDBNull(1)) objUser.Name = objReader.GetString(1);
                        if (!objReader.IsDBNull(2)) objUser.Password = objReader.GetString(2);
                        if (!objReader.IsDBNull(3)) objUser.Email = objReader.GetString(3);
                        if (!objReader.IsDBNull(4)) objUser.Cpf = objReader.GetString(4);
                        if (!objReader.IsDBNull(5)) objUser.Sex = objReader.GetString(5);
                        if (!objReader.IsDBNull(6)) objUser.Telephone = objReader.GetString(6);
                        if (!objReader.IsDBNull(7)) objUser.Celullar = objReader.GetString(7);
                        if (!objReader.IsDBNull(8)) objUser.Cep = objReader.GetString(8);
                        if (!objReader.IsDBNull(9)) objUser.Address = objReader.GetString(9);
                        if (!objReader.IsDBNull(10)) objUser.Number = objReader.GetString(10);
                        if (!objReader.IsDBNull(11)) objUser.Country = objReader.GetString(11);
                        if (!objReader.IsDBNull(12)) objUser.State = objReader.GetString(12);
                        if (!objReader.IsDBNull(13)) objUser.AddressComplement = objReader.GetString(13);
                        Ok = true;
                    }
                }
            }

            return Ok;
        }

        public async Task<bool> SaveUserAsync(UsersDetail objUser)
        {
            try
            {
                if (!await FindUserAsync(objUser))
                { await AddUserAsync(objUser); }
                else
                { await UpdateUserAsync(objUser); }

                return true;
            }
            catch (DbException e)
            { throw e; }

        }


        private async Task<bool> FindUserAsync(UsersDetail objUser)
        {
            try
            {
                string outCodigo;
                List<DbParameter> parameterList = new List<DbParameter>();

                DbParameter objParam = base.GetParameter("@Name", DbType.String, objUser.Name);
                parameterList.Add(objParam);

                outCodigo = (string)await base.ExecuteScalarAsync("spFindUser", parameterList);

                if (outCodigo == null)
                { return false; }
                else
                { return true; }

            }
            catch (DbException e)
            { throw e; }
            catch (NullReferenceException)
            { return false; }
        }

        public async Task AddUserAsync(UsersDetail objUser)
        {

            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter objParam = base.GetParameter("@Name", DbType.String, null);
            if (objUser.Name == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Name;
            parameterList.Add(objParam);


            objParam = base.GetParameter("@Password", DbType.String, null);
            if (objUser.Password == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Password;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Email", DbType.String, null);
            if (objUser.Email == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Email;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Cpf", DbType.String, null);
            if (objUser.Cpf == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Cpf;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Sex", DbType.String, null);
            if (objUser.Sex == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Sex;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Telephone", DbType.String, null);
            if (objUser.Telephone == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Telephone;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Celullar", DbType.String, null);
            if (objUser.Celullar == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Celullar;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Cep", DbType.String, null);
            if (objUser.Cep == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Cep;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Address", DbType.String, null);
            if (objUser.Address == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Address;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Number", DbType.String, null);
            if (objUser.Number == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Number;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Country", DbType.String, null);
            if (objUser.Country == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Country;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@State", DbType.String, null);
            if (objUser.State == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.State;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@AddressComplement", DbType.String, null);
            if (objUser.AddressComplement == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.AddressComplement;
            parameterList.Add(objParam);

            await base.ExecuteNonQueryAsync("spAddUser", parameterList, CommandType.StoredProcedure);
        }

        public async Task UpdateUserAsync(UsersDetail objUser)
        {
            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter objParam = base.GetParameter("@Name", DbType.String, null);
            if (objUser.Name == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Name;
            parameterList.Add(objParam);


            objParam = base.GetParameter("@Password", DbType.String, null);
            if (objUser.Password == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Password;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Email", DbType.String, null);
            if (objUser.Email == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Email;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Cpf", DbType.String, null);
            if (objUser.Cpf == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Cpf;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Sex", DbType.String, null);
            if (objUser.Sex == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Sex;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Telephone", DbType.String, null);
            if (objUser.Telephone == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Telephone;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Celullar", DbType.String, null);
            if (objUser.Celullar == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Celullar;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Cep", DbType.String, null);
            if (objUser.Cep == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Cep;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Address", DbType.String, null);
            if (objUser.Address == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Address;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Number", DbType.String, null);
            if (objUser.Number == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Number;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@Country", DbType.String, null);
            if (objUser.Country == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.Country;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@State", DbType.String, null);
            if (objUser.State == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.State;
            parameterList.Add(objParam);

            objParam = base.GetParameter("@AddressComplement", DbType.String, null);
            if (objUser.AddressComplement == "") objParam.Value = DBNull.Value; else objParam.Value = objUser.AddressComplement;
            parameterList.Add(objParam);

            await base.ExecuteNonQueryAsync("spUpdateUser", parameterList, CommandType.StoredProcedure);
        }

        }
}
