﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view-enquiry-details.aspx.cs"
    Inherits="backoffice_others_view_enquiry_details"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: lavender">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2" align="center" class="head1">
                <h3>
                    <asp:Label ID="lblname" runat="server"></asp:Label></h3>
            <%--    <h4>
                    Enquiry Type -
                    <asp:Label ID="lbltype" runat="server"></asp:Label></h4>--%>
            </td>
        </tr>
        <tr>
            <td align="left">
                <table border="0" cellpadding="2" cellspacing="2" width="100%">
                    <tr>
                        <td>
                            <asp:DetailsView ID="dtlview" runat="server" Width="100%" Font-Bold="true" Font-Size="Medium"
                                AlternatingRowStyle-BackColor="AliceBlue" EmptyDataRowStyle-Height="0px" EmptyDataRowStyle-Width="0px">
                            </asp:DetailsView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
