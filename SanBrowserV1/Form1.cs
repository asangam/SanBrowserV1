using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace SanBrowserV1
{
    public partial class SanBrowser : Form
    {
        public SanBrowser()
        {
            InitializeComponent();
            InitializeChromium();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //exits the application
            Application.Exit();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if(sidemenu.Width==49)
            {
                sidemenu.Width = 212;

                sidemenu.Visible = false;
                
                PanelAnimator.ShowSync(sidemenu);
                LogoAnimator.ShowSync(logo);

            }
            else
            {
                LogoAnimator.Hide(logo);
                sidemenu.Width = 49;
                PanelAnimator.ShowSync(sidemenu);
            }
        }

        

        private void Form1_Load_1(object sender, EventArgs e)
        {
            sidemenu.Width = 49;
            if(sidemenu.Width==49)
            {
                //panel2.Dock = DockStyle.Fill;
                //panel2.Margin = new Padding(10);
               

                //panel2.Top = -24;

            }


        }

        private void btnCredits_MouseHover(object sender, EventArgs e)
        {
            //ToolTip toolTip1 = new ToolTip();

            //toolTip1.ShowAlways = true;

            //toolTip1.SetToolTip(btnCredits, "Click me to execute."); 
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(1000, "Minimized to taskbar", " Application has been Minimized to taskbar", ToolTipIcon.Info);
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/asangam/SanBrowserV1/blob/master/README.md");
        }

        //private void btnCredits_MouseHover(object sender, EventArgs e)
        //{
        //    btnCredits.Text = "hry";
        //}

        //private void tt(object sender, PopupEventArgs e)
        //{
        //    btnCredits.Text = "Spell-Checker...";

        //}
        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            txtUrl.Text = "http://www.google.com";

            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser(txtUrl.Text);
            //chromeBrowser = new ChromiumWebBrowser("chrome://print/foo?");
            // Add it to the form and fill it to the form window.
            this.panel2.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
            chromeBrowser.AddressChanged += chromeBrowser_AddressChanged;
        }

        void chromeBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {


            this.Invoke(new MethodInvoker(() =>
                {
                    txtUrl.Text = e.Address;
                }

                ));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            chromeBrowser.ShowDevTools();
        }

        private void bunifuFlatButton1_MouseHover(object sender, EventArgs e)
        {
           


        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            chromeBrowser.Load(txtUrl.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            chromeBrowser.Refresh();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            chromeBrowser.Stop();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (chromeBrowser.CanGoForward)
                chromeBrowser.Forward();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (chromeBrowser.CanGoBack)
                chromeBrowser.Back();
        }

        private void txtUrl_MouseClick(object sender, MouseEventArgs e)
        {
            txtUrl.Select();
        }
    }
}
