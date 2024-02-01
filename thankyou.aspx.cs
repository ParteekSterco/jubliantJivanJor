using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class thankyou : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["msg"] == "Sub")
            {
                lblsuccess.Text = "Thank you ! You have successfully subscribed for Us.";
            }
            if (Request.QueryString["msg"] == "order")
            {
                lblsuccess1.Text = "Thank you !";
                lblsuccess.Text = "Your Enquiry has been successfully submitted. <br>Our representative will contact you soon.<br><br>";

            }
            if (Request.QueryString["msg"] == "thankyou")
            {
                lblsuccess1.Text = "Thank you !";
                lblsuccess.Text = "Your Enquiry has been successfully submitted. <br>Our representative will contact you soon.<br><br>";
            }

            if (Request.QueryString["msg"] == "helpdesk")
            {
                lblsuccess1.Text = "Thank you !";
                lblsuccess.Text = "Your Enquiry has been successfully submitted. <br>Our representative will contact you soon.<br><br>";
            }
            if (Request.QueryString["msg"] == "apply")
            {
                lblsuccess1.Text = "Thank you !";
                lblsuccess.Text = "Your Enquiry has been successfully submitted. <br>Our representative will contact you soon.<br><br>";
            }
            if (Request.QueryString["msg"] == "campusvisit")
            {
                lblsuccess1.Text = "Thank you !";
                lblsuccess.Text = "Your Enquiry has been successfully submitted. <br>Our representative will contact you soon.<br><br>";
            }
            if (Request.QueryString["msg"] == "job")
            {
                lblsuccess.Text = "Thank you ! Your Application has been successfully submitted. <br>Our representative will contact you soon.<br><br>";
            }
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        HtmlContainerControl panelbreadcrumb = (HtmlContainerControl)Master.FindControl("panelbreadcrumb");
        panelbreadcrumb.Visible = false;
    }
}