using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using System.IO;
using System.Collections;

namespace RegistroUsuarios
{
    
    public partial class RegistroInformacionDocumentos : System.Web.UI.Page
    {
        SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog=ControlDocumental;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DropDepartamento();
                llenarGrid();
                PanelFormulario.Visible = false;
                MultiView2.ActiveViewIndex = -1;
                obtenerId();
                txtFechaPublicacio.Text=DateTime.Now.ToString("dd/MM/yyyy");
                MsjResultado.Visible = false;
                dropBusqDep();
            }         
            
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdDocument.Text!="" && txtNombreDocument.Text!="" && txtCodigo.Text!="" && txtFechaRevicio.Text!="" && cbIdDepartament.SelectedValue!="" && txtFechaPublicacio.Text!="" && txtFechaModificacio.Text!="" && txtFechaRevicio.Text!="" && (chbStatu.Checked==true || chbStatu.Checked==false) && (chbUsoGenerl.Checked==true || chbUsoGenerl.Checked==false))
                {
                    SqlCommand cmd = new SqlCommand("grabar_InformacionDocumentos", conexion);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdDocumento", SqlDbType.Int).Value = txtIdDocument.Text;
                        cmd.Parameters.AddWithValue("@NombreDocumento", SqlDbType.VarChar).Value = txtNombreDocument.Text;
                        cmd.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = txtCodigo.Text;
                        cmd.Parameters.AddWithValue("@Version", SqlDbType.VarChar).Value = txtVersio.Text;
                        cmd.Parameters.AddWithValue("@IdDepartamento", SqlDbType.Int).Value = cbIdDepartament.SelectedValue;
                        cmd.Parameters.AddWithValue("@FechaPublicacion", SqlDbType.Date).Value = txtFechaPublicacio.Text;
                        cmd.Parameters.AddWithValue("@FechaModificacion", SqlDbType.Date).Value = txtFechaModificacio.Text;
                        cmd.Parameters.AddWithValue("@FechaRevicion", SqlDbType.Date).Value = txtFechaRevicio.Text;
                        cmd.Parameters.AddWithValue("@Status", SqlDbType.Bit).Value = chbStatu.Checked;
                        cmd.Parameters.AddWithValue("@UsoGeneral", SqlDbType.Bit).Value = chbUsoGenerl.Checked;
                    }
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    Limpiar();
                    llenarGrid();
                    MultiView2.ActiveViewIndex = -1;
                    MsjResultado.Visible = true;
                    MsjResultado.Text = "Informacion de Documento Guardado Correctamente";
                }
                else
                {
                    MultiView2.ActiveViewIndex = -1;
                    MsjResultado.Visible = true;
                    MsjResultado.Text = "Completar el Formulario";
                }
            }
            catch (Exception ex)
            {
                MsjResultado.Text = ex.Message.ToString();
            }
        }

        public void DropDepartamento()
        {
           if (!this.IsPostBack)
           {
               using (SqlCommand cmd = new SqlCommand("SELECT IdDepartamento, NombreDepartamento FROM Departamento"))
               {
                   cmd.CommandType = CommandType.Text;
                   cmd.Connection = conexion;
                   conexion.Open();
                   cbIdDepartament.DataSource = cmd.ExecuteReader();
                   cbIdDepartament.DataTextField = "NombreDepartamento";
                   cbIdDepartament.DataValueField = "IdDepartamento";
                   cbIdDepartament.DataBind();
                   conexion.Close();
               }
           }
        }

        public void obtenerId()
        {
            SqlCommand cmd = new SqlCommand("select MAX(IdDocumento) as max from DocumentoInformacion", conexion);                 
            conexion.Open();
            string iddoc =Convert.ToString(cmd.ExecuteScalar());
            int idc=Convert.ToInt32(iddoc)+1;
            txtIdDocument.Text=Convert.ToString(idc);
            conexion.Close();

        }

       
        protected void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            
            MsjResultado.Visible = false;
            MultiView2.ActiveViewIndex = -1;
            if (PanelFormulario.Visible)
            {
                PanelFormulario.Visible = false;
                
            }
            else
            {
                PanelFormulario.Visible = true;
                MsjResultado.Visible = false;
                MultiView2.ActiveViewIndex = -1;
               
                obtenerId();
                Limpiar();
            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            PanelFormulario.Visible = false;
            MultiView2.ActiveViewIndex = -1;
            MsjResultado.Text = "";
            MsjResultado.Visible = false;
        }

        protected void GridInformacionDocumento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                llenarGrid();
                GridInformacionDocumento.PageIndex = e.NewPageIndex;
                this.GridInformacionDocumento.DataBind();
            }
            catch (Exception ex)
            {

                MsjResultado.Text = ex.Message.ToString();
            }
            
        }

        public void llenarGrid()
        {
            SqlCommand cmd = new SqlCommand("llenar_GridInformacionDocumentos", conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridInformacionDocumento.DataSource = dt;
            this.GridInformacionDocumento.DataBind();
        }

        protected void btnConsulta_Click(object sender, EventArgs e)
        {
            MsjResultado.Visible = false;
            MultiView2.ActiveViewIndex = 0;            
            PanelFormulario.Visible = false;
            try
            {
                if (cbIdDepBusqueda.SelectedValue != "")
                {
                    ConsultaPorDepartamento();
                    if (cbIdDepBusqueda.SelectedValue=="0")
                    {
                        llenarGrid();
                    }
                }                               
                  
            }
            catch (Exception)
            {
                
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

        }
        protected void ConsultaPorDepartamento()
        {
            SqlCommand cmd = new SqlCommand("select *from DocumentoInformacion where IdDepartamento like'" + cbIdDepBusqueda.SelectedValue + "%'", conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridInformacionDocumento.DataSource = dt;
            GridInformacionDocumento.DataBind();
            conexion.Close();
        }

        protected void GridInformacionDocumento_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            MsjResultado.Visible = false;
            try
            {
                GridInformacionDocumento.EditIndex = -1;
                llenarGrid();
            }
            catch (Exception ex)
            {
                MsjResultado.Visible = true;
                MsjResultado.Text = ex.Message.ToString();
            }
        }

        protected void GridInformacionDocumento_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridInformacionDocumento.EditIndex = e.NewEditIndex;
                llenarGrid();
            }
            catch (Exception ex)
            {
                MsjResultado.Text = ex.Message.ToString();
            }		 
        }        

        protected void GridInformacionDocumento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MsjResultado.Visible = false;
            try
            {
                SqlCommand cmd = new SqlCommand("usp_DocumentoInformacion_eliminar", conexion);
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                {
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdDocumento",SqlDbType.Int).Value=GridInformacionDocumento.DataKeys[e.RowIndex].Value;
                }
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                GridInformacionDocumento.EditIndex = -1;
                llenarGrid();
                PanelFormulario.Visible = false;
                MsjResultado.Visible = true;
                MsjResultado.Text = "Informacion Documento Eliminado";

            }
            catch (Exception)
            {

                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            
        }

        protected void GridInformacionDocumento_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string iddocumento, nombredocumento, codigo, version, iddepartamento, fechapublicacion, fechamodificacion, fecharevicion, status, usogeneral;
            try
            {
                TextBox txt = new TextBox();
                txt = (TextBox)GridInformacionDocumento.Rows[e.RowIndex].FindControl("txtIdDocumento");
                iddocumento = txt.Text;

                txt = (TextBox)GridInformacionDocumento.Rows[e.RowIndex].FindControl("txtNombreDocumento");
                nombredocumento = txt.Text;

                txt = (TextBox)GridInformacionDocumento.Rows[e.RowIndex].FindControl("txtCodigo");
                codigo = txt.Text;

                txt = (TextBox)GridInformacionDocumento.Rows[e.RowIndex].FindControl("txtVersion");
                version = txt.Text;

                DropDownList IdDepartamento = new DropDownList();
                IdDepartamento = (DropDownList)GridInformacionDocumento.Rows[e.RowIndex].FindControl("cbIdDepartamento");
                iddepartamento = Convert.ToString(IdDepartamento.SelectedValue);

                txt = (TextBox)GridInformacionDocumento.Rows[e.RowIndex].FindControl("txtFechaPublicacion");
                fechapublicacion = txt.Text;


                txt = (TextBox)GridInformacionDocumento.Rows[e.RowIndex].FindControl("txtFechaModificacion");
                fechamodificacion = txt.Text;


                txt = (TextBox)GridInformacionDocumento.Rows[e.RowIndex].FindControl("txtFechaRevicion");
                fecharevicion = txt.Text;

                CheckBox Status = new CheckBox();
                Status = (CheckBox)GridInformacionDocumento.Rows[e.RowIndex].FindControl("chbStatus");
                status = Convert.ToString(Status.Checked);

                CheckBox UsoGeneral = new CheckBox();
                UsoGeneral = (CheckBox)GridInformacionDocumento.Rows[e.RowIndex].FindControl("chbUsoGeneral");
                usogeneral = Convert.ToString(UsoGeneral.Checked);

                SqlCommand cmd = new SqlCommand("update_InfoDocumento", conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                {
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    cmd.Parameters.AddWithValue("@IdDocumento", SqlDbType.Int).Value = iddocumento;
                    cmd.Parameters.AddWithValue("@NombreDocumento", SqlDbType.VarChar).Value = nombredocumento;
                    cmd.Parameters.AddWithValue("@Codigo", SqlDbType.VarChar).Value = codigo;
                    cmd.Parameters.AddWithValue("@Version", SqlDbType.VarChar).Value = version;
                    cmd.Parameters.AddWithValue("@IdDepartamento", SqlDbType.Int).Value = iddepartamento;
                    cmd.Parameters.AddWithValue("@FechaPublicacion", SqlDbType.Date).Value = fechapublicacion;
                    cmd.Parameters.AddWithValue("@FechaModificacion", SqlDbType.Date).Value = fechamodificacion;
                    cmd.Parameters.AddWithValue("@FechaRevicion", SqlDbType.Date).Value = fecharevicion;
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Bit).Value = status;
                    cmd.Parameters.AddWithValue("@UsoGeneral", SqlDbType.Bit).Value = usogeneral;
                }
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                GridInformacionDocumento.EditIndex = -1;
                Limpiar();
                llenarGrid();
                MultiView2.ActiveViewIndex = -1;
                MsjResultado.Visible = true;
                MsjResultado.Text = "Información de Documento Actualizado Correctamente.";
            }
            catch (Exception ex)
            {

                MsjResultado.Text = ex.Message.ToString();
            }
        }

        public void Limpiar()
        {
            //txtIdDocument.Text = "";
            txtNombreDocument.Text = "";
            txtVersio.Text = "";
            txtCodigo.Text = "";
           // txtFechaPublicacio.Text = "";
            txtFechaModificacio.Text = "";
            txtFechaRevicio.Text = "";
           // cbIdDepartament.SelectedValue = "0";
            chbStatu.Checked = false;
            chbUsoGenerl.Checked = false;
        }
        public void dropBusqDep()
        {
            if (!this.IsPostBack)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT IdDepartamento, NombreDepartamento FROM Departamento"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conexion;
                    conexion.Open();
                    cbIdDepBusqueda.DataSource = cmd.ExecuteReader();
                    cbIdDepBusqueda.DataTextField = "NombreDepartamento";
                    cbIdDepBusqueda.DataValueField = "IdDepartamento";
                    cbIdDepBusqueda.DataBind();
                    conexion.Close();
                }
            }
        }
    }
}