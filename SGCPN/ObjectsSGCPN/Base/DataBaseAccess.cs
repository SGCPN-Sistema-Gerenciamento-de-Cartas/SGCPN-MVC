using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsSGCPN.Base
{
    public static class MyProviders
    {
        public const string
            SQlClient = "System.Data.SqlClient",
            OleDb = "System.Data.OleDb";
    }

    public enum Providers
    {
        SqlClient,
        OleDb
    }

    public class DataBaseAccess
    {
        protected Providers objProvider;

        protected string ProviderName;
        protected string ConnectionString { get; set; }
        protected DbConnection connection { get; set; }
        protected DbTransaction transaction { get; set; }

        public DataBaseAccess(Providers objProvider, string connectionString)
        {
            this.objProvider = objProvider;
            this.ConnectionString = connectionString;
            if (objProvider == Providers.SqlClient)
            {
                this.ProviderName = MyProviders.SQlClient;
                DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            }
            else
                 if (objProvider == Providers.OleDb)
            {
                this.ProviderName = MyProviders.OleDb;
                DbProviderFactories.RegisterFactory("System.Data.OleDb", System.Data.OleDb.OleDbFactory.Instance);
            }
        }

        public DataBaseAccess(Providers objProvider, DbConnection objConnection, DbTransaction objTransaction)
        {
            this.connection = objConnection;
            this.transaction = objTransaction;

            if (objProvider == Providers.SqlClient)
            {
                this.ProviderName = MyProviders.SQlClient;
                DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            }
            else
                if (objProvider == Providers.OleDb)
            {
                this.ProviderName = MyProviders.OleDb;
                DbProviderFactories.RegisterFactory("System.Data.OleDb", System.Data.OleDb.OleDbFactory.Instance);
            }
        }

        private async Task<DbConnection> GetConnectionAsync()
        {
            this.connection = DbProviderFactories.GetFactory(this.ProviderName).CreateConnection();
            connection.ConnectionString = this.ConnectionString;
            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();
            this.transaction = null;
            return connection;
        }

        public async Task BeginTransactionAsync()
        {
            this.connection = DbProviderFactories.GetFactory(this.ProviderName).CreateConnection();
            connection.ConnectionString = this.ConnectionString;
            if (this.connection.State != ConnectionState.Open)
                await this.connection.OpenAsync();
            this.transaction = await this.connection.BeginTransactionAsync(IsolationLevel.RepeatableRead);
        }

        public async Task CommitTransactionAsync()
        {
            await this.transaction.CommitAsync();
            await this.connection.CloseAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await this.transaction.RollbackAsync();
            await this.connection.CloseAsync();
        }

        protected DbCommand GetCommand(DbConnection connection, string commandText, CommandType commandType)
        {
            DbCommand command = DbProviderFactories.GetFactory(this.ProviderName).CreateCommand();
            command.Connection = connection;
            command.CommandType = commandType;
            command.CommandText = commandText;
            return command;
        }

        protected DbCommand GetCommandTransaction(string commandText, CommandType commandType)
        {

            DbCommand command = DbProviderFactories.GetFactory(this.ProviderName).CreateCommand();
            command.Connection = this.connection;
            command.CommandType = commandType;
            command.CommandText = commandText;
            command.Transaction = this.transaction;
            command.CommandType = commandType;
            return command;
        }

        protected DbParameter GetParameter(string parameter, DbType type, object value)
        {
            DbParameter parameterObject = DbProviderFactories.GetFactory(this.ProviderName).CreateParameter();
            parameterObject.ParameterName = parameter;
            parameterObject.Value = value ?? DBNull.Value;
            parameterObject.DbType = type;
            parameterObject.Direction = ParameterDirection.Input;
            return parameterObject;
        }

        protected DbParameter GetParameterOut(string parameter, DbType type, object value = null, ParameterDirection parameterDirection = ParameterDirection.InputOutput)
        {
            DbParameter parameterObject = DbProviderFactories.GetFactory(this.ProviderName).CreateParameter();
            parameterObject.Direction = parameterDirection;
            parameterObject.Value = value ?? DBNull.Value;
            return parameterObject;
        }

        protected async Task<int> ExecuteNonQueryTransactionAsync(string procedureName, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            int returnValue = -1;

            DbCommand cmd = this.GetCommandTransaction(procedureName, commandType);

            if (parameters != null && parameters.Count > 0)
            {
                cmd.Parameters.AddRange(parameters.ToArray());
            }

            returnValue = await cmd.ExecuteNonQueryAsync();

            return returnValue;
        }

        protected async Task<int> ExecuteNonQueryAsync(string procedureName, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            int returnValue = -1;

            using (DbConnection connection = await this.GetConnectionAsync())
            {
                DbCommand cmd = this.GetCommand(connection, procedureName, commandType);

                if (parameters != null && parameters.Count > 0)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                returnValue = await cmd.ExecuteNonQueryAsync();
            }

            return returnValue;
        }

        protected async Task<object> ExecuteScalarAsync(string procedureName, List<DbParameter> parameters)
        {
            object returnValue = null;

            using (DbConnection connection = await this.GetConnectionAsync())
            {
                DbCommand cmd = this.GetCommand(connection, procedureName, CommandType.StoredProcedure);

                if (parameters != null && parameters.Count > 0)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                returnValue = await cmd.ExecuteScalarAsync();
            }

            return returnValue;
        }

        protected async Task<object> ExecuteScalarTransactionAsync(string procedureName, List<DbParameter> parameters)
        {
            object returnValue = null;

            DbCommand cmd = this.GetCommandTransaction(procedureName, CommandType.StoredProcedure);

            if (parameters != null && parameters.Count > 0)
            {
                cmd.Parameters.AddRange(parameters.ToArray());
            }

            returnValue = await cmd.ExecuteScalarAsync();

            return returnValue;
        }
        protected async Task<DbDataReader> GetDataReaderAsync(string procedureName, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            DbDataReader ds;

            //try
            //{
            DbConnection connection = await this.GetConnectionAsync();
            {
                DbCommand cmd = this.GetCommand(connection, procedureName, commandType);
                if (parameters != null && parameters.Count > 0)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                ds = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);
            }
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}

            return ds;
        }

        protected async Task<DbDataReader> GetDataReaderTransactionAsync(string procedureName, List<DbParameter> parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            DbDataReader ds;

            DbCommand cmd = this.GetCommandTransaction(procedureName, commandType);
            if (parameters != null && parameters.Count > 0)
            {
                cmd.Parameters.AddRange(parameters.ToArray());
            }

            ds = await cmd.ExecuteReaderAsync();

            return ds;
        }
    }
}
