<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DivarWebForm.Pages.Register" MasterPageFile="~/Pages/Layout.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>ثبت نام</h2>
    <form id="form1" runat="server" class="registration-form">
        <div>
            <asp:TextBox ID="Email" runat="server" placeholder="ایمیل" CssClass="input-field"></asp:TextBox>
            <asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="رمز عبور" CssClass="input-field"></asp:TextBox>
            <asp:TextBox ID="FirstName" runat="server" placeholder="نام" CssClass="input-field"></asp:TextBox>
            <asp:TextBox ID="LastName" runat="server" placeholder="نام خانوادگی" CssClass="input-field"></asp:TextBox>
            <asp:TextBox ID="PhoneNumber" runat="server" placeholder="شماره تلفن" CssClass="input-field"></asp:TextBox>
            <asp:Button ID="RegisterButton" runat="server" Text="ثبت نام" CssClass="submit-button" OnClick="RegisterButton_Click" />
        </div>
    </form>

    <style>
        .registration-form {
            max-width: 400px;
            margin: 0 auto; /* وسط‌چین کردن */
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            background-color: #f9f9f9;
        }

        .input-field {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 16px;
        }

        .submit-button {
            background-color: #4CAF50; /* رنگ سبز */
            color: white;
            padding: 10px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            width: 100%;
        }

        .submit-button:hover {
            background-color: #45a049; /* رنگ سبز تیره برای حالت hover */
        }

        h2 {
            text-align: center; /* وسط‌چین کردن عنوان */
            color: #333;
        }
    </style>
</asp:Content>
<%--  --%>