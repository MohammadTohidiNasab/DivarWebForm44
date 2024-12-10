<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Layout.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DivarWebForm.Pages.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8" />
    <title>صفحه اصلی</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>آگهی‌ها</h2>
        <div class="row">
            <asp:Repeater ID="AdsRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="ad-item article">
                            <asp:Image ID="AdImage" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' CssClass="img-fluid" />
                            <h3><a href='Details.aspx?id=<%# Eval("Id") %>'><%# Eval("Title") %></a></h3>
                            <p>قیمت: <%# Eval("Price") %> تومان</p>
                            <p>دسته‌بندی: <%# HttpUtility.HtmlDecode(Eval("CategoryName").ToString()) %></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
