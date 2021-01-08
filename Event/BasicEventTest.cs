using System;
using System.Threading;

namespace EventTest
{
    public static class BasicEventTest
    {
        public static void Test()
        {
            MailManager mailManager = new MailManager();
            Fax fax = new Fax(mailManager);
            mailManager.SimulateNewMailComing();
        }
        internal class MailManager
        {
            public event EventHandler<NewMailEventArgs> NewMailEvent; // 考虑大写，因为是给别人用的。 
            protected void OnNewMail(NewMailEventArgs mail)
            {
                EventHandler<NewMailEventArgs> temp = Volatile.Read(ref NewMailEvent);
                if (temp != null)
                {
                    temp.Invoke(this, mail);
                }
            }
            public void SimulateNewMailComing()
            {
                NewMailEventArgs newMail = new NewMailEventArgs("LiuYongfeng", "MaMingqian", "I Love You");
                NewMailEvent.Raise(this, newMail);
                // or 
                // OnNewMail(newMail);
            }
        }
        class Fax
        {
            public Fax(MailManager manager)
            {
                manager.NewMailEvent += FaxMassage;
            }
            protected void FaxMassage(Object sender, NewMailEventArgs eventArgs)
            {
                System.Console.WriteLine("The fax is faxing: {0}From: {1}{0}To: {2}{0}Subject: {3}", Environment.NewLine, eventArgs.From, eventArgs.To, eventArgs.Subject);
            }
        }
        internal class NewMailEventArgs : EventArgs
        {
            private String m_from;
            private String m_to;
            private String m_subject;

            public NewMailEventArgs(String from, String to, String subject)
            {
                m_from = from;
                m_to = to;
                m_subject = subject;
            }

            public String From
            {
                get { return m_from; }
            }
            public String To
            {
                get { return m_to; }
            }
            public String Subject
            {
                get { return m_subject; }
            }
        }

    }
    internal static class NewMailEventExtensions
    {
        public static void Raise(this EventHandler<BasicEventTest.NewMailEventArgs> eventHandler, Object sender, BasicEventTest.NewMailEventArgs eventArgs)
        {
            var temp = Volatile.Read(ref eventHandler);
            if (temp != null)
            {
                temp(sender, eventArgs);
            }
        }
    }
}