<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Layout.master" CodeBehind="AddAdvertisement.aspx.cs" Inherits="DivarWebForm.Pages.AddAdvertisement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ثبت آگهی</title>
    <link href="../Content/AddAdvertisement.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div>
            <h2>ثبت آگهی جدید</h2>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="لطفاً خطاهای زیر را بررسی کنید:" CssClass="validation-summary" />

            <div>
                <label for="Title">تیتر:</label>
                <asp:TextBox ID="Title" runat="server" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="TitleRequired" runat="server" ControlToValidate="Title" ErrorMessage="افزودن تیتر الزامی است" />
            </div>

            <div>
                <label for="Content">محتوا:</label>
                <asp:TextBox ID="Content" runat="server" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
            </div>

            <div>
                <label for="Price">قیمت:</label>
                <asp:TextBox ID="Price" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PriceRequired" runat="server" ControlToValidate="Price" ErrorMessage="افزودن قیمت محصول الزامی است" />
                <asp:RegularExpressionValidator ID="PriceValidator" runat="server" ControlToValidate="Price" 
                                                ErrorMessage="قیمت باید یک عدد باشد" 
                                                ValidationExpression="^\d+$" />
            </div>

            <div>
                <label for="SelectedCategory">دسته‌بندی انتخاب شده:</label>
                <asp:Label ID="SelectedCategoryLabel" runat="server" Text="دسته‌بندی"></asp:Label>
            </div>

            <div>
                <label for="Image1">تصویر ۱:</label>
                <asp:FileUpload ID="Image1" runat="server" />
            </div>

            <div>
                <label for="Image2">تصویر ۲:</label>
                <asp:FileUpload ID="Image2" runat="server" />
            </div>

            <div>
                <label for="Image3">تصویر ۳:</label>
                <asp:FileUpload ID="Image3" runat="server" />
            </div>

            <div>
                <asp:Button ID="SubmitButton" runat="server" Text="ثبت آگهی" OnClick="SubmitButton_Click" />
            </div>
        </div>
    </form>
</asp:Content>
