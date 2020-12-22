using System;
using System.Reflection;
using System.IO;
using System.Runtime;

namespace reflection_test
{
    class Program
    {
        static void Main(string[] args)
        {
            String assemblyLoadPath = @"/Users/mac/Documents/test_projects/dotnet_test/reflection_test/point.dll";

            Assembly loadAssembly;
            try
            {
                loadAssembly = Assembly.Load("point");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Can not find the point assembly, " + ex.Message);
            }

            Assembly loadFromAssembly;
            try
            {
                loadFromAssembly = Assembly.LoadFrom(assemblyLoadPath); // 内部调用load
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not find the point assembly from LoadFrom(), " + ex.Message);
            }

            Assembly loadFileAssembly = null;
            try
            {
                loadFileAssembly = Assembly.LoadFile(assemblyLoadPath); // 不处理依赖
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not find the point assembly from LoadFile(), " + ex.Message);
            }

            Assembly onlyLoadAssembly = null;
            try
            {
                onlyLoadAssembly = Assembly.ReflectionOnlyLoadFrom(assemblyLoadPath); // 仅解析，
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can not find the point assembly from OnlyLoadFrom(), " + ex.Message);
            }
            if (loadFileAssembly != null)
            {
                try
                {
                    object a = loadFileAssembly.CreateInstance("PPP.PointObject");
                    Console.WriteLine(a.GetType().FullName);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("the assembly reference is null!");
            }

            ShowPublicTypesOfAssembly(onlyLoadAssembly);

            try
            {
                Console.WriteLine(Type.GetType("reflection_test.Program").FullName ); // notice that the namespace is needed
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            ShowAllAssembly(AppDomain.CurrentDomain);

            //object point = AppDomain.CurrentDomain.CreateInstance("Point", "PointObject");
            ////Console.WriteLine(point.GetType().FullName);

            Console.WriteLine("OK!");
        }

        

        /// <summary>
        /// Output all exported types in the assembly input.
        /// </summary>
        /// <param name="a"> The assembly to be parsed </param>
        public static void ShowPublicTypesOfAssembly(Assembly a) 
        {
            foreach (var item in a.ExportedTypes)
            {
                Console.WriteLine(item.FullName);
            }
        }

        public static void ShowAllAssembly(AppDomain ad)
        {
            foreach (var item in ad.GetAssemblies())
            {
                Console.WriteLine(item.FullName);
            }
        }
    }
}
