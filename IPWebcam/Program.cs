using System;
using System.IO;
using System.Windows.Forms;

namespace IPWebcam
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string architecture = Environment.Is64BitProcess ? "x64" : "x86";
            CopyFiles(architecture); // Copy files before running the application
            Application.Run(new frmWeb());
        }

        private static void CopyFiles(string architecture)
        {
            string sourceDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, architecture);
            string destinationDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string[] files = Directory.GetFiles(sourceDirectory);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destinationFilePath = Path.Combine(destinationDirectory, fileName);
                File.Copy(file, destinationFilePath, true);
                //MessageBox.Show($"Copied {fileName} to {destinationFilePath}");
            }
        }

    }
}
