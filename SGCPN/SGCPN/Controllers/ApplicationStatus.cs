using ObjectsSGCPN;
using ObjectsSGCPN.Base;
using ObjectsSGCPN.Util;

namespace SGCPN.Controllers
{
    public class ApplicationStatus
    {
        IConfiguration _iconfiguration;
        public string connectionString { get; set; }

        public ApplicationStatus(IConfiguration iconfiguration, Providers objProvider)
        {
            this._iconfiguration = iconfiguration;
            this.connectionString = "";
            if (objProvider == Providers.SqlClient)
                this.connectionString = _iconfiguration.GetSection("ConnectionStringSQL").Value;
            else
                this.connectionString = _iconfiguration.GetSection("ConnectionStringOleDb").Value;
            GlobalVariables.ConnectionString = this.connectionString;
        }
    }
}
