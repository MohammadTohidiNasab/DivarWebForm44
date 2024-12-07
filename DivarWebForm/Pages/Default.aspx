<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DivarWebForm.Pages.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>آگهی‌ها</title>
    <link href="~/Content/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>آگهی‌ها</h2>
            <div class="row">
                <asp:Repeater ID="AdsRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-4">
                            <div class="ad-item article">
                                <h3><a href='Details.aspx?id=<%# Eval("Id") %>'><%# Eval("Title") %></a></h3>
                                <p>قیمت: <%# Eval("Price") %> تومان</p>
                                <p>دسته بندی: <%# Eval("Category") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
