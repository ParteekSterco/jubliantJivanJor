<%@ Page Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" AutoEventWireup="true"
    CodeFile="viewproduct.aspx.cs" Inherits="backoffice_Products_viewproduct" Theme="backtheme" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <input type="hidden" value="<%=appno%>" name="appno" id="appno">
  <script type="text/javascript" src="/fancybox/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
   <script type="text/javascript">
       $(document).ready(function () {
           
               $(".various").fancybox({
                   'width': '90%',
                   'height': '90%',
                   'autoScale': true,
                   'scrolling': true,
                   'transitionIn': 'elastic',
                   'transitionOut': 'elastic',
                   'type': 'iframe'
               });
           
       });
    </script>

       <script type="text/javascript">
           $(document).ready(function () {
               var i = 0;
               var toappno = document.getElementById("appno").value;
               for (i = 1; i <= toappno; i++) {
                   $("#variouss_" + i).fancybox({
                       'width': '90%',
                       'height': '90%',
                       'autoScale': true,
                       'scrolling': true,
                       'transitionIn': 'elastic',
                       'transitionOut': 'elastic',
                       'type': 'iframe'
                   });
               }
           });
    </script>

  <%--  <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>--%>

        <h2>  View / Edit Product</h2>
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
                    <td align="center" colspan="2" height="10">
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
                    <td align="center" colspan="2">
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                            Width="80%" meta:resourcekey="Panel1Resource1">
                            <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                                <tr>
                                    <td align="left" colspan="4" height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        Category:
                                    </td>
                                    <td align="left">
                                         <asp:DropDownList ID="pcatid" runat="server" Width="200px" 
                                         AutoPostBack="false" onselectedindexchanged="pcatid_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>

                                        <td align="right">
                                      Product Name:
                                    </td>
                                    <td align="left">
                                         <asp:TextBox ID="productname" runat="server" Width="197px"></asp:TextBox>
                                    </td>                                                                  
                                </tr>
                                <tr>
                                <td align="right">
                                      Application Area:
                                    </td>
                                    <td align="left">
                                    <asp:DropDownList ID="brand" runat="server" Width="200px">
                                        </asp:DropDownList>
                                        
                                    </td>

                                     <td align="right">
                                       
                                    </td>
                                    <td align="left">
                                          <asp:DropDownList ID="subcate" runat="server" Width="200px" Visible="false">
                                        </asp:DropDownList>
                                    </td>                                
                                </tr>
                                                                                               
                                <tr>
                                    <td align="center" colspan="4">
                                        &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click" />
                                        <%--<asp:Button ID="btnexport" runat="server" Text="Export To Excel" Visible="false"
                                    CssClass="btnbg" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" height="5">
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                            AllowPaging="True" PageSize="100" OnPageIndexChanging="GridView1_PageIndexChanging"
                            OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Category">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("category") %>
                                    </ItemTemplate>
                                </asp:TemplateField>                                                            

                                 <asp:TemplateField HeaderText="Product">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>
                                        <%# Eval("productname")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                              
                             

                                <asp:TemplateField HeaderText="Add Banner Image" Visible="true">
                                    <ItemStyle Width="10%" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnstatus" runat="server" Visible="false" CausesValidation="false"
                                    CommandArgument='<%#Eval("productid") %>'><img border="0" src="../images/view.gif" alt="" /></asp:LinkButton>
                                    <a  class="various toptxt"  href='mapproduct.aspx?productid=<%#Eval("productid") %>'>
                                    Add Edit Image</a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                              

                                <asp:TemplateField HeaderText="Download File" Visible="true">
                                    <ItemStyle Width="3%" />
                                    <ItemTemplate>

                                        <asp:Label ID="lblprodimg" runat="server" Text='<%#Eval("UploadAImage")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lbldown" runat="server" Text='<%#Eval("prospectus")%>' Visible="false"></asp:Label>
                                        <asp:LinkButton ID="downbtn" runat="server" CausesValidation="false" CommandArgument='<%#Eval("productid")%>'
                                            CommandName="downbtn">
                                            <asp:Image ID="imgDown" runat="server" BorderWidth="0" ImageUrl="~/backoffice/assets/Download_24x24.png" /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                                    <HeaderStyle HorizontalAlign="center" Width="3%" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>


                                  <asp:TemplateField HeaderText="Show On Home" Visible="true">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtshowonhome" runat="server" Text='<%# Eval("showonhome") %>' Visible="false"></asp:TextBox>
                                        <asp:ImageButton ID="lnkshowonhome" CssClass="toptxt" runat="server" CausesValidation="false"
                                            CommandArgument='<%#Eval("productid")%>' CommandName="showonhome"></asp:ImageButton>
                                    </ItemTemplate>
                                  </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Show on video">
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtshowongroup" runat="server" Text='<%# Eval("showongroup") %>' Visible="false"></asp:TextBox>
                                        <asp:ImageButton ID="lnkshowongroup" CssClass="toptxt" runat="server" CausesValidation="false"
                                            CommandArgument='<%#Eval("productid")%>' CommandName="showongroup"></asp:ImageButton>
                                    </ItemTemplate>
                                  </asp:TemplateField>       
                        

                                    <asp:TemplateField HeaderText="Map Testimonials" Visible="true">
                                    <ItemStyle Width="10%" />
                                    <ItemTemplate>
                                       
                                    <a  class="various toptxt"  href='maptestimonials.aspx?productid=<%#Eval("productid") %>'>
                                    Map Testimonials </a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Map Application" Visible="true">
                                    <ItemStyle Width="10%" />
                                    <ItemTemplate>
                                       
                                    <a  class="various toptxt"  href='mapapplication.aspx?productid=<%#Eval("productid") %>'>
                                    Map Application </a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Map Product Application" Visible="true">
                                    <ItemStyle Width="10%" />
                                    <ItemTemplate>
                                       
                                    <a  class="various toptxt"  href='mapproductapplication.aspx?productid=<%#Eval("productid") %>'>
                                    Map Product Application </a>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Publish">
                                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtstatus" runat="server" Text='<%# Eval("status") %>' Visible="false"></asp:TextBox>
                                        <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                            CommandArgument='<%#Eval("productid")%>' CommandName="lnkstatus"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Add Application Image" Visible="false">
                                    <ItemStyle Width="10%" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtn" runat="server" Visible="false" CausesValidation="false"
                                    CommandArgument='<%#Eval("productid") %>'><img border="0" src="../images/view.gif" alt="" /></asp:LinkButton>
                                    <a  class="various toptxt"  href='mapproductimage.aspx?productid=<%#Eval("productid") %>'>
                                    Add Image</a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Add Images" Visible="false">
                                    <ItemStyle Width="10%" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnstat" runat="server" Visible="false" CausesValidation="false"
                                    CommandArgument='<%#Eval("productid") %>'><img border="0" src="../images/view.gif" alt="" /></asp:LinkButton>
                                    <a id='various_<%# ((GridViewRow)Container).RowIndex + 1 %>' class="toptxt" visible="false"
                                    href='upload_image.aspx?prodid=<%#Eval("productid") %>'>
                                    Add Edit Image
                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Is Family Product" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtIsfamilyproduct" runat="server" Text='<%# Eval("Isfamilyproduct") %>' Visible="false"></asp:TextBox>
                                        <asp:ImageButton ID="lnkIsfamilyproduct" CssClass="toptxt" runat="server" CausesValidation="false"
                                            CommandArgument='<%#Eval("productid")%>' CommandName="lnkIsfamilyproduct"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                                      

                                <asp:TemplateField HeaderText="Edit">
                                    <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("productid") %>'
                                            CommandName="btnedit" ImageUrl="~/backoffice/assets/edit.png" ToolTip="Click to Edit" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("productid")%>'
                                            CommandName="btndel" ImageUrl="~/backoffice/assets/Remove_24x24.png" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                            TargetControlID="btndel">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </div>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
