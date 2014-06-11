using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

// Set 'RunInstaller' attribute to true. 


[RunInstaller(true)]
public class MyInstallerClass : Installer
{

    public MyInstallerClass()
    { // Attach the 'Committed' event. 
        this.Committed += new InstallEventHandler(MyInstaller_Committed);
        // Attach the 'Committing' event. 
        this.Committing += new InstallEventHandler(MyInstaller_Committing);
        this.AfterInstall += new InstallEventHandler(MyInstallerClass_AfterInstall);
        this.AfterUninstall += new InstallEventHandler(MyInstallerClass_AfterUninstall);
    }

    void MyInstallerClass_AfterUninstall(object sender, InstallEventArgs e)
    {
        try
        {
            if (System.IO.File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "Doppler.lnk")))
            {
                System.IO.File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "Doppler.lnk"));
            }
            if (System.IO.File.Exists(Path.Combine(QuickLaunchFolder, "Doppler.lnk")))
            {
                System.IO.File.Delete(Path.Combine(QuickLaunchFolder, "Doppler.lnk"));
            }
            if (System.IO.File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Doppler.lnk")))
            {
                System.IO.File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Doppler.lnk"));
            }
        }
        catch { }
    }

    void MyInstallerClass_AfterInstall(object sender, InstallEventArgs e)
    {
        string autostart = this.Context.Parameters["AUTOSTART"];
        if (autostart == "1")
        {
            fCreateShellLink(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "Doppler.lnk", Assembly.GetExecutingAssembly().Location, "Subscribe to and download podcasts", Assembly.GetExecutingAssembly().Location+", 0");
        }
        string quicklaunch = this.Context.Parameters["QUICKLAUNCH"];
        if (quicklaunch == "1")
        {
            fCreateShellLink(QuickLaunchFolder, "Doppler.lnk", Assembly.GetExecutingAssembly().Location, "Subscribe to and download podcasts", Assembly.GetExecutingAssembly().Location + ", 0");
        }
        string desktop = this.Context.Parameters["DESKTOP"];
        if (desktop == "1")
        {
            fCreateShellLink(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Doppler.lnk", Assembly.GetExecutingAssembly().Location, "Subscribe to and download podcasts", Assembly.GetExecutingAssembly().Location + ", 0");
        }
    }

    private string QuickLaunchFolder
    {
        get
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                "\\Microsoft\\Internet Explorer\\Quick Launch";
        }
    }

    // Event handler for 'Committing' event. 
    private void MyInstaller_Committing(object sender, InstallEventArgs e)
    {
        MessageBox.Show("Starting commit");
    }

    // Event handler for 'Committed' event. 
    private void MyInstaller_Committed(object sender, InstallEventArgs e)
    {
        MessageBox.Show("Committed");
    }

    // Override the 'Install' method. 
    public override void Install(IDictionary savedState)
    {
        base.Install(savedState);
        
    }

    // Override the 'Commit' method. 

    public override void Commit(IDictionary savedState)
    {
        base.Commit(savedState);
    }

    // Override the 'Rollback' method. 
    public override void Rollback(IDictionary savedState)
    {
        base.Rollback(savedState);
    }
    //public static void Main()
    //{
    //    Console.WriteLine("Usage : installutil.exe Installer.exe ");
    //}

    static void fCreateShellLink(string lpstrFolderName, string lpstrLinkName, string lpstrLinkPath, string lpstrDescription, string lpstrIconLocation)
    {
        object fso, shortcut;
        Type type = Type.GetTypeFromProgID("WScript.Shell");
        if (type != null)
        {
            fso = Activator.CreateInstance(type);//type.InvokeMember(null,BindingFlags.CreateInstance,null,null,new object[]{});
            shortcut = type.InvokeMember("CreateShortcut", BindingFlags.InvokeMethod, null, fso, new object[] { System.IO.Path.Combine(lpstrFolderName, lpstrLinkName) });
            type.InvokeMember("TargetPath", BindingFlags.SetProperty, null, shortcut, new object[] { lpstrLinkPath });
            type.InvokeMember("Description", BindingFlags.SetProperty, null, shortcut, new object[] { lpstrDescription });
            type.InvokeMember("IconLocation", BindingFlags.SetProperty, null, shortcut, new object[] { lpstrIconLocation });
            type.InvokeMember("Save", BindingFlags.InvokeMethod, null, shortcut, new object[] { });
            
        }
        shortcut = null; fso = null;
    }
} 
