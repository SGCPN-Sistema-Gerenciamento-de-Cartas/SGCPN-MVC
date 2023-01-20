using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsSGCPN.Base
{
    public abstract class BaseDetail
    {
        private bool myIsvalid;
        private bool myInactive;

        protected abstract void Detail_Validate_Fields();

        public bool Inactive
        {
            get { return myInactive; }
            set { myInactive = value; }
        }

        public bool Isvalid
        {
            get { return myIsvalid; }
            set { myIsvalid = value; }
        }
        public BaseDetail()
        {
            myIsvalid = false;
            myInactive = false;
        }
    }
}
