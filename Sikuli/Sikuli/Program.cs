using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SikuliSharp;
using System.Windows.Forms;
namespace SikuliTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderpath = @"C:\Users\Jihan\source\repos\NikeAuto\NikeAuto\Steps\Step1\";
            string path = folderpath + "Chrome.PNG";
            SikuliRunner.InitializeSession();
            IPattern ima = Patterns.FromFile(path);
            SikuliRunner.Click(ima);

            string path2 = folderpath + "Chromeaddress.PNG";
            var ima2 = Patterns.FromFile(path2);
            SikuliRunner.Wait(ima2);
  
            SikuliRunner.Type("https://www.nike.com/launch/");
            SikuliRunner.PressKey(Keys.Enter);

            folderpath = @"C:\Users\Jihan\source\repos\NikeAuto\NikeAuto\Steps\Step2\";
            path = folderpath + "Instock.PNG";
            ima = Patterns.FromFile(path);
            SikuliRunner.Wait(ima);
            SikuliRunner.Click(ima);

            folderpath = @"C:\Users\Jihan\source\repos\NikeAuto\NikeAuto\Steps\Step3\";
            path = folderpath + "Product1.PNG";
            ima = Patterns.FromFile(path);
            if (SikuliRunner.SearchDown(ima, 10.0))
            {
                SikuliRunner.Click(ima);
            }
            System.Threading.Thread.Sleep(1000);
            SikuliRunner.PressKey(Keys.Down);
            SikuliRunner.PressKey(Keys.Down);
            //path = folderpath + "Size1.PNG";
            //ima = Patterns.FromFile(path);

            //if (SikuliRunner.SearchDown(ima,10.0))
            //{
            //    SikuliRunner.Click(ima);
            //}
            //else
            //{
            //    Console.Write("Time out");
            //}
        }
    }
}
