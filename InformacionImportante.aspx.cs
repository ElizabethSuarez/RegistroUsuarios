using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroUsuarios
{
    public partial class InformacionImportante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //panel2.Visible = false;

            }
            
        }

        //protected void btnHigieneManos_Click(object sender, ImageClickEventArgs e)
        //{
        //    if //(panel2.Visible)
        //    {
        //       // panel2.Visible = false;
        //       // Image1.Visible = false;
        //       // Image2.Visible = false;
        //    }
        //    else
        //    {
        //      //  panel2.Visible = true;
        //      //  Image1.Visible = false;
        //       // Image2.Visible = true;
 
        //    }
        //}

        //protected void imag5m_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (panel2.Visible)
        //    {
        //        panel2.Visible = false;
        //        Image1.Visible = false;
        //        Image2.Visible = false;
        //    }
        //    else
        //    {
        //        panel2.Visible = true;
        //        Image1.Visible = true;
        //        Image2.Visible = false;
        //    }
        //}       
    }
}