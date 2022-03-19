<%@ Page Language="C#" MasterPageFile="~/ex2.WebFormWithMasterPage/Site.Master" AutoEventWireup="true"  CodeBehind="Reg.aspx.cs" Inherits="RSVP.Reg" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Приглашаем на семинар</h1>
        <p></p>
    </div>
    <div>
        <label>Ваше имя:</label><asp:TextBox id="txtBoxName" runat="server"></asp:TextBox>
    </div>
    <div>
        <label>Ваш email:</label><asp:TextBox id="txtBoxEmail" runat="server"></asp:TextBox>
    </div>
    <div>
        <label>Ваш телефон:</label><asp:TextBox id="txtBoxPhone" runat="server"></asp:TextBox>
    </div>
    <div>
        <label>Вы будете делать доклад?</label>
        <asp:CheckBox id="CheckBoxYN" runat="server" />
    </div>
    <div>
        <button id="btnSubmit" type="submit">Отправить ответ на приглашение</button>
    </div>
</asp:Content>