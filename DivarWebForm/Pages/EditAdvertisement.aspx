<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Layout.master" CodeBehind="EditAdvertisement.aspx.cs" Inherits="DivarWebForm.Pages.EditAdvertisement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ویرایش آگهی</title>
    <style>
        .container {
            max-width: 600px; /* حداکثر عرض فرم */
            margin: 0 auto; /* وسط چین کردن */
            padding: 20px; /* فضای داخلی */
            border: 1px solid #ccc; /* حاشیه */
            border-radius: 8px; /* گوشه‌های گرد */
            background-color: #f9f9f9; /* رنگ پس‌زمینه */
        }

        h2 {
            text-align: center; /* وسط چین کردن عنوان */
        }

        label {
            display: block; /* نمایش برچسب به صورت بلوک */
            margin-top: 10px; /* فاصله بالای برچسب */
        }

        .form-group {
            margin-bottom: 15px; /* فاصله بین گروه‌های فرم */
        }

        .form-group input,
        .form-group select,
        .form-group textarea {
            width: 100%; /* عرض کامل */
            padding: 10px; /* فضای داخلی */
            border: 1px solid #ccc; /* حاشیه */
            border-radius: 4px; /* گوشه‌های گرد */
        }

        .form-group button {
            width: 48%; /* عرض دکمه‌ها */
            padding: 10px; /* فضای داخلی */
            margin: 5px 1%; /* فاصله بین دکمه‌ها */
            border: none; /* حذف حاشیه */
            border-radius: 4px; /* گوشه‌های گرد */
            cursor: pointer; /* نشانگر ماوس */
        }

        .form-group button[type="submit"] {
            background-color: #28a745; /* رنگ دکمه ذخیره */
            color: white; /* رنگ متن دکمه */
        }

        .form-group button[type="button"] {
            background-color: #dc3545; /* رنگ دکمه انصراف */
            color: white; /* رنگ متن دکمه */
        }

        .form-group button:hover {
            opacity: 0.9; /* تغییر شفافیت هنگام hover */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <h2>ویرایش آگهی</h2>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="لطفاً خطاهای زیر را بررسی کنید:" />

            <div class="form-group">
                <label for="Title">تیتر:</label>
                <asp:TextBox ID="Title" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="TitleRequired" runat="server" ControlToValidate="Title" ErrorMessage="افزودن تیتر الزامی است" CssClass="text-danger" />
            </div>

            <div class="form-group">
                <label for="Content">محتوا:</label>
                <asp:TextBox ID="Content" runat="server" MaxLength="500" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="Price">قیمت:</label>
                <asp:TextBox ID="Price" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PriceRequired" runat="server" ControlToValidate="Price" ErrorMessage="افزودن قیمت محصول الزامی است" CssClass="text-danger" />
            </div>


            <div class="form-group">
                <asp:Button ID="SubmitButton" runat="server" Text="ذخیره تغییرات" OnClick="SubmitButton_Click" />
                <asp:Button ID="CancelButton" runat="server" Text="انصراف" OnClick="CancelButton_Click" />
            </div>
        </div>
    </form>
</asp:Content>
