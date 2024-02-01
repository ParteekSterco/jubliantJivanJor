using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections;

public partial class backoffice_Products_mapproductapplication : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!IsPostBack)
        {
            Filltestimonials();
            Fill_alldata();
        }
    }
    private void Filltestimonials()
    {
        Parameters.Clear();
        string stralbum = "select * from brand WHERE status=1 order by DisplayOrder   ";
        DataSet ds = clsm.senddataset_Parameter(stralbum, Parameters);
        collegelist.DataSource = ds.Tables[0];
        collegelist.DataBind();
        if (collegelist.Items.Count > 0)
        {
            Button1.Visible = true;
        }
        else
        {
            Button1.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (DataListItem item in collegelist.Items)
        {
            Parameters.Clear();
            Label lblcampusid = item.FindControl("lblcampusid") as Label;
            TextBox lblcampusname = item.FindControl("lblcampusname") as TextBox;
            CheckBox checkfeature = item.FindControl("checkfeature") as CheckBox;
            if (checkfeature.Checked == true)
            {
                if (clsm.Checking("select * from map_product_application_new  where productid='" + Conversion.Val(Request.QueryString["productid"]) + "' and appid= '" + Conversion.Val(lblcampusid.Text) + "' ") == false)
                {
                    if (clsm.Checking("select mapid from map_product_application_new where appid='"
                                    + (Conversion.Val(lblcampusid.Text) + "' and productid='"
                                    + (Conversion.Val(Request.QueryString["productid"])) + "'")) == false)
                    {
                        clsm.ExecuteQry("insert into map_product_application_new (productid,appid)values("
                                      + (Request.QueryString["productid"]) + ","
                                      + (Conversion.Val(lblcampusid.Text) + ")"));
                    }
                }
            }
            else
            {
                clsm.ExecuteQry("delete from map_product_application_new where appid="
                                + (Conversion.Val(lblcampusid.Text) + " and productid="
                                + (Conversion.Val(Request.QueryString["productid"]) + "  ")));
            }
            trsuccess.Visible = true;
            lblsuccess.Text = "Application Map Successfully.";
        }
        Filltestimonials();
        Fill_alldata();
    }
    private void Fill_alldata()
    {
        Parameters.Clear();
        Parameters.Add("@productid", Conversion.Val(Request.QueryString["productid"]));
        string strquery = "select * from map_product_application_new where productid=@productid";
        DataSet ds = clsm.senddataset_Parameter(strquery, Parameters);
        if ((ds.Tables[0].Rows.Count > 0))
        {
            foreach (DataListItem li in collegelist.Items)
            {
                CheckBox checkfeature = (CheckBox)li.FindControl("checkfeature");
                Label lblcampusname = (Label)li.FindControl("lblcampusname");
                Label lblcampusid = (Label)li.FindControl("lblcampusid");
                for (int index = 0; index <= ds.Tables[0].Rows.Count - 1; index++)
                {
                    if (Conversion.Val(ds.Tables[0].Rows[index]["appid"]) == Conversion.Val(lblcampusid.Text))
                    {
                        checkfeature.Checked = true;
                        lblcampusname.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
        }
    }
}