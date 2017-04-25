using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ValidSAT.Classes;
using ValidSAT.DataAccess;

namespace ValidSAT.forms
{
    public partial class frmMainMenu : Form
    {
        private long _empresa = Global.Instance.userLogin.emp_empresa;

        private bool foco_menu = true;

        private int page = 1;

        public frmMainMenu()
        {
            InitializeComponent();
            // SE OPTIMIZARA POR PASO MAS ADELANTE; AHORA RELLENAR  

            //BussinessModel.test();
            //Application.Exit();

            if (Global.Instance.goToConfigApp)
            {
                this._clearOption();
                opt_configurarApp.Image = global::ValidSAT.Properties.Resources.b8;
                panel_ConfigurarApp.Visible = true;
            }

            initCodigoPostal();

            List<CMailServers> mail_list = new List<CMailServers>();
            mail_list.Add(new CMailServers("@hotmail.com", "hotmail.com") );
            mail_list.Add(new CMailServers("@outlook.com", "outlook.com"));
            mail_list.Add(new CMailServers("@live.com", "live.com"));
            mail_list.Add(new CMailServers("@gmail.com", "gmail.com"));
            mail_list.Add(new CMailServers("@yahoo.es", "yahoo.es"));
            mail_list.Add(new CMailServers("@yahoo.com", "yahoo.com"));
            mail_list.Add(new CMailServers("@yahoo.com.mx", "yahoo.com.mx"));

            emailServerList.DataSource = mail_list;

            //Thread thread_1 = new Thread(new ThreadStart(initCodigoPostal));
            //thread_1.Start();
            //new Thread(new ThreadStart(initCodigoPostal)).Start();

            dataRfcAdministrados.AutoGenerateColumns = false;
            this.Focus();
        }



        void initCodigoPostal()
        {
            CodigoPostalListado.DataSource = BussinessModel.dameCodigosPostales(0, 1000);
        }


        private void opt_descargarXMLS_Click(object sender, EventArgs e)
        {
            this._clearOption();
            opt_descargarXMLS.Image = global::ValidSAT.Properties.Resources.b1;
            panel_DescargarXMLS.Visible = true;
        }

        private void opt_validarXMLS_Click(object sender, EventArgs e)
        {
            this._clearOption();
            opt_validarXMLS.Image = global::ValidSAT.Properties.Resources.b2;
        }

        private void opt_cancelarXMLS_Click(object sender, EventArgs e)
        {
            this._clearOption();
            opt_cancelarXMLS.Image = global::ValidSAT.Properties.Resources.b3;
        }

        private void opt_generarConfronta_Click(object sender, EventArgs e)
        {
            this._clearOption();
            opt_generarConfronta.Image = global::ValidSAT.Properties.Resources.b4;
        }

        private void opt_descargarPdf_Click(object sender, EventArgs e)
        {
            this._clearOption();
            opt_descargarPdf.Image = global::ValidSAT.Properties.Resources.b5;
        }

        private void opt_creaarPdf_Click(object sender, EventArgs e)
        {
            this._clearOption();
            opt_creaarPdf.Image = global::ValidSAT.Properties.Resources.b6;
        }

        private void opt_generarReporte_Click(object sender, EventArgs e)
        {
            this._clearOption();
            opt_generarReporte.Image = global::ValidSAT.Properties.Resources.b7;
        }

        private void opt_configurarApp_Click(object sender, EventArgs e)
        {
           configurarApp();
        }

        private void configurarApp()
        {
            long cntRFCEmpresas = BussinessModel.cantidadEmpresasAdministrados(Global.Instance.userLogin.emp_empresa);
            if (cntRFCEmpresas == 0)
                ValidSAT.Classes.MessageBox.showAdviseModal("Hace falta registrar la empresa. Póngase en comunicación con el personal de ValidSAT. Gracias.");

            rfcListado.DataSource = dataRfcAdministrados.DataSource = BussinessModel.getRfcAdministrados(this._empresa,
                                                                                                         Global.Instance.userLogin.emp_aplicadespachocontable == 1 && cntRFCEmpresas >= 1 &&
                                                                                                         cntRFCEmpresas <= Global.Instance.userLogin.emp_rfcsampara
                                                                                                         );


            if (((IList)rfcListado.DataSource).Count == 0 && Global.Instance.userLogin.emp_aplicadespachocontable == 1)
                ValidSAT.Classes.MessageBox.showAdviseModal("No se pueden encontrar los datos de la empresa. Por favor avise sobre este mensaje a nuestra área de soporte tècnico. Gracias");

            if (((IList)rfcListado.DataSource).Count > 1)
                rfcListado.SelectedIndex = 1;

            if (Global.Instance.userLogin.emp_aplicadespachocontable == 1 && BussinessModel.ExistenRfcAdministrados(this._empresa))
                dataRfcAdministrados.Rows[0].Visible = false;

            rfcListado.Visible = false;
            CodigoPostalListado.Visible = false;
            emailServerList.Visible = false;

            page = 8;
            _clearOption();
            opt_configurarApp.Image = global::ValidSAT.Properties.Resources.b8;
            panel_ConfigurarApp.Visible = true;
        }

