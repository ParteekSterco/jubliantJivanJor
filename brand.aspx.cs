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

public partial class brand : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptbrand, "select distinct p.* from products p inner join productcate pcate on pcate.pcatid=p.pcatid where p.status=1 order by p.displayorder", parameters);

            
        }
    }


    protected void rptbrand_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpcatid = (Literal)e.Item.FindControl("litpcatid");
            Literal litcatid = (Literal)e.Item.FindControl("litcatid");
           
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            HtmlContainerControl panel1 = (HtmlContainerControl)e.Item.FindControl("panel1");
      
            panel1.Attributes.Add("class", "all " + Conversion.Val(litpcatid.Text));
            ank.HRef = "/testimonial-detailt.aspx?mpgid=36&pgidtrail=36&pcatid=" + Conversion.Val(litpcatid.Text);
        }
    }


}