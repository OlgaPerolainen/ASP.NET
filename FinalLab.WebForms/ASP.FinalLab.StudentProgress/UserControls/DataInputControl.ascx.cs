using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.FinalLab.StudentProgress.Models;
using System.Data.Linq;
using System.Data.Entity;

namespace ASP.FinalLab.StudentProgress.UserControls
{
    public partial class DataInputControl : System.Web.UI.UserControl
    {
        // UserControl
        // Форма для заполнения или изменения информации о студентах
        // Для полей ввода реализована валидация данных RequiredFieldValidator и RegularExpressionValidator

        UniversityContext universityContext;

        public TextBox txtBoxLastName;
        public TextBox txtBoxFirstName;
        public TextBox txtBoxAddress;
        public TextBox txtBoxPhone;
        public TextBox txtBoxEmail;
        public TextBox txtBoxEnrollmentDate;
        public Label lblError;

        protected void Page_Load(object sender, EventArgs e)
        {
            universityContext = new UniversityContext();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {            
            // Выясняем, к какой странице относится экземпляр UserControl: регистрации нового студента или обновления информации
            // Если параметр не передается, то это регистрация нового студента
            // В противном случае - обновление данных существующего студента
            string redirectedPage = Request.QueryString["new"];

            // Регистрация нового студента
            if (redirectedPage != null && Int32.Parse(redirectedPage) == 1)
            {
                try
                {
                    universityContext.StudentsSet.Add(new Student
                    {
                        FirstName = txtBoxFirstName.Text,
                        LastName = txtBoxLastName.Text,
                        Address = txtBoxAddress.Text,
                        Phone = txtBoxPhone.Text,
                        Email = txtBoxEmail.Text,
                        EnrollmentDate = DateTime.Parse(txtBoxEnrollmentDate.Text)
                    });
                    universityContext.SaveChanges();

                    ClearInputForm();
                }
                catch (Exception)
                {
                    lblError.Visible = true;
                    lblError.Text = "Ошибка. Проверьте данные!";
                }
            }
            // Обновление данных существующего студента
            else
            {
                string studID = Request.QueryString["cardID"];
                Student student = new Student();
                int studentID = Int32.Parse(studID);
                student = universityContext.StudentsSet.Find(studentID);
                try
                {
                    student.LastName = txtBoxLastName.Text;
                    student.FirstName = txtBoxFirstName.Text;
                    student.Address = txtBoxAddress.Text;
                    student.Phone = txtBoxPhone.Text;
                    student.Email = txtBoxEmail.Text;
                    student.EnrollmentDate = DateTime.Parse(txtBoxEnrollmentDate.Text);

                    universityContext.Entry(student).State = EntityState.Modified;
                    universityContext.SaveChanges();

                    ClearInputForm();
                }
                catch (Exception)
                {
                    lblError.Visible = true;
                    lblError.Text = "Ошибка. Проверьте данные";
                }
            }
        }
        
        // Метод очищает все поля формы и для удобства заполняет поле "дата зачисления" текущей датой 
        private void ClearInputForm()
        {

            txtBoxFirstName.Text = "";
            txtBoxLastName.Text = "";
            txtBoxAddress.Text = "";
            txtBoxEmail.Text = "";
            txtBoxPhone.Text = "";
            lblError.Visible = false;
            txtBoxEnrollmentDate.Text = DateTime.Now.ToShortDateString();
        }
    }
}