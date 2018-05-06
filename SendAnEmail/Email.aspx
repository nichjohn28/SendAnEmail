<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="SendAnEmail.Email" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server" CellPadding="2">
                <asp:TableRow>
                    <asp:TableCell Width="100"><label>Sender: </label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtSender" runat="server" Width="300"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="100"><label>Recipient: </label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtRecipient" runat="server" Width="300"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="100"><label>Subject: </label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtSubject" runat="server" Width="300"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="100"><label>Body: </label></asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtBody" runat="server" Height="100" Width="300"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <div style="display: inline-block; margin-top: 15px">
                <asp:Button ID="send" runat="server" Text="Send" Width="100" OnClick="send_Click" />
                <asp:Label ID="Lblstatus" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
