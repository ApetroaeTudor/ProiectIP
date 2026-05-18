using System;
using System.Threading;
using System.Windows.Forms;
using CustomExceptions;

namespace Proiect_Ip
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += GlobalThreadExceptionHandler;

            Application.Run(new Form1());
        }

        private static void GlobalThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;

            switch (ex)
            {
                case LibraryManagementException libraryManagementException:
                    MessageBox.Show(libraryManagementException.Message, "LibraryManagement", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;

                case MediaManagementException mediaManagementException:
                    MessageBox.Show(mediaManagementException.Message, "MediaManagement", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;

                default:
                    DialogResult res = MessageBox.Show($"Eroare Neprevazuta {ex.Message}", "Eroare",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                    if (res == DialogResult.No)
                    {
                        Application.Exit();
                    }

                    break;
            }
        }
    }
}