using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.FinalLab.StudentProgress.Models;
using System.Text;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;

namespace ASP.FinalLab.StudentProgress.Pages
{
    public partial class GradesPage : System.Web.UI.Page
    {
        // Страница, посвященная успеваемости студентов.
        // Позволяет посмотреть оценки студента по всем предметам или по одному конкретному,
        // узнать сумму всех баллов студента,
        // а также изменить оценки или добавить их
        // В поле ввода быллов реализована валидация введенного значения RangeValidator
        // Здесь можно посмотреть список пяти лучших и худших студентов

        UniversityContext universityContext;
        bool showAllGrades = false;
        bool getBests = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            universityContext = new UniversityContext();

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
                    drpDwnListStudent.SelectedValue = studID;
                }
            }
        }

        // Кнопка "Показать все оценки"
        // Вывод на форму всех оценок студента по всем курсам
        protected void btnAllGrades_Click(object sender, EventArgs e)
        {
            showAllGrades = true;
            GetScores(showAllGrades);        
        }

        // Кнопка "Оценка за курс"
        // Поиск и вывод на форму оценки конкретного студента по конкретному курсу
        protected void btn_ChooseCourse_Click(object sender, EventArgs e)
        {
            showAllGrades = false;
            GetScores(showAllGrades);
        }
       
        // Кнопка "Изменить"
        // Добавляет, удаляет, изменяет оценку студента по выбранному курсу
        protected void btnAddGrade_Click(object sender, EventArgs e)
        {
            int studentID = Int32.Parse(drpDwnListStudent.SelectedValue);
            int courseID = Int32.Parse(drpDwnListCourse.SelectedValue);
            var grade = universityContext.GradesSet.Find(studentID, courseID);

            if (grade == null)
            {
                // Добавление новой оценки
                try
                {
                    universityContext.GradesSet.Add(new Grades
                    {
                        StudentID = studentID,
                        CourseID = courseID,
                        Grade = Decimal.Parse(txtBoxGrade.Text)
                    });
                    universityContext.SaveChanges();
                }
                catch (Exception)
                {
                    frmInfo.InnerText = "Ошибка. Проверьте данные!";
                }
            }
            else
            {
                // Изменение или удаление существующей оценки
                try
                {
                    grade.Grade = Decimal.Parse(txtBoxGrade.Text);
                    universityContext.Entry(grade).State = EntityState.Modified;
                    universityContext.SaveChanges();
                }
                catch (Exception)
                {
                    frmInfo.InnerText = "Ошибка. Проверьте данные!";
                }
            }

            StringBuilder html = new StringBuilder();

            var grades = from gr in universityContext.GradesSet.Where(gr => gr.StudentID == studentID)
                         join c in universityContext.CourseSet on gr.CourseID equals c.CourseId
                         orderby c.CourseName
                         select new { Score = gr.Grade, CourseName = c.CourseName };

            foreach (var score in grades)
            {
                html.Append(String.Format("<li>{0}: {1}</li>", score.CourseName, score.Score));
            }
            frmInfo.InnerHtml = html.ToString();
        }

        // Кнопка "Общий балл"
        // Подсчет и вывод на форму обшего количества баллов студента
        protected void btnTotalScore_Click(object sender, EventArgs e)
        {
            decimal allGrades = 0;
            int studentID = Int32.Parse(drpDwnListStudent.SelectedValue);
            var courses = universityContext.CourseSet;
            var grades = universityContext.GradesSet.Where(gr => gr.StudentID == studentID);

            foreach (var grade in grades)
            {
                allGrades += (decimal)grade.Grade;
            }

            frmInfo.InnerHtml = String.Format("Всего баллов: ") + allGrades.ToString();
        }

        // Кнопка "Пять лучших студентов"
        protected void btn_FiveBestStudents_Click(object sender, EventArgs e)
        {
            getBests = true;
            GetFiveBestsOrWorsts(getBests);
        }

        // Кнопка "Пять худших студентов"
        protected void btn_FiveWorstStudents_Click(object sender, EventArgs e)
        {
            getBests = false;
            GetFiveBestsOrWorsts(getBests);
        }
        
        // Метод поиска и вывода оценок для конкретного студента либо по всем курсам, либо по одному выбранному
        private void GetScores(bool allGrades)
        {
            int studentID = Int32.Parse(drpDwnListStudent.SelectedValue);
            StringBuilder html = new StringBuilder();
            var courses = universityContext.CourseSet;

            // Поиск и вывод всех оценов
            if (allGrades)
            {
                var grades = from gr in universityContext.GradesSet.Where(gr => gr.StudentID == studentID)
                             join c in universityContext.CourseSet on gr.CourseID equals c.CourseId
                             orderby c.CourseName
                             select new { Score = gr.Grade, CourseName = c.CourseName };
                foreach (var grade in grades)
                {
                    html.Append(String.Format("<li>{0}: {1}</li>", grade.CourseName, grade.Score));
                }
                frmInfo.InnerHtml = html.ToString();
            }

            // Поиск и вывод оценки по определенному предмету
            else
            {
                int courseID = Int32.Parse(drpDwnListCourse.SelectedValue);
                var grades = from gr in universityContext.GradesSet.Where(gr => gr.StudentID == studentID && gr.CourseID == courseID)
                             join c in universityContext.CourseSet on gr.CourseID equals c.CourseId
                             select new { Score = gr.Grade, CourseName = c.CourseName };
                foreach (var grade in grades)
                {
                    html.Append(String.Format("{0}: {1}", grade.CourseName, grade.Score));
                }
                frmInfo.InnerHtml = html.ToString();
            }
        }

        // Метод поиска и вывода пяти лучших и худших студентов
        private void GetFiveBestsOrWorsts(bool getBests)
        {
            StringBuilder html = new StringBuilder();

            var studentGrades = universityContext.StudentsSet.GroupJoin(universityContext.GradesSet, st => st.StudentId, gr => gr.StudentID,
                (st, grds) => new
                {
                    firstName = st.FirstName,
                    lastName = st.LastName,
                    totalScores = grds.Sum(gr => gr.Grade)
                });
            if (getBests)
            {
                foreach (var grade in studentGrades.OrderByDescending(grds => grds.totalScores).Take(5))
                {
                    html.Append(String.Format("<li>{0} {1}: {2}</li>", grade.lastName, grade.firstName, grade.totalScores));
                }
            }
            else
            {
                foreach (var grade in studentGrades.OrderBy(grds => grds.totalScores).Take(5))
                {
                    html.Append(String.Format("<li>{0} {1}: {2}</li>", grade.lastName, grade.firstName, grade.totalScores));
                }
            }
            frmInfo.InnerHtml = html.ToString();
        }
    }
}