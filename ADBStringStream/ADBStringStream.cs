using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADBStringStream
{
    public partial class ADBStringStream : Form
    {
        bool connection = false;

        public ADBStringStream()
        {
            InitializeComponent();

        }

        public void connected()
        {
            this.connection = true;

            buttonConnect.Text = "Disconnect";
            buttonConnect.Enabled = true;
            textBoxIP.Enabled = false;

            buttonSend.Enabled = true;
            textBoxString.Enabled = true;
        }

        public void disconnected()
        {
            this.connection = false;

            buttonConnect.Text = "Connect";
            buttonConnect.Enabled = true;
            textBoxIP.Enabled = true;

            buttonSend.Enabled = false;
            textBoxString.Enabled = false;
        }

        public void disableButtons()
        {
            buttonSend.Enabled = false;
            buttonConnect.Enabled = false;
            textBoxIP.Enabled = false;
            textBoxString.Enabled = false;
        }

        public bool testForDevice()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "adb.exe";
            startInfo.Arguments = "get-state";
            startInfo.RedirectStandardOutput = true;

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                    var output = exeProcess.StandardOutput.ReadToEnd();

                    Debug.WriteLine(output);

                    if ( output.Contains("device"))
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            disableButtons();
            if (connection)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "adb.exe";
                startInfo.Arguments = "disconnect ";
                startInfo.RedirectStandardOutput = true;

                try
                {
                    // Start the process with the info we specified.
                    // Call WaitForExit and then the using statement will close.
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                        var output = exeProcess.StandardOutput.ReadToEnd();

                        Debug.WriteLine(output);
                    }
                }
                catch
                {
                    // Log error.
                }
                disconnected();
                return;
            }
            if (textBoxIP.Text.Length > 0)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.UseShellExecute = false;
                startInfo.FileName = "adb.exe";
                startInfo.Arguments = "connect " + textBoxIP.Text;
                startInfo.RedirectStandardOutput = true;

                try
                {
                    // Start the process with the info we specified.
                    // Call WaitForExit and then the using statement will close.
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                        var output = exeProcess.StandardOutput.ReadToEnd();

                        Debug.WriteLine(output);

                        if (output.Contains("connected"))
                        {
                            connected();
                        }
                        else
                        {
                            disconnected();
                        }
                    }
                }
                catch
                {
                    // Log error.
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (testForDevice())
            {
                connected();
            }
            else
            {
                disconnected();
            }

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            disableButtons();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "adb.exe";
            startInfo.Arguments = @"shell input text """ + textBoxString.Text.Replace(" ","%s") + @"""";
            Console.WriteLine(startInfo.Arguments);
            
            startInfo.RedirectStandardOutput = true;

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                    var output = exeProcess.StandardOutput.ReadToEnd();
                    textBoxString.Text = "";
                    Debug.WriteLine(output);
                }
            }
            catch
            {
                // Log error.
            }

            startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "adb.exe";
            startInfo.Arguments = "shell input keyevent 66";
            startInfo.RedirectStandardOutput = true;

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                    var output = exeProcess.StandardOutput.ReadToEnd();

                    Debug.WriteLine(output);
                }
            }
            catch
            {
                // Log error.
            }
            connected();
        }

    }
}
