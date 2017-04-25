using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ValidSAT.DataAccess
{
    [Table("cnf_empresas")]
    public partial class cnf_empresas : Entity
    {
        public cnf_empresas()
        {
           //this.cnf_rfcadministrados = new HashSet<cnf_rfcadministrados>();
        }

        [Key]
        public long emp_empresa { get; set; }
    /*
        public string emp_nombrecomercial { get; set; }
        public string emp_tipopersona { get; set; }
        public string emp_nombrepersonafisica { get; set; }
        public string emp_apepatpersonafisica { get; set; }
        public string emp_apematpersonafisica { get; set; }
        public string emp_rfc { get; set; }
        public string emp_curp { get; set; }
        public string edo_estado { get; set; }
        public string emp_llavemunicipio { get; set; }
        public string emp_llavepoblacion { get; set; }
        public string emp_calle { get; set; }
        public string emp_numero { get; set; }
        public string emp_numinter { get; set; }
        public string emp_codigopostal { get; set; }
        public string emp_telefonos { get; set; }
        public string emp_website { get; set; }
        public decimal emp_tasaimpuesto1 { get; set; }
        public string emp_emailfacturacionelectronica { get; set; }
        public string emp_emailnomservidorent { get; set; }
        public string emp_emailnomservidorsal { get; set; }
        public Nullable<int> emp_emailpuerto { get; set; }
        public string emp_emailnombreusuario { get; set; }
        public string emp_emailcontrasena { get; set; }
        public Nullable<System.DateTime> emp_fechacompra { get; set; }
        public Nullable<System.DateTime> emp_fechaexpiracion { get; set; }
        public Nullable<int> emp_costolicencia { get; set; }
        public Nullable<short> emp_rfcsampara { get; set; }
        */
        public string emp_usernameasignado { get; set; }
        public string emp_passwasignado { get; set; }
        //public System.DateTime emp_fecalta { get; set; }
        public int emp_aplicadespachocontable { get; set; }
        public int emp_rfcsampara { get; set; }
        public bool emp_inicioactividad { get; set; }
        
        //public virtual ICollection<cnf_rfcadministrados> cnf_rfcadministrados { get; set; }

    }

}

