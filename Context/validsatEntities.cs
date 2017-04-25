using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ValidSAT.DataAccess;
using ValidSAT.Properties;

namespace ValidSAT.Context
{
    public partial class validsatEntities : DbContext
    {
        public validsatEntities() : base(nameOrConnectionString: "real") { }
        public validsatEntities(string connection) : base(connection) { }

        public validsatEntities(DbConnection existingConnection, bool contextOwnsConnection)
      : base(existingConnection, contextOwnsConnection)
        {

        }

        public DbSet<cnf_empresas> cnf_empresas { get; set; }
        public DbSet<cnf_codigospostales> cnf_codigospostales { get; set; }

        public DbSet<cnf_rfcadministrados> cnf_rfcadministrados { get; set; }
    }
}
