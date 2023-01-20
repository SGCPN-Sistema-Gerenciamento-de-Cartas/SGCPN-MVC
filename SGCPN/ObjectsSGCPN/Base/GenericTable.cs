using ObjectsSGCPN.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsSGCPN.Base
{
    public class GenericTable : DataBaseAccess
    {
        internal System.Globalization.CultureInfo BR = new System.Globalization.CultureInfo("pt-BR");

        public Detail objDetail;

        internal Parameters objParameters;

        public GenericTable(Providers objProvider, string ConnectionString, UsersDetail objDetail) : base(objProvider, ConnectionString)
        {
            this.objDetail = objDetail;
        }

        public GenericTable(Providers objProvider, string ConnectionString, UsersDetail objDetail, Parameters objParameters) : base(objProvider, ConnectionString)
        {
            this.objDetail = objDetail;
            this.objParameters = objParameters;
        }

        public GenericTable(Providers objProvider, DbConnection objConnection,DbTransaction objTransaction, UsersDetail objDetail, Parameters objParameters) : base(objProvider, objConnection, objTransaction)
        {
            this.objDetail = objDetail;
            this.objParameters = objParameters;
        }
    }

}
