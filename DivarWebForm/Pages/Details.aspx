<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Layout.master" CodeBehind="Details.aspx.cs" Inherits="DivarWebForm.Pages.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>جزئیات آگهی</title>
    <link href="~/Content/Detail.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <br />
            <h2 class="text-center">جزئیات آگهی</h2>

            <!-- اضافه کردن اسلایدر تصاویر -->
            <div id="imageCarousel" class="carousel slide" data-ride="carousel" data-interval="false" data-pause="hover">
                <div class="carousel-inner">
                    <asp:PlaceHolder ID="ImageCarouselPlaceholder" runat="server"></asp:PlaceHolder>
                </div>
                <a class="carousel-control-prev" href="#imageCarousel" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">قبلی</span>
                </a>
                <a class="carousel-control-next" href="#imageCarousel" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">بعدی</span>
                </a>
            </div>

            <div class="">
                <h3 class="text-center">
                    <asp:Literal ID="TitleLiteral" runat="server"></asp:Literal>
                </h3>
                <p class="text-center">
                    <asp:Literal ID="ContentLiteral" runat="server"></asp:Literal>
                </p>
                <p class="text-center">
                    قیمت:
                    <asp:Literal ID="PriceLiteral" runat="server"></asp:Literal>
                    تومان
                </p>
                <p class="text-center">
                    دسته‌بندی:
                    <asp:Literal ID="CategoryLiteral" runat="server"></asp:Literal>
                </p>
                <p class="text-center">
                    تاریخ ایجاد:
                    <asp:Literal ID="CreatedDateLiteral" runat="server"></asp:Literal>
                </p>

                <!-- اضافه کردن بخش اطلاعات تماس -->
                <p class="text-center">
                    نام منتشر کننده اگهی:
                    <asp:Literal ID="FullNameLiteral" runat="server"></asp:Literal>
                </p>
                <p class="text-center">
                    اطلاعات تماس:
                    <asp:Literal ID="PhoneNumberLiteral" runat="server"></asp:Literal>
                </p>

                <!-- اضافه کردن دکمه‌ها برای ویرایش و حذف آگهی -->
                <div class="button-group">
                    <asp:Button ID="EditButton" runat="server" Text="ویرایش آگهی" CssClass="btn btn-primary" OnClick="EditButton_Click" />
                    <asp:Button ID="DeleteButton" runat="server" Text="حذف آگهی" CssClass="btn btn-danger" OnClick="DeleteButton_Click" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
