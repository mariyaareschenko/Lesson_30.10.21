using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_30._10._21
{
    class Report
    {
        private string text;
        private DateTime date;
        private Worker worker;
        public Report(Worker worker, string text)
        {
            this.worker = worker;
            this.text = text;
        }
        public static Report CreateReport(Worker worker)
        {
            Console.WriteLine("Напишите отчет");
            string text = Console.ReadLine();
            Task.StatusReport(worker);
            return new Report(worker, text);
        }
        public void Print()
        {
            Console.WriteLine($"{text}");
        }
    }
}
