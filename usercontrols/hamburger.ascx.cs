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

public partial class usercontrols_hamburger : System.Web.UI.UserControl
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rpthamburger, "select * from pagemaster where pagestatus=1 and Parentid=0 and  linkposition like'%Hamburger menu%'  and collageid=0 order by displayorder", parameters);
        }
    }
    protected void rpthamburger_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Literal litdynamicrewrite = (Literal)e.Item.FindControl("litdynamicrewrite");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
        

            if (litpageurl.Text.Contains("http") == true || litpageurl.Text.Contains("https") == true)
            {
                ank.HRef = litpageurl.Text;
                ank.Target = "_blank";
            }
            else
            {
                if (!string.IsNullOrEmpty(litrewriteurl.Text))
                {
                    ank.HRef = "~/" + litrewriteurl.Text.Trim();
                }
                else if (!string.IsNullOrEmpty(litdynamicrewrite.Text))
                {
                    ank.HRef = "~" + litdynamicrewrite.Text.Trim();
                }
                else
                {
                    ank.HRef = "~/" + litpageurl.Text;
                }
            }
        }
    }
}