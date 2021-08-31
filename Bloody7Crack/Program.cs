using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Bloody7Crack
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var application in Process.GetProcessesByName("Bloody7"))
            {
                application.Kill();
                application.WaitForExit();
            }

            if (!File.Exists("Bloody7.exe"))
            {
                MessageBox.Show("File Bloody7.exe not found");
                return;
            }

            if (File.Exists("Cracked.exe"))
            {
                File.Delete("Cracked.exe");
            }

            File.Copy("Bloody7.exe", "Original.exe");

            var stream = File.Open("Bloody7.exe", FileMode.Open);
            stream.Position = 2578955;
            stream.WriteByte(0x85);
            stream.Position = 2938178;
            stream.WriteByte(0x84)
            stream.Flush();
            stream.Close();

            Process.Start("Bloody7.exe");

            File.Move("Bloody7.exe", "Cracked.exe");
            File.Move("Original.exe", "Bloody7.exe");
        }
    }
}
