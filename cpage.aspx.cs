using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Web.UI.HtmlControls;

public partial class cpage : System.Web.UI.Page
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
        parameters.Add("@Pageid", Conversion.Val(Request.QueryString["pgidtrail"]));
        ds1 = clsm.senddataset_Parameter("select PageDescription from PageMaster where pagestatus=1 and Pageid=@Pageid order by displayorder", parameters);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            litdesc.Text = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageDescription"].ToString());
          
        }


    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        HtmlContainerControl panelbreadcrumb = (HtmlContainerControl)Master.FindControl("panelbreadcrumb");


        if (Conversion.Val(Request.QueryString["pgidtrail"]) == 7 )
        {
            panelbreadcrumb.Visible = false;
        }

        else if (Conversion.Val(Request.QueryString["pgidtrail"]) == 31)
        {
            panelbreadcrumb.Visible = false;
        }

        else if (Conversion.Val(Request.QueryString["pgidtrail"]) == 48)
        {
            panelbreadcrumb.Visible = false;
        }

        else if (Conversion.Val(Request.QueryString["pgidtrail"]) == 47)
        {
            panelbreadcrumb.Visible = false;
        }
        else if (Conversion.Val(Request.QueryString["pgidtrail"]) == 26)
        {
            panelbreadcrumb.Visible = false;
        }
        
    }
    
}