using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public abstract class Detail
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
        public Detail()
        {
            myIsvalid = false;
            myInactive = false;
        }
    }
}

