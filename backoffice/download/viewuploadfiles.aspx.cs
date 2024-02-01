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


public partial class backoffice_download_viewuploadfiles : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (Page.IsPostBack == false)
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("Select Title,UTId,displayorder from UploadType where Status=1 order by displayorder", Parameters, drpcat);
            drpcat.Items[0].Text = "Upload Type";

             Label1.Visible = false;
             griddata();
             if (Request.QueryString["edit"] == "edit")
             {
                     trsuccess.Visible = true;
                     lblsuccess.Text = "Record Updated Successfully.";
             }
         
        }
    }

    protected void griddata()
    {
        Label1.Visible = false;
        string strq2 = null;
        strq2 = "select a.*,b.downloadtimes,b.title from uploadedfiles a left outer join uploadtype b on a.utid=b.utid where 1=1";
        Parameters.Clear();

        if (Convert.ToInt32(drpcat.SelectedValue) != 0)
        {
            Parameters.Add("@uploadcat", Convert.ToInt32(drpcat.SelectedValue));
            strq2 += " and a.utid =@uploadcat";
        }

        if (!string.IsNullOrEmpty(TextBox4.Text))
        {
           
            Parameters.Add("@fileTitle", TextBox4.Text);
            strq2 += " and a.fileTitle  like '%'+@fileTitle+'%'";
        }
        if (!string.IsNullOrEmpty(TextBox5.Text))
        {
          
            Parameters.Add("@TRdate", TextBox5.Text);
            strq2 += " and a.TRdate >=@TRdate";
        }
        if (!string.IsNullOrEmpty(TextBox6.Text))
        {
   
            Parameters.Add("@trdateone", TextBox6.Text + " 23:59:59");
            strq2 += " and a.trdate <=@trdateone";
        }
        strq2 += " order by a.displayorder";
       
        clsm.GridviewData_Parameter(GridView1, strq2, Parameters);
        if (GridView1.Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "Record(s) not found.";
            //Label1.Visible = True
            //Label1.Text = "No Uploaded Files"
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            griddata();
        }
        catch (Exception ex)
        {
            Label1.Visible = true;
            Label1.Text = ex.Message.ToString();
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus = e.Row.FindControl("lnkstatus")as ImageButton;
            TextBox txtstatus = e.Row.FindControl("txtstatus") as TextBox;
            if (txtstatus.Text == "True")
            {
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_unblock.png";
                lnkstatus.ToolTip = "Active";
            }
            else if (txtstatus.Text == "False")
            {
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_block.png";
                lnkstatus.ToolTip = "Inactive";
            }
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");

            Image imgDown = e.Row.FindControl("imgDown") as Image;
            Label lbldown = e.Row.FindControl("lbldown") as Label;
            if (string.IsNullOrEmpty(lbldown.Text))
            {
                imgDown.Visible = false;
            }
            else
            {
                imgDown.Visible = true;
            }
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "btndel")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lbldown = row.FindControl("lbldown") as Label;
            Label lblimage = row.FindControl("lblimage") as Label;
            // row.Cells(4).FindControl("lbldown")'lblimage
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" +lbldown.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }
            FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + lblimage.Text);
            if (F2.Exists)
            {
                F2.Delete();
            }
            //clsm.ExecuteQry("delete from uploadedfiles where fileid=" & e.CommandArgument.ToString() & "")
            Parameters.Clear();
            Parameters.Add("@fileid", Convert.ToInt32(e.CommandArgument.ToString()));
            clsm.ExecuteQry_Parameter("delete from uploadedfiles where fileid=@fileid", Parameters);
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully.";
            //Label1.Visible = True
            //Label1.Text = "Record Deleted Successfully !!!"
        }
        if (e.CommandName == "lnkstatus")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus = row.FindControl("txtstatus") as TextBox;
            if (txtstatus.Text == "False")
            {
                // clsm.ExecuteQry("update uploadedfiles set status=1 where fileid=" & e.CommandArgument.ToString() & "")
                Parameters.Clear();
                Parameters.Add("@fileid", Convert.ToInt32(e.CommandArgument.ToString()));
                clsm.ExecuteQry_Parameter("update uploadedfiles set status=1 where fileid=@fileid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                //clsm.ExecuteQry("update uploadedfiles set status=0 where fileid=" & e.CommandArgument.ToString() & "")
                Parameters.Clear();
                Parameters.Add("@fileid", Convert.ToInt32(e.CommandArgument.ToString()));
                clsm.ExecuteQry_Parameter("update uploadedfiles set status=0 where fileid=@fileid", Parameters);
            }
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully.";
            //Label1.Visible = True
            //Label1.Text = "Status Changed Successfully !!!"
        }
        if (e.CommandName == "downbtn")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lbldown = row.FindControl("lbldown") as Label;
            Response.Redirect("~/BackOffice/DownloadFile.aspx?D=~/Uploads/Files/" + lbldown.Text);
        }
        if (e.CommandName == "btnedit")
        {
            Response.Redirect("uploadfiles.aspx?fid=" + Convert.ToInt32(e.CommandArgument));
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        griddata();
    }
}
