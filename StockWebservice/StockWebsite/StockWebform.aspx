<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockWebform.aspx.cs" Inherits="StockWebsite.StockWebform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Using the Stock Service</h3>
            <br /><br />
            <asp:Label ID="lblmessage" runat="server"></asp:Label>
            <br /><br />
            <asp:Button ID="btnpostback" runat="server" onclick="Button1_Click" Text="Post Back" style="width: 132px" />
            <asp:Button ID="btnservice" runat="server" onclick="btnservice_Click" Text="Get Stock" style="width:99px" />
        </div>
    </form>
</body>
</html>
