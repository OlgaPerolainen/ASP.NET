using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RSVP
{
    public partial class Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Проверяем,  загружается ли форма в ответ на обратный запрос клиента
            if (IsPostBack)
            {
                Page.Validate();
                if(!Page.IsValid)
                {
                    return;
                }
                // Создаем экземпляр объекта GuestResponse с полученными от элементов формы данными
                GuestResponse rsvp = new GuestResponse(txtBoxName.Text, txtBoxEmail.Text, txtBoxPhone.Text, CheckBoxYN.Checked);
                
				// Помещаем созданный экземпляр в хранилище
                ResponseRepository.GetRepository().AddResponse(rsvp);

                // Проверяем, будет ли пользователь выступать с докладом
                // Предоставляем ответ в зависимости от этого
                if (rsvp.WillAttend.HasValue && rsvp.WillAttend.Value)
                {
                    Response.Redirect(@"..\Responses.Html\seeyouthere.html");
                }
                else
                {
                    Response.Redirect(@"..\Responses.Html\sorryyoucantperform.html");
                }
            }
        }
    }
}