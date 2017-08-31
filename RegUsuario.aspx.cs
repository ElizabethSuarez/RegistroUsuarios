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
    public partial class RegUsuario : System.Web.UI.Page
    {
        SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog=ControlDocumental;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)            
            {
                txtMensaje.Visible = false;
                dropDepartamento();                  
                dropRol();
                PanelFormulario.Visible = false;                
                dropBusqDep();
            }
        }       
        //Grilla
        protected void GridUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {                
                llenar_Grid();
                GridUsuario.PageIndex = e.NewPageIndex;
                this.GridUsuario.DataBind();
                Limpiar();
                txtMensaje.Text = "";
            }
            catch (Exception ex)
            {
                txtMensaje.Visible = true;
                txtMensaje.Text = ex.Message.ToString();
            }
        }      

        protected void GridUsuario_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridUsuario.EditIndex = e.NewEditIndex;                
                llenar_Grid();            
                    if (cbIdDepBusqueda.SelectedValue != "0")
                    {
                        ConsultaPorDepartamento();
                    }
                    else if (bst.Text != "")
                    {
                        ConsultaUsuario();
                       
                    }
                    else if (BusquedaPorMetodo.SelectedValue!="0")
                    {
                        Consultas_Asignadas();
                    }    
                                       
                }
            catch (Exception ex)
            {
                txtMensaje.Visible = true;
                txtMensaje.Text = ex.Message.ToString();
                
            }
        }
        
        protected void GridUsuario_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string idusuario, nombreusuario, apellidopaterno, apellidomaterno, numerodenomina, status, idrol,iddepartamento,  responsabledepartamento;
            try
            {
                TextBox txt = new TextBox();
                txt = (TextBox)GridUsuario.Rows[e.RowIndex].FindControl("txtIdUsuario");
                idusuario = txt.Text;

                txt = (TextBox)GridUsuario.Rows[e.RowIndex].FindControl("txtNombreUsuario");
                nombreusuario = txt.Text;

                txt = (TextBox)GridUsuario.Rows[e.RowIndex].FindControl("txtApellidoPaterno");
                apellidopaterno = txt.Text;

                txt = (TextBox)GridUsuario.Rows[e.RowIndex].FindControl("txtApellidoMaterno");
                apellidomaterno = txt.Text;

                txt = (TextBox)GridUsuario.Rows[e.RowIndex].FindControl("txtNumeroDeNomina");
                numerodenomina = txt.Text;

                CheckBox Status = new CheckBox();
                Status = (CheckBox)GridUsuario.Rows[e.RowIndex].FindControl("cbStatus");
                status = Convert.ToString(Status.Checked);

                DropDownList IdDepartamento = new DropDownList();
                IdDepartamento = (DropDownList)GridUsuario.Rows[e.RowIndex].FindControl("cbIdDepartamento");
                iddepartamento = Convert.ToString(IdDepartamento.SelectedValue);

                
                DropDownList IdRol = new DropDownList();
                IdRol = (DropDownList)GridUsuario.Rows[e.RowIndex].FindControl("cbIdRol");
                idrol = Convert.ToString(IdRol.SelectedValue);


                CheckBox ResponsableDepartamento = new CheckBox();
                ResponsableDepartamento = (CheckBox)GridUsuario.Rows[e.RowIndex].FindControl("cbResponsableDepartamento");
                responsabledepartamento = Convert.ToString(ResponsableDepartamento.Checked);


                SqlCommand cmd = new SqlCommand("usp_Usuario_actualizar", conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);                
                {                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", SqlDbType.VarChar).Value = idusuario;
                    cmd.Parameters.AddWithValue("@NombreUsuario", SqlDbType.VarChar).Value = nombreusuario;
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", SqlDbType.VarChar).Value = apellidopaterno;
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", SqlDbType.VarChar).Value = apellidomaterno;
                    cmd.Parameters.AddWithValue("@NumeroDeNomina", SqlDbType.Int).Value = numerodenomina;
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Bit).Value = status;
                    cmd.Parameters.AddWithValue("@IdDepartamento",SqlDbType.Int).Value=iddepartamento;
                    cmd.Parameters.AddWithValue("@IdRol", SqlDbType.Int).Value = idrol;
                    cmd.Parameters.AddWithValue("@ResponsableDepartamento", SqlDbType.Bit).Value = responsabledepartamento;
                }
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                GridUsuario.EditIndex=-1;
                llenar_Grid();
               // bst.Text = "";//
                PanelFormulario.Visible = false;
                txtMensaje.Visible = true;
                txtMensaje.Text = "Usuario Actualizado Correctamente.";
                
            }
            catch (Exception ex)
            {
                txtMensaje.Visible = true;
                txtMensaje.Text = ex.Message.ToString();                
            }
        }              

        protected void GridUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Usuariol_eliminar", conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", SqlDbType.VarChar).Value=GridUsuario.DataKeys[e.RowIndex].Value;
                }
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                GridUsuario.EditIndex = -1;
                llenar_Grid();
                PanelFormulario.Visible=false;
                txtMensaje.Visible = true;
                txtMensaje.Text="Personal Eliminado Correctamente";
         }
            catch (Exception)
            {
                if (conexion.State==ConnectionState.Open)
	            {
                    conexion.Close();		 
	            }
            }
        }

        protected void GridUsuario_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridUsuario.EditIndex = -1;
                llenar_Grid();
            }
            catch (Exception ex)
            {
                txtMensaje.Visible = true;
                txtMensaje.Text = ex.Message.ToString();
            }
        }
        //--
       //Botones
        protected void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            txtMensaje.Visible = false;
            if (PanelFormulario.Visible)
            {
                PanelFormulario.Visible = false;
                MultiView1.ActiveViewIndex = -1;
                Limpiar();
            }
            else
            {
                PanelFormulario.Visible = true;        
                MultiView1.ActiveViewIndex = -1;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            PanelFormulario.Visible = false;
            Limpiar();
            txtMensaje.Visible = false;
            txtMensaje.Text = "";
        }
                 
        protected void Busqueda_Click(object sender, EventArgs e)
        {
            txtMensaje.Visible = false;
            PanelFormulario.Visible = false;
            MultiView1.ActiveViewIndex = 0;            
            try
            {
                if (bst.Text != "")
                {
                    ConsultaUsuario();
                    if (bst.Text == "Todos")
                    {
                        llenar_Grid();
                        cbIdDepBusqueda.SelectedValue = "0";
                    }
                    cbIdDepBusqueda.SelectedValue = "0";
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

        protected void BusquedaDepartamento_Click(object sender, EventArgs e)
        {
            txtMensaje.Visible = false;
            PanelFormulario.Visible = false;
            MultiView1.ActiveViewIndex = 0;
            try
            {
                 if (cbIdDepBusqueda.SelectedValue != "")
                    {
                        ConsultaPorDepartamento();

                        if (cbIdDepBusqueda.SelectedValue == "0")
                        {
                            llenar_Grid();
                            bst.Text = "";
                        }
                    }
                bst.Text = "";
            }
            catch (Exception)
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdUsuari.Text != "" && txtNombreUsuari.Text != "" && txtApellidoPatern.Text != "" && txtApellidoMatern.Text != "" && txtNumeroDeNomin.Text != "" && cbStatu.Text != "" && cbIdDepartament.Text != "" && cbIdRo.Text != "" && cbResponsableDeDepartament.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("sp_Usuario_grabar", conexion);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdUsuario", SqlDbType.VarChar).Value = txtIdUsuari.Text;
                        cmd.Parameters.AddWithValue("@NombreUsuario", SqlDbType.VarChar).Value = txtNombreUsuari.Text;
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", SqlDbType.VarChar).Value = txtApellidoPatern.Text;
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", SqlDbType.VarChar).Value = txtApellidoMatern.Text;
                        cmd.Parameters.AddWithValue("@NumeroDeNomina", SqlDbType.Int).Value = txtNumeroDeNomin.Text;
                        cmd.Parameters.AddWithValue("@Status", SqlDbType.Bit).Value = cbStatu.SelectedValue;
                        cmd.Parameters.AddWithValue("@IdDepartamento", SqlDbType.Int).Value = cbIdDepartament.SelectedValue;
                        cmd.Parameters.AddWithValue("@IdRol", SqlDbType.Int).Value = cbIdRo.SelectedValue;
                        cmd.Parameters.AddWithValue("@ResponsableDepartamento", SqlDbType.Bit).Value = cbResponsableDeDepartament.SelectedValue;
                    }
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    llenar_Grid();
                    PanelFormulario.Visible = false;
                    Limpiar();
                    txtMensaje.Visible = true;
                    txtMensaje.Text = "Personal Guardado Correctamente";
                    
                }
                else
                {
                    txtMensaje.Visible = true;
                    txtMensaje.Text = "Completar el Formulario";
                }
            }
            catch (Exception ex)
            {
                txtMensaje.Visible = true;
                txtMensaje.Text = ex.Message.ToString();
            }
        }
        //--
        //metodos
        protected void llenar_Grid()
        {
            SqlCommand cmd = new SqlCommand("usp_Usuario_mostrar", conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridUsuario.DataSource = dt;
            this.GridUsuario.DataBind();
        }

        public void dropDepartamento()
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

        public void dropRol()
        {
            if (!this.IsPostBack)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT IdRol, NombreRol FROM Roles"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conexion;
                    conexion.Open();
                    cbIdRo.DataSource = cmd.ExecuteReader();
                    cbIdRo.DataTextField = "NombreRol";
                    cbIdRo.DataValueField = "IdRol";
                    cbIdRo.DataBind();
                    conexion.Close();
                }

            }
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

        private void Limpiar()
        {
            txtIdUsuari.Text = "";
            txtNombreUsuari.Text = "";
            txtApellidoPatern.Text = "";
            txtApellidoMatern.Text = "";
            txtNumeroDeNomin.Text = "";
            cbIdRo.ClearSelection();
            cbIdDepartament.ClearSelection();
            cbStatu.ClearSelection();
            cbResponsableDeDepartament.ClearSelection();
            txtMensaje.Text = "";
        }
        
        protected void GridUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void UsuariosActivos_Click1(object sender, EventArgs e)
        {
            txtMensaje.Visible = false;
            cbIdDepBusqueda.SelectedValue = "0";
            PanelFormulario.Visible = false;
            MultiView1.ActiveViewIndex = 0;
            try
            {
                Consultas_Asignadas();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Consultas_Asignadas()
        {
            if (BusquedaPorMetodo.SelectedValue == "0")
            {
                MultiView1.ActiveViewIndex = -1;
            }
            else if (BusquedaPorMetodo.SelectedValue == "1")
            {
                ConsultaUsuariosActivos();
            }
            else if (BusquedaPorMetodo.SelectedValue == "2")
            {
                ConsultaUsuariosInactivos();
            }
            else if (BusquedaPorMetodo.SelectedValue == "3")
            {
                Consulta_ResponsablesDeDepartamento();
            }
            else if (BusquedaPorMetodo.SelectedValue == "4")
            {
                Consulta_No_ResponsablesDeDepartamento();
            }
            else if (BusquedaPorMetodo.SelectedValue == "5")
            {
                ConsultaUsuariosActivos_Respon();
            }
            else if (BusquedaPorMetodo.SelectedValue == "6")
            {
                ConsultaUsuariosActivos_No_Resp();
            }
        }
        //Consultas
        protected void ConsultaPorDepartamento()
        {
            SqlCommand cmd = new SqlCommand("select *from Usuario where IdDepartamento like'" + cbIdDepBusqueda.SelectedValue + "%'", conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridUsuario.DataSource = dt;
            GridUsuario.DataBind();
            conexion.Close();
        }
        protected void ConsultaUsuario()
        {
            SqlCommand cmd = new SqlCommand("select *from Usuario where IdUsuario like'" + bst.Text + "%'", conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridUsuario.DataSource = dt;
            GridUsuario.DataBind();
            conexion.Close();
        }
        protected void ConsultaUsuariosActivos()
        {
            SqlCommand cmd = new SqlCommand("usuarios_Activos", conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridUsuario.DataSource = dt;
            GridUsuario.DataBind();
            conexion.Close();
        }
        protected void ConsultaUsuariosInactivos()
        {
            SqlCommand cmd = new SqlCommand("usuarios_Inactivos", conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridUsuario.DataSource = dt;
            GridUsuario.DataBind();
            conexion.Close();
        }
        protected void Consulta_ResponsablesDeDepartamento()
        {
            SqlCommand cmd = new SqlCommand("usuarios_ResDep", conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridUsuario.DataSource = dt;
            GridUsuario.DataBind();
            conexion.Close();
        }
        protected void Consulta_No_ResponsablesDeDepartamento()
        {
            SqlCommand cmd = new SqlCommand("usuarios_NoResponsableDep", conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridUsuario.DataSource = dt;
            GridUsuario.DataBind();
            conexion.Close();
        }
        protected void ConsultaUsuariosActivos_Respon()
        {
            SqlCommand cmd = new SqlCommand("usuarios_ActivosResponsables", conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridUsuario.DataSource = dt;
            GridUsuario.DataBind();
            conexion.Close();
        }
        protected void ConsultaUsuariosActivos_No_Resp()
        {
            SqlCommand cmd = new SqlCommand("usuarios_ActivosNoReponsablesDep", conexion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridUsuario.DataSource = dt;
            GridUsuario.DataBind();
            conexion.Close();
        }
    }
}