        private void _clearOption()
        {
            opt_cancelarXMLS.Image = global::ValidSAT.Properties.Resources.ValidSAT_UI_Design_WideScreen_03;
            opt_configurarApp.Image = global::ValidSAT.Properties.Resources.ValidSAT_UI_Design_WideScreen_08;
            opt_creaarPdf.Image = global::ValidSAT.Properties.Resources.ValidSAT_UI_Design_WideScreen_06;
            opt_descargarPdf.Image = global::ValidSAT.Properties.Resources.ValidSAT_UI_Design_WideScreen_05;
            opt_descargarXMLS.Image = global::ValidSAT.Properties.Resources.ValidSAT_UI_Design_WideScreen_01;
            opt_generarConfronta.Image = global::ValidSAT.Properties.Resources.ValidSAT_UI_Design_WideScreen_04;
            opt_generarReporte.Image = global::ValidSAT.Properties.Resources.ValidSAT_UI_Design_WideScreen_07;
            opt_validarXMLS.Image = global::ValidSAT.Properties.Resources.ValidSAT_UI_Design_WideScreen_02;

            panel_DescargarXMLS.Visible = false;
            panel_ConfigurarApp.Visible = false;
        }

        private void frmMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                          new SolidBrush(Color.FromArgb(255, 204, 236, 234))
                        : new SolidBrush(e.BackColor);
            g.FillRectangle(brush, e.Bounds);
            if (((ListBox)sender).DisplayMember == "")
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font,
                         new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
            else
            {
                object c = ((ListBox)sender).Items[e.Index];
                string d = "";

                switch(c.ToString())
                {
                    case "ValidSAT.DataAccess.cnf_rfcadministrados":
                        d = ((cnf_rfcadministrados)c).displayMember;
                        break;
                    case "ValidSAT.DataAccess.cnf_codigospostales":
                        d = ((cnf_codigospostales)c).displayMember;
                        break;
                    case "ValidSAT.DataAccess.CMailServers":
                        d = ((CMailServers)c).name;
                        break;
                }

                e.Graphics.DrawString( d, e.Font,
                         new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
            }
            
            e.DrawFocusRectangle();
        }

        private void RFC_combobox_Click(object sender, EventArgs e)
        {
            this._listBoxsHide(RFC_List);
            RFC_List.Visible = !RFC_List.Visible;
        }

        private void Filtro_combobox_Click(object sender, EventArgs e)
        {
            this._listBoxsHide(Filtro_list);
            Filtro_list.Visible = !Filtro_list.Visible;
        }

        private void combobox_rango_Click(object sender, EventArgs e)
        {
            this._setBoolean(sender);
        }

        private void _setBoolean(object combobox)
        {
            string pos = (string)((PictureBox)combobox).Tag;
            int pos_x = Convert.ToInt32(pos.Split(',')[0]);
            int pos_y = Convert.ToInt32(pos.Split(',')[1]);

            this._listBoxsHide();

            list_rango.Visible = !(list_rango.Visible && list_rango.Location.X == pos_x && list_rango.Location.Y == pos_y);

            list_rango.Location = new System.Drawing.Point(pos_x, pos_y);
            list_rango.Tag = combobox;
        }

        private void _listBoxsHide()
        {
            list_rango.Visible = false;
            RFC_List.Visible = false;
            Filtro_list.Visible = false;
        }

        private void _listBoxsHide(ListBox control)
        {
            if (control.Name != "list_rango") list_rango.Visible = false;
            if (control.Name != "RFC_List") RFC_List.Visible = false;
            if (control.Name != "Filtro_list") Filtro_list.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this._setBoolean(sender);
        }

        private void combobo_rango2_Click(object sender, EventArgs e)
        {
            this._setBoolean(sender);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this._setBoolean(sender);
        }

        private void combobox_detalle_Click(object sender, EventArgs e)
        {
            this._listBoxsHide(searchConditionListado);
            searchConditionListado.Visible = !searchConditionListado.Visible;
        }

        private void list_rango_SelectedIndexChanged(object sender, EventArgs e)
        {
            PictureBox combobox = (PictureBox)((ListBox)sender).Tag;

            switch ((string)combobox.Tag)
            {
                case "433, 503":
                    label35.Text = list_rango.Text;
                    break;
                case "688, 504":
                    label38.Text = list_rango.Text;
                    break;
                case "432, 574":
                    label36.Text = list_rango.Text;
                    break;
                case "688, 574":
                    label39.Text = list_rango.Text;
                    break;
                case "249, 99":
                    label37.Text = list_rango.Text;
                    break;
            }

            list_rango.Visible = false;
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            cerrarListados(rfcListado);
            rfcListado.Visible = !rfcListado.Visible;
        }

