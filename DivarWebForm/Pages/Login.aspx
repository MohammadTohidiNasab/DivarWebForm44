<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DivarWebForm.Pages.Login" MasterPageFile="~/Pages/Layout.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Content/Login.css" rel="stylesheet" />
    <h2 class="text-center">ورود به حساب کاربری</h2>
    <div class="login-container">
        <form id="form1" runat="server" class="login-form">
            <div class="form-group">
                <asp:TextBox ID="Email" runat="server" placeholder="ایمیل" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="رمز عبور" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="LoginButton" runat="server" Text="ورود" OnClick="LoginButton_Click" CssClass="btn btn-primary btn-block" />
            </div>
            <div class="form-group text-center">
                <asp:Button ID="BackButton" runat="server" Text="بازگشت به صفحه اصلی" PostBackUrl="Default.aspx" CssClass="btn btn-secondary btn-block" />
                <br />
                <%--<br />--%>
                <a href="Register.aspx">اکانت ندارید؟ ثبت نام</a>

            </div>
        </form>
    </div>
</asp:Content>
