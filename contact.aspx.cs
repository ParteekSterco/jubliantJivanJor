using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;

public partial class contact : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(Request.QueryString["pgidtrail"]));

            litcontact.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pagestatus=1 and pageid=@pageid", parameters)));
        }
    }
   
   protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string var = string.Empty;
        string ID = string.Empty;
        try
        {
           
                SqlConnection cn = new SqlConnection(clsm.strconnect);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[enquirysp]";
                cmd.Parameters.AddWithValue("@fname", txtname.Text.Trim());
                cmd.Parameters.AddWithValue("@emailid", txtemail.Text.Trim());               
                cmd.Parameters.AddWithValue("@Subject", txtsubject.Text.Trim());
                cmd.Parameters.AddWithValue("@FMessage", txtmsg.Text.Trim());
                cmd.Parameters.AddWithValue("@mode", 1);
                cmd.Parameters.AddWithValue("@Uname", "User");
                cmd.Parameters.Add("@eid", SqlDbType.Int, 0, "@eid").Direction = ParameterDirection.Output;
                cn.Open();
                cmd.ExecuteNonQuery();
           
                ID = cmd.Parameters["@eid"].Value.ToString();
                cn.Close();
                var = ID;

                Response.Redirect("~/thankyou.aspx?mpgid=11&pgidtrail=11&msg=thankyou");


            }
            catch (Exception ex)
            {

            }
        }

   protected void Page_LoadComplete(object sender, EventArgs e)
   {
       HtmlContainerControl panelbreadcrumb = (HtmlContainerControl)Master.FindControl("panelbreadcrumb");

       if (Conversion.Val(Request.QueryString["pgidtrail"]) == 10)
       {
           panelbreadcrumb.Visible = false;

       }
   }

    }
    
