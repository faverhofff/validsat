using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidSAT.DataAccess
{
    class CMailServers
    {
        public string server { get; set; }
        public string  name { get; set; }
        public string domain { get; set; }

        public CMailServers() { }
        public CMailServers(string domain, string name) { this.domain = domain; this.name = name; }
    }
}
