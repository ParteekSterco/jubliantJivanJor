<%@ Page Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" AutoEventWireup="true" CodeFile="states.aspx.cs" Inherits="backoffice_masters_states" Theme="backtheme"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h2>  Add State</h2>
<div class="content-panel">
<table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                            </td>
                        <td align="right">
                            &nbsp; &nbsp;<asp:TextBox ID="sid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            <asp:TextBox ID="displayorder" runat="server" Width="150px" Visible="False"></asp:TextBox>
                            &nbsp; &nbsp;&nbsp; &nbsp;
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
                Fields with <span class="star">*</span> are mandatory</td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
            <span class="star">*</span>Country :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="countryid" runat="server" Width="350px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="countryid"
                    Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                <span class="star">*</span>State :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="statename" runat="server" CssClass="box" TabIndex="3" Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="statename"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr style="display:none">
            <td align="right" style="width: 15%">
                <span class="star">*</span>State Code :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="statecode" runat="server" CssClass="box" TabIndex="3" Width="350px"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="statecode"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                    
                    </td>
        </tr>
       <%-- <tr>
            <td align="right">
                <span class="star">*</span>Display Order :&nbsp;
            </td>
            <td align="left" height="10">--%>
                
                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Numeric"
                    Display="Dynamic" ControlToValidate="displayorder" ValidationExpression="^\d+?$"></asp:RegularExpressionValidator></td>
        </tr>--%>
        <tr>
            <td align="right">
                Status :&nbsp;
            </td>
            <td align="left" height="10">
                <asp:CheckBox ID="status" runat="server" Checked="true" /></td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left" height="10">
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
             <asp:Button ID="btnsearch" runat="server" CssClass="btnbg" Text="Search" CausesValidation="false"  OnClick="btnsearch_Click" />
                <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Submit" OnClick="btnsubmit_Click" />
                <asp:Button ID="btncancel" runat="server" CssClass="btnbg" Text="Cancel" CausesValidation="false" OnClick="btncancel_Click" /></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp; &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="50"
                    Width="100%" AutoGenerateColumns="false" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                       <%--  <asp:BoundField DataField="countryname" HeaderText="Country">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>--%>
                           <asp:TemplateField HeaderText="Country">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("countryname")%>
                             
                            </ItemTemplate>
                        </asp:TemplateField>
                      <%--  <asp:BoundField DataField="statename" HeaderText="State">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>--%>
                          <asp:TemplateField HeaderText="State">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("statename")%>
                             
                            </ItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="State Code" Visible="false">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                                <asp:Label ID="lblpagename" runat="server" Text='<%#Eval("statecode")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                        <asp:BoundField DataField="displayorder" HeaderText="Display Order" Visible="false">
                            <HeaderStyle HorizontalAlign="center"  />
                            <ItemStyle HorizontalAlign="center"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Publish">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%# Eval("sid") %>'
                                    CommandName="lnkstatus" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%# Eval("sid") %>'
                                    CommandName="btnedit" ImageUrl="~/backoffice/assets/Edit.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

