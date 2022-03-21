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
    public partial class Home : System.Web.UI.Page
    {
        // Главная страница
        // На ней отображаются карточки всех студентов из базы данных в алфавитном порядке
        // На личной карточке указана информация о студента,
        // также с нее можно перейти на страницу изменения данных и успеваемости
        // Здесь можно посмотреть личные карточки пяти лучших и худших студентов

        UniversityContext universityContext = new UniversityContext();
        StudentInfo studentCard;
        public TextBox txtBoxSearch;
        bool showButtons = false;
        bool searchForBestsStudents = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Обращение к базе данных для заполнения и отображения карточек всех студентов в алфавитном порядке
            if (!IsPostBack)
            {
                universityContext = new UniversityContext();
            }
            var students = universityContext.StudentsSet.OrderBy(st => st.LastName).ThenBy(st => st.FirstName);

            foreach (var student in students)
            {
                // Обращение к методу заполнения карточки студента
                FillStudentCard(student);
                showButtons = true;
                ShowButtons(showButtons);
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

                var students = universityContext.StudentsSet;
                PlaceHolder1.Controls.Clear();
                foreach (Student student in students.Where(st => st.LastName.StartsWith(txtBoxSearch.Text))
                    .OrderBy(st => st.LastName).ThenBy(st => st.FirstName))
                {
                    // Обращение к методу заполнения карточки студента
                    FillStudentCard(student);
                }
            }
        }
        
        // Кнопка "Пять лучших студентов"
        // Вывод списка
        protected void btn_FiveBestStudents_Click(object sender, EventArgs e)
        {
            searchForBestsStudents = true;
            GetBestsOrWorstsStudents(searchForBestsStudents);
        }

        // Кнопка "Пять худших студентов"
        // Вывод списка
        protected void btn_FiveWorstStudents_Click(object sender, EventArgs e)
        {
            searchForBestsStudents = false;
            GetBestsOrWorstsStudents(searchForBestsStudents);
        }

        
        // Метод заполняет карточки студента личными сведениями
        private void FillStudentCard(Student student)
        {
            studentCard = (StudentInfo)Page.LoadControl(@"../UserControls/StudentInfo.ascx");

            studentCard.UniversityContextCard = universityContext;
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

        // Метод скрывает или показывает кнопки на карточке студента
        private void ShowButtons(bool yes)
        {
            if (yes)
            {
                studentCard.DeleteStudent.Visible = true;
                studentCard.UpdateStudent.Visible = true;
                studentCard.Grades.Visible = true;
            }
            else
            {
                studentCard.DeleteStudent.Visible = false;
                studentCard.UpdateStudent.Visible = false;
                studentCard.Grades.Visible = false;
            }
        }

        // Метод вычисления и вывода пяти лучших или худших студентов
        private void GetBestsOrWorstsStudents(bool bests)
        {
            PlaceHolder1.Controls.Clear();

            var studentGrades = universityContext.StudentsSet
                    .GroupJoin(universityContext.GradesSet, st => st.StudentId, gr => gr.StudentID,
                    (st, grds) => new
                    {
                        id = st.StudentId,
                        totalScores = grds.Sum(gr => gr.Grade)
                    });
            if (bests)
            {
                foreach (var student in studentGrades.OrderByDescending(grds => grds.totalScores).Take(5))
                {
                    var neededStudent = universityContext.StudentsSet.Find(student.id);
                    FillStudentCard(neededStudent);
                    showButtons = false;
                    ShowButtons(showButtons);
                }
            }
            else
            {
                foreach (var student in studentGrades.OrderBy(grds => grds.totalScores).Take(5))
                {
                    var neededStudent = universityContext.StudentsSet.Find(student.id);
                    FillStudentCard(neededStudent);
                    showButtons = false;
                    ShowButtons(showButtons);
                }
            }
        }       
    }
}