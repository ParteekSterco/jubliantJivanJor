<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dataupdate.aspx.cs" Inherits="backoffice_dataupdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Data Update</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="Table1" style="z-index: 101; width: 927px; position: absolute; top: 6px;
            height: 421px" cellspacing="1" cellpadding="1" width="927" border="1">
            <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Show Data" Width="110px" Height="23px">
                    </asp:Button><asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Excute Sql" Width="110px"
                        Height="23px"></asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="909px" Height="207px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="DataGrid2" runat="server">
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
