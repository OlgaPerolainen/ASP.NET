<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summary01.aspx.cs" Inherits="RSVP.Summary01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Участники семинара</title>
    <link rel="stylesheet" href="Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Приглашения</h2>
            <h3>Выступающие с докладом: </h3>
            <table>
                <thead>
                    <tr>
                        <th>Имя</th>
                        <th>Email</th>
                        <th>Телефон</th>
                        <th>Дата</th>
                    </tr>
                </thead>
                <tbody>
                    <% var yesData = RSVP.ResponseRepository.GetRepository().GetAllResponses().Where(r => r.WillAttend.Value);
                        foreach(var rsvp in yesData)
                        {
                            string htmlString = String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>", rsvp.Name, rsvp.Email, rsvp.Phone, rsvp.RegDate);
                            Response.Write(htmlString);
                        }
                        %>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
