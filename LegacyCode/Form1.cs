using System.Runtime.InteropServices;

namespace LegacyCode
{
    public partial class Form1 : Form
    {
        const int WM_SETTEXT = 0x000C;
        const int WM_CLOSE = 0x0010;
        const int WM_GETTEXTLENGTH = 0x000E;

        [DllImport("user32.dll")]
        public static extern int MessageBox(int h, string m, string c, int type);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, string lParam);

        [DllImport("kernel32.dll")]
        public static extern bool Beep(int dwFreq, int dwDuration);

        [DllImport("user32.dll")]
        public static extern bool MessageBeep(int uType);

        public Form1()
        {
            InitializeComponent();

            MessageBox(0, "Some info about me:\nMy name is Vyacheslav!", "Info About Me 1", 0);
            MessageBox(0, "Some info about me:\nI love programming!", "Info About Me 2", 0);
            MessageBox(0, "Some info about me:\nAnd Cats, of course.", "Info About Me 3", 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = FindWindow(null, textBox1.Text);

            if (hWnd != IntPtr.Zero)
            {
                // Changing Window Title
                SendMessage(hWnd, WM_SETTEXT, IntPtr.Zero, textBox2.Text);
            }
            else
            {
                MessageBox(0, "Window not found", "Info", 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = FindWindow(null, textBox1.Text);

            if (hWnd != IntPtr.Zero)
            {
                // Closing Window
                SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, null);
            }
            else
            {
                MessageBox(0, "Window not found", "Info", 0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = FindWindow(null, textBox1.Text);

            int textLength = 0;

            if (hWnd != IntPtr.Zero)
            {
                // Getting Window Title Length
                textLength = SendMessage(hWnd, WM_GETTEXTLENGTH, IntPtr.Zero, null);
                label4.Text = textLength.ToString();
            }
            else
            {
                MessageBox(0, "Window not found", "Info", 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            // Playing some Windows Sounds
            for (int i = 0; i < rnd.Next(1, 3); i++)
            {
                Beep(500, 500);
                Thread.Sleep(1000);

                MessageBeep(0);
                Thread.Sleep(1000);

                Beep(1000, 500);
                Thread.Sleep(1000);

                MessageBeep(0);
                Thread.Sleep(1000);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}