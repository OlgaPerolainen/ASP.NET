<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentInfo.ascx.cs" Inherits="ASP.FinalLab.StudentProgress.UserControls.StudentInfo" %>

<table class="user_control_table">
    <tr>
        <td colspan="2">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityConnectionString %>" SelectCommand="SELECT [LastName], [FirstName], [Address], [Phone], [Email], [EnrollmentDate] FROM [Student]"></asp:SqlDataSource>
            <p>Фамилия: <asp:Label ID="LastName" runat="server"></asp:Label></p>
            <p>Имя: <asp:Label ID="FirstName" runat="server"></asp:Label></p>
            <p>Адрес: <asp:Label ID="Address" runat="server"></asp:Label></p>
            <p>Телефон: <asp:Label ID="Phone" runat="server"></asp:Label></p>
            <p>Почта: <asp:Label ID="Email" runat="server"></asp:Label></p>
            <p>Дата зачисления: <asp:Label ID="EnrollmentDate" runat="server"></asp:Label></p>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="UpdateStudent" text="Изменить данные" class="btns_update_delete" runat="server" OnClick="UpdateStudent_Click" />
        </td>
        <td>
            <asp:Button ID="DeleteStudent" text="Удалить" class="btns_update_delete" runat="server" OnClick="DeleteStudent_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="Grades" text="Успеваемость" class="btn_grades" runat="server" OnClick="Grades_Click" />
        </td>
    </tr>
</table>