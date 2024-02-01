<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



<div class="breadcrumb">
	<div class="container-lg">
        <nav aria-label="breadcrumb next_arrow">
            <ol class="breadcrumb pt-0 justify-content-center pb-1">
              <li class="breadcrumb-item"><a href="/">Home</a></li>
              <li class="breadcrumb-item active" aria-current="page">Contact Us</li>
            </ol>
          </nav>
        
		<h1 class="text-center">
			Contact Us</h1>
		</div>
</div>
    <section class="contact-us">
        <div class="container-lg">
            <div class="row">
                <asp:Literal ID="litcontact" runat="server"></asp:Literal>
                <div class="col-lg-5 col-md-12">
                    <div class="form-wrapper">
                        <h4>WRITE TO US</h4>

                        <div class="form-group">
                            <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Your Name" required=""></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname"
                                Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server"
                                Enabled="true" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight1"
                                CssClass="BlockPopup" />
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtemail" runat="server" class="form-control" placeholder="Email*"
                                autocomplete="none"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemail"
                                Font-Size="Smaller" Display="None" ErrorMessage="Enter E-mail ID" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Enter Valid E-mail ID"
                                ControlToValidate="txtemail" ValidationGroup="validcontact" Display="None" Font-Size="Smaller"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                Enabled="true" TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight1"
                                CssClass="BlockPopup" />
                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server"
                                Enabled="true" TargetControlID="RegularExpressionValidator5" HighlightCssClass="validatorCalloutHighlight1"
                                CssClass="BlockPopup" />
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtsubject" runat="server" class="form-control" placeholder="Subject"
                                autocomplete="none" required=""></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsubject"
                                Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                                Enabled="true" TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight1"
                                CssClass="BlockPopup" />
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtmsg" runat="server" class="form-control" placeholder="Message"
                                autocomplete="none" TextMode="MultiLine"></asp:TextBox>
                        </div>                        
                        <asp:LinkButton ID="lnk" runat="server" ValidationGroup="validcontact" class="btn" OnClick="btnsubmit_Click">Submit</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="conatct-map">
        <figure>
            <!-- <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d7015.953769658691!2d77.06720309538325!3d28.45011318622222!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x390d1894daaaaaab%3A0xfde470b65bb4221c!2sJubilant%20Agri%20and%20Consumer%20Products%20Ltd.!5e0!3m2!1sen!2sin!4v1698323517577!5m2!1sen!2sin" width="100%" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe> -->
            <iframe src="https://www.google.com/maps/embed?pb=!1m16!1m12!1m3!1d3504.0716473809125!2d77.31261017549839!3d28.567611175700215!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!2m1!1s1A%2C%20Sector%2016A%2C%20Noida%20-%20201%20301%2C%20Uttar%20Pradesh%2C%20India!5e0!3m2!1sen!2sin!4v1706174600903!5m2!1sen!2sin" width="100%" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
       
       
       
       
        </figure>
    </div>
</asp:Content>

