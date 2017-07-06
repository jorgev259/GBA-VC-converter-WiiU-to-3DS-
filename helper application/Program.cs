using System;
using System.IO;
using System.Linq;

namespace helper_application
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = Environment.CurrentDirectory + "/data_008_0000.bin";
            var filename2 = Environment.CurrentDirectory + "/vba.sav";

            var bin = hexArray(filename);
            var sav = hexArray(filename2);

            Console.Write("Choose your option: \n 1) WiiU to 3DS \n 2)3DS to WiiU \n");

            var option = Console.ReadKey();
            switch ((option.Key).ToString())
            {
                case "D1":
                    for (int i = 0; i < sav.Length; i++)
                    {
                        sav[i] = (hexToInt("4080") + i).ToString();
                    }
                    File.WriteAllBytes("conv.sav", GetBytes(sav));
                    break;
                case "D2":
                    break;
            }

            
        }

        static string[] hexArray(string path)
        {
            byte[] data = File.ReadAllBytes(path);
            string hex = BitConverter.ToString(data);
            return hex.Split("-".ToCharArray()[0]);
        }

        static byte[] GetBytes(string[] strArray)
        {
            var str = String.Join("-", strArray);

           var array = str.Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();

            return array;
        }

        static int hexToInt(string hexValue)
        {
            return int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
        }
    }
}
