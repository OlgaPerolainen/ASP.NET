using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.FinalLab.StudentProgress.Models;
using System.Data.Entity;

namespace ASP.FinalLab.StudentProgress.UserControls
{
    
    public partial class StudentInfo : System.Web.UI.UserControl
    {
        // UserControl
        // Личная карточка студента

        public UniversityContext UniversityContextCard { get; set; }
        public int CardID { get ; set; }
        public Label LastName;
        public Label FirstName;
        public Label Address;
        public Label Phone;
        public Label Email;
        public Label EnrollmentDate;

        public Button UpdateStudent;
        public Button DeleteStudent;
        public Button Grades;

        protected void Page_Load(object sender, EventArgs e)
        {
            UniversityContextCard = new UniversityContext();
        }

        // Кнопка "Изменить данные"
        // Переход на соответствующею страницу с передачей параметра ID студента
        protected void UpdateStudent_Click(object sender, EventArgs e)
        {    
            Response.Redirect("~/Pages/UpdateStudentInfo.aspx?cardID=" + CardID.ToString());
        }
        
        // Кнопка "Удалить"
        // Поиск студента по его ID и удаление сведений
        protected void DeleteStudent_Click(object sender, EventArgs e)
        {
            var student = UniversityContextCard.StudentsSet.Find(CardID);
            UniversityContextCard.Entry(student).State = EntityState.Deleted;
            UniversityContextCard.SaveChanges();

            // Обновляение страницы
            Page.Response.Redirect(Page.Request.Url.ToString());
        }

        // Кнопка "Успеваемость"
        // Переход на соответствующею страницу с передачей параметра ID студента
        protected void Grades_Click(object sender, EventArgs e)
        {      
            Response.Redirect("~/Pages/GradesPage.aspx?cardID=" + CardID.ToString());
        }
    }
}