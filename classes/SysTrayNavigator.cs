using System;
using System.Threading;
using Doppler.languages;

namespace Doppler
{
	/// <summary>
	/// Summary description for SysTrayNavigator.
	/// </summary>
	public class SysTrayNavigator : IDisposable
	{
		public System.Windows.Forms.NotifyIcon notifyIcon;
		static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();


		bool isDisposed;
		int intIcon;
		private int _threads;
    

        public int Threads
        {
            set { _threads = value;}
            get { return _threads; }
        }
       

		public SysTrayNavigator(System.Windows.Forms.NotifyIcon notifyIconIn)
		{
			notifyIcon = notifyIconIn;

			timer.Tick+=new EventHandler(timer_Tick);
			intIcon = 0;

			timer.Enabled = true;
			timer.Interval = 100;
		}

		public void Dispose()
		{
			isDisposed = true;
            timer.Stop();
			timer.Enabled = false;

		}

		~SysTrayNavigator()
		{
			if(!isDisposed)
			{
				Dispose();
			}
		}


		private void timer_Tick(object sender, EventArgs e)
		{
            // get the threads from the main form
            if(_threads > 0)
            {
                intIcon++;
                if (intIcon > 9)
                {
                    intIcon = 1;
                }

                try
                {
                    notifyIcon.Icon = new System.Drawing.Icon(typeof(MainForm), "icons.pro" + intIcon.ToString() + ".ico");
                }
                catch (Exception)
                { }
            }
            else
            {
                try
                {
                    notifyIcon.Icon = new System.Drawing.Icon(typeof(MainForm), "icons.doppler.ico");
                }
                catch { }
            }
		}
	}
}
