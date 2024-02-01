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

public partial class branddetails : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            parameters.Clear();
            parameters.Add("@pcatid", Conversion.Val(Request.QueryString["pcatid"]));
            litpagedescription.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select detail from brand where status=1 and pcatid=@pcatid order by displayorder", parameters)));
        }

    }
 
}