using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;

public partial class backoffice_Products_mapproduct : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    string StrFileName;
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trnotice.Visible = false;
        trsuccess.Visible = false;
        if (Page.IsPostBack == false)
        {
            productid.Text = Convert.ToString(Request.QueryString["productid"]);
         
          //  bindmodel();
            

        


            if (Conversion.Val(Request.QueryString["mapid"]) > 0)
            {


                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                parameters.Clear();
                parameters.Add("@mapid", Conversion.Val(Request.QueryString["mapid"]));
                clsm.MoveRecord_Parameter(this, mapid.Parent,"Select * from map_product where mapid=@mapid",parameters);
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor1.Text = Server.HtmlDecode(shortdetail.Text);
                CKeditor2.Text = Server.HtmlDecode(bid.Text);

                if (!string.IsNullOrEmpty(bannerimage.Text.Trim()))
                {
                    File2.Visible = true;
                    LinkButton1.Visible = true;
                    Imageban.Visible = true;
                    Imageban.ImageUrl = "../../Uploads/LargeImages/" + bannerimage.Text;
                }
                else
                {
                    LinkButton1.Visible = false;
                }
                if (!string.IsNullOrEmpty(smallimage.Text.Trim()))
                {
                    File1.Visible = true;
                    LinkButton1.Visible = true;
                    Image1.Visible = true;
                    Image1.ImageUrl = "/Uploads/SmallImages/" + smallimage.Text;
                }
                else
                {
                    LinkButton2.Visible = false;
                }


            }



          gridshow();

           if (Request.QueryString["edit"] == "edit")
           {
                trsuccess.Visible = true;

               lblsuccess.Text = "Record Updated Successfully";
           }
        }
    }
  
    protected void modelselect(object sender, EventArgs e)
    {
       
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        if ((Page.IsValid == true))
        {
            try
            {
                shortdetail.Text = Server.HtmlEncode(CKeditor1.Text);
                bid.Text = Server.HtmlEncode(CKeditor2.Text);
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                //if (Convert.ToInt32(clsm.MasterSave(this, mapid.Parent, 14, mainclass.Mode.modeCheckDuplicate, "map_productSP", Session["Name"].ToString()).ToString()) > 0)
                //{
                //    Label1.Visible = true;
                //    Label1.Text = "This Record Already Exist";
                //    return;
                //}

                if ((mapid.Text != ""))
                {
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckImgType(File1.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        smallimage.Text = Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                    }


                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        if ((CheckImgType(File2.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        bannerimage.Text = Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                    }
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    object var = clsm.MasterSave(this, mapid.Parent, 14, mainclass.Mode.modeModify, "map_productSP", Session["Name"].ToString());
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        parameters.Clear();
                        parameters.Add("@mapid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select smallimage from map_product where mapid=@mapid", parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\smallimages\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + StrFileName);
                    }
                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        parameters.Clear();
                        parameters.Add("@mapid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select bannerimage from map_product where mapid=@mapid", parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\LargeImages\\" + StrFileName);
                    }
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    clsm.ClearallPanel(this, mapid.Parent);
                    productid.Text = Convert.ToString(Request.QueryString["productid"]);
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                    smallimage.Text = "";
                    Image1.Visible = false;
                    LinkButton1.Text = "";
                    bannerimage.Text = "";
                    Imageban.Visible = false;
                    LinkButton2.Text = "";
                   gridshow();
                }
                else
                {
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckImgType(File1.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        smallimage.Text = Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                    }
                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        if ((CheckImgType(File2.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        bannerimage.Text = Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                    }

                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    object var = clsm.MasterSave(this, mapid.Parent, 14, mainclass.Mode.modeAdd, "map_productSP", Session["Name"].ToString());
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        parameters.Clear();
                        parameters.Add("@mapid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select smallimage from map_product where mapid=@mapid", parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + StrFileName);
                    }
                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        parameters.Clear();
                        parameters.Add("@mapid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select bannerimage from map_product where mapid=@mapid", parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\LargeImages\\" + StrFileName);
                    }


                    clsm.ClearallPanel(this, mapid.Parent);
                   productid.Text = Convert.ToString(Request.QueryString["productid"]);
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record updated Successfully.";
                }
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor1.Text = "";
                CKeditor2.Text = "";
                Response.Redirect("mapproduct.aspx?productid=" + Conversion.Val(Request.QueryString["productid"]) + "&edit=edit");
            }
            catch (Exception eer)
            {
                Label1.Visible = true;
                Label1.Text = eer.Message;
            }

        }

    }

    protected void gridshow()
    {
        string strq2;
        parameters.Clear();
        parameters.Add("@productid", Conversion.Val(productid.Text));
        strq2 = "SELECT mp.*,p.productname FROM map_product mp  left join Products p on mp.productid=p.productid where mp.productid=@productid order by mp.displayorder";
        clsm.GridviewData_Parameter(GridView1, strq2, parameters);
        if ((GridView1.Rows.Count == 0))
        {
            trnotice.Visible = true;
            lblnotice.Text = "No Record(s) Available";
            GridView1.Visible = false;
        }
        else
        {
            GridView1.Visible = true;
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
            Label1.Visible = true;
            Label1.Text = ex.Message.ToString();
        }

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if ((e.CommandName == "btndel"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));


            TextBox mapid = (TextBox)row.FindControl("mapid");


            parameters.Clear();
            parameters.Add("@mapid", double.Parse(e.CommandArgument.ToString()));
            clsm.ExecuteQry_Parameter("delete from map_product where mapid=@mapid", parameters);
            //}

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully.";
        }

        if ((e.CommandName == "lnkstatus"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            if ((txtstatus.Text == "False"))
            {
                parameters.Clear();
                parameters.Add("@mapid", double.Parse(e.CommandArgument.ToString()));
                string strsql = "update map_product set status=1 where mapid=@mapid";
                clsm.ExecuteQry_Parameter(strsql, parameters);
            }
            else if ((txtstatus.Text == "True"))
            {
                Hashtable parameters = new Hashtable();
                parameters.Add("@mapid", double.Parse(e.CommandArgument.ToString()));
                string strsql = "update map_product set status=0 where mapid=@mapid";
                clsm.ExecuteQry_Parameter(strsql, parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";
        }

        if ((e.CommandName == "btnedit"))
        {
            Response.Redirect("mapproduct.aspx?productid=" + Conversion.Val(Request.QueryString["productid"]) + "&mapid=" + Conversion.Val(e.CommandArgument) + "");
        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");



            if ((txtstatus.Text == "True"))
            {
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_unblock.png";
                lnkstatus.ToolTip = "Active";
            }
            else if ((txtstatus.Text == "False"))
            {
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_block.png";
                lnkstatus.ToolTip = "Inactive";
            }

            e.Row.Attributes.Add("onmouseover", ("this.style.backgroundColor=\'"
                            + (Session["altColor"] + "\'")));
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#FFFFFF\'");
        }

    }


    protected void Button2_Click(object sender, System.EventArgs e)
    {
        clsm.ClearallPanel(this, Label1.Parent);
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(bannerimage.Text))
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + smallimage.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }

        }
        parameters.Clear();
        parameters.Add("@mapid", Convert.ToString(Request.QueryString["mapid"]));
        clsm.ExecuteQry_Parameter("update map_product set smallimage='' WHERE mapid=@mapid", parameters);
        smallimage.Text = "";
        Image1.Visible = false;
        LinkButton1.Text = "";


    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(smallimage.Text))
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + bannerimage.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }

        }
        parameters.Clear();
        parameters.Add("@mapid", Convert.ToString(Request.QueryString["mapid"]));
        clsm.ExecuteQry_Parameter("update map_product set bannerimage='' WHERE mapid=@mapid", parameters);
        bannerimage.Text = "";
        Imageban.Visible = false;
        LinkButton2.Text = "";


    }
    public bool CheckImgType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".gif":
                return true;
            case ".png":
                return true;
            case ".jpg":
                return true;
            case ".jpeg":
                return true;
            case ".bmp":
                return true;
            case ".webp":
                return true;
            case ".svg":
                return true;
            default:
                return false;
        }
    }
}