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
using System.ComponentModel.Design;

public partial class gallery : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptgallerytype, "select atype.* from album a inner join albumtype atype on atype.typeid=a.typeid", parameters);

            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptgallerymain, "select atype.* from album a inner join albumtype atype on atype.typeid=a.typeid", parameters);

            //parameters.Clear();
            //clsm.repeaterDatashow_Parameter(rptvedio, "select vedioid,vediotitle,Albumid,uploadvedio,thumbnailimage from vedio where  status=1 order by displayorder ", parameters);
        }
    }
    protected void rptgallerytype_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal littypeid = (Literal)e.Item.FindControl("littypeid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            HtmlContainerControl i1 = (HtmlContainerControl)e.Item.FindControl("i1");
            if (littypeid.Text == "1")
            {
                i1.Attributes.Add("class", "fa fa-picture-o");
            }
            else
            {
                i1.Attributes.Add("class", "fa fa-video-camera");
            }
            ank.Attributes.Add("data-bs-target", ".ex2-tabs-" + (e.Item.ItemIndex + 1));
        }
    }
    protected void rptgallerymain_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal littypeid = (Literal)e.Item.FindControl("littypeid");
            HtmlContainerControl panel1 = (HtmlContainerControl)e.Item.FindControl("panel1");
            HtmlContainerControl panelphoto = (HtmlContainerControl)e.Item.FindControl("panelphoto");
            HtmlContainerControl panelvedio = (HtmlContainerControl)e.Item.FindControl("panelvedio");

            Repeater rptalbum = (Repeater)e.Item.FindControl("rptalbum");
            Repeater rptvedio = (Repeater)e.Item.FindControl("rptvedio");

            if (e.Item.ItemIndex == 0)
            {
                panel1.Attributes.Add("class", "tab-pane fade show active ex2-tabs-" + (e.Item.ItemIndex + 1));
                panelphoto.Visible = true;
            }
            else
            {
                panel1.Attributes.Add("class", "tab-pane fade ex2-tabs-" + (e.Item.ItemIndex + 1));
                panelvedio.Visible = true;
            }
            parameters.Clear();
            parameters.Add("@typeid", Conversion.Val(littypeid.Text));
            clsm.repeaterDatashow_Parameter(rptalbum, "select a.*,atype.typename from album a inner join albumtype atype on atype.typeid=a.typeid where a.status=1 and a.typeid=@typeid order by a.displayorder", parameters);


            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptvedio, "select v.vedioid,v.vediotitle,v.Albumid,v.uploadvedio,v.thumbnailimage from vedio v inner join album a on a.albumid=v.albumid where  v.status=1 and a.status=1 order by v.displayorder ", parameters);
        }
    }
    protected void rptalbum_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal littypeid = (Literal)e.Item.FindControl("littypeid");
            Literal litalbumid = (Literal)e.Item.FindControl("litalbumid");
            Literal lblcount = (Literal)e.Item.FindControl("lblcount");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");


            if (Conversion.Val(littypeid.Text) == 1)
            {
                parameters.Clear();
                parameters.Add("@albumid", Conversion.Val(litalbumid.Text));
                lblcount.Text = Convert.ToString(clsm.SendValue_Parameter("select count(*) as cnt from albumphoto where albumid=@albumid", parameters));
                ank.HRef = "/gallery-detail.aspx?mpgid=8&pgidtrail=8&albumid=" + Conversion.Val(litalbumid.Text);
            }            

        }
    }
    protected void rptvedio_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litvedioid = (Literal)e.Item.FindControl("litvedioid");
            Literal litalbumid = (Literal)e.Item.FindControl("litalbumid");
            //HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal lblcount = (Literal)e.Item.FindControl("lblcount");         

          //  ank.HRef = "javascript:void(0)";
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        HtmlContainerControl panelbreadcrumb = (HtmlContainerControl)Master.FindControl("panelbreadcrumb");

        if (Conversion.Val(Request.QueryString["pgidtrail"]) == 8)
        {
            panelbreadcrumb.Visible = false;

        }
    }
}