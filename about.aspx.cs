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

public partial class about : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(12));
            litpagedes.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select PageDescription from pagemaster where pagestatus=1 and pageid=@pageid", parameters)));

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(12));
            clsm.repeaterDatashow_Parameter(rptaboutbanner, "select UploadBanner from pagemaster where pagestatus=1 and pageid=@pageid", parameters);


        }

    }

}