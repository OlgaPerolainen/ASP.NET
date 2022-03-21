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
        string studID;
        UniversityContext universityContext;
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
                studID = Request.QueryString["cardID"];
                if (studID != null)
                {
                    drpDwnListStudent.SelectedValue = studID;
                }
            }
        }

        // Кнопка "Показать все оценки"
        // Вывод на форму всех оценок студента по всем курсам
        protected void btnAllGrades_Click(object sender, EventArgs e)
        {          
            int studentID = Int32.Parse(drpDwnListStudent.SelectedValue);
            StringBuilder html = new StringBuilder();

            var courses = universityContext.CourseSet;
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

        // Кнопка "Оценка за курс"
        // Поиск и вывод на форму оценки конкретного студента по конкретуному курсу
        protected void btn_ChooseCourse_Click(object sender, EventArgs e)
        {
            int studentID = Int32.Parse(drpDwnListStudent.SelectedValue);
            int courseID = Int32.Parse(drpDwnListCourse.SelectedValue);

            var courses = universityContext.CourseSet;
            StringBuilder html = new StringBuilder();

            var grades = from gr in universityContext.GradesSet.Where(gr => gr.StudentID == studentID && gr.CourseID == courseID)
                         join c in universityContext.CourseSet on gr.CourseID equals c.CourseId
                         select new { Score = gr.Grade, CourseName = c.CourseName };

            foreach (var grade in grades)
            {
                html.Append(String.Format("{0}: {1}", grade.CourseName, grade.Score));
            }

            frmInfo.InnerHtml = html.ToString();
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
            StringBuilder html = new StringBuilder();

            var studentGrades = universityContext.StudentsSet.GroupJoin(universityContext.GradesSet, st => st.StudentId, gr => gr.StudentID,
                (st, grds) => new
                {
                    name = st.LastName,
                    totalScores = grds.Sum(gr => gr.Grade)
                }).OrderByDescending(grds => grds.totalScores).Take(5);

            foreach(var grade in studentGrades)
            {
                html.Append(String.Format("<li>{0}: {1}</li>", grade.name, grade.totalScores));
            }

            frmInfo.InnerHtml = html.ToString();
        }

        // Кнопка "Пять худших студентов"
        protected void btn_FiveWorstStudents_Click(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();

            var studentGrades = universityContext.StudentsSet.GroupJoin(universityContext.GradesSet, st => st.StudentId, gr => gr.StudentID,
                (st, grds) => new
                {
                    name = st.LastName,
                    totalScores = grds.Sum(gr => gr.Grade)
                }).OrderBy(grds => grds.totalScores).Take(5);

            foreach (var grade in studentGrades)
            {
                html.Append(String.Format("<li>{0}: {1}</li>", grade.name, grade.totalScores));
            }

            frmInfo.InnerHtml = html.ToString();
        }
    }
}