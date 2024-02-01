﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;

public partial class backoffice_masters_viewcoursetype : System.Web.UI.Page
{
    mainclass Clsm = new mainclass();
    Hashtable Parameters = new Hashtable();


    protected void Page_Load(object sender, System.EventArgs e)
    {
        trsuccess.Visible = false;
        trnotice.Visible = false;
        trerror.Visible = false;
        if ((Page.IsPostBack == false))
        {
            gridshow();
        }
        if ((Request.QueryString["edit"] == "edit"))
        {
            trsuccess.Visible = true;
            lblsuccess.Text = "Record updated successfully..";
        }
    }
    protected void gridshow()
    {
        Parameters.Clear();
        Clsm.GridviewData_Parameter(GridView1, "select * from coursetype order by displayorder", Parameters);
        if ((GridView1.Rows.Count == 0))
        {
            trnotice.Visible = true;
            lblnotice.Text = "Course Type (s) not found.";
        }

    }
    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");

            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");

            if (txtstatus.Text == "True")
            {
                lnkstatus.ImageUrl = "../assets/ico_unblock.png";
                lnkstatus.ToolTip = "Active";
            }
            else if (txtstatus.Text == "False")
            {
                lnkstatus.ImageUrl = "../assets/ico_block.png";
                lnkstatus.ToolTip = "Inactive";
            }

            e.Row.Attributes.Add("onmouseover", ("this.style.backgroundColor=\'"
                            + (Server.HtmlDecode(Convert.ToString(Session["altColor"])) + "\'")));
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#FFFFFF\'");
        }

        // If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Or e.Row.RowType = DataControlRowType.Footer Then
        //     e.Row.Cells(3).Visible = False
        // End If
    }

    protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if ((e.CommandName == "redit"))
        {
            Response.Redirect(("addcoursetype.aspx?ctid=" + Conversion.Val(e.CommandArgument)));

        }

        if ((e.CommandName == "lnkstatus"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            if ((txtstatus.Text == "False"))
            {
                Parameters.Clear();
                Parameters.Add("@ctid", Conversion.Val(e.CommandArgument));
                Clsm.ExecuteQry_Parameter("update coursetype set status=1 where ctid=@ctid", Parameters);
            }
            else if ((txtstatus.Text == "True"))
            {
                Parameters.Clear();
                Parameters.Add("@ctid", Conversion.Val(e.CommandArgument));
                Clsm.ExecuteQry_Parameter("update coursetype set status=0 where ctid=@ctid", Parameters);
            }

            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
            gridshow();
        }

    }

    protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            gridshow();
        }
        catch (Exception ex)
        {
        }

    }
}