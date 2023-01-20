using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class UsersDetail : Detail
    {
        public int myId;
        public string myName;
        public string myPassword;
        public string myEmail;
        public string myCpf;
        public string mySex;
        public string myTelephone;
        public string myCelullar;
        public string myCep;
        public string myAddress;
        public string myNumber;
        public string myCountry;
        public string myState;
        public string myAddressComplement;

        public UsersDetail()
        {
            myId = 0;
            myName = "";
            myPassword = "";
            myEmail = "";
            myCpf = "";
            mySex = "";
            myTelephone = "";
            myCelullar = "";
            myCep = "";
            myAddress = "";
            myNumber = "";
            myCountry = "";
            myState = "";
            myAddressComplement = "";
        }

        protected override void Detail_Validate_Fields()
        {
            if(myName == "")
            {
                Isvalid = false;
                return;
            }
            if (myPassword == "")
            {
                Isvalid = false;
                return;
            }
        }

        public int Id
        {
            get { return myId; }
            set { myId = value; }
        }

        public string Name
        {
            get { return myName; }
            set { myName = value; }
        }
        public string Password
        {
            get { return myPassword; }
            set { myPassword = value; }
        }
        public string Email
        {
            get { return myEmail; }
            set { myEmail = value; }
        }
        public string Cpf
        {
            get { return myCpf; }
            set { myCpf = value; }
        }
        public string Sex
        {
            get { return mySex; }
            set { mySex = value; }
        }
        public string Telephone
        {
            get { return myTelephone; }
            set { myTelephone = value; }
        }
        public string Celullar
        {
            get { return myCelullar; }
            set { myCelullar = value; }
        }
        public string Cep
        {
            get { return myCep; }
            set { myCep = value; }
        }
        public string Address
        {
            get { return myAddress; }
            set { myAddress = value; }
        }
        public string Number
        {
            get { return myNumber; }
            set { myNumber = value; }
        }
        public string Country
        {
            get { return myCountry; }
            set { myCountry = value; }
        }
        public string State
        {
            get { return myState; }
            set { myState = value; }
        }
        public string AddressComplement
        {
            get { return myAddressComplement; }
            set { myAddressComplement = value; }
        }


    }
}
