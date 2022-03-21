using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.FinalLab.StudentProgress.UserControls;
using System.Data.Entity;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using ASP.FinalLab.StudentProgress.Models;
using ASP.FinalLab.StudentProgress.Pages;
using System.Text;

namespace ASP.FinalLab.StudentProgress.Pages
{
    public partial class UpdateStudentInfo : System.Web.UI.Page
    {
        UniversityContext universityContext;
        public DropDownList drpDwnListChooseStudent;
        public DataInputControl inputForm;

        protected void Page_Load(object sender, EventArgs e)
        {
            universityContext = new UniversityContext();

            // Загрузка формы для заполнения
            inputForm = (DataInputControl)Page.LoadControl(@"../UserControls/DataInputControl.ascx");

            if (IsPostBack)
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;                
            }
            else
            {   
                // Проверка наличия входного параметра ID студента
                string studID = Request.QueryString["cardID"];
                if (studID != null)
                {
                    // Выбор соответствующего студента
                    drpDwnListChooseStudent.SelectedValue = studID;
                    int studentID = Int32.Parse(studID);
                    Student student = new Student();
                    student = universityContext.StudentsSet.Find(studentID);
                    FillInputForm(student);
                }
            }
            // Вывод формы с имеющимися данными
            PlaceHolderInputForm.Controls.Add(inputForm);
        }

        // Метод записывает имющиеся данные в поля формы
        private void FillInputForm(Student neededStudent)
        {
            inputForm.txtBoxLastName.Text = neededStudent.LastName;
            inputForm.txtBoxFirstName.Text = neededStudent.FirstName;
            inputForm.txtBoxAddress.Text = neededStudent.Address;
            inputForm.txtBoxPhone.Text = neededStudent.Phone;
            inputForm.txtBoxEnrollmentDate.Text = neededStudent.EnrollmentDate.ToShortDateString();


            if (neededStudent.Email != null)
            {
                inputForm.txtBoxEmail.Text = neededStudent.Email;
            }
            else
            {
                inputForm.txtBoxEmail.Text = "";
            }
        }

        // Выпадающий список
        // Передача нового параметра для автоматического заполнения формы
        protected void drpDwnListChooseStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            int studentID = Int32.Parse(drpDwnListChooseStudent.SelectedValue);
            Response.Redirect("~/Pages/UpdateStudentInfo.aspx?cardID=" + studentID.ToString());
        }
    }
}