using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class category : System.Web.UI.Page
{
    public mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["pgidtrail"]) != 0)
            {
                ShowData();
            }
        }
    }
    private void ShowData()
    {
        DataSet ds1 = new DataSet();
        parameters.Clear();
        parameters.Add("@Pageid", Conversion.Val(Request.QueryString["pcatid"]));
        ds1 = clsm.senddataset_Parameter("select detail from productcate where status=1 and pcatid=@Pageid order by displayorder", parameters);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            litcategory.Text = Server.HtmlDecode(ds1.Tables[0].Rows[0]["detail"].ToString());

        }


    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        HtmlContainerControl panelbreadcrumb = (HtmlContainerControl)Master.FindControl("panelbreadcrumb");
        panelbreadcrumb.Visible = false;
    }
}