using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ValidSAT.Context;
using ValidSAT.DataAccess;

namespace ValidSAT.Classes
{
    public static class BussinessModel
    {
        private static MySqlConnection connection;
        private static string connectionString;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;

        static public System.Data.ConnectionState dbConnectionActive()
        {
            server = "dallaswin200.arvixeshared.com";
            database = "validsat";
            uid = "validsat";
            password = "ahmed2017";
/*
            server = "127.0.0.1";
            database = "validsat";
            uid = "root";
            password = "sa";
*/
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            try
            {
                Global.Instance.connectionState = connection.State;
                connection.Open();
            }
            catch (Exception error)
            {
                return connection.State;
            }
            

            return connection.State;
        }

        static public List<cnf_codigospostales> dameCodigosPostales(int skip=0, int limit = -1)
        {            
            using (var db = new validsatEntities(connection, true))
            {
                if (limit >= 0)
                    return db.cnf_codigospostales.Take(limit).ToList();
                else
                    return db.cnf_codigospostales.ToList();
            }
        }

        static public int countCodigosPostales()
        {
            using (var db = new validsatEntities(connection, true))
            {
                return db.cnf_codigospostales.Count();
            }
        }

        static public cnf_empresas ValidarUsuarioDeEmpresa(string user, string password)
        {
            if (user.Trim() == "")
                return null;

            cnf_empresas cnf_empresa = null;

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = string.Format("SELECT * from cnf_empresas where emp_usernameasignado='{0}' and emp_passwasignado='{1}'", user, Helper.Encrypt(password));
            
            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    cnf_empresa = new cnf_empresas();
                    cnf_empresa.emp_empresa = Convert.ToInt64( reader["emp_empresa"] );
                    cnf_empresa.emp_aplicadespachocontable = Convert.ToInt16(reader["emp_aplicadespachocontable"]);
                    cnf_empresa.emp_inicioactividad = Convert.ToBoolean(reader["emp_inicioactividad"]);
                    cnf_empresa.emp_passwasignado = Convert.ToString(reader["emp_passwasignado"]);
                    cnf_empresa.emp_rfcsampara = Convert.ToInt32(reader["emp_rfcsampara"]);
                    cnf_empresa.emp_usernameasignado = Convert.ToString(reader["emp_usernameasignado"]);
                }
            }
            catch (Exception ex) { return null; }
            finally
            {
                reader.Close();
            }

            return cnf_empresa;
        }

        static public int cantidadEmpresasAdministrados(long empresa)
        {
            connection.Close();

            if (connection.State == ConnectionState.Closed)
                connection.Open();

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = string.Format("SELECT count(*) as cantidad from cnf_rfcadministrados where rfc_llaveempresa={0}", empresa);
            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    return Convert.ToInt32(reader[0]);
                }
            }
            catch (Exception ex) { reader.Close();  return 0; }
            finally
            {
                reader.Close();
            }

            return 0;
        }

        static public bool deleteRfcAdministrados(int id)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = string.Format("delete from cnf_rfcadministrados where rfc_llaveinterna={0}", id);
            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read()){ return true; }
            }
            catch (Exception ex) { reader.Close(); return false; }
            finally
            {
                reader.Close();
            }

            return false;
        }

        static public bool ExistenRfcAdministrados(long empresa)
        {
            try
            {
                using (var db = new validsatEntities(connection, true))
                {
                    cnf_rfcadministrados rfcadministrados = db.cnf_rfcadministrados.FirstOrDefault(e => e.rfc_llaveempresa == empresa);

                    return rfcadministrados != null; ;
                }
            }
            catch (DbEntityValidationException e)
            {
                return false;
            }
        }

        static public cnf_rfcadministrados ExisteRfc(string rfc)
        {
            try
            {
                using (var db = new validsatEntities(connection, true))
                {
                    return  db.cnf_rfcadministrados.FirstOrDefault(e => e.rfc_rfcempresa == rfc);
                }
            }
            catch (DbEntityValidationException e)
            {
                return null;
            }

            return null;
        }

        static public List<cnf_rfcadministrados> getRfcAdministrados(long empresa, bool nuevo_registro=false)
        {
            try
            {
                using (var db = new validsatEntities(connection, true))
                {
                    List<cnf_rfcadministrados> salida = new List<cnf_rfcadministrados>();
                    
                    if (nuevo_registro)
                    {
                        cnf_rfcadministrados agregar = new cnf_rfcadministrados();
                        agregar.rfc_nombreempresa = "Agregar Empresa";
                        agregar.rfc_rfcempresa = "";
                        agregar.rfc_codigopostal = "";
                        salida.Add(agregar);
                    }

                    salida.AddRange(db.cnf_rfcadministrados.Where(e => e.rfc_llaveempresa == empresa).ToList());
                    return salida;
                }
            }
            catch (DbEntityValidationException e)
            {
                return null;
            }
        }

        static public void storeConfigApp(string rfc, string nombre, string correo, string servidor, string password, string cp, string ciec_key, string sat_key, string path_ciec, string path_sat, string rfc_update = "")
        {
            var db = new validsatEntities(connection, true);
            cnf_rfcadministrados row = new cnf_rfcadministrados();

            if (((ExisteRfc(rfc)) != null && rfc_update == "") || ((ExisteRfc(rfc)) != null && rfc_update != "" && rfc != rfc_update))
                throw new RfcExistsException();

            if (rfc_update != "")
                row = db.cnf_rfcadministrados.First(e => e.rfc_rfcempresa == rfc_update);

            row.rfc_nombreempresa = nombre;
            row.rfc_rfcempresa = rfc;
            row.rfc_codigopostal = cp;
            row.rfc_correoelectronico = correo;
            row.rfc_emailnomservidorent = servidor;
            row.rfc_emailcontrasena = password;
            row.rfc_llaveempresa = Global.Instance.userLogin.emp_empresa;
            row.rfc_passwordclaveciec = ciec_key;
            row.rfc_passwordkeysat = sat_key;
            row.rfc_pathllavesat = path_ciec;
            row.rfc_pathcertificadosat = path_sat;

            if (rfc_update == "")
                db.cnf_rfcadministrados.Add(row);

            db.SaveChanges();
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static public void test()
        {
            var db = new validsatEntities(connection, true);

            for (int j = 5204; j <= 1000000; j++)
            {
                cnf_rfcadministrados row = new cnf_rfcadministrados();
                row.rfc_nombreempresa = RandomString(50);
                row.rfc_rfcempresa = RandomString(10);
                row.rfc_codigopostal = RandomString(10);
                row.rfc_correoelectronico = RandomString(15);
                row.rfc_emailcontrasena = RandomString(10);

                db.cnf_rfcadministrados.Add(row);
                db.SaveChanges();

            }
        }

    }
}
