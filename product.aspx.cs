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

public partial class product : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["pid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@pid", Conversion.Val(Request.QueryString["pid"]));
                littechnical.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select productdetail from products where status=1 and productid=@pid order by displayorder", parameters)));

                litpacksize.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select producttitle from products where status=1 and productid=@pid order by displayorder", parameters)));

                litfeature.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select longdesc from products where status=1 and productid=@pid order by displayorder", parameters)));


                binddata();
                //***********************                   
                parameters.Clear();
                parameters.Add("@pid", Conversion.Val(Request.QueryString["pid"]));
                parameters.Add("@pcatid", Conversion.Val(Request.QueryString["pcatid"]));
                litdetail.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select appdetail from products where status=1 and productid=@pid order by displayorder", parameters)));


                if (!string.IsNullOrEmpty(litdetail.Text))
                {
                    panelapplication.Visible = true;
                    rptapplication.Visible = false;
                }
                else
                {
                    paneltestimonial.Attributes.Add("class", "testimonials rounder_testimonial bg-white bg-color");
                }
                //**************************************


            }
        }
    }
    private void binddata()
    {
        parameters.Clear();
        parameters.Add("@productid", Conversion.Val(Request.QueryString["pid"]));      
        clsm.repeaterDatashow_Parameter(rptapplication, "select p.appdetail,  p.productid,p.productname,b.brand,p.displayorder,b.banner,b.youtubeurl,b.homeimage,p.pcatid,p.purl,mapnew.appid from products p inner join map_product_application_new mapnew on mapnew.productid=p.productid left join brand b on b.pcatid=mapnew.appid where p.status=1 and p.productid=@productid order by p.displayorder", parameters);

      
        if (rptapplication.Items.Count > 0)
        {
            panelapplication.Visible = true;

        }

        parameters.Clear();
        parameters.Add("@productid", Conversion.Val(Request.QueryString["pid"]));
        clsm.repeaterDatashow_Parameter(rpttestimonials, "select distinct top 5 p.productid,p.displayorder,t.testimonialname,t.uploadphoto,t.desg,t.testimonialdesc from products p inner join map_product_testimonials map on map.productid=p.productid inner join testimonials t on t.testimonialid=map.testimonialid where p.status=1 and p.productid=@productid and t.status=1 order by p.displayorder", parameters);
        if (rpttestimonials.Items.Count > 0)
        {
            paneltestimonial.Visible = true;
        }
        parameters.Clear();
        parameters.Add("@productid", Conversion.Val(Request.QueryString["pid"]));
        clsm.repeaterDatashow_Parameter(rptbanner, "select productid,mapid,bid,shortdetail,smallimage,rewriteurl  from map_product where productid=@productid and status=1", parameters);
        if (rptbanner.Items.Count > 0)
        {
            panelbanner.Visible = true;
        }
    }
    protected void rptbanner_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litproductid = (Literal)e.Item.FindControl("litproductid");
            panelbanner.Attributes.Add("class", "rounder_banner r" + Conversion.Val(litproductid.Text));

        }
    }

    protected void rptapplication_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlContainerControl panel1 = (HtmlContainerControl)e.Item.FindControl("panel1");
            Literal litproductid = (Literal)e.Item.FindControl("litproductid");
            Literal lityoutubeurl = (Literal)e.Item.FindControl("lityoutubeurl");
            HtmlGenericControl divvideo = (HtmlGenericControl)e.Item.FindControl("divvideo");

            Literal litbanner = (Literal)e.Item.FindControl("litbanner");
            Literal litbannerspec = (Literal)e.Item.FindControl("litbannerspec");
            HtmlImage imgbanner = (HtmlImage)e.Item.FindControl("imgbanner");
            HtmlImage img1 = (HtmlImage)e.Item.FindControl("img1");
            //Literal litdetail = (Literal)e.Item.FindControl("litdetail");

            if (!string.IsNullOrEmpty(lityoutubeurl.Text))
            {
                divvideo.Visible = true;
                img1.Src = "/uploads/ProductsImage/" + litbanner.Text;
            }
            else
            {

                imgbanner.Src = "/uploads/ProductsImage/" + litbanner.Text;
                panel1.Visible = true;
            }

            if (Conversion.Val(litproductid.Text) == 26)
            {
                //divvideo.Visible = false;
                //panel1.Visible = false;

            }

        }
    }


}