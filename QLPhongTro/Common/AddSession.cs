using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLPhongTro.Common
{
    [Serializable]
    public class AddSession
    {

        private long userID;
        private string userName;
        private string name;

        public long UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
}