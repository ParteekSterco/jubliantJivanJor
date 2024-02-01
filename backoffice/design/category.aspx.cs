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
using Microsoft.VisualBasic;
public partial class backoffice_design_category : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!Page.IsPostBack)
        {
            if (Convert.ToInt32(Request.QueryString["pcatid"]) > 0)
            {
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                Parameters.Clear();
                Parameters.Add("@pcatid", Convert.ToInt32(Request.QueryString["pcatid"]));
                clsm.MoveRecord_Parameter(this, pcatid.Parent, "select * from designcate where pcatid=@pcatid", Parameters);
                pcatid.Text = HttpUtility.HtmlDecode(pcatid.Text);
                pcatid.Text = HttpUtility.HtmlDecode(pcatid.Text);
                displayorder.Text = HttpUtility.HtmlDecode(displayorder.Text);
                CKeditor1.ReadOnly = false;
                CKeditor1.Text = Server.HtmlDecode(detail.Text);
                CKeditor2.ReadOnly = false;
                CKeditor2.Text = Server.HtmlDecode(shortdetail.Text);

                CKeditor3.ReadOnly = false;
                CKeditor3.Text = Server.HtmlDecode(homedesc.Text);
                if (!string.IsNullOrEmpty(banner.Text.Trim()))
                {
                    File2.Visible = true;
                    LinkButton1.Visible = true;
                    Image1.Visible = true;
                    Image1.ImageUrl = "../../Uploads/ProductsImage/" + banner.Text;
                }
                else
                {
                    LinkButton1.Visible = false;
                }


                if (!string.IsNullOrEmpty(homeimage.Text.Trim()))
                {
                    File3.Visible = true;
                    LinkButton3.Visible = true;
                    Image2.Visible = true;
                    Image2.ImageUrl = "../../Uploads/ProductsImage/" + homeimage.Text;
                }
                else
                {
                    LinkButton3.Visible = false;
                }


            }
            if (Request.QueryString["add"] == "add")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record added successfully.";
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string StrFileName = null;
        try
        {
            detail.Text = Server.HtmlEncode(CKeditor1.Text);
            CKeditor1.ReadOnly = true;
            shortdetail.Text = Server.HtmlEncode(CKeditor2.Text);
            CKeditor2.ReadOnly = true;
            homedesc.Text = Server.HtmlEncode(CKeditor3.Text);
            CKeditor3.ReadOnly = true;
            if (Convert.ToInt32(clsm.MasterSave(this, pcatid.Parent, 18, mainclass.Mode.modeCheckDuplicate, "designcateSP", Convert.ToString(Session["UserId"]))) > 0)
            {
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                trnotice.Visible = true;
                lblnotice.Text = "This Category  already exist.";
                return;
            }
            if (string.IsNullOrEmpty(pcatid.Text))
            {
                if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                {
                    if ((CheckImgType(File2.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                    banner.Text = Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                }
                //else
                //{
                //    trnotice.Visible = true;
                //    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                //    return;
                //}
                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    if ((CheckFileType(File1.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
                        return;
                    }
                    UploadAPDF.Text = Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                }
                //else
                //{
                //    trnotice.Visible = true;
                //    lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
                //    return;

                //}


                if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                {
                    if ((CheckImgType(File3.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                    homeimage.Text = Path.GetFileName(Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                }



                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                Status.Checked = true;
                string var = clsm.MasterSave(this, pcatid.Parent, 18, mainclass.Mode.modeAdd, "designcateSP", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                {
                    Parameters.Clear();
                    Parameters.Add("@pcatid", var);
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select banner from designcate   where pcatid=@pcatid", Parameters));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + StrFileName);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\ProductsImage\\" + StrFileName);
                }
                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    Parameters.Clear();
                    Parameters.Add("@pcatid", var);
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select UploadAPDF from designcate where pcatid=@pcatid", Parameters));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + StrFileName);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\prospectus\\" + StrFileName);
                }


                if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                {
                    Parameters.Clear();
                    Parameters.Add("@pcatid", var);
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select homeimage from designcate where pcatid=@pcatid", Parameters));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + StrFileName);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File3.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\ProductsImage\\" + StrFileName);
                }


                clsm.ClearallPanel(this, pcatid.Parent);
                Status.Checked = true;
                trsuccess.Visible = true;
                lblsuccess.Text = "Record added successfully.";
            }
            else
            {
                if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                {
                    if ((CheckImgType(File2.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    if ((CheckFileType(File1.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                {
                    if ((CheckImgType(File3.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                }
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                string var = clsm.MasterSave(this, pcatid.Parent, 18, mainclass.Mode.modeModify, "designcateSP", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + UploadAPDF.Text);
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }
                    UploadAPDF.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "cpd_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    //UploadAPDF.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + UploadAPDF.Text);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand("update designcate set UploadAPDF=@UploadAPDF where pcatid=" + Convert.ToInt32(var) + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@UploadAPDF", UploadAPDF.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\prospectus\\" + UploadAPDF.Text);
                }
                if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                {
                    banner.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "ccimg_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + banner.Text);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    //' update banner file
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand("update designcate set banner=@banner where pcatid=" + var + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@banner", banner.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\ProductsImage\\" + banner.Text);
                }



                if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                {
                    homeimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "chimg_" + Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + homeimage.Text);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    //' update homeimage file
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand("update designcate set homeimage=@homeimage where pcatid=" + var + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@homeimage", homeimage.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File3.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\ProductsImage\\" + homeimage.Text);
                }
                Response.Redirect("viewcategory.aspx?edit=edit");
            }
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message;
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        
        if (Conversion.Val(Request.QueryString["pcatid"]) > 0)
        {
            Response.Redirect("viewcategory.aspx?edit=edit");
        }
        
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(banner.Text))
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + banner.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }
        }
        Parameters.Clear();
        Parameters.Add("@pcatid", Convert.ToInt32(Request.QueryString["pcatid"]));
        clsm.SendValue_Parameter("update designcate set banner='' where pcatid=@pcatid", Parameters);
        banner.Text = "";
        Image1.Visible = false;
        trsuccess.Visible = true;
        LinkButton1.Visible = false;
        lblsuccess.Text = "Image deleted successfully.";
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(UploadAPDF.Text))
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + UploadAPDF.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }
        }
        //clsm.ExecuteQry("update Products set prospectus='' where productid=" & Val(Request.QueryString("pid")))
        Parameters.Clear();
        Parameters.Add("@pcatid", Convert.ToInt32(Request.QueryString["pcatid"]));
        clsm.SendValue_Parameter("update designcate set UploadAPDF='' where pcatid=@pcatid", Parameters);
        banner.Text = "";
        Image1.Visible = false;
        trsuccess.Visible = true;
        LinkButton1.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(homeimage.Text))
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + homeimage.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }
        }
        Parameters.Clear();
        Parameters.Add("@pcatid", Convert.ToInt32(Request.QueryString["pcatid"]));
        clsm.SendValue_Parameter("update designcate set homeimage='' where pcatid=@pcatid", Parameters);
        homeimage.Text = "";
        Image2.Visible = false;
        trsuccess.Visible = true;
        LinkButton3.Visible = false;
        lblsuccess.Text = "Image deleted successfully.";
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
            case ".swf":
                return true;
            case ".webp":
                return true;
            case ".svg":
                return true;
            default:
                return false;
        }
    }
    public bool CheckFileType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".doc":
                return true;
            case ".pdf":
                return true;
            case ".docx":
                return true;
            case ".txt":

                return true;
            default:
                return false;
        }
    }
}