        private void updateEmpresa(bool set=true)
        {
            if (rfcListado.SelectedIndex != 0 && rfcListado.SelectedItem!=null)
            {
                label50.Visible = false;
                pictureBox36.Visible = false;
                txt_contrasena_CIEC.Visible = false;
                panel5.Visible = false;

                txt_RFC.Text = ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_rfcempresa.ToString();
                txt_nombre.Text = ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_nombreempresa.ToString();
                txt_CodigoPostal.Text = ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_codigopostal.ToString();
                txt_correo_electronico.Text = ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_correoelectronico;
                servidor.Text = ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_emailnomservidorent;
                
                if ( ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_pathcertificadosat!="" || ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_pathllavesat != "")
                {
                    label48.Text = ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_pathcertificadosat;
                    label49.Text = ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_pathllavesat;
                } else {
                    label48.Text = "";
                    label49.Text = "";
                }

                if (
                    (((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_pathcertificadosat != "" || ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_pathllavesat != "") &&
                    (((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_pathcertificadosat != null || ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_pathllavesat != null)
                   )
                {
                    switch1.setPos(1);
                }
                else if (((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_passwordclaveciec != "" && ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_passwordclaveciec != null)
                    switch1.setPos(2);
                else
                    switch1.setPos(0);

                switch_menu();
                label34.Text = label51.Text = txt_contrasena_key.Text = txt_contrasena_CIEC.Text = "";

                switch (switch1.KeyValue)
                {
                    case 1:
                        label34.Text = ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_pathcertificadosat;
                        label51.Text = ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_pathllavesat;
                        txt_contrasena_key.Text = ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_passwordkeysat;
                        break;

                    case 2:
                        txt_contrasena_CIEC.Text = ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_passwordclaveciec;
                        break;
                }
            } 

            if (rfcListado.Text == "  Agregar Empresa" && rfcListado.Tag == "OK")
            {
                setEditState(true, true);

                //if (((IList<cnf_rfcadministrados>)dataRfcAdministrados.DataSource)[0].rfc_nombreempresa == "Agregar Empresa")
                //    ((IList<cnf_rfcadministrados>)dataRfcAdministrados.DataSource).RemoveAt(0);

                //dataRfcAdministrados.Refresh();
                switch1.setPos(0);
                label34.Text = label51.Text = "";
                if (set) txt_RFC.Focus();
            }
            rfcListado.Tag = "OK";
            panel3.Visible = false;
        }

        private void setEditState(bool state, bool new_reg = false )
        {
            //panel1.Visible = state;
            panel3.Visible = state;

            //combobox_codigoPostal.Enabled = state;
            servidor.Text = "";

            pictureBox36.Image = state ? global::ValidSAT.Properties.Resources.separator2_green : global::ValidSAT.Properties.Resources.separator1;

            /*
            txt_correo_electronico.ReadOnly = !state;
            txt_CodigoPostal.ReadOnly = !state;
            txt_contrasena.ReadOnly = !state;
            txt_nombre.ReadOnly = !state;
            txt_RFC.ReadOnly = !state;
            */

            if (new_reg)
                txt_RFC.Text = txt_CodigoPostal.Text = txt_nombre.Text = txt_correo_electronico.Text = txt_contrasena.Text = "";

            //if (Global.Instance.userLogin.emp_aplicadespachocontable == 1 && BussinessModel.ExistenRfcAdministrados(this._empresa))
              //  dataRfcAdministrados.Rows[0].Visible = false;
        }

        private void combobox_codigoPostal_Click(object sender, EventArgs e)
        {
            if (txt_CodigoPostal.ReadOnly)
                txt_CodigoPostal.ReadOnly = false;

            cerrarListados(CodigoPostalListado);
            CodigoPostalListado.Visible = !CodigoPostalListado.Visible;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this._listBoxsHide(filtroOneListado);
            filtroOneListado.Visible = !filtroOneListado.Visible;
        }

        private void filtroOneListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtroOneListado.Visible = false;
            label15.Text = (string)filtroOneListado.SelectedItem;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this._listBoxsHide(filtradoTwoListado);
            filtradoTwoListado.Visible = !filtradoTwoListado.Visible;
        }

        private void filtradoTwoListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtradoTwoListado.Visible = false;
            label16.Text = (string)filtradoTwoListado.SelectedItem;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this._listBoxsHide(filtroThreeListado);
            filtroThreeListado.Visible = !filtroThreeListado.Visible;
        }

        private void ImportesElegiblesListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImportesElegiblesListado.Visible = false;
            label13.Text = (string)ImportesElegiblesListado.SelectedItem;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this._listBoxsHide(ImportesElegiblesListado);
            ImportesElegiblesListado.Visible = !ImportesElegiblesListado.Visible;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this._listBoxsHide(ImportesElegiblesTwoListado);
            ImportesElegiblesTwoListado.Visible = !ImportesElegiblesTwoListado.Visible;
        }

        private void ImportesElegiblesTwoListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImportesElegiblesTwoListado.Visible = false;
            label14.Text = (string)ImportesElegiblesTwoListado.SelectedItem;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this._listBoxsHide(detailDataListado);
            detailDataListado.Visible = !detailDataListado.Visible;
        }

        private void detailDataListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            detailDataListado.Visible = false;
            label16.Text = (string)detailDataListado.SelectedItem;
        }

        private void searchConditionListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchConditionListado.Visible = false;
            label37.Text = (string)searchConditionListado.SelectedItem;
        }

