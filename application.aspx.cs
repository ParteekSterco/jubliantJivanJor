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

public partial class application : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {         
            parameters.Clear();
            
            parameters.Add("@pageid", Conversion.Val(Request.QueryString["pgidtrail"]));
            litpagedescription.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select PageDescription from pagemaster where pagestatus=1 and pageid=@pageid", parameters)));

            binddata();
        }
    }
    private void binddata()
    {
        // First Section
        string sql = "select pcatid,brand,detail,shortdetail from brand where status=1 and pcatid=5 ";
        sql += " order by displayorder";
        DataSet ds = clsm.senddataset_Parameter(sql, parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            littltle.Text = Convert.ToString(ds.Tables[0].Rows[0]["brand"]);
            litdetail.Text = Server.HtmlDecode(Convert.ToString(ds.Tables[0].Rows[0]["detail"]));
        }

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptproduct, "select distinct top 1 p.productid,productname,pcatid,psubcatid,producttitle,productdetail,UploadAImage,p.displayorder from products p inner join map_product_application map on map.productid=p.productid where status=1 and map.appid=5 order by p.displayorder", parameters);

        parameters.Clear();
        parameters.Add("@productid", Convert.ToString(ViewState["productid"]));
        clsm.repeaterDatashow_Parameter(rptprod, "select distinct top 2 p.productid,productname,pcatid,psubcatid,producttitle,productdetail,UploadAImage,p.displayorder from products p inner join map_product_application map on map.productid=p.productid where status=1 and map.appid=5 and p.productid<>@productid order by p.displayorder", parameters);

        // End
        // Second Section
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptplywood, "select pcatid,brand,detail,banner from brand where status=1 and pcatid=4 ", parameters);

        parameters.Clear();
        string sql1 = "select pcatid,brand,detail,shortdetail from brand where status=1 and pcatid=3 ";
        sql += " order by displayorder";
        DataSet ds1 = clsm.senddataset_Parameter(sql1, parameters);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            litapptitle.Text = Convert.ToString(ds1.Tables[0].Rows[0]["brand"]);
            litappdetail.Text = Server.HtmlDecode(Convert.ToString(ds1.Tables[0].Rows[0]["detail"]));
        }
        //End

        // Third Section
        parameters.Clear();        
        clsm.repeaterDatashow_Parameter(rptdecorative, "select distinct top 2 p.productid,productname,pcatid,psubcatid,producttitle,productdetail,UploadAImage,p.displayorder from products p inner join map_product_application map on map.productid=p.productid where status=1 and map.appid=3 order by p.displayorder", parameters);

        parameters.Clear();
        string strproductid = Convert.ToString(ViewState["pid"]);
        strproductid = strproductid.ToString().TrimEnd(',');
        parameters.Add("@productid", strproductid);
        clsm.repeaterDatashow_Parameter(rptdecorative2, "select distinct top 2 p.productid,productname,pcatid,psubcatid,producttitle,productdetail,UploadAImage,p.displayorder from products p inner join map_product_application map on map.productid=p.productid where status=1 and map.appid=3 and p.productid not in (" + strproductid + ") order by p.displayorder", parameters);
        // End


        // Fourth Section
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptplytoply, "select pcatid,brand,detail,banner from brand where status=1 and pcatid=2 ", parameters);

        parameters.Clear();
        string sql2 = "select pcatid,brand,detail,shortdetail from brand where status=1 and pcatid=1 ";
        sql2 += " order by displayorder";
        DataSet ds2 = clsm.senddataset_Parameter(sql2, parameters);
        if (ds2.Tables[0].Rows.Count > 0)
        {
            littitle1.Text = Convert.ToString(ds2.Tables[0].Rows[0]["brand"]);
            lidetail1.Text = Server.HtmlDecode(Convert.ToString(ds2.Tables[0].Rows[0]["detail"]));
        }
        //End

        // fifth Section
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptveneers, "select distinct top 2 p.productid,productname,pcatid,psubcatid,producttitle,productdetail,UploadAImage,p.displayorder from products p inner join map_product_application map on map.productid=p.productid where status=1 and map.appid=3 order by p.displayorder", parameters);

        parameters.Clear();
        string strproductid1 = Convert.ToString(ViewState["pid"]);
        strproductid1 = strproductid1.ToString().TrimEnd(',');
        parameters.Add("@productid", strproductid1);
        clsm.repeaterDatashow_Parameter(rptveneers2, "select distinct top 2 p.productid,productname,pcatid,psubcatid,producttitle,productdetail,UploadAImage,p.displayorder from products p inner join map_product_application map on map.productid=p.productid where status=1 and map.appid=3 and p.productid not in (" + strproductid1 + ") order by p.displayorder", parameters);
        // End


        // Six Section
        clsm.repeaterDatashow_Parameter(repapplication, "select distinct top 5 p.productid,p.productname,p.pcatid,p.psubcatid,p.producttitle,p.productdetail,p.UploadAImage,p.displayorder,b.brand,b.detail from products p inner join map_product_application map on map.productid=p.productid inner join brand b on map.appid=b.pcatid  where p.status=1 and map.appid=6 order by p.displayorder", parameters);

        //if (repapplication.Items.Count > 0)
        //{
        //    secapp.Visible = true;
        //}

        //End

        // Six Section
        //parameters.Clear();
        //clsm.repeaterDatashow_Parameter(rptwoodacrylic, "select pcatid,brand,detail,banner from brand where status=1 and pcatid=6 ", parameters);
       
        //parameters.Clear();
        //string sql4 = "select pcatid,brand,detail,shortdetail from brand where status=1 and pcatid=3 ";
        //sql4 += " order by displayorder";
        //DataSet ds4 = clsm.senddataset_Parameter(sql4, parameters);
        //if (ds4.Tables[0].Rows.Count > 0)
        //{
        //    //litapptitleacrylic.Text = Convert.ToString(ds1.Tables[0].Rows[0]["brand"]);
        //    //litappdetailacrylic.Text = Server.HtmlDecode(Convert.ToString(ds1.Tables[0].Rows[0]["detail"]));
        //    sectionacrylic.Visible = true;
        //}

        //else
        //{
        //    sectionacrylic.Visible = false;
        //}


        //End

    }
    protected void rptproduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litproductid = (Literal)e.Item.FindControl("litproductid");
            ViewState["productid"] = litproductid.Text;
        }
    }

    protected void rptplywood_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpcatid = (Literal)e.Item.FindControl("litpcatid");
            Repeater rptinner = (Repeater)e.Item.FindControl("rptinner");

            parameters.Clear();
            parameters.Add("@pcatid",Conversion.Val(litpcatid.Text));
            clsm.repeaterDatashow_Parameter(rptinner, "select distinct top 5 p.productid,productname,pcatid,psubcatid,producttitle,productdetail,UploadAImage,p.displayorder from products p inner join map_product_application map on map.productid=p.productid where status=1 and map.appid=@pcatid order by p.displayorder", parameters);          
        }
    }
    protected void rptdecorative_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litproductid = (Literal)e.Item.FindControl("litproductid");
            ViewState["pid"] += litproductid.Text + ",";
        }
    }
    
    protected void rptplytoply_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpcatid = (Literal)e.Item.FindControl("litpcatid");
            Repeater rptrptplytoplyinner = (Repeater)e.Item.FindControl("rptrptplytoplyinner");

            parameters.Clear();
            parameters.Add("@pcatid", Conversion.Val(litpcatid.Text));
            clsm.repeaterDatashow_Parameter(rptrptplytoplyinner, "select distinct top 2 p.productid,productname,pcatid,psubcatid,producttitle,productdetail,UploadAImage,p.displayorder from products p inner join map_product_application map on map.productid=p.productid where status=1 and map.appid=@pcatid order by p.displayorder", parameters);
        }
    }
    protected void rptveneers_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litproductid = (Literal)e.Item.FindControl("litproductid");
            ViewState["pid"] += litproductid.Text + ",";
        }
    }


    //protected void rptwoodacrylic_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        Literal litpcatid = (Literal)e.Item.FindControl("litpcatid");
    //        Repeater rptwoodinner = (Repeater)e.Item.FindControl("rptwoodinner");
    //        //Literal litapptitleacrylic = (Literal)e.Item.FindControl("litapptitleacrylic");
    //        //Literal litappdetailacrylic = (Literal)e.Item.FindControl("litappdetailacrylic");
         
    //        parameters.Clear();
    //        parameters.Add("@pcatid", Conversion.Val(litpcatid.Text));
    //        clsm.repeaterDatashow_Parameter(rptwoodinner, "select distinct top 5 p.productid,productname,pcatid,psubcatid,producttitle,productdetail,UploadAImage,p.displayorder from products p inner join map_product_application map on map.productid=p.productid where status=1 and map.appid=@pcatid order by p.displayorder", parameters);

               
    //    }
    //}


    protected void repapplication_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litbrand = (Literal)e.Item.FindControl("litbrand");
            Literal litdetail = (Literal)e.Item.FindControl("litdetail");

            littopbrand.Text = litbrand.Text;
            littopdetail.Text = Server.HtmlDecode(litdetail.Text);

           
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        HtmlContainerControl panelbreadcrumb = (HtmlContainerControl)Master.FindControl("panelbreadcrumb");

        if (Conversion.Val(Request.QueryString["pgidtrail"]) == 6)
        {
            panelbreadcrumb.Visible = false;

        }
    }
}