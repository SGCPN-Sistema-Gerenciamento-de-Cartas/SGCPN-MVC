using Microsoft.Extensions.Options;
using SGCPN.Utils;

namespace SGCPN.Authorization
{
    public interface IUtils
    {

    }
    public class Utils : IUtils
    {
        private readonly AppSettings appSettings;

        public Utils(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }
    }
}
