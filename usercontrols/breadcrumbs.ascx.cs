using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class usercontrols_breadcrumbs : System.Web.UI.UserControl
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    string str = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["mpgid"] != null)
            {
                bindbredcrumb();
                //if (Conversion.Val(Request.QueryString["pcatid"]) > 0)
                if (Conversion.Val(Request.QueryString["pid"]) > 0)
                {
                    //parameters.Clear();
                    //parameters.Add("@pcatid", Conversion.Val(Request.QueryString["pcatid"]));
                    //lblcoursename.Text = Convert.ToString(clsm.SendValue_Parameter("select category from productcate where pcatid=@pcatid and status=1", parameters));
                    parameters.Clear();
                    parameters.Add("@pid", Conversion.Val(Request.QueryString["pid"]));
                    lblcoursename.Text = Convert.ToString(clsm.SendValue_Parameter("select (productname) from Products where productid=@pid and status=1", parameters));
                }              
            }
        }
    }
    private void bindbredcrumb()
    {

        if (Conversion.Val(Request.QueryString["mpgid"]) != 0)
        {
            parameters.Clear();
            parameters.Add("@Pageid", Conversion.Val(Request.QueryString["pgidtrail"]));
            parameters.Add("@pgidtrail", Conversion.Val(Request.QueryString["pgidtrail"]));

        }
        if (Conversion.Val(Request.QueryString["pgid0"]) != 0)
        {
            parameters.Clear();
            parameters.Add("@PageId", Conversion.Val(Request.QueryString["pgid0"]));
            DataSet ds = clsm.senddataset_Parameter("select * from PageMaster where PageStatus=1 and PageId=@PageId", parameters);
            parameters.Clear();
            if (ds.Tables[0].Rows.Count == 1)
            {
                int i = Convert.ToInt32(ds.Tables[0].Rows[0]["ParentId"]);
                if (i != 0)
                {
                    parameters.Add("@PageId", Conversion.Val(Request.QueryString["pgid0"]));
                    int ix = Convert.ToInt32(clsm.SendValue_Parameter("select ParentId from PageMaster where PageStatus=1 and PageId=@PageId", parameters));
                    parameters.Clear();
                    Populate(ix);
                    string pageids = ArrangeStr();
                    clsm.repeaterDatashow(rptBread, "select PageId, PageName, PageUrl,rewriteurl from PageMaster where PageId in (" + pageids + ")", false);
                    parameters.Clear();
                    parameters.Add("@Pageid", Conversion.Val(Request.QueryString["pgid0"]));
                    lblcoursename.Text = clsm.SendValue_Parameter("Select PageName from PageMaster Where Pageid=@Pageid", parameters).ToString();
                    parameters.Clear();
                }
                else
                {
                    parameters.Clear();
                    parameters.Add("@PageId", Conversion.Val(Request.QueryString["pgid0"]));
                    //clsm.repeaterDatashow(rptBread, "select PageId, PageName, PageUrl,rewriteurl from PageMaster where PageId=" & Val(Request.QueryString("pgid0")))
                }
            }
        }
        else if (Conversion.Val(Request.QueryString["pgidtrail"]) != 0)
        {
            parameters.Clear();
            parameters.Add("@PageId", Conversion.Val(Request.QueryString["pgidtrail"]));
            DataSet ds = clsm.senddataset_Parameter("select * from PageMaster where PageStatus=1 and PageId=@PageId", parameters);
            
            if (ds.Tables[0].Rows.Count == 1)
            {
                int i = Convert.ToInt32(ds.Tables[0].Rows[0]["ParentId"]);
                if (i != 0)
                {            
                    parameters.Clear();
                    parameters.Add("@Pageid", Conversion.Val(Request.QueryString["pgidtrail"]));
                    int ix = Convert.ToInt32(clsm.SendValue_Parameter("select ParentId from PageMaster where PageStatus=1 and PageId=@Pageid", parameters));
                    parameters.Clear();

                    Populate(ix);
                    string pageids = ArrangeStr();
                    clsm.repeaterDatashow(rptBread, "select PageId, PageName, PageUrl,rewriteurl from PageMaster where PageId in (" + pageids + ")", false);
                }
                else
                {
                    parameters.Clear();
                    parameters.Add("@PageId", Conversion.Val(Request.QueryString["pgidtrail"]));                    
                }
                if (Conversion.Val(Request.QueryString["mpgid"]) != Conversion.Val(Request.QueryString["pgidtrail"]))
                {                    
                    parameters.Clear();
                    parameters.Add("@Pageid", Conversion.Val(Request.QueryString["pgidtrail"]));
                    lblcoursename.Text = clsm.SendValue_Parameter("Select PageName from PageMaster Where Pageid=@Pageid", parameters).ToString();
                    parameters.Clear();
                }
                else
                {
                    parameters.Clear();
                    parameters.Add("@Pageid", Conversion.Val(Request.QueryString["pgidtrail"]));
                    lblcoursename.Text = clsm.SendValue_Parameter("Select PageName from PageMaster Where Pageid=@Pageid", parameters).ToString();
                    parameters.Clear();
                }
            }
        }
    }

    protected void Populate(int pid)
    {
        Hashtable parameters = new Hashtable();
        parameters.Add("@pid", Conversion.Val(pid));
        int i = Convert.ToInt32(clsm.SendValue_Parameter("select ParentId from PageMaster where PageStatus=1 and PageId=@pid", parameters));
        parameters.Clear();

        if (i >= 0)
        {
            str += pid.ToString() + ",";
            if (i != 0)
            {
                Populate(i);
            }
        }
    }
    protected string ArrangeStr()
    {
        str = str.TrimEnd(',');
        Array arr = str.Split(',');
        string ids = string.Empty;
        for (int x = arr.Length - 1; x >= 0; x += -1)
        {
            ids += arr.GetValue(x) + ",";
        }
        ids = ids.TrimEnd(',');
        return ids;
    }
    protected void rptBread_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lblpageurl = e.Item.FindControl("lblpageurl") as Label;
            Label lblrewrite = e.Item.FindControl("lblrewrite") as Label;
            HtmlAnchor ancher = (HtmlAnchor)e.Item.FindControl("ancher");

            if (lblpageurl.Text.Contains("http:") == true || lblpageurl.Text.Contains("https:") == true)
            {
                ancher.HRef = lblpageurl.Text;
                ancher.Target = "_blank";
            }
            else
            {
                if (lblrewrite.Text.Trim() != "")
                {
                    ancher.HRef = "~/" + lblrewrite.Text.Trim();
                }
                else
                {
                    ancher.HRef = "~/" + lblpageurl.Text;
                }
            }

        }
    }
 


}