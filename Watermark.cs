using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using gma.System.Windows;
using System.Diagnostics;

namespace Caesar_TestFaker
{
    public partial class Watermark : Form
    {
        UserActivityHook actHook;

        private Label waterMarkLabel;
        private string[] paragraphs;
        private int index = 1;
        public string[] PublicParagraph; // Global variable for reading Q by Q
        string TestFile; // Test File Name e.g. I2Psi18.txt!
        string TestText; // Load Test

        // Start key hook

        public Watermark()
        {
            actHook = new UserActivityHook(); // crate an instance with global hooks
                                              // hang on events
            //actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            actHook.KeyPress += new KeyPressEventHandler(MyKeyPress);


            actHook.Start();

            // Get Test File Name
            //var default_config_path = Path.Combine(Directory.GetCurrentDirectory(), "Testy.ini"); // Testy.ini
            var default_config_path = Path.Combine(@"K:\Aplikace\TestyVyt3\", "Testy.ini"); // Testy.ini
            string line;
            using (StreamReader file = new StreamReader(default_config_path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains(".txt!"))
                    {
                        TestFile = line;
                    }
                }
            }
            ////////////////// NOW WE KNOW TEST FILENAME
            //// COPY FILE INTO TEMP FOLDER
            string sourceFile = @"K:\Aplikace\TestyVyt3\Testy\" + TestFile;
            string tempFile = Path.GetTempPath() + TestFile;
            try
            {
                File.Copy(sourceFile, tempFile, true);
            }
            catch (IOException iox)
            {
                Application.Exit();
            }

            //// READ TEST FILE
            //var path = Path.Combine(@"K:\Aplikace\TestyVyt3\", "Testy\\" + TestFile);
            var path = Path.Combine(Path.GetTempPath(), TestFile);
            System.IO.StreamReader reader = new System.IO.StreamReader(path);
            TestText = reader.ReadToEnd(); // LOAD TEST FILE INTO MEMORY (TEST FILE IS STILL ENCRYPTED)
            TestText = Decipher(TestText, 2); // 2 == Encrypt alphabet (Move Alphabet +2 chars)
            reader.Close();
            //var paragraphs = TestText.Split('\n');
            //PublicParagraph = TestText.Split('\n'); // Save paragraph for Global use (RightMouseClick/"-"(Minus) KeyButton)





            //Location Buttom-Left
            //Rectangle workingArea = Screen.GetWorkingArea(this);
            //var waterLocation = new Point(workingArea.Left - Size.Width,
            //workingArea.Bottom - Size.Height);

            waterMarkLabel = new Label
            {
                Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right),
                Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                //ForeColor = SystemColors.ControlDarkDark,
                ForeColor = System.Drawing.Color.Red,
                Location = new Point(5,5),
                Name = "WATERMARK",
                Size = new Size(2, 5),
                TabIndex = 0,
                Text = "",
                TextAlign = ContentAlignment.BottomLeft
            };

            InitializeComponent();
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2, 5);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Opacity = 0.05; // 0.05
            ShowIcon = false;
            ShowInTaskbar = false;
            TopMost = true;
            var hwnd = Handle;
            WindowsServices.SetWindowExTransparent(hwnd);
            TopMost = true;
            AllowTransparency = true;
            ResumeLayout(false);

            Controls.Add(waterMarkLabel);
            WindowState = FormWindowState.Maximized;
        }


        public void MyKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                index--;
                //waterMarkLabel.Text = PublicParagraph[index]; // Get previous
                //var path = Path.Combine(@"K:\Aplikace\TestyVyt3\Testy\", TestFile);
                var path = Path.Combine(Path.GetTempPath(), TestFile);
                waterMarkLabel.Text = Decipher(File.ReadLines(path).Skip(index-1).Take(1).First(), 2);
            }
            if (e.KeyChar == '+')
            {
                index++;


                if (!testy_checker.Enabled)
                {
                    testy_checker.Start();
                }
                //waterMarkLabel.Text = PublicParagraph[index];
                //var path = Path.Combine(@"K:\Aplikace\TestyVyt3\Testy\", TestFile);
                var path = Path.Combine(Path.GetTempPath(), TestFile);
                waterMarkLabel.Text = Decipher(File.ReadLines(path).Skip(index - 1).Take(1).First(), 2);
            }
            if (e.KeyChar == 'a')
            {
                this.Hide();
            }
          if (e.KeyChar == 's')
            {
                this.Show();
            }
        }

        private void Watermark_MouseDown(object sender, MouseEventArgs e)
        {
            index++;
            //waterMarkLabel.Text = "ahoj";
            //MessageBox.Show("Right click! :)");
        }

        // DECODING
        // ||=============================================================||
        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }


        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }

        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }
        // ||=============================================================||

        private static string DecodeFromUtf8(string input)
        {
            string utf8_String = input;
            byte[] bytes = Encoding.Default.GetBytes(utf8_String);
            utf8_String = Encoding.UTF8.GetString(bytes);
            return utf8_String;
        }

        private void testy_checker_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("Testy");
            if (pname.Length == 0)
            {
                //Not running
                Application.Exit();
            }
            else
            {
                // Running
            }
        }

        private void Watermark_Load(object sender, EventArgs e)
        {
            
            //actHook = new UserActivityHook(); // crate an instance with global hooks
            // hang on events
            //actHook.OnMouseActivity += new MouseEventHandler(MouseMoved);
            // actHook.KeyPress += new KeyPressEventHandler(MyKeyPress);
        }
    }

    public static class WindowsServices
    {
        const int WS_EX_TRANSPARENT = 0x00000020;
        const int GWL_EXSTYLE = (-20);

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

        public static void SetWindowExTransparent(IntPtr hwnd)
        {
            var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
        }
    }
}
