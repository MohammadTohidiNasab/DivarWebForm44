<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Layout.master" CodeBehind="SelectCategory.aspx.cs" Inherits="DivarWebForm.Pages.SelectCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>انتخاب دسته‌بندی</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div>
            <h2 style="text-align: center;">انتخاب دسته‌بندی</h2>
            <hr />
            <br />

            <div style="display: flex; justify-content: center;">
                <table class="table" style="border-collapse: collapse; border: 4px solid #000; width: 80%;">
                    <thead>
                        <tr>
                            <th style="border: 4px solid #000; padding: 8px; text-align: center;">دسته‌بندی</th>
                            <th style="border: 4px solid #000; padding: 8px; text-align: center;">عملیات</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style="border: 4px solid #000; padding: 8px; text-align: center;">کتاب</td>
                            <td style="border: 4px solid #000; padding: 8px; text-align: center;">
                                <asp:Button ID="SelectBookButton" runat="server" Text="انتخاب" CssClass="btn btn-primary" OnClick="SelectCategoryButton_Click" CommandArgument="کتاب" />
                            </td>
                        </tr>
                        <tr>
                            <td style="border: 4px solid #000; padding: 8px; text-align: center;">خانه</td>
                            <td style="border: 4px solid #000; padding: 8px; text-align: center;">
                                <asp:Button ID="SelectHomeButton" runat="server" Text="انتخاب" CssClass="btn btn-primary" OnClick="SelectCategoryButton_Click" CommandArgument="خانه" />
                            </td>
                        </tr>
                        <tr>
                            <td style="border: 4px solid #000; padding: 8px; text-align: center;">موبایل</td>
                            <td style="border: 4px solid #000; padding: 8px; text-align: center;">
                                <asp:Button ID="SelectMobileButton" runat="server" Text="انتخاب" CssClass="btn btn-primary" OnClick="SelectCategoryButton_Click" CommandArgument="موبایل" />
                            </td>
                        </tr>
                        <tr>
                            <td style="border: 4px solid #000; padding: 8px; text-align: center;">ماشین</td>
                            <td style="border: 4px solid #000; padding: 8px; text-align: center;">
                                <asp:Button ID="SelectCarButton" runat="server" Text="انتخاب" CssClass="btn btn-primary" OnClick="SelectCategoryButton_Click" CommandArgument="ماشین" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</asp:Content>
