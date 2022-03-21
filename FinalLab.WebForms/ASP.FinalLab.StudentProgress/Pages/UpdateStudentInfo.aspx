<%@ Page Title="Изменение данных" Language="C#" MasterPageFile="~/Pages/StudentSiteMaster.Master" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="UpdateStudentInfo.aspx.cs" Inherits="ASP.FinalLab.StudentProgress.Pages.UpdateStudentInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../SiteStyle/Style.css" />
    <div style="margin-top: 20px; margin-left:10px; margin-right:10px; margin-bottom:10px">      
        <asp:DropDownList ID="drpDwnListChooseStudent" class="dropDownLists" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="LastName" DataValueField="StudentID" OnSelectedIndexChanged="drpDwnListChooseStudent_SelectedIndexChanged"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityConnectionString %>" SelectCommand="SELECT [StudentID], [LastName], [FirstName], [Address], [Phone], [Email], [EnrollmentDate] FROM [Students] ORDER BY [LastName], [FirstName]"></asp:SqlDataSource>
        &nbsp;
    </div>
    <div>
        <asp:ValidationSummary ID="ValidationSummary1" ShowModelStateErrors="true" runat="server" />
    </div>
    <div>
        <asp:PlaceHolder ID="PlaceHolderInputForm" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>