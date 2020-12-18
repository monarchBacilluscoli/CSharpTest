using System;

namespace enum_test
{
    enum Posture
    {
        missionary,
        riding,
        doge
    }

    

    class Program
    {
        private Posture m_p;
        public Posture PostureUsed
        {
            set
            {
                if(Enum.IsDefined(typeof(Posture), value))
                {
                    throw (new ArgumentOutOfRangeException("PostureUsed", value, "Enum Posture doesn't contain this value"));
                }
            }
            get
            {
                return m_p;
            }
        }
        static void Main(string[] args)
        {
            Posture p = new Posture();
            p = Posture.doge;

            var e1 = Enum.Parse<Posture>("doge");
            Posture e2;
            try
            {
                e2 = Enum.Parse<Posture>("doges");
            }
            catch (ArgumentException a)
            {
                a.ToString();
            }
            finally
            {
                e2 = e1;
            }
            var e3 = Enum.Parse<Posture>("1");
            Console.WriteLine(Enum.IsDefined(typeof(Posture),2));
            Console.WriteLine();

            Program pp = new Program();
            try
            {
                pp.PostureUsed = (Posture)123;

            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("ParamName: {0}, ActualValue: {1}, Message: {2}", e.ParamName, e.ActualValue, e.Message);
            }

            GetAttributesTest gat = new GetAttributesTest();

            Console.WriteLine(Enum.GetUnderlyingType(typeof(Posture)));
        }
    }
}
