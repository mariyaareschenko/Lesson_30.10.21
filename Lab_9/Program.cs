using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 9.1");
            BankAccount account1 = new BankAccount();
            BankAccount account2 = new BankAccount(AccountType.Savings);
            BankAccount account3 = new BankAccount(1000);
            BankAccount account4 = new BankAccount(AccountType.Actual, 5000);
            account1.PrintValues();
            Console.WriteLine();
            account2.PrintValues();
            Console.WriteLine();
            account3.PrintValues();
            Console.WriteLine();
            account4.PrintValues();
            Console.WriteLine();

            Console.WriteLine("Упражнение 9.2");
            Console.WriteLine("Перевод денег на первый аккаунт");
            TestPutMoney(account1);
            PrintTransaction(account1);
            account1.PrintValues();
            Console.WriteLine();

            Console.WriteLine("Перевод денег на второй аккаунт");
            TestPutMoney(account2);
            PrintTransaction(account2);
            account2.PrintValues();
            Console.WriteLine();

            Console.WriteLine("Снятие денег с третьего аккаунта");
            TestWithdrawMoney(account3);
            PrintTransaction(account3);
            account3.PrintValues();
            Console.WriteLine();

            Console.WriteLine("Снятие денег с четвертого аккаунта");
            TestWithdrawMoney(account4);
            PrintTransaction(account4);
            account4.PrintValues();
            Console.WriteLine();

            Console.WriteLine("Упражнение 9.3");
            using (BankAccount acc1 = new BankAccount())
            {
                acc1.PutMoney(100);
                acc1.WithdrawMoney(50);
                acc1.PutMoney(75);
                acc1.WithdrawMoney(30);
                acc1.PrintValues();
            }
            Console.Clear();
            Console.WriteLine("Домашнее задание 9.1");
            Song song1 = new Song();
            List<Song> songs = new List<Song>();
            songs.Add(new Song("Моя любовь на пятом этаже", "Секрет"));
            songs.Add(new Song("Белая ночь", "Виктор Салтыков"));
            songs.Add(new Song("Последняя поэма", "Ирина Отиева"));
            songs.Add(new Song("Этот мир придуман не нами", "Алла Пугачева"));
            songs.Add(new Song("Белая ночь", "Виктор Салтыков"));
            foreach (var song in songs)
            {
                Console.WriteLine(Song.Title(song));
            }
            Song.Search(songs);
            Console.ReadKey();
        }
        public static void TestPutMoney(BankAccount acc)
        {
            Console.WriteLine("Введите сумму");
            decimal sum;
            while (!decimal.TryParse(Console.ReadLine(), out sum))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            acc.PutMoney(sum);
        }
        public static void TestWithdrawMoney(BankAccount acc)
        {
            Console.WriteLine("Введите сумму");
            decimal sum;
            while (!decimal.TryParse(Console.ReadLine(), out sum))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            if (!acc.WithdrawMoney(sum))
            {
                Console.WriteLine("Невозможно снять данную сумму денег");
            }
        }
        static void PrintTransaction(BankAccount bank_account)
        {
            Console.WriteLine($"Transaction:");
            foreach (BankTransaction tran in bank_account.Transaction())
            {
                Console.WriteLine($"Date/Time: {tran.When()}. Summa: {tran.Summa()}");
            }
        }
    }
}
