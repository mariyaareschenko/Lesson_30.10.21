using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_30._10._21
{
    class Worker
    {
        private string name;
        private string surname;
        private Task task;
        public Task Task
        {
            get { return task; }
        }
        public Worker(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
        public static void GiveTask(List<Worker> workers, List<Task> tasks)
        {
            var temp = new List<Task>();
            temp.AddRange(tasks);
            foreach(var worker in workers)
            {
                for(int i = 0; i < temp.Count; i++)
                {
                    Console.WriteLine("Задача:");
                    temp[i].Print();
                    Console.WriteLine("Сотрудник:");
                    Console.WriteLine(worker.Print());
                    Console.WriteLine("Берет ли сотрудник задачу? Да/Нет");
                    string answer = Console.ReadLine().ToLower();
                    while(!answer.Equals("да") && !answer.Equals("нет"))
                    {
                        Console.WriteLine("Повторите ответ");
                        answer = Console.ReadLine();

                    }
                    if (answer.Equals("да") ||  i == temp.Count-1)
                    {
                        worker.task = temp[i];
                        Task.ChangeTheStatus(worker, temp[i]);
                        Console.WriteLine("Сотрудник получил задачу");
                        temp.Remove(temp[i]);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Выберете другую задачу");
                    }
                }
            }
        }
        public string Print()
        {
            return $"{name}, {surname}";
        }
    }
}
