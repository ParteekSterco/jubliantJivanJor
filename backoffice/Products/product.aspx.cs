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


public partial class backoffice_Products_product : System.Web.UI.Page
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
        if (!Page.IsPostBack)
        {

            //Response.Write(DateTime.Now.AddHours(72).ToString("MM/dd/yyyy"));
            //Label3.Text = DateTime.Now.AddHours(72).ToString("MM/dd/yyyy");
            expiraydate.Text = DateTime.Now.AddHours(72).ToString("MM/dd/yyyy"); 
            BindCategories();
            BindSubCategories();
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select brand,pcatid from brand where status = 1 order by displayorder", Parameters, ycatid);

            Parameters.Clear();
            clsm.Fillcombo_Parameter("select ytitle,yqid from year_quater where status = 1 order by displayorder", Parameters, yqid);



            Int32 p = 0;
            if (Int32.TryParse(Request.QueryString["pid"], out p) == true)
            {
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor6.ReadOnly = true;
                CKeditor7.ReadOnly = true;

                Parameters.Clear();
                Parameters.Add("@productid", Convert.ToInt32(Request.QueryString["pid"]));
                clsm.MoveRecord_Parameter(this, productid.Parent, "select * from Products where productid=@productid", Parameters);


                BindSubCategories();

                Parameters.Clear();
                Parameters.Add("@productid", Convert.ToInt32(Request.QueryString["pid"]));
                clsm.MoveRecord_Parameter(this, productid.Parent, "select * from Products where productid=@productid", Parameters);

                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor6.ReadOnly = false;
                CKeditor7.ReadOnly = false;
                CKeditor2.Text = Server.HtmlDecode(productdetail.Text);
                CKeditor1.Text = Server.HtmlDecode(shortdetail.Text);
                CKeditor3.Text = Server.HtmlDecode(longdesc.Text);
                CKeditor4.Text = Server.HtmlDecode(producttitle.Text);
                CKeditor6.Text = Server.HtmlDecode(appdetail.Text);
                CKeditor7.Text = Server.HtmlDecode(appvideodetail.Text);

                if (!string.IsNullOrEmpty(UploadAImage.Text.Trim()))
                {
                    File2.Visible = true;
                    LinkButton1.Visible = true;
                    Image1.Visible = true;
                    Image1.ImageUrl = "../../Uploads/ProductsImage/" + UploadAImage.Text;
                }
                else
                {
                    LinkButton1.Visible = false;
                }

                if (!string.IsNullOrEmpty(largeimage.Text.Trim()))
                {
                    File3.Visible = true;
                    LinkButton2.Visible = true;
                    Image2.Visible = true;
                    Image2.ImageUrl = "../../Uploads/ProductsImage/" + largeimage.Text;
                }
                else
                {
                    LinkButton2.Visible = false;
                }

                if (!string.IsNullOrEmpty(producticon.Text.Trim()))
                {
                    File4.Visible = true;
                    LinkButton3.Visible = true;
                    Image3.Visible = true;
                    Image3.ImageUrl = "../../Uploads/ProductsImage/" + producticon.Text;
                }
                else
                {
                    LinkButton3.Visible = false;
                }
                if (!string.IsNullOrEmpty(videoimage.Text.Trim()))
                {
                    File5.Visible = true;
                    LinkButton4.Visible = true;
                    Image4.Visible = true;
                    Image4.ImageUrl = "../../Uploads/ProductsImage/" + videoimage.Text;
                }
                else
                {
                    LinkButton4.Visible = false;
                }
            }

        }

    }

    protected void BindCategories()
    {
        Parameters.Clear();
        clsm.Fillcombo_Parameter("select category,pcatid from productcate where status = 1 order by displayorder", Parameters, pcatid);
    }

    protected void BindSubCategories()
    {
        string sqlstr = "select category,psubcatid from productsubcate where 1=1 and status = 1";
        Parameters.Clear();
        Parameters.Add("@pcatid", Conversion.Val(pcatid.SelectedValue));
        sqlstr += " and pcatid=@pcatid";
        if (Conversion.Val(pcatid.SelectedValue) > 0)
        {
            // Parameters.Add("@pcatid", Conversion.Val(pcatid.SelectedValue));
            sqlstr += " and pcatid=@pcatid";
        }
        sqlstr += " order by displayorder";
        clsm.Fillcombo_Parameter(sqlstr, Parameters, psubcatid);
    }
    protected void pcatid_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubCategories();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string StrFileName = null;
            productdetail.Text = Server.HtmlEncode(CKeditor2.Text);
            shortdetail.Text = Server.HtmlEncode(CKeditor1.Text);

            longdesc.Text = Server.HtmlEncode(CKeditor3.Text);
            producttitle.Text = Server.HtmlEncode(CKeditor4.Text);
            appdetail.Text = Server.HtmlEncode(CKeditor6.Text);
            appvideodetail.Text = Server.HtmlEncode(CKeditor7.Text);

            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            CKeditor3.ReadOnly = true;
            CKeditor4.ReadOnly = true;
            CKeditor6.ReadOnly = true;
            CKeditor7.ReadOnly = true;


            if (string.IsNullOrEmpty(productid.Text))
            {
                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    if ((CheckFileType(File1.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
                        return;
                    }
                    prospectus.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
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
                    UploadAImage.Text = Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                }
                if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                {
                    if ((CheckImgType(File3.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                    largeimage.Text = Path.GetFileName(Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                }
                if (!string.IsNullOrEmpty(File4.PostedFile.FileName))
                {
                    if ((CheckImgType(File4.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                    UploadAImage.Text = Path.GetFileName(Path.GetFileName(File4.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                }
                if (!string.IsNullOrEmpty(File5.PostedFile.FileName))
                {
                    if ((CheckImgType(File5.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                    videoimage.Text = Path.GetFileName(Path.GetFileName(File5.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                }
                //else
                //{
                //    trnotice.Visible = true;
                //    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                //    return;

                //}
                status.Checked = true;
                showongroup.Checked = true;
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor6.ReadOnly = true;
                CKeditor7.ReadOnly = true;

                string var = clsm.MasterSave(this, productid.Parent, 33, mainclass.Mode.modeAdd, "ProductsSP", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor6.ReadOnly = false;
                CKeditor7.ReadOnly = false;



                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    Parameters.Clear();
                    Parameters.Add("@productid", Convert.ToInt32(var));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select prospectus from Products where productid=@productid", Parameters));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + StrFileName);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\prospectus\\" + StrFileName);
                }



                //Azhar 9 Oct 2021

                if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                {
                    Parameters.Clear();
                    Parameters.Add("@productid", var);
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select UploadAImage from Products where productid=@productid", Parameters));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + StrFileName);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\ProductsImage\\" + StrFileName);
                }







                if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                {
                    Parameters.Clear();
                    Parameters.Add("@productid", var);
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select largeimage from Products where productid=@productid", Parameters));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + StrFileName);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File3.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\ProductsImage\\" + StrFileName);
                }

                if (!string.IsNullOrEmpty(File4.PostedFile.FileName))
                {
                    Parameters.Clear();
                    Parameters.Add("@productid", Convert.ToInt32(var));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select producticon from Products where productid=@productid", Parameters));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + StrFileName);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File4.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\ProductsImage\\" + StrFileName);
                }
                if (!string.IsNullOrEmpty(File5.PostedFile.FileName))
                {
                    Parameters.Clear();
                    Parameters.Add("@productid", Convert.ToInt32(var));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select videoimage from Products where productid=@productid", Parameters));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + StrFileName);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File5.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\ProductsImage\\" + StrFileName);
                }
                clsm.ClearallPanel(this, productid.Parent);


                CKeditor1.Text = "";
                CKeditor2.Text = "";
                CKeditor3.Text = "";
                CKeditor4.Text = "";
                CKeditor6.Text = "";
                CKeditor7.Text = "";
                trsuccess.Visible = true;
                lblsuccess.Text = "Record added successfully.";
            }
            else
            {
                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    if ((CheckFileType(File1.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                {
                    if ((CheckImgType(File2.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
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
                if (!string.IsNullOrEmpty(File4.PostedFile.FileName))
                {
                    if ((CheckImgType(File4.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(File5.PostedFile.FileName))
                {
                    if ((CheckImgType(File5.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                }

                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor6.ReadOnly = true;
                CKeditor7.ReadOnly = true;

                string var = clsm.MasterSave(this, productid.Parent, 33, mainclass.Mode.modeModify, "ProductsSP", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor6.ReadOnly = false;
                CKeditor7.ReadOnly = false;

                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + prospectus.Text);
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }
                    prospectus.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "pdctfile_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    // prospectus.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + prospectus.Text);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand("update Products set prospectus=@prospectus where productid=" + Convert.ToInt32(var) + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@prospectus", prospectus.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\prospectus\\" + prospectus.Text);
                }

                if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                {
                    UploadAImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "simg_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    // UploadAImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + UploadAImage.Text);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\ProductsImage\\" + UploadAImage.Text);
                    //' update banner file
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand("update Products set uploadaimage=@uploadaimage where productid=" + var + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@uploadaimage", UploadAImage.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();

                }

                if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                {
                    largeimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "limg_" + Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    //largeimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + largeimage.Text);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    //' update banner file
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand("update Products set largeimage=@largeimage where productid=" + var + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@largeimage", largeimage.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File3.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\ProductsImage\\" + largeimage.Text);
                }
                if (!string.IsNullOrEmpty(File4.PostedFile.FileName))
                {
                    producticon.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "simg_" + Path.GetFileName(File4.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));                    
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + producticon.Text);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File4.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\ProductsImage\\" + producticon.Text);
                    //' update banner file
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand("update Products set producticon=@uploadaimage where productid=" + var + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@uploadaimage", producticon.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();

                }
                if (!string.IsNullOrEmpty(File5.PostedFile.FileName))
                {
                    videoimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "simg_" + Path.GetFileName(File5.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + videoimage.Text);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File5.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\ProductsImage\\" + videoimage.Text);
                    //' update banner file
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand("update Products set videoimage=@uploadaimage where productid=" + var + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@uploadaimage", videoimage.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();

                }



                Response.Redirect("viewproduct.aspx?edit=edit");
            }
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(productid.Text) == 0)
        {
            clsm.ClearallPanel(this, productid.Parent);
        }
        else
        {
            Response.Redirect("viewproduct.aspx");
        }
        Response.Redirect("");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(UploadAImage.Text))
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + UploadAImage.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }
        }
        //clsm.ExecuteQry("update Products set prospectus='' where productid=" & Val(Request.QueryString("pid")))
        Parameters.Clear();
        Parameters.Add("@productid", Convert.ToInt32(Request.QueryString["pid"]));
        clsm.SendValue_Parameter("update Products set UploadAImage='' where productid=@productid", Parameters);
        UploadAImage.Text = "";
        Image1.Visible = false;
        trsuccess.Visible = true;
        LinkButton1.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(largeimage.Text))
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + largeimage.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }
        }
        //clsm.ExecuteQry("update Products set prospectus='' where productid=" & Val(Request.QueryString("pid")))
        Parameters.Clear();
        Parameters.Add("@productid", Convert.ToInt32(Request.QueryString["pid"]));
        clsm.SendValue_Parameter("update Products set largeimage='' where productid=@productid", Parameters);
        largeimage.Text = "";
        Image2.Visible = false;
        trsuccess.Visible = true;
        LinkButton2.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(largeimage.Text))
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + producticon.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }
        }
        
        Parameters.Clear();
        Parameters.Add("@productid", Convert.ToInt32(Request.QueryString["pid"]));
        clsm.SendValue_Parameter("update Products set producticon='' where productid=@productid", Parameters);
        producticon.Text = "";
        Image3.Visible = false;
        trsuccess.Visible = true;
        LinkButton3.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(largeimage.Text))
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\ProductsImage\\" + largeimage.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }
        }
        
        Parameters.Clear();
        Parameters.Add("@productid", Convert.ToInt32(Request.QueryString["pid"]));
        clsm.SendValue_Parameter("update Products set videoimage='' where productid=@productid", Parameters);
        videoimage.Text = "";
        Image4.Visible = false;
        trsuccess.Visible = true;
        LinkButton4.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
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
            case ".svg":
                return true;
            case ".webp":
                return true;
            case ".mp3":
                return true;
            case ".mp4":
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
            case ".mp3":
                return true;
            case ".mp4":
                return true;
            default:
                return false;
        }
    }
}
