﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;

public partial class testimonials : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    private void BindData()
    {        
        parameters.Clear();
        parameters.Add("@tesid", Conversion.Val(Request.QueryString["tesid"]));
        clsm.repeaterDatashow_Parameter(rpttestimonials, "select tesid,testimonialname,testimonialdesc,desg,Uploadphoto,uploadvedio,testimonialid from testimonials where status=1 order by displayorder", parameters);
     
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        HtmlContainerControl panelbreadcrumb = (HtmlContainerControl)Master.FindControl("panelbreadcrumb");

        if (Conversion.Val(Request.QueryString["pgidtrail"]) == 9)
        {
            panelbreadcrumb.Visible = false;

        }
    }
}