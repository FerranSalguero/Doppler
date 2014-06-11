using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Doppler.Properties;


namespace Doppler
{
    class Doppler 
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            MainForm mainForm = new MainForm(args);
            try
            {
                if (Settings.Default.WindowLocation != null)
                {
                    mainForm.Location = Settings.Default.WindowLocation;
                    mainForm.StartPosition = FormStartPosition.Manual;
                }
                if (Settings.Default.WindowSize != null)
                {
                    mainForm.Size = Settings.Default.WindowSize;
                }
            }
            catch { }
            SingleInstance.SingleApplication.Run(mainForm);
            //SingleInstance.SingleApplication.Run(new MainForm(args));
            //Application.Run(new frmMain(args));
           // SingleInstanceApplication.Run(new frmMain(args),
           //     StartupNextInstanceHandler);
        }

      
        //static int Main(string[] args)
        //{
        //        //return UserApplicationContext.Run(args, typeof(Doppler));
        //    Application.Run(new frmMain(args));

        //}

        //static void Doppler_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        //{

        //    throw new Exception("The method or operation is not implemented.");
        //}
    }
}
