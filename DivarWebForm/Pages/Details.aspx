<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="DivarWebForm.Pages.Details" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>جزئیات آگهی</title>
    <link href="~/Content/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>جزئیات آگهی</h2>
            <div class="article">
                <h3><asp:Literal ID="TitleLiteral" runat="server"></asp:Literal></h3>
                <p><asp:Literal ID="ContentLiteral" runat="server"></asp:Literal></p>
                <p>قیمت: <asp:Literal ID="PriceLiteral" runat="server"></asp:Literal> تومان</p>
                <p>دسته‌بندی: <asp:Literal ID="CategoryLiteral" runat="server"></asp:Literal></p>
                <p>تاریخ ایجاد: <asp:Literal ID="CreatedDateLiteral" runat="server"></asp:Literal></p>
            </div>
        </div>
    </form>
</body>
</html>
