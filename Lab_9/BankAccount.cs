using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Lab_9
{
    public enum AccountType { Actual, Savings };

    sealed class BankAccount : IDisposable
    {
        private long number;
        private decimal balance;
        private AccountType accountType;
        private static long uniq_num;
        private Queue transaction_queue = new Queue();
        bool disposed = false;
        public BankAccount()
        {
            number = UniqNumber();
            accountType = Type();
            balance = 0;
        }
        public BankAccount(AccountType accountType)
        {
            number = UniqNumber();
            this.accountType = accountType;
            balance = 0;
        }
        public BankAccount(decimal balance)
        {
            number = UniqNumber();
            accountType = Type();
            this.balance = balance;
        }
        public BankAccount(AccountType accountType, decimal balance)
        {
            number = UniqNumber();
            this.accountType = accountType;
            this.balance = balance;
        }
        public long UniqNumber()
        {
            return uniq_num++;
        }
        public AccountType Type()
        {
            return accountType;
        }
        public decimal Balance()
        {
            return balance;
        }
        public decimal PutMoney(decimal summa)
        {
            balance += summa;
            BankTransaction account_tran = new BankTransaction(summa);
            transaction_queue.Enqueue(account_tran);
            return balance;
        }
        public bool WithdrawMoney(decimal summa)
        {
            bool examination = (balance >= summa);
            if (examination)
            {
                balance -= summa;
                BankTransaction account_tran = new BankTransaction(-summa);
                transaction_queue.Enqueue(account_tran);
            }
            return examination;
        }
        public Queue Transaction()
        {
            return transaction_queue;
        }
        public void Dispose()
        {
            if (!disposed)
            {
                StreamWriter file_info = File.AppendText("Transactions.txt");
                file_info.WriteLine($"Account number:{number}");
                file_info.WriteLine($"Account balance:{balance}");
                file_info.WriteLine($"Account type: {accountType}");
                file_info.WriteLine("Transaction:");
                foreach(BankTransaction tran in transaction_queue)
                {
                    file_info.WriteLine($"Date/Time: {tran.When()}. Summa: {tran.Summa()}");
                }
                file_info.Close();
                disposed = true;
                GC.SuppressFinalize(this);
            }
        }
        ~BankAccount()
        {
            Dispose();
        }
        public void PrintValues()
        {
            Console.WriteLine($"Account number: {number}");
            Console.WriteLine($"Account balance: {balance}");
            Console.WriteLine($"Account type: {accountType}");
        }
    }
}
