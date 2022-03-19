<%@ Page Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"  CodeBehind="Reg.aspx.cs" Inherits="RSVP.Reg" UnobtrusiveValidationMode="None"%>

<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Приглашаем на семинар</h1>
        <p></p>
    </div>
    <div>
        <asp:ValidationSummary ID="validationSummary" runat="server" ShowModelStateErrors="true"/>
        <label>Ваше имя:</label><asp:TextBox id="txtBoxName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ControlToValidate="txtBoxName"
            ErrorMessage="Введите имя"
            ForeColor="Red">Не оставляйте поле пустым</asp:RequiredFieldValidator>
    </div>
    <div>
        <label>Ваш email:</label><asp:TextBox id="txtBoxEmail" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtBoxEmail"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ErrorMessage="Неверный формат электронной почты"
            Display="Dynamic"
            ForeColor="Red">Неверный формат</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
            ControlToValidate="txtBoxEmail"
            ErrorMessage="Введите электронную почту"
            ForeColor="Red">Не оставляйте поле пустым</asp:RequiredFieldValidator>
    </div>
    <div>
        <label>Ваш телефон:</label><asp:TextBox id="txtBoxPhone" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
            ControlToValidate="txtBoxPhone"
            ErrorMessage="Введите телефон"
            ForeColor="Red">Не оставляйте поле пустым</asp:RequiredFieldValidator>
    </div>
    <div>
        <label>Вы будете делать доклад?</label>
        <asp:CheckBox id="CheckBoxYN" runat="server" />
    </div>
    <div>
        <button id="btnSubmit" type="submit">Отправить ответ на приглашение</button>
    </div>
</asp:Content>