        private void Filtro_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtro_list.Visible = false;
            Filtro_text.Text = (string)Filtro_list.SelectedItem;
        }

        private void RFC_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            RFC_List.Visible = false;
            RFC_label.Text = (string)RFC_List.SelectedItem;
        }

        private void txt_CodigoPostal_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CodigoPostalListado_Click(object sender, EventArgs e)
        {
            setCodigo();
        }

        private void setCodigo()
        {
            txt_CodigoPostal.Text = ((cnf_codigospostales)CodigoPostalListado.SelectedValue).cpo_codigopostal.ToString();
            CodigoPostalListado.Hide();
            txt_correo_electronico.Focus();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                Color c1 = Color.FromArgb(255, 54, 54, 54);
                Color c2 = Color.FromArgb(255, 62, 62, 62);
                Color c3 = Color.FromArgb(255, 98, 98, 98);

                LinearGradientBrush br = new LinearGradientBrush(e.CellBounds, c1, c3, 90, true);
                ColorBlend cb = new ColorBlend();
                cb.Positions = new[] { 0, (float)0.5, 1 };
                cb.Colors = new[] { c1, c2, c3 };
                br.InterpolationColors = cb;

                e.Graphics.FillRectangle(br, e.CellBounds);
                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }

            
        }

        private void dataRfcAdministrados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
              //  if ( MessageBox.showAQuestionModal("Se eliminara el registro seleccionado. Por favor confirme la accion.")== MessageBox.questionResponse.Yes )
                //{ }
            }
            


            //setEditState(false);
            //cerrarListados(rfcListado);
            //rfcListado.SelectedItem = (cnf_rfcadministrados)dataRfcAdministrados.CurrentRow.DataBoundItem;
        }

        private void mailListSelect_Click(object sender, EventArgs e)
        {
            cerrarListados(emailServerList);
            emailServerList.Visible = !emailServerList.Visible;
        }

        private void emailServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cerrarListados(Control control)
        {
            bool last_value = control.Visible;
            rfcListado.Visible = CodigoPostalListado.Visible = emailServerList.Visible = false;

            control.Visible = last_value;
        }

        private void txt_CodigoPostal_Leave(object sender, EventArgs e)
        {
            if (!CodigoPostalListado.Focused)
                CodigoPostalListado.Visible = false;
        }

        private void txt_correo_electronico_Leave(object sender, EventArgs e)
        {
           //if ( txt_correo_electronico.Text=="" &&  servidor.Text!="")
                emailServerList.Hide();
        }

        private void guardarEvent(object sender, EventArgs e)
        {
            storeData();
        }

        private bool storeData()
        {
            try
            {

                if (txt_RFC.Text.Trim() == "")
                {
                    ValidSAT.Classes.MessageBox.showAdviseModal("Inserte el nuevo código RFC por favor.");
                    txt_RFC.Focus();
                    return false;
                }

                string correo = "";
                if (txt_correo_electronico.Text.Trim().Length != 0)
                {
                    if (servidor.Text == "")
                    {
                        ValidSAT.Classes.MessageBox.showAdviseModal("Seleccione el servidor de correo por favor.");
                        emailServerList.Show();
                        emailServerList.Focus();
                        return false;
                    }
                    else if (txt_correo_electronico.Text.IndexOf("@") > 0)
                        correo = txt_correo_electronico.Text.Substring(0, txt_correo_electronico.Text.IndexOf('@'));
                    else
                        correo = txt_correo_electronico.Text;
                }

                if (txt_CodigoPostal.Text.Trim()=="")
                {
                    ValidSAT.Classes.MessageBox.showAdviseModal("Seleccione el Código Postal por favor.");
                    txt_CodigoPostal.Focus();
                    return false;
                }


                if (txt_RFC.Text.Trim().Length == 0)
                {
                    ValidSAT.Classes.MessageBox.showAdviseModal("El campo RFC es obligatorio.");
                    txt_RFC.Focus();
                    return false;
                }

                if (txt_nombre.Text.Trim().Length == 0)
                {
                    ValidSAT.Classes.MessageBox.showAdviseModal("El nombre de la Persona Fiscal o Moral es obligatorio.");
                    txt_RFC.Focus();
                    return false;
                }

                if (switch1.KeyValue == 0)
                    label34.Text = label51.Text = txt_contrasena_CIEC.Text = txt_contrasena_key.Text = "";

                if (panel3.Visible)
                    BussinessModel.storeConfigApp(txt_RFC.Text, txt_nombre.Text, correo, servidor.Text, txt_contrasena.Text, txt_CodigoPostal.Text,txt_contrasena_CIEC.Text, txt_contrasena_key.Text, label34.Text, label51.Text, ((cnf_rfcadministrados)rfcListado.SelectedItem).rfc_rfcempresa);

                long cntRFCEmpresas = BussinessModel.cantidadEmpresasAdministrados(Global.Instance.userLogin.emp_empresa);
                List<cnf_rfcadministrados> listado = BussinessModel.getRfcAdministrados(this._empresa, Global.Instance.userLogin.emp_aplicadespachocontable == 1 && cntRFCEmpresas >= 1 && cntRFCEmpresas <= Global.Instance.userLogin.emp_rfcsampara);

                rfcListado.DataSource = null;
                rfcListado.DisplayMember = "displayMember";
                rfcListado.DataSource = listado;

                //listado.RemoveAt(0);
                dataRfcAdministrados.DataSource = listado;

                if (listado.Count > 1)
                    rfcListado.SelectedIndex = listado.Count - 1;

                if (BussinessModel.cantidadEmpresasAdministrados(Global.Instance.userLogin.emp_empresa) >= Global.Instance.userLogin.emp_rfcsampara)
                    if (((IList<cnf_rfcadministrados>)rfcListado.DataSource)[0].rfc_nombreempresa == "  Agregar Empresa")
                        ((IList<cnf_rfcadministrados>)rfcListado.DataSource).RemoveAt(0);
            }
            catch (FormatException ex)
            {
                ValidSAT.Classes.MessageBox.showAdviseModal("Inserte un correo electrónico válido.");
                return false;
            }
            catch (RfcExistsException ex)
            {
                ValidSAT.Classes.MessageBox.showAdviseModal("El valor RFC de empresa insertado ya existe.");
                txt_RFC.Focus();
                return false;
            }

            return true;
            //setEditState(false);
        }

        private void buttonSalirdeCaptura1_OnUserControlButtonClicked(object sender, EventArgs e)
        {
            panel_ConfigurarApp.Visible = false;
            Focus();
        }

        private void switch_menu()
        {
            label34.Text = label51.Text = txt_contrasena_CIEC.Text = txt_contrasena_key.Text = "";

            if (switch1.KeyValue == 0)
            {
                label50.Visible = false;
                pictureBox46.Visible = false;
                txt_contrasena_CIEC.Visible = false;
                panel5.Visible = false;
            }
            else if (switch1.KeyValue == 1)
            {
                panel5.Visible = true;
                label50.Visible = false;
                pictureBox46.Visible = false;
                txt_contrasena_CIEC.Visible = false;
                txt_contrasena_CIEC.Text = "";
            }
            else
            {
                panel5.Visible = false;
                label50.Visible = true;
                
                folder_archivo_cer.Image = global::ValidSAT.Properties.Resources.folder;
                folder_archivo_key.Image = global::ValidSAT.Properties.Resources.folder;
                pictureBox46.Visible = true;
                txt_contrasena_CIEC.Visible = true;
            }
        }

        private void switch1_onChange(object sender, Keys codigo)
        {
            if (codigo == Keys.Escape)
            {
                panel_ConfigurarApp.Hide();
                Focus();
            }


            switch_menu();
            
            if (codigo == Keys.Enter || codigo == Keys.Tab)
                switch (switch1.KeyValue)
                {
                    case 0:
                        if (!panel3.Visible)
                            buttonSalirdeCaptura1.Focus();
                        else
                        {
                            buttonGuardarDatos1.setOn();
                            buttonGuardarDatos1.Focus();
                        }
                        break;
                    case 2:
                        txt_contrasena_CIEC.Focus();
                        break;
                    case 1:
                        folder_archivo_cer.Image = global::ValidSAT.Properties.Resources.folder2;
                        folder_archivo_key.Image = global::ValidSAT.Properties.Resources.folder;
                        folder_archivo_cer.Focus();
                        break;
                }
        }

        private void txt_RFC_onKey(object sender, Keys codigo)
        {
            if (codigo == Keys.Enter)
                txt_nombre.Focus();
            else if (codigo == Keys.Escape)
            {
                panel_ConfigurarApp.Visible = AllowDrop;
                Focus();
            }
            else if (codigo == Keys.Down || codigo == Keys.NumPad2)
            {
                rfcListado.Visible = true;
                rfcListado.Focus();
            }
            else if (codigo != Keys.Tab)
                panel3.Show();
        }

        private void txt_CodigoPostal_onKey(object sender, Keys codigo)
        {
            if (codigo == Keys.Down || codigo == Keys.NumPad2 )
            {
                CodigoPostalListado.Visible = true;
                CodigoPostalListado.Focus();
            }
            else if (codigo == Keys.Up || codigo == Keys.NumPad8)
                txt_nombre.Focus();
            else if (codigo == Keys.Enter)
            {
                
                if (txt_CodigoPostal.Text != "")
                {
                    List<cnf_codigospostales> items = (List<cnf_codigospostales>)CodigoPostalListado.DataSource;
                    List<cnf_codigospostales> row = items.FindAll(delegate (cnf_codigospostales s)
                    {
                        return s.displayMember.Contains(txt_CodigoPostal.Text.ToUpper());
                    });
                    CodigoPostalListado.SelectedItem = row.Count > 0 ? row[0] : items[0];

                    txt_CodigoPostal.Text = ((cnf_codigospostales)CodigoPostalListado.SelectedItem).cpo_codigopostal.ToString();
                }
                
                txt_correo_electronico.Focus();
            }
            else if (codigo == Keys.Escape)
            {
                if (CodigoPostalListado.Visible)
                    CodigoPostalListado.Visible = false;
                else
                {
                    panel_ConfigurarApp.Visible = AllowDrop;
                    Focus();
                }
            }
            else
            {
                if (txt_CodigoPostal.Text != "")
                {
                    List<cnf_codigospostales> items = (List<cnf_codigospostales>)CodigoPostalListado.DataSource;
                    List<cnf_codigospostales> row = items.FindAll(delegate (cnf_codigospostales s)
                    {
                        return s.displayMember.Contains(txt_CodigoPostal.Text.ToUpper());
                    });
                    CodigoPostalListado.SelectedItem = row.Count > 0 ? row[0] : items[0];
                    CodigoPostalListado.Visible = true;
                }
                if (codigo != Keys.Tab)
                    panel3.Show();
            }
        }

        private void txt_nombre_onKey(object sender, Keys codigo)
        {
            if (codigo == Keys.Escape)
            {
                panel_ConfigurarApp.Visible = false;
                Focus();
                return;
            }
            else if (codigo == Keys.Enter || codigo == Keys.NumPad8 || codigo == Keys.Down)
                txt_CodigoPostal.Focus();
            else if (codigo == Keys.Up || codigo == Keys.NumPad8)
                txt_RFC.Focus();
            else if (codigo != Keys.Tab)
                panel3.Show();
        }

        private void txt_contrasena_CIEC_onKey(object sender, Keys codigo)
        {
            if (codigo == Keys.Escape)
            {
                panel_ConfigurarApp.Visible = false;
                Focus();
            }
            else if (codigo == Keys.Down || codigo == Keys.NumPad2)
            {
                if (panel3.Visible)
                {
                    buttonGuardarDatos1.setOn();
                    buttonGuardarDatos1.Focus();
                }
                else
                    buttonSalirdeCaptura1.Focus();
            }
            else if (codigo == Keys.Up || codigo == Keys.NumPad8)
            {
                folder_archivo_key.Image = global::ValidSAT.Properties.Resources.folder2;
                textBox12.Focus();
            }
            else if (codigo == Keys.Enter)
            {
                if (panel3.Visible)
                {
                    buttonGuardarDatos1.setOn();
                    buttonGuardarDatos1.Focus();
                }
                else
                    buttonSalirdeCaptura1.Focus();
            }
            else if (codigo != Keys.Tab)
                panel3.Visible = true;
        }

        private void txt_correo_electronico_onKey(object sender, Keys codigo)
        {
            if (codigo == Keys.Enter || codigo == Keys.Down || codigo == Keys.NumPad2)
            {
                if (emailServerList.Visible)
                {
                    emailServerList.Focus();
                    return;
                }
                if ((servidor.Text != "" && txt_correo_electronico.Text != "") || (txt_correo_electronico.Text == ""))
                {
                    //if (txt_correo_electronico.Text.Trim() == "")
                    //  servidor.Text = "";

                    txt_contrasena.Focus();
                }
                else
                {
                    emailServerList.SelectedIndex = 1;
                    emailServerList.Visible = true;
                    emailServerList.Focus();
                }
            }

            else if (codigo == Keys.Up || codigo == Keys.NumPad8)
                txt_CodigoPostal.Focus();

            else if (codigo == Keys.Escape)
            {
                panel_ConfigurarApp.Visible = AllowDrop;
                Focus();
            }
            else if (emailServerList.Visible)
                emailServerList.Focus();
            else if (codigo != Keys.Tab)
                panel3.Show();
        }

        private void frmMainMenu_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Control pb;
            page = Convert.ToInt16(Tag);

            _clearOption();

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.NumPad6)
            {
                page++;
                if (page > 8)
                    page = 1;
            }

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.NumPad4)
            {
                page--;
                if (page < 1)
                    page = 8;
            }

            pb = getNextActiveOption(page);

            switch (Convert.ToInt16(pb.Tag))
            {
                case 1:
                    opt_descargarXMLS.Image = global::ValidSAT.Properties.Resources.b1;
                    break;
                case 2:
                    opt_validarXMLS.Image = global::ValidSAT.Properties.Resources.b2;
                    break;
                case 3:
                    opt_cancelarXMLS.Image = global::ValidSAT.Properties.Resources.b3;
                    break;
                case 4:
                    opt_generarConfronta.Image = global::ValidSAT.Properties.Resources.b4;
                    break;
                case 5:
                    opt_descargarPdf.Image = global::ValidSAT.Properties.Resources.b5;
                    break;
                case 6:
                    opt_creaarPdf.Image = global::ValidSAT.Properties.Resources.b6;
                    break;
                case 7:
                    opt_generarReporte.Image = global::ValidSAT.Properties.Resources.b7;
                    break;
                case 8:
                    opt_configurarApp.Image = global::ValidSAT.Properties.Resources.b8;
                    break;
            }

            Tag = page;

            if (e.KeyCode == Keys.Enter)
            {
                switch (Convert.ToInt16(pb.Tag))
                {
                    case 1:
                        panel_DescargarXMLS.Visible = true;
                        break;

                    case 8:
                        configurarApp();
                        txt_RFC.Focus();
                        break;
                }
            }
        }

        private Control getNextActiveOption(int page)
        {
            foreach (Control pb in this.Controls)
                if (pb.Name.IndexOf("opt_") >= 0)
                    if ( Convert.ToInt16(pb.Tag) == page)
                        return pb;

            return null;
        }

        private void txt_contrasena_CIEC_onKey_1(object sender, Keys codigo)
        {
            if (codigo == Keys.Escape)
            {
                panel_ConfigurarApp.Visible = AllowDrop;
                Focus();
            }
            else if (codigo == Keys.Enter || codigo == Keys.Tab)
            {
                if (panel3.Visible)
                {
                    buttonGuardarDatos1.setOn();
                    buttonGuardarDatos1.Focus();
                }
                else
                    buttonSalirdeCaptura1.Focus();
            }
            else if (codigo != Keys.Tab)
                panel3.Show();
        }

        private void dataRfcAdministrados_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                panel_ConfigurarApp.Visible = AllowDrop;
                Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                txt_RFC.Focus();
            }

        }

        private void txt_contrasena_onKey(object sender, Keys codigo)
        {
            if (codigo == Keys.NumPad8 || codigo == Keys.Up)
                txt_correo_electronico.Focus();

            else if (codigo.Equals(Keys.Escape))
            {
                panel_ConfigurarApp.Visible = false;
                Focus();
                return;
            }
            else if (codigo.Equals(Keys.Tab) || codigo.Equals(Keys.Enter) || codigo==Keys.Down || codigo==Keys.NumPad2)
            {
                switch1.Focus();
                return;
            }
            else if (codigo != Keys.Tab)
                panel3.Show();
        }

        private void txt_correo_electronico_TextChanged(object sender, EventArgs e)
        {
            if (servidor.Text == "")
                mailListSelect.Visible = true;
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailServerList_Click(object sender, EventArgs e)
        {
            emailServerList.Visible = false;
            servidor.Text = ((CMailServers)emailServerList.SelectedItem).domain;
            if (panel3.Visible == true)
                txt_correo_electronico.Focus();

        }

        private void emailServerList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                emailServerList.Visible = false;
                servidor.Text = ((CMailServers)emailServerList.SelectedItem).domain;
                panel3.Show();
                txt_correo_electronico.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                emailServerList.Visible = false;
                txt_contrasena.Focus();
            }
        }

        private void rfcListado_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                rfcListado.Hide();
                updateEmpresa();
                txt_RFC.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                rfcListado.Hide();
                txt_RFC.Focus();
            }
        }

        private void rfcListado_Click(object sender, EventArgs e)
        {
            updateEmpresa();
            rfcListado.Hide();
        }

        private void rfcListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateEmpresa(false);
        }

        private void CodigoPostalListado_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                setCodigo();
            if (e.KeyCode == Keys.Escape)
            {
                CodigoPostalListado.Hide();
                txt_CodigoPostal.Focus();
            }
        }

        private void buttonGuardarDatos1_onChange(object sender, Keys codigo)
        {
            if (codigo == Keys.Enter)
            {
                if (storeData())
                {
                    buttonGuardarDatos1.setOff();
                    panel3.Visible = false;
                    txt_RFC.Focus();
                }
            }
            else if (codigo == Keys.Escape)
            {
                panel_ConfigurarApp.Visible = false;
                Focus();
            }
            else if (codigo == Keys.Down || codigo == Keys.NumPad2 || codigo == Keys.Tab)
                buttonSalirdeCaptura1.Focus();
            else if (codigo != Keys.Tab)
                panel3.Show();

        }

        private void buttonGuardarDatos1_Leave(object sender, EventArgs e)
        {
            buttonGuardarDatos1.setOff();
        }

        private void folder_archivo_cer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                panel_ConfigurarApp.Visible = false;
                Focus();
            }
            else if(e.KeyCode==Keys.Enter)
                folder_archivo_cer_Click(sender, new EventArgs());
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.NumPad8)
            {
                folder_archivo_cer.Image = global::ValidSAT.Properties.Resources.folder;
                switch1.Focus();
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.NumPad2 || e.KeyCode==Keys.Tab)
            {
                folder_archivo_cer.Image = global::ValidSAT.Properties.Resources.folder;
                folder_archivo_key.Image = global::ValidSAT.Properties.Resources.folder2;
                folder_archivo_key.Focus();
            }
        }

        private void folder_archivo_cer_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Dialog = new FolderBrowserDialog();
            Dialog.ShowDialog();
            label34.Text = Dialog.SelectedPath;
            label34.Visible = true;
        }

        private void folder_archivo_key_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                txt_contrasena_key.Focus();
        }

        private void folder_archivo_key_Click(object sender, EventArgs e)
        {
            textBox12_Click(sender, new EventArgs());
        }

        private void label34_TextChanged(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void label51_TextChanged(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void CodigoPostalListado_Leave(object sender, EventArgs e)
        {
            CodigoPostalListado.Hide();
        }

        private void txt_contrasena_key_Enter(object sender, EventArgs e)
        {
            if (folder_archivo_key.Image == global::ValidSAT.Properties.Resources.folder2)
                folder_archivo_key.Focus();
        }

        private void buttonGuardarDatos1_Load(object sender, EventArgs e)
        {

        }

        private void textBox12_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                panel_ConfigurarApp.Visible = false;
                Focus();
            }
            else if (e.KeyCode == Keys.Enter)
                textBox12_Click(sender, new EventArgs());
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.NumPad8)
            {
                folder_archivo_key.Image = global::ValidSAT.Properties.Resources.folder;
                folder_archivo_cer.Image = global::ValidSAT.Properties.Resources.folder2;
                folder_archivo_cer.Focus();
            }
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.NumPad2)
            {
                folder_archivo_key.Image = global::ValidSAT.Properties.Resources.folder;
                txt_contrasena_key.Focus();
            }
        }

        private void textBox12_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Dialog = new FolderBrowserDialog();
            Dialog.ShowDialog();
            label51.Text = Dialog.SelectedPath;
            label51.Visible = true;
            folder_archivo_key.Image = global::ValidSAT.Properties.Resources.folder;

            txt_contrasena_key.Focus();
        }

        private void emailServerList_Leave(object sender, EventArgs e)
        {
            //if (!(txt_correo_electronico.Text != "" && servidor.Text.Trim() != ""))
            if (servidor.Text.Trim() != "")
                emailServerList.Hide();
        }

        private void textBox13_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Keys codigo = e.KeyCode;
            if (codigo == Keys.Down || codigo == Keys.Left || codigo == Keys.NumPad2 || codigo == Keys.NumPad4)
                dataRfcAdministrados.Focus();

            if (codigo == Keys.Up || codigo == Keys.NumPad8)
            {
                if (panel3.Visible)
                {
                    //buttonSalirdeCaptura2.setOff();
                    //buttonGuardarDatos1.setOn();
                    buttonGuardarDatos1.Focus();
                }
            }

            if (codigo == Keys.Enter)
            {
                panel_ConfigurarApp.Hide();
                Focus();
            }
        }

        private void rfcListado_Leave(object sender, EventArgs e)
        {
            rfcListado.Hide();
        }

        private void buttonGuardarDatos1_Enter(object sender, EventArgs e)
        {
            buttonGuardarDatos1.setOn();
        }

        private void buttonSalirdeCaptura1_Enter(object sender, EventArgs e)
        {
            buttonSalirdeCaptura1.setOn();
        }

        private void buttonSalirdeCaptura1_Leave(object sender, EventArgs e)
        {
            buttonSalirdeCaptura1.setOff();
        }

        private void buttonSalirdeCaptura1_onChange(object sender, Keys codigo)
        {
            if (codigo == Keys.Up || codigo == Keys.NumPad8)
                buttonGuardarDatos1.Focus();
            if (codigo == Keys.Down || codigo == Keys.NumPad2)
                dataRfcAdministrados.Focus();
            if (codigo == Keys.Enter)
            {
                panel_ConfigurarApp.Hide();
                Focus();
            }
        }

        private void txt_correo_electronico_Enter(object sender, EventArgs e)
        {
            if (txt_correo_electronico.Text == "" && servidor.Text == "")
            {
                emailServerList.Show();
                emailServerList.Focus();
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            folder_archivo_key.Image = global::ValidSAT.Properties.Resources.folder;
        }
    }
}