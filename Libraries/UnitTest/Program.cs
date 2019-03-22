using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeStreamAPI;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();

            Console.ReadLine();
        }

        private static async void Test()
        {
            YouTubeStream stream = new YouTubeStream("dQw4w9WgXcQ"); // https://www.youtube.com/watch?v=dQw4w9WgXcQ
            string res = await stream.LoadVideoStreamData();
        }
    }
}
