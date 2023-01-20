using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsSGCPN.Models
{
    [Serializable]
    public class Parameters
    {
        public string SystemDate;

        public Parameters()
        {
            SystemDate = DateTime.Now.ToString();
        }
    }
}
