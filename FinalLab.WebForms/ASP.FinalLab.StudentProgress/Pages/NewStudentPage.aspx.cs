using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.FinalLab.StudentProgress.UserControls;
using ASP.FinalLab.StudentProgress.Models;

namespace ASP.FinalLab.StudentProgress.Pages
{
    public partial class NewStudentPage : System.Web.UI.Page
    {
        // Страница позволяет зарегистрировать нового студента
        // На ней отображается UserControl DataInputControl в виде формы с полями.
        // Для полей ввода реализована валидация данных RequiredFieldValidator и RegularExpressionValidator

        UniversityContext universityContext = new UniversityContext();
        DataInputControl inputForm;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Загрузка формы для регистрации (экземпляр DataInputControl) нового студента
            inputForm = (DataInputControl)Page.LoadControl(@"../UserControls/DataInputControl.ascx");
            PlaceHolder1.Controls.Add(inputForm);

            if (IsPostBack)
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
            }
            inputForm.txtBoxEnrollmentDate.Text = DateTime.Now.ToShortDateString();
        }
    }
}