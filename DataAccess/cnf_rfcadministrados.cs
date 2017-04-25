using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ValidSAT.DataAccess
{
    [Table("cnf_rfcadministrados")]
    public partial class cnf_rfcadministrados : Entity 
    {
        public cnf_rfcadministrados()
        {

        }

        [Key]
        public int rfc_llaveinterna { get; set; }

        public long rfc_llaveempresa { get; set; }

        public string rfc_nombreempresa { get; set; }

        public string rfc_rfcempresa { get; set; }

        public string rfc_emailcontrasena { get; set; }

        public string rfc_correoelectronico { get; set; }

        public string rfc_codigopostal  { get; set; }

        public string displayMember { get { return string.Format("{0}  {1}", rfc_rfcempresa, rfc_nombreempresa); } }

        public int rfc_accesosalrfcadministrado { get; internal set; }

        public string rfc_pathcertificadosat { get; set; }
        public string rfc_pathllavesat { get; set; }

        public string rfc_emailnomservidorent { get; set; }

        public string rfc_passwordkeysat { get; set; }

        public string rfc_passwordclaveciec { get; set; }

        //public virtual cnf_empresas empresa { get; set; }
    }
}
