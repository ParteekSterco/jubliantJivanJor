using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.Mail;
using Microsoft.VisualBasic;

public partial class backoffice_Products_viewsubcategory : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    string StrFileName;
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (Page.IsPostBack == false)
        {
            Parameters.Clear();
            categoryname();
            gridshow();

            if (Request.QueryString["edit"] == "edit")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record updated successfully.";
            }
        }
    }
    private void categoryname()
    {
        Parameters.Clear();
        clsm.Fillcombo_Parameter("select category,pcatid from productcate where status = 1 order by displayorder", Parameters, pcatid);
        pcatid.Items[0].Text = "Search By Category";
    }
    protected void gridshow()
    {
        try
        {
            string strsql = "select sc.*,pc.category as subcategory from productsubcate sc left join productcate pc on sc.pcatid=pc.pcatid where 1=1  ";
            Parameters.Clear();

            if (Conversion.Val(pcatid.SelectedValue) > 0)
            {

                Parameters.Add("@pcatid", Conversion.Val(pcatid.SelectedValue));
                strsql += " and sc.pcatid=@pcatid";
            }
            if (!string.IsNullOrEmpty(catname.Text))
            {
                Parameters.Add("@category", catname.Text);
                strsql += " and sc.category like '%'+@category+'%'";
            }

            strsql += " order by sc.displayorder";
            clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
            if (GridView1.Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "Record(s) not found.";
            }
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus = e.Row.FindControl("lnkstatus") as ImageButton;
            TextBox txtstatus = e.Row.FindControl("txtstatus") as TextBox;

            ImageButton lnkshowonhome = e.Row.FindControl("lnkshowonhome") as ImageButton;
            TextBox txtshowonhome = e.Row.FindControl("txtshowonhome") as TextBox;


            if (lnkstatus == null == false)
            {
                if (txtstatus.Text == "True")
                {
                    lnkstatus.ImageUrl = "../assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Yes";
                }
                else if (txtstatus.Text == "False")
                {
                    lnkstatus.ImageUrl = "../assets/ico_block.png";
                    lnkstatus.ToolTip = "No";
                }
            }

            if (lnkshowonhome == null == false)
            {
                if (txtshowonhome.Text == "True")
                {
                    lnkshowonhome.ImageUrl = "../assets/ico_unblock.png";
                    lnkshowonhome.ToolTip = "Yes";
                }
                else if (txtshowonhome.Text == "False")
                {
                    lnkshowonhome.ImageUrl = "../assets/ico_block.png";
                    lnkshowonhome.ToolTip = "No";
                }
            }

        }


    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Response.Redirect("subcategory.aspx?psubcatid=" + e.CommandArgument);
        }
        if (e.CommandName == "status")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus = row.FindControl("txtstatus") as TextBox;
            if (txtstatus.Text == "False")
            {
                //Clsm.ExecuteQry("update newstype set status=1 where ntypeid=" & Val(e.CommandArgument) & "")
                Parameters.Clear();
                Parameters.Add("@psubcatid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update productsubcate set status=1 where psubcatid=@psubcatid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                //Clsm.ExecuteQry("update newstype set status=0 where ntypeid=" & Val(e.CommandArgument) & "")
                Parameters.Clear();
                Parameters.Add("@psubcatid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update productsubcate set status=0 where psubcatid=@psubcatid", Parameters);
            }
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }



        if (e.CommandName == "showonhome")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtshowonhome = row.FindControl("txtshowonhome") as TextBox;
            if (txtshowonhome.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@psubcatid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update productsubcate set showonhome=1 where psubcatid=@psubcatid", Parameters);
            }
            else if (txtshowonhome.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@psubcatid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update productsubcate set showonhome=0 where psubcatid=@psubcatid", Parameters);
            }
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }






        if (e.CommandName == "del")
        {
            Parameters.Clear();
            Parameters.Add("@psubcatid", Convert.ToInt32(e.CommandArgument));
            if (clsm.Checking_Parameter("select * from products where psubcatid=@psubcatid", Parameters) == true)
            {
                //If Clsm.Checking("select * from newstype where ntypeid=" & Val(e.CommandArgument)) = True Then
                trnotice.Visible = true;
                lblnotice.Text = "Sorry, Data in use. Can not delete.";
                return;
            }
            else
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblimage = row.FindControl("lblimage") as Label;
                //Clsm.ExecuteQry("delete from newstype where ntypeid=" & Val(e.CommandArgument) & "")
                Parameters.Clear();
                Parameters.Add("@psubcatid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("delete from productsubcate where psubcatid=@psubcatid", Parameters);
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + Server.HtmlDecode(lblimage.Text));
                if (F1.Exists)
                {
                    F1.Delete();
                }
                gridshow();
                trnotice.Visible = true;
                lblnotice.Text = "Sub Category deleted successfully.";
            }

        }


    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        gridshow();
    }
}