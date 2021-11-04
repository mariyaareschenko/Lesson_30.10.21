using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_30._10._21
{
    public enum Status_project
    {
        Project, InProcess, Completed
    }
    class Project
    {
        private string description;
        private DateTime date;
        private Customer customer;
        List<Task> tasks;
        private Status_project status;
        public Project(string description, DateTime date, Employer employer, Customer customer)
        {
            this.description = description;
            this.date = date;
            status = Status_project.Project;

        }
        public void AddTasksInProject(List<Task> tasks)
        {
            if (tasks != null && this.tasks != null)
            {
                this.tasks = tasks;
            }
        }
        public void CloseProject()
        {
            status = Status_project.Completed;
            if (date < DateTime.Now)
            {
                Console.WriteLine("Проект просрочен");

            }
            else
            {
                Console.WriteLine("Проект успешно завершен");
            }
        }
    }   
}
