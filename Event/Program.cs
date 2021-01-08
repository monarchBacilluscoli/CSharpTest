using System;
using System.Threading;

namespace EventTest
{
    class LuckyMan
    {
        internal class NewMoneyEventArgs:EventArgs
        {
            private Int32 m_shared_money;
            public NewMoneyEventArgs(Int32 amout)
            {
                m_shared_money = amout;
            }
            public Int32 SharedMoney
            {
                get { return m_shared_money; }
            }
        }

        public event EventHandler<NewMoneyEventArgs> NewMoney;

        public void GetNewMoney(Int32 amount)
        {
            OnGetNewMoney(amount);
        }

        // 实质上这仍然是一个交给事件定义者的函数调用。
        protected void OnGetNewMoney(Int32 amount) // execute the delegate
        {
            var temp = Volatile.Read(ref NewMoney);
            if (temp != null)
            {
                Int32 each_amount = amount/temp.GetInvocationList().Length;
                temp(this, new NewMoneyEventArgs(each_amount));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            { // basic event test as the book
                BasicEventTest.Test();
                return;
            }
            Console.WriteLine("Hello World!");
            LuckyMan lm = new LuckyMan();
            LuckyFriend[] lfs = new LuckyFriend[5];
            for (int i = 0; i < lfs.Length; i++)
            {
                lfs[i] = new LuckyFriend(1);
                lm.NewMoney += lfs[i].OnLuckManGetMoney;
            }

            lm.GetNewMoney(1000);

            Console.WriteLine("exit");
        }
    }
    class LuckyFriend
    {
        private Int32 m_money = 0;
        public LuckyFriend(int initial_money)
        {
            m_money = initial_money;
        }
        public void OnLuckManGetMoney(Object sender, LuckyMan.NewMoneyEventArgs e)
        {
            Console.WriteLine(sender.GetType());
            ReceiveMoney(e.SharedMoney);
            Console.WriteLine("Now I have {0} yuan!", m_money);
        }
        private void ReceiveMoney(Int32 amount)
        {
            m_money += amount;
        }
    }
}
