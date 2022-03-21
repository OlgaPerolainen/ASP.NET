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
        UniversityContext universityContext = new UniversityContext();
        DataInputControl inputForm;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Загрузка формы для заполнения
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