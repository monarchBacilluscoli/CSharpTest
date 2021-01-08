using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using PPP;

namespace SerializationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                ASerializationdvancedTest.Test();
            }
            {

                BinaryFormatter bf = new BinaryFormatter();
                bf.Context = new StreamingContext(StreamingContextStates.Other);
                MemoryStream ms = new MemoryStream();
                CircleObjectISer co = new CircleObjectISer(new PointObject(1, 2), 11);
                co.Area = 100000;

                bf.Serialize(ms, co);
                ms.Position = 0;
                co = null;

                co = (CircleObjectISer)bf.Deserialize(ms);
                Console.WriteLine("The deserialized object's center is ({0},{1}), radius is {2}, area is {3}", co.Center.X, co.Center.Y, co.Radius, co.Area); ;

                return;
            }
            {
                AClassWithRefField acwrf = new AClassWithRefField(13, 231);
                AClassWithRefField acwrf2 = new AClassWithRefField(-87, -9898);
                MemoryStream ms = new MemoryStream();
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(ms, acwrf);
                bf.Serialize(ms, acwrf2);
                acwrf = null;
                acwrf2 = null;
                ms.Position = 0;

                acwrf = (AClassWithRefField)bf.Deserialize(ms);
                acwrf2 = (AClassWithRefField)bf.Deserialize(ms);
                // 按顺序反序列化
                Console.WriteLine("The value in that instance1: {0}, {1}", acwrf.AC.X, acwrf.X);
                Console.WriteLine("The value in that instance2: {0}, {1}", acwrf2.AC.X, acwrf2.X);
                return;
            }
            {
                List<Int32> ls = new List<int> { 1, 23, 4, 51, 51 };
                XmlSerializer xs = new XmlSerializer(typeof(List<Int32>));

                FileStream fs = File.Open("serialization_test.txt", FileMode.OpenOrCreate);
                xs.Serialize(fs, ls);

                fs.Close();
                ls = null;
                if (ls == null)
                {
                    Console.WriteLine("ls is null now.");
                }
                else
                {
                    throw (new ApplicationException());
                }

                fs = File.Open("serialization_test.txt", FileMode.Open);
                ls = (List<Int32>)xs.Deserialize(fs);
                try
                {
                    foreach (var item in ls)
                    {
                        Console.Write(item + "\t");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
