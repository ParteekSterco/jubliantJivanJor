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


public partial class backoffice_design_viewproduct : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    string StrFileName;
    public int appno;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Int32 p = 0;
        //  if (Int32.TryParse(Request.QueryString["cid"], out p) == true)

        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (Page.IsPostBack == false)
        {
            Parameters.Clear();
           
            categoryname();
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select category,ycatid from yearcategory where status = 1 order by displayorder", Parameters, ycatid);

            Parameters.Clear();
            clsm.Fillcombo_Parameter("select ytitle,yqid from year_quater where status = 1 order by displayorder", Parameters, yqid);
            
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
        clsm.Fillcombo_Parameter("select category,pcatid from designcate where status = 1 order by displayorder", Parameters, pcatid);
        pcatid.Items[0].Text = "Search By Category";
    }

  

 

    protected void gridshow()
    {
        string strsql = null;

        strsql = "select distinct p.*,b.category as category,c.category as subcategory,yq.ytitle,yc.category as ycategory from DesignProducts p left  join  designcate b on p.pcatid=b.pcatid left join designsubcate c on p.psubcatid=c.psubcatid left join yearcategory yc on p.ycatid=yc.ycatid left join year_quater yq on p.yqid=yq.yqid   where 1=1   ";

        Parameters.Clear();
        if (Conversion.Val(pcatid.SelectedValue) > 0)
        {
            Parameters.Add("@pcatid", Conversion.Val(pcatid.SelectedValue));
            //strsql += " and p.pcatid=@pcatid";
            strsql += " and p.pcatid=" + Conversion.Val(pcatid.SelectedValue)  + "";
        }

       
   
        if (Conversion.Val(ycatid.SelectedValue) > 0)
        {
            Parameters.Add("@ycatid", Conversion.Val(ycatid.SelectedValue));
            //strsql += " and p.pcatid=@pcatid";
            strsql += " and p.ycatid=" + Conversion.Val(ycatid.SelectedValue) + "";
        }


        if (Conversion.Val(yqid.SelectedValue) > 0)
        {
            Parameters.Add("@yqid", Conversion.Val(yqid.SelectedValue));
            //strsql += " and p.pcatid=@pcatid";
            strsql += " and p.yqid=" + Conversion.Val(yqid.SelectedValue) + "";
        }
        
        if (!string.IsNullOrEmpty(productname.Text))
        {
            Parameters.Add("@productname", productname.Text);
            strsql += " and p.productname like '%'+@productname+'%'";
        }
       

        strsql += " order by  p.displayorder";

       // Response.Write(strsql);
        clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
        if (GridView1.Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "Record(s) not found.";
            // btnexport.Visible = False
        }
        else
        {
            //btnexport.Visible = True
        }
        appno = GridView1.Rows.Count;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus = e.Row.FindControl("lnkstatus") as ImageButton;
            Label lbldown = e.Row.FindControl("lbldown") as Label;
            LinkButton downbtn = e.Row.FindControl("downbtn") as LinkButton;
            TextBox txtstatus = e.Row.FindControl("txtstatus") as TextBox;

            ImageButton lnkIsfamilyproduct = e.Row.FindControl("lnkIsfamilyproduct") as ImageButton;
            TextBox txtIsfamilyproduct = e.Row.FindControl("txtIsfamilyproduct") as TextBox;
            ImageButton lnkshowonhome = e.Row.FindControl("lnkshowonhome") as ImageButton;
            TextBox txtshowonhome = e.Row.FindControl("txtshowonhome") as TextBox;


            ImageButton lnkshowongroup = e.Row.FindControl("lnkshowongroup") as ImageButton;
            TextBox txtshowongroup = e.Row.FindControl("txtshowongroup") as TextBox;

            if (string.IsNullOrEmpty(lbldown.Text))
            {
                downbtn.Visible = false;
            }
            if (lnkstatus == null == false)
            {
                if (txtstatus.Text == "True")
                {
                    lnkstatus.ImageUrl = "~/Backoffice/assets/ico_unblock.png";
                    lnkstatus.ToolTip = "Yes";
                }
                else if (txtstatus.Text == "False")
                {
                    lnkstatus.ImageUrl = "~/Backoffice/assets/ico_block.png";
                    lnkstatus.ToolTip = "No";
                }
            }


            if (lnkIsfamilyproduct == null == false)
            {
                if (txtIsfamilyproduct.Text == "True")
                {
                    lnkIsfamilyproduct.ImageUrl = "~/Backoffice/assets/ico_unblock.png";
                    lnkIsfamilyproduct.ToolTip = "Yes";
                }
                else if (txtIsfamilyproduct.Text == "False")
                {
                    lnkIsfamilyproduct.ImageUrl = "~/Backoffice/assets/ico_block.png";
                    lnkIsfamilyproduct.ToolTip = "No";
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

            if (lnkshowongroup == null == false)
            {
                if (txtshowongroup.Text == "True")
                {
                    lnkshowongroup.ImageUrl = "../assets/ico_unblock.png";
                    lnkshowongroup.ToolTip = "Yes";
                }
                else if (txtshowongroup.Text == "False")
                {
                    lnkshowongroup.ImageUrl = "../assets/ico_block.png";
                    lnkshowongroup.ToolTip = "No";
                }
            }

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkstatus")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus = row.FindControl("txtstatus") as TextBox;
            if (txtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Products set status=1 where productid=@productid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Products set status=0 where productid=@productid", Parameters);
            }
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if (e.CommandName == "lnkIsfamilyproduct")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtIsfamilyproduct = row.FindControl("txtIsfamilyproduct") as TextBox;
            if (txtIsfamilyproduct.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Products set Isfamilyproduct=1 where productid=@productid", Parameters);
            }
            else if (txtIsfamilyproduct.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Products set Isfamilyproduct=0 where productid=@productid", Parameters);
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
                Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Products set showonhome=1 where productid=@productid", Parameters);
            }
            else if (txtshowonhome.Text == "True")
            {
                //Clsm.ExecuteQry("update newstype set status=0 where ntypeid=" & Val(e.CommandArgument) & "")
                Parameters.Clear();
                Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Products set showonhome=0 where productid=@productid", Parameters);
            }
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }


        if (e.CommandName == "showongroup")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtshowongroup = row.FindControl("txtshowongroup") as TextBox;
            if (txtshowongroup.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Products set showongroup=1 where productid=@productid", Parameters);
            }
            else if (txtshowongroup.Text == "True")
            {
                //Clsm.ExecuteQry("update newstype set status=0 where ntypeid=" & Val(e.CommandArgument) & "")
                Parameters.Clear();
                Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Products set showongroup=0 where productid=@productid", Parameters);
            }
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }


        if (e.CommandName == "btnedit")
        {
            Response.Redirect("product.aspx?pid=" + Convert.ToInt32(e.CommandArgument) + "");
        }
        if (e.CommandName == "btndel")
        {
            Parameters.Clear();
            Parameters.Add("@productid", Convert.ToInt32(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from Products where productid=@productid", Parameters);


            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lbldown = row.FindControl("lbldown") as Label;

            Label lblprodimg = row.FindControl("lblprodimg") as Label;

            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + lbldown.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }

            FileInfo F3 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + lblprodimg.Text);
            if (F3.Exists)
            {
                F3.Delete();
            }

            


            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record deleted successfully.";
        }
        if (e.CommandName == "downbtn")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lbldown = row.FindControl("lbldown") as Label;
            Response.Redirect("~/BackOffice/DownloadFile.aspx?D=~/Uploads/prospectus/" + lbldown.Text);
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            gridshow();
        }
        catch (Exception ex)
        {

        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridshow();
    }
    
}
