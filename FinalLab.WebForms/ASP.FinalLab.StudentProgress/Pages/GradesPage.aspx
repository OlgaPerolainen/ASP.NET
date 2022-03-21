<%@ Page Title="Успеваемость" Language="C#" MasterPageFile="~/Pages/StudentSiteMaster.Master" AutoEventWireup="true" CodeBehind="GradesPage.aspx.cs" Inherits="ASP.FinalLab.StudentProgress.Pages.GradesPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../SiteStyle/Style.css" />
    <div class=".panel" style="margin:15px">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <table>
            <tr>
                <td class="column1"><label>Студент:</label></td>
                <td class="column2" style="width:70%"><asp:DropDownList ID="drpDwnListStudent" class="dropDownLists" runat="server" DataSourceID="SqlDataSource1" DataTextField="LastName" DataValueField="StudentID"></asp:DropDownList>                  
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityConnectionString %>" SelectCommand="SELECT [StudentID], [LastName] FROM [Students] ORDER BY [LastName]"></asp:SqlDataSource>                  
                </td>
                <td class="column1" >
                    <asp:Button ID="btnAllGrades" Text="Показать все оценки" CssClass="btn_choose_student_course" runat="server" OnClick="btnAllGrades_Click" /></td>
                <td class="column2">
                    <asp:Button ID="btnTotalScore" Text="Общий балл" CssClass="btn_choose_student_course" runat="server" OnClick="btnTotalScore_Click" /></td>
            </tr>
            <tr>
                <td class="column1"><label>Курс:</label></td>
                <td class="column2"><asp:DropDownList ID="drpDwnListCourse" class="dropDownLists" runat="server" DataSourceID="SqlDataSource2" DataTextField="CourseName" DataValueField="CourseID" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityConnectionString %>" SelectCommand="SELECT [CourseID], [CourseName] FROM [Courses] ORDER BY [CourseName]"></asp:SqlDataSource>
                </td>
                <td colspan="2" class="column1"><asp:Button ID="btn_ChooseCourse" Text="Оценка за курс" CssClass="btn_choose_student_course" runat="server" OnClick="btn_ChooseCourse_Click" /></td>
            </tr>
            <tr>
                <td class="column1"><label>Балл:</label></td>  
                <td class="column4"><asp:TextBox ID="txtBoxGrade" CssClass="txtBoxGrade" runat="server"></asp:TextBox>
                <asp:RangeValidator ID="RangeValidatorGrade"
                    MinimumValue="0" 
                    MaximumValue="10"
                    Type="Double"
                    ControlToValidate="txtBoxGrade"                    
                    ErrorMessage="Неверный диапазон"
                    Font-Italic="true" 
                    ForeColor="Maroon" 
                    runat="server">Неверный диапазон</asp:RangeValidator>
                </td>
                <td colspan="2" class="column1"><asp:Button ID="btnAddGrade" Text="Изменить" CssClass="btn_choose_student_course" runat="server" OnClick="btnAddGrade_Click" /></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align:center">
                     <ul class="statistics">
                        <li>
                            <asp:Button ID="btn_FiveBestStudents" Text="Пять лучших студентов" CssClass="btn_grade_statistics" runat="server" OnClick="btn_FiveBestStudents_Click" />
                        </li>
                        <li>
                            <asp:Button ID="btn_FiveWorstStudents" Text="Пять худших студентов" CssClass="btn_grade_statistics" runat="server" OnClick="btn_FiveWorstStudents_Click" />
                        </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td style="margin:15px" colspan="4">
                    <div ID="frmInfo" class="panel" runat="server">
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>