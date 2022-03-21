<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataInputControl.ascx.cs" Inherits="ASP.FinalLab.StudentProgress.UserControls.DataInputControl" %>

<table class="formDataInput">
    <tr>
        <td class="column1"><label>Фамилия:</label></td>
        <td class="column2">
            <asp:TextBox ID="txtBoxLastName" runat="server"></asp:TextBox>
        </td>
        <td class="column2">
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastName" 
                ControlToValidate="txtBoxLastName" 
                ErrorMessage="Укажите фамилию" 
                Font-Italic="true" 
                ForeColor="Maroon" 
                runat="server">Заполните поле</asp:RequiredFieldValidator>
        </td>        
    </tr>
    <tr>
        <td class="column1"><label>Имя:</label></td>
        <td class="column2">
            <asp:TextBox ID="txtBoxFirstName" runat="server"></asp:TextBox>
        </td>
        <td class="column2">    
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFirstName"
                ControlToValidate="txtBoxFirstName"
                ErrorMessage="Укажите имя" 
                Font-Italic="true" 
                ForeColor="Maroon" 
                runat="server">Заполните поле</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="column1"><label>Адрес:</label></td>
        <td class="column2">
            <asp:TextBox ID="txtBoxAddress" runat="server"></asp:TextBox>
        </td>
        <td class="column2">            
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" 
                ControlToValidate="txtBoxAddress" 
                ErrorMessage="Укажите адрес" 
                Font-Italic="true" 
                ForeColor="Maroon" 
                runat="server">Заполните поле</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="column1"><label>Телефон:</label></td>
        <td class="column2">
            <asp:TextBox ID="txtBoxPhone" runat="server"></asp:TextBox>
        </td>
        <td class="column2">         
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPhone" 
                ControlToValidate="txtBoxPhone" 
                ErrorMessage="Укажите телефон" 
                Font-Italic="true" 
                ForeColor="Maroon" 
                runat="server">Заполните поле</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="column1"><label>Почта:</label></td>
        <td class="column2">
            <asp:TextBox ID="txtBoxEmail" runat="server"></asp:TextBox>       
        </td>
        <td class="column2">
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" 
                ControlToValidate="txtBoxEmail" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                ErrorMessage="Неверный формат почты" 
                Font-Italic="true"
                ForeColor="Maroon" 
                runat="server">Неверный формат</asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="column1"><label>Дата зачисления:</label></td>
        <td class="column2">
            <asp:TextBox ID="txtBoxEnrollmentDate" ForeColor="#999999" runat="server"></asp:TextBox>
        </td>
        <td class="column2">            
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEnrollDate"
                ControlToValidate="txtBoxEnrollmentDate"
                ErrorMessage="Укажите дату зачисления" 
                Font-Italic="true" 
                ForeColor="Maroon" 
                runat="server">Заполните поле</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr style="text-align:center">
        <td class="column1"><asp:Label ID="lblError" runat="server" Text="" Visible="false"></asp:Label></td>
        <td class="column1">
            <asp:Button ID="btnSubmit" CssClass="btn_SubmitForm" type="submit" runat="server" text="Готово" OnClick="btnSubmit_Click"/></td>
        <td>
        </td>
    </tr>
</table>