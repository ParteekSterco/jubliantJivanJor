using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class gallery_detail : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["albumid"]) > 0)
            {               
                parameters.Clear();
                parameters.Add("@albumid", Conversion.Val(Request.QueryString["albumid"]));
                clsm.repeaterDatashow_Parameter(rptalbum, "select a.albumtitle,a.albumid,photoid,Uploadphoto,phototitle from Albumphoto ap inner join album a on a.Albumid=ap.albumid where a.status=1 and ap.status=1 and ap.albumid=@albumid order by ap.displayorder", parameters);            
            }
        }

    }
}