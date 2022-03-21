<%@ Page Title="Регистрация" Language="C#" MasterPageFile="~/Pages/StudentSiteMaster.Master" UnobtrusiveValidationMode="None"  AutoEventWireup="true" CodeBehind="NewStudentPage.aspx.cs" Inherits="ASP.FinalLab.StudentProgress.Pages.NewStudentPage" %>
<%@ Register TagPrefix="inputUserControl" TagName="inputForm" Src="~/UserControls/DataInputControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../SiteStyle/Style.css" />
    <div>
        <asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" runat="server" />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>
