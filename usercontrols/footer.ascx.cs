using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;

public partial class usercontrols_footer : System.Web.UI.UserControl
{
    mainclass clsm = new mainclass();
    HttpCookie UserSession = default(HttpCookie);
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lnksubscribe_Click(object sender, EventArgs e)
    {
        //if (clsm.Checking("select * from Subscribers where subemail='" + txtsubEmail.Text + "'") == false)
        //{
        //    SqlConnection cn = new SqlConnection(clsm.strconnect);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = cn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "SubscribersSP";
        //    cmd.Parameters.AddWithValue("@subid", 0);
        //    cmd.Parameters.AddWithValue("@mobile", "");
        //    cmd.Parameters.AddWithValue("@subemail", txtsubEmail.Text);
        //    cmd.Parameters.AddWithValue("@status", 1);
        //    cmd.Parameters.AddWithValue("@uname", "user");
        //    cmd.Parameters.AddWithValue("@Mode", 1);
        //    cn.Open();
        //    cmd.ExecuteNonQuery();
        //    Response.Redirect("~/thankyou.aspx?mpgid=11&pgidtrail=11&msg=Sub");

        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('This email-id already registered.')", true);
        //}
    }
}