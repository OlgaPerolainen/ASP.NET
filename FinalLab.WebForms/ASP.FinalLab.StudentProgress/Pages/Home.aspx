<%@ Page Title="Все студенты" Language="C#" MasterPageFile="~/Pages/StudentSiteMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ASP.FinalLab.StudentProgress.Pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../SiteStyle/Style.css" />
    <div class=".panel" style="margin:10px; width:100%"">
        <table class="auto-style1">
            <tr>
                <td class="column1" style="width:10%;">
                    <asp:Label ForeColor="#999999" Font-Italic="True" runat="server">Введите фамилию&nbsp;</asp:Label>
                </td>
                <td class="column2" style="width:70%">
                    <asp:TextBox ID="txtBoxSearch" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSearch" Text="Найти" runat="server" CssClass="btn_choose_student_course" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td class="column1" colspan="3">
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
        </table>
    </div>
    <div style="margin: 5px">
        <ul class="student_cards_holder">
            <li>
                <table class="new_student_card">
                    <tr>
                        <td style="text-align:center">
                            <a href="NewStudentPage.aspx?new=1">
                                <img id="img_plus_sign" src="../Images/plus_sign.png">
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnNewStudent" text="Добавить нового студента" class="btn_grades" runat="server" OnClick="btnNewStudent_Click" />
                        </td>
                    </tr>
                </table>
            </li> 
            <li>               
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </li> 
        </ul>
    </div>
</asp:Content>