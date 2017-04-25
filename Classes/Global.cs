using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidSAT.DataAccess;

namespace ValidSAT.Classes
{
    public sealed class Global
    {
        private static Global instance = null;
        private static readonly object padlock = new object();

        public cnf_empresas userLogin = null;

        public bool goToConfigApp = false;

        public System.Data.ConnectionState connectionState { get; set; }

        public bool can_Alta = false;
                
        Global()
        {
        }

        public static Global Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Global();
                    }
                    return instance;
                }
            }
        }



    }
}
