<%@ Page Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" AutoEventWireup="true"
    CodeFile="product.aspx.cs" Inherits="backoffice_design_product" Theme="backtheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="/fancybox/1.4/jquery.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".various4").fancybox({
                'width': '90%',
                'height': '90%',
                'autoScale': true,
                'scrolling': 'yes',
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });
        });
    </script>
    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=investordate.ClientID%>'));
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=expiraydate.ClientID%>'));

        };
    </script>
    <h2>
        Add Product</h2>
    <div class="content-panel">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="head1">
                            </td>
                            <td align="right">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="h_dot_line">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="headingtext" colspan="2">
                    <div class="error" align="left" id="trerror" runat="server">
                        &nbsp;&nbsp;
                        <asp:Label ID="lblerror" runat="server"></asp:Label>
                    </div>
                    <div class="success" align="left" id="trsuccess" runat="server">
                        &nbsp;&nbsp;
                        <asp:Label ID="lblsuccess" runat="server"></asp:Label>
                    </div>
                    <div class="notice" align="left" id="trnotice" runat="server">
                        &nbsp;&nbsp;
                        <asp:Label ID="lblnotice" runat="server"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    Fields with <span style="color: #ff0000">*</span> are mandatory
                    <asp:TextBox ID="productid" runat="server" Visible="false"></asp:TextBox>
                    <asp:CheckBox ID="showonhome" runat="server" Visible="False" Checked="false" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
           <%-- <tr style="display: none;">
                <td align="right" colspan="2">
                    <a class="various4 btnbg" href="uploadproduct.aspx">Upload Product</a>
                </td>
            </tr>--%>
           
            <tr>
                <td valign="top" width="15%" align="right">
                    Category<span class="star">*</span> : &nbsp;
                </td>
                <td width="85%">
                    <asp:DropDownList ID="pcatid" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="pcatid_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="pcatid"
                        Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr >
                <td valign="top" width="15%" align="right">
                    Sub Category<span class="star"></span> : &nbsp;
                </td>
                <td width="85%">
                    <asp:DropDownList ID="psubcatid" runat="server" Width="200px">
                    </asp:DropDownList>
                   
                </td>
            </tr>
            <tr style="display:none;">
                <td valign="top" width="15%" align="right">
                    Year Category<span class="star"></span> : &nbsp;
                </td>
                <td width="85%">
                    <asp:DropDownList ID="ycatid" runat="server" Width="200px">
                    </asp:DropDownList>
                   
                </td>
            </tr>
            <tr style="display:none;">
                <td valign="top" width="15%" align="right">
                    Year Quarterly<span class="star"></span> : &nbsp;
                </td>
                <td width="85%">
                    <asp:DropDownList ID="yqid" runat="server" Width="200px">
                    </asp:DropDownList>
                   
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    Product Name<span class="star">*</span> : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="productname" runat="server" Width="350px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="productname"
                                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr style="display:none;">
                <td align="right" valign="top">
                    Investor Date<span class="star">*</span> :&nbsp;
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="investordate" runat="server" CssClass="box" Width="200px"></asp:TextBox>
                 <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="investordate"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="investordate"
                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>--%>
                </td>
            </tr>


             <tr style="display:none;">
                <td align="right" valign="top">
                    New Expiry Date<span class="star"></span> :&nbsp;
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="expiraydate" runat="server" CssClass="box" Width="200px"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="expiraydate"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="expiraydate"
                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr style="display: none;">
                <td valign="top" align="right">
                    Product Title<span class="star"></span> : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="producttitle" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>

             <tr style="display: none;">
                <td valign="top" align="right">
                    Model No.<span class="star"></span> : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="modelno" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>




            <tr style="display: none;">
                <td valign="top" align="right">
                    Short Detail : &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="shortdetail" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    Detail : &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="productdetail" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>


             <tr style="display: none;">
                <td valign="top" align="right">
                    Popup details : &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKeditor3" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="longdesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>



            <tr>
                <td align="right">
                    Upload Image<span class="star">*</span> :&nbsp;
                </td>
                <td align="left">
                    <input id="File2" runat="server" class="box" contenteditable="false" onchange="showpreview(this);"
                        type="file" />&nbsp;<asp:Label ID="Label1" runat="server" Text="(Image should be of size : 191x209.)"
                            ForeColor="red" Font-Italic="true" Visible="false"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="(Gallery Image show on homepage should be of size : 500 x 511.)"
                        ForeColor="red" Font-Italic="true" Visible="false"></asp:Label>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="toptxt" Visible="false"
                        OnClick="LinkButton1_Click">Remove File</asp:LinkButton>
                    <asp:TextBox ID="UploadAImage" runat="server" Visible="False" Width="122px">
                
                
                
                    </asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right">
                </td>
                <td align="left">
                    <asp:Image ID="Image1" runat="server" Height="120px" Visible="False" Width="107px" />
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right">
                    Large Image<span class="star">*</span> :&nbsp;
                </td>
                <td align="left">
                    <input id="File3" runat="server" class="box" contenteditable="false" onchange="showpreview(this);"
                        type="file" />&nbsp;<asp:Label ID="Label2" runat="server" Text="(Image should be of size : 387x351.)"
                            ForeColor="red" Font-Italic="true" Visible="false"></asp:Label>
                    <br />
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="toptxt" Visible="false"
                        OnClick="LinkButton2_Click">Remove File</asp:LinkButton>
                    <asp:TextBox ID="largeimage" runat="server" Visible="False" Width="122px">
                
                
                
                    </asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right">
                </td>
                <td align="left">
                    <asp:Image ID="Image2" runat="server" Height="120px" Visible="False" Width="107px" />
                </td>
            </tr>
            <tr style="display:none;" >
                <td align="right" valign="top">
                    Upload File<span class="star">*</span> :&nbsp;
                </td>
                <td align="left">
                    <input id="File1" runat="server" contenteditable="false" type="file" class="box" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="prospectus" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" valign="top">
                    Family Product :&nbsp;
                </td>
                <td align="left">
                    <asp:CheckBox ID="Isfamilyproduct" runat="server" Checked="False" />
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" valign="top">
                    Show on Group :&nbsp;
                </td>
                <td align="left">
                   
                </td>
            </tr>
             <tr  style="display:none;">
                <td align="right" valign="top">Third Party URL
                </td>
                <td align="left">
                    <asp:TextBox ID="purl" runat="server" Width="350px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    Display Order<span class="star"></span> : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="displayorder" runat="server" Width="50px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="displayorder"
                                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                    <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                        ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                        ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                    <asp:CheckBox ID="status" runat="server" Checked="True" Visible="false" />
                     <asp:CheckBox ID="showongroup" runat="server" Visible="false" />
                </td>
            </tr>
           
            <tr style="display: none">
                <td valign="top" align="right">
                    Rewrite Url<%--<span class="star">*</span>--%>
                    : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="rewrite_url" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td colspan="2">
                    <b>SEO SECTION</b>
                </td>
            </tr>
            <tr style="display: none;">
                <td valign="top" align="right">
                    <span class="star"></span>Page Title : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="PageTitle" runat="server" Width="500px"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="coursename"
                                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr style="display: none;">
                <td valign="top" align="right">
                    <span class="star"></span>Page Meta : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="PageMeta" runat="server" Width="500px" Height="100" TextMode="MultiLine"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="coursename"
                                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr style="display: none;">
                <td valign="top" align="right">
                    <span class="star"></span>Page Meta Desc : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="PageMetaDesc" runat="server" Width="500px" Height="100" TextMode="MultiLine"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="coursename"
                                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr style="display: none;">
                <td valign="top" align="right">
                    <span class="star"></span>Page Script : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="pagescript" runat="server" Width="500px" Height="100" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td valign="top" align="right">
                    <span class="star"></span>Canonical : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="canonical" runat="server" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" valign="top">
                    No Index Follow :
                </td>
                <td align="left" valign="top">
                    <asp:CheckBox ID="no_indexfollow" runat="server"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td valign="top">
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" OnClick="btnSubmit_Click" />&nbsp;<asp:Button
                        ID="btnCancel" runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False"
                        OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
