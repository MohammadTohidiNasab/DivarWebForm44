<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Layout.master" CodeBehind="DeleteAdvertisement.aspx.cs" Inherits="DivarWebForm.Pages.DeleteAdvertisement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>حذف آگهی</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .container {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 8px;
            background-color: #f9f9f9;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        }

        .btn-danger, .btn-secondary {
            width: 100px;
            margin: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container text-center">
            <h3>آیا از حذف کردن این آگهی مطمئن هستید؟</h3>
            <hr />
            <div class="my-4">
                <h4><asp:Literal ID="TitleLiteral" runat="server"></asp:Literal></h4>
                <p><asp:Literal ID="ContentLiteral" runat="server"></asp:Literal></p>
                <p>قیمت: <asp:Literal ID="PriceLiteral" runat="server"></asp:Literal></p>
                <p>دسته: <asp:Literal ID="CategoryLiteral" runat="server"></asp:Literal></p>
                <p>تاریخ انتشار: <asp:Literal ID="CreatedDateLiteral" runat="server"></asp:Literal></p>
            </div>
            <div>
                <asp:Button ID="DeleteButton" runat="server" Text="حذف" CssClass="btn btn-danger" OnClick="DeleteButton_Click" />
                <asp:Button ID="CancelButton" runat="server" Text="انصراف" CssClass="btn btn-secondary" OnClick="CancelButton_Click" />
            </div>
        </div>
    </form>
</asp:Content>
