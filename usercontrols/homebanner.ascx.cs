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


public partial class usercontrols_homebanner : System.Web.UI.UserControl
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext context = HttpContext.Current;
            if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
            {
                System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
                if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice)
                {
                    parameters.Clear();
                    clsm.repeaterDatashow_Parameter(rptbanner, "Select b.bannerimage,b.title,b.tagline1,b.tagline2,b.url,b.displayorder,b.bid,b.bannermobile,b.blogo,btype.btype from homebanner b inner join homebannertype btype on btype.btypeid=b.btypeid where b.status=1 and btype.mobilestatus=1 and b.devicetype='mobile'  and b.collageid=0  order by b.displayorder", parameters);

                }
                else
                {
                    parameters.Clear();
                    clsm.repeaterDatashow_Parameter(rptbanner, "Select b.bannerimage,b.title,b.tagline1,b.tagline2,b.url,b.displayorder,b.bid,b.bannermobile,b.blogo,btype.btype from homebanner b inner join homebannertype btype on btype.btypeid=b.btypeid where b.status=1 and btype.status=1 and b.devicetype='desktop'  and b.collageid=0 order by b.displayorder", parameters);

                }
            }
        }
    }
    protected void rptbanner_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlContainerControl panel1 = (HtmlContainerControl)e.Item.FindControl("panel1");
            Literal litblogo = (Literal)e.Item.FindControl("litblogo");
            HtmlContainerControl panellogo = (HtmlContainerControl)e.Item.FindControl("panellogo");
            Literal litbtype = (Literal)e.Item.FindControl("litbtype");
            HtmlGenericControl divvideo = (HtmlGenericControl)e.Item.FindControl("divvideo");
            if (litbtype.Text == "Banner")
            {
                panel1.Visible = true;
            }
            else if (litbtype.Text == "Video")
            {
                divvideo.Visible = true;
            }

            if (!string.IsNullOrEmpty(litblogo.Text))
            {
                panellogo.Visible = true;
            }
            panel1.Attributes.Add("class", "banner-text r" + (e.Item.ItemIndex + 1));
        }
    }
}