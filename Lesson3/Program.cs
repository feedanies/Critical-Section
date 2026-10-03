namespace Lesson3
{
    internal class Program
    {

        public class Account
        {
            public Account(string fullName, double balance)
            {
                Fullname = fullName;
                Balance = balance;
            }

            public string? Fullname { get; set; }
            public double Balance { get; set; }

            object lockObject = new object();

            public void withDraw(object amount)
            {
                lock (lockObject)
                {
                    double mebleg = (double)amount;
                    if (Balance >= mebleg)
                    {
                        Thread.Sleep(100);
                        Balance -= mebleg;
                        Console.WriteLine($"ATM vasitesile {mebleg} mebleg cixarildi. Balansiniz: {Balance}");
                    }
                    else
                    {
                        Console.WriteLine("Balansinizda kifayet qeder mebleg yoxdur");
                    }
                }
            }

            public void transfer(object amount)
            {
                lock (lockObject)
                {
                    double mebleg = (double)amount;
                    if (Balance >= mebleg)
                    {
                        Thread.Sleep(100);
                        Balance -= mebleg;
                        Console.WriteLine($"Transfer vasitesile {mebleg} mebleg gonderildi. Balansiniz: {Balance}");
                    }
                    else
                    {
                        Console.WriteLine("Balansinizda kifayet qeder mebleg yoxdur");
                    }
                }
            }

        }


        static void Main(string[] args)
        {

            Account account = new Account("Mahmud Mahmudlu", 150);

            Thread thread1 = new Thread(account.withDraw);
            Thread thread2 = new Thread(account.transfer);

            thread1.Start(100.0);
            thread2.Start(60.0);

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Balans: " + account.Balance);


        }
    }
}
