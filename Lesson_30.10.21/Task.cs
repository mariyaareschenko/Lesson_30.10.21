using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_30._10._21
{
    public enum Status_task
    {
        Appointed, InWorker, OnCheck, Completed
    }
    class Task
    {
        private string description;
        private DateTime date;
        private Employer employer;
        private Worker worker;
        private Status_task status;
        public Task(string description, Employer employer)
        {
            this.description = description;
            this.employer = employer;
            status = Status_task.Appointed;
        }
        public Worker Worker
        {
            get { return worker; }
            private set { worker = value; }
        }
        public static void ChangeTheStatus(Worker worker, Task task)
        {
            if(worker.Task != null && worker.Task.status == Status_task.Appointed)
            {
                worker.Task.status = Status_task.InWorker;
                task.Worker = worker;
            }
        }
        public void Print()
        {
            Console.WriteLine($"Задача: {description}. Cрок: {date}");
        }
        public static void StatusReport(Worker worker)
        {
            if(worker.Task.status == Status_task.InWorker)
            {
                worker.Task.status = Status_task.OnCheck;
            }
        }
        public static void CloseTask(Worker worker)
        {
            if(worker.Task.status == Status_task.OnCheck)
            {
                worker.Task.status = Status_task.Completed;
            }
        }
    }
}
