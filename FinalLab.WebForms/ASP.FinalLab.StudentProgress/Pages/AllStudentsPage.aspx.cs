using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.FinalLab.StudentProgress.Models;
using ASP.FinalLab.StudentProgress.UserControls;
using System.Data.Linq;
using System.Data.Entity;
using System.Text;

namespace ASP.FinalLab.StudentProgress.Pages
{
    public partial class AllStudentsPage : System.Web.UI.Page
    {
        UniversityContext universityContext = new UniversityContext();
        StudentInfo studentCard;
        public TextBox txtBoxSearch;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Отображение на странице карточек всех студентов из базы данных в алфавитном порядке
            var students = universityContext.StudentsSet.OrderBy(st => st.LastName).ThenBy(st => st.FirstName);

            foreach (var student in students)
            {
                FillStudentCard(student);
                studentCard.DeleteStudent.Visible = true;
                studentCard.UpdateStudent.Visible = true;
                studentCard.Grades.Visible = true;
            }

        }

        // Кнопка "Добавить нового студента"
        // Переход на соответствующую страницу
        protected void btnNewStudent_Click(object sender, EventArgs e)
        {           
            Response.Redirect("~/Pages/NewStudentPage.aspx?new=1");
        }

        // Кнопка "Найти"
        // Поиск по фамилии
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == "" || txtBoxSearch.Text == "Введите фамилию")
            {
                return;
            }
            else
            {
                PlaceHolder1.Controls.Clear();

                var students = universityContext.StudentsSet;
                foreach (Student student in students.Where(st => st.LastName.StartsWith(txtBoxSearch.Text)).OrderBy(st => st.LastName).ThenBy(st => st.FirstName))
                {
                    FillStudentCard(student);
                }
            }
        }

        // Заполнение карточки студента личными сведениями
        private void FillStudentCard(Student student)
        {
            studentCard = (StudentInfo)Page.LoadControl(@"../UserControls/StudentInfo.ascx");

            studentCard.CardID = student.StudentId;
            studentCard.LastName.Text = student.LastName;
            studentCard.FirstName.Text = student.FirstName;
            studentCard.Address.Text = student.Address;
            studentCard.Phone.Text = student.Phone;
            studentCard.EnrollmentDate.Text = student.EnrollmentDate.ToShortDateString();
            if (student.Email != null)
            {
                studentCard.Email.Text = student.Email;
            }
            else
            {
                studentCard.Email.Text = "";
            }
            PlaceHolder1.Controls.Add(studentCard);
        }

        // Кнопка "Пять лучших студентов"
        // Вывод списка
        protected void btn_FiveBestStudents_Click(object sender, EventArgs e)
        {
            PlaceHolder1.Controls.Clear();

            var studentGrades = universityContext.StudentsSet.GroupJoin(universityContext.GradesSet, st => st.StudentId, gr => gr.StudentID,
                            (st, grds) => new
                            {
                                id = st.StudentId,
                                totalScores = grds.Sum(gr => gr.Grade)
                            }).OrderByDescending(grds => grds.totalScores).Take(5);

            foreach (var student in studentGrades)
            {
                var bestStudent = universityContext.StudentsSet.Find(student.id);
                FillStudentCard(bestStudent);
                studentCard.DeleteStudent.Visible = false;
                studentCard.UpdateStudent.Visible = false;
                studentCard.Grades.Visible = false;
            }
        }

        // Кнопка "Пять худших студентов"
        // Вывод списка
        protected void btn_FiveWorstStudents_Click(object sender, EventArgs e)
        {
            PlaceHolder1.Controls.Clear();
            var studentGrades = universityContext.StudentsSet.GroupJoin(universityContext.GradesSet, st => st.StudentId, gr => gr.StudentID,
                (st, grds) => new
                {
                    id = st.StudentId,
                    totalScores = grds.Sum(gr => gr.Grade)
                }).OrderBy(grds => grds.totalScores).Take(5);

            foreach (var student in studentGrades)
            {
                var wostStudent = universityContext.StudentsSet.Find(student.id);
                FillStudentCard(wostStudent);
                studentCard.DeleteStudent.Visible = false;
                studentCard.UpdateStudent.Visible = false;
                studentCard.Grades.Visible = false;
            }
        }
    }
}