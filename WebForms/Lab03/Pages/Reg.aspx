<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="RSVP.Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../ex1/Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>
