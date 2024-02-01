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
using System.ComponentModel.Design;

public partial class index : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    double strcounting = 275;
    double strlist = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(12));
            litsmalldesc.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pagestatus=1 and pageid=@pageid", parameters)));

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(1));
            //litshortdesc.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pagestatus=1 and pageid=@pageid", parameters)));

            clsm.repeaterDatashow_Parameter(rpthappleft, "select top 3 eventsid,ntypeid,eventstitle,tagline,eventsdate,rewriteurl,largeimage,uploadevents from events where status=1 and showonhome=1 order by eventsdate desc,displayorder", parameters);

            parameters.Clear();
            string streventsid = Convert.ToString(ViewState["eventsid"]);
            streventsid = streventsid.TrimEnd(',');
            if (!string.IsNullOrEmpty(streventsid))
            {
                clsm.repeaterDatashow_Parameter(rpthapplemiddle, "select top 3 eventsid,ntypeid,eventstitle,tagline,eventsdate,rewriteurl,largeimage,uploadevents from events where status=1 and showonhome=1 and eventsid not in (" + streventsid + ") order by eventsdate desc, displayorder ", parameters);
            }
            parameters.Clear();
            streventsid = Convert.ToString(ViewState["eventsid"]);
            streventsid = streventsid.TrimEnd(',');
            if (!string.IsNullOrEmpty(streventsid))
            {
                clsm.repeaterDatashow_Parameter(rpthappright, "select top 3 eventsid,ntypeid,eventstitle,tagline,eventsdate,rewriteurl,largeimage,uploadevents from events where status=1 and showonhome=1 and eventsid not in (" + streventsid + ") order by eventsdate desc, displayorder ", parameters);
            }

            Binddata();

            Label1.Text = Convert.ToString(clsm.SendValue_Parameter("select counterlist from counter_list where status=1", parameters));

        }
    }
    private void Binddata()
    {
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptproductimage, "select p.productid,productname,pcatid,p.largeimage,p.producticon,p.shortdetail,p.modelno from products p  where p.status=1 and p.showonhome=1  order by p.displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptapplication, "select distinct  p.productname,p.displayorder,b.banner,p.purl,p.videoimage,p.appvideodetail from products p inner join map_product_application_new mapnew on mapnew.productid=p.productid left join brand b on b.pcatid=mapnew.appid where p.status=1 and p.showongroup=1 and isnull(b.youtubeurl,'')<>'' order by p.displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rpttestimonials, "select testimonialid,Testimonialname,testimonialdesc,desg,Uploadphoto,uploadvedio from testimonials where status=1 and showonhome=1 order by displayorder", parameters);
    }

    protected void rptproductimage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpcatid = (Literal)e.Item.FindControl("litpcatid");
            Literal litproductid = (Literal)e.Item.FindControl("litproductid");
            Literal litpanelimage1 = (Literal)e.Item.FindControl("litpanelimage1");
            Literal litpanelimage2 = (Literal)e.Item.FindControl("litpanelimage2");
            HtmlContainerControl panelimage1 = (HtmlContainerControl)e.Item.FindControl("panelimage1");
            HtmlContainerControl panelimage2 = (HtmlContainerControl)e.Item.FindControl("panelimage2");
            //HtmlContainerControl panelbanner = (HtmlContainerControl)e.Item.FindControl("panelbanner");

            if (!string.IsNullOrEmpty(litpanelimage1.Text))
            {
                panelimage1.Visible = true;
            }
            if (!string.IsNullOrEmpty(litpanelimage2.Text))
            {
                panelimage2.Visible = true;
            }
            //panelbanner.Attributes.Add("class", "slider-box r" + Conversion.Val(litproductid.Text));
        }
    }


    protected void rpthappleft_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlContainerControl panel1 = (HtmlContainerControl)e.Item.FindControl("panel1");
            HtmlContainerControl panel2 = (HtmlContainerControl)e.Item.FindControl("panel2");
            Label lblevents = (Label)e.Item.FindControl("lblevents");
            //HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            ViewState["eventsid"] += lblevents.Text + ",";
            if (e.Item.ItemIndex % 3 == 0)
            {
                if (!String.IsNullOrEmpty(Convert.ToString((e.Item.DataItem as DataRowView).Row["uploadevents"])))
                {
                    panel1.Attributes.Add("class", "col-md-12");
                    panel2.InnerHtml = "";
                    panel2.Visible = false;
                    //panel3.Visible = true;

                }
                else
                {
                    panel2.Attributes.Add("class", "col-md-12");
                    panel1.InnerHtml = "";
                    panel1.Visible = false;
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(Convert.ToString((e.Item.DataItem as DataRowView).Row["uploadevents"])))
                {
                    panel1.Attributes.Add("class", "col-md-6");
                    panel2.InnerHtml = "";
                    panel2.Visible = false;
                }
                else
                {
                    panel2.Attributes.Add("class", "col-md-6");
                    panel1.InnerHtml = "";
                    panel1.Visible = false;
                }
            }

        }
    }

    protected void rpthappmiddle_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlContainerControl panel1 = (HtmlContainerControl)e.Item.FindControl("panel1");
            HtmlContainerControl panel2 = (HtmlContainerControl)e.Item.FindControl("panel2");
            Label lblevents = (Label)e.Item.FindControl("lblevents");
            ViewState["eventsid"] += lblevents.Text + ",";
            if (e.Item.ItemIndex % 3 == 2)
            {
                if (!String.IsNullOrEmpty(Convert.ToString((e.Item.DataItem as DataRowView).Row["uploadevents"])))
                {
                    panel1.Attributes.Add("class", "col-md-12");
                    panel2.InnerHtml = "";
                    panel2.Visible = false;
                }
                else
                {
                    panel2.Attributes.Add("class", "col-md-12");
                    panel1.InnerHtml = "";
                    panel1.Visible = false;
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(Convert.ToString((e.Item.DataItem as DataRowView).Row["uploadevents"])))
                {
                    panel1.Attributes.Add("class", "col-md-6");
                    panel2.InnerHtml = "";
                    panel2.Visible = false;
                }
                else
                {
                    panel2.Attributes.Add("class", "col-md-6");
                    panel1.InnerHtml = "";
                    panel1.Visible = false;
                }
            }
        }
    }

    protected void rpthappright_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlContainerControl panel1 = (HtmlContainerControl)e.Item.FindControl("panel1");
            HtmlContainerControl panel2 = (HtmlContainerControl)e.Item.FindControl("panel2");

            if (!String.IsNullOrEmpty(Convert.ToString((e.Item.DataItem as DataRowView).Row["uploadevents"])))
            {
                panel2.InnerHtml = "";
                panel2.Visible = false;
            }
            else
            {
                panel1.InnerHtml = "";
                panel1.Visible = false;
            }
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //if (Timer1.Enabled)
        //{
        //    double str = Convert.ToDouble(clsm.SendValue_Parameter("select counterlist from counter_list where status=1", parameters));
        //    string countername = Convert.ToString(str + 1);
        //    clsm.ExecuteQry("update counter_list set counterlist='" + countername + "' where counterid=1");
        //    Label1.Text = Convert.ToString(clsm.SendValue_Parameter("select counterlist from counter_list where status=1",parameters));

        //}
    }


}