<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Layout.master" CodeBehind="DeleteAdvertisement.aspx.cs" Inherits="DivarWebForm.Pages.DeleteAdvertisement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>حذف آگهی</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <h3 style="text-align: center;">آیا از حذف کردن این آگهی مطمئن هستید؟</h3>
            <hr />
            <br />

            <div style="display: flex; flex-direction: column; align-items: center;">
                <h4><asp:Literal ID="TitleLiteral" runat="server"></asp:Literal></h4>
                <div style="text-align: center;">
                    <p><asp:Literal ID="ContentLiteral" runat="server"></asp:Literal></p>
                    <p>قیمت: <asp:Literal ID="PriceLiteral" runat="server"></asp:Literal></p>
                    <p>دسته: <asp:Literal ID="CategoryLiteral" runat="server"></asp:Literal></p>
                    <p>تاریخ انتشار: <asp:Literal ID="CreatedDateLiteral" runat="server"></asp:Literal></p>
                </div>

                <asp:Button ID="DeleteButton" runat="server" Text="حذف" CssClass="btn btn-danger" OnClick="DeleteButton_Click" />
                <asp:Button ID="CancelButton" runat="server" Text="انصراف" CssClass="btn btn-secondary" OnClick="CancelButton_Click" />
            </div>
        </div>
    </form>
</asp:Content>
