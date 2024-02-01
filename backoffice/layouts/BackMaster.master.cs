using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class backoffice_layouts_BackMaster : System.Web.UI.MasterPage
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["AUserSession"] == null)
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = Request.Cookies["AUserSession"];
        }

        Session["Trid"] = AUserSession["Trid"];
        Session["UserId"] = AUserSession["UserId"];
        Session["Name"] = AUserSession["Name"];
        Session["Uname"] = AUserSession["Uname"];
        
        


        if (Page.IsPostBack == false)
        {

            //SqlConnection cn = new SqlConnection(clsm.strconnect);
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = cn;
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "lastupdatelogSP";
            //cmd.Parameters.AddWithValue("@username", Convert.ToString(Session["Trid"]));
            //cn.Open();
            //cmd.ExecuteNonQuery();
            //cn.Close();

            lbldatetime.Text = DateTime.Today.ToString("dddd,MMMM dd,yyyy");
            Label1.Text = Convert.ToString(Session["Name"]);
            if (Session["UserId"] == null || Session["UserId"] == "")
            {
                Response.Redirect("~/backoffice/default.aspx");
            }
        }
        else
        {

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/backoffice/logout.aspx");

    }
    protected void LinkButton2_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("~/backoffice/users/homepage.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/backoffice/users/homepage.aspx");
    }
}
