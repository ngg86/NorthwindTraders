<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomersAndOrders.aspx.cs" Inherits="NorthwindTraders.CustomersAndOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:DropDownList ID="ddlCompName" runat="server" OnSelectedIndexChanged="ddlCompName_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        <asp:GridView ID="gvCustomerOrders" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
