using System.Diagnostics;
namespace exception_test
{
    public class DiagnosticsTest
    {
        public static void Test()
        {
            StackTrace st = new StackTrace();
            var a = st.GetFrames();
            var b = st.FrameCount;
            var c = st.GetFrame(1);
            return;
        }
    }
}