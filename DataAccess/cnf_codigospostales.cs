using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ValidSAT.DataAccess
{
    [Table("cnf_codigospostales")]
    public partial class cnf_codigospostales : Entity
    {

        [Key]
        [Column("cpo_llavecodigopostal")]
        public int cpo_llavecodigopostal { get; set; }
        public long cpo_codigopostal { get; set; }
        public string cpo_poblacioncolonia { get; set; }
        public string cpo_municipio { get; set; }
        public string cpo_estado { get; set; }
        public string cpo_pais { get; set; }
        
        public string displayMember
        {
            get { return string.Format("{0} {1}, {2}", this.cpo_codigopostal, this.cpo_municipio, this.cpo_poblacioncolonia); }
        }
    }

}

