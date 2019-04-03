using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;
using System.IO;

namespace Jarvis
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        Choices list = new Choices();
        Boolean wake;
        Boolean search = false;
        Double resultValue = 0;
        Boolean isoperationPerformed = false;
        int n = 0;
        

        public Form1()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            list.Add(File.ReadAllLines(@"H:\ana_2\command\Comands.txt"));
            Grammar gr = new Grammar(new GrammarBuilder(list));
            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeechRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);

            }
            catch 
            {
                return;
            }
            
            s.SelectVoiceByHints(VoiceGender.Female);
            InitializeComponent();
        }

        public void say(String h)
        {
            s.Speak(h);
            textBox2.AppendText(h + "\n");

        }

        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;
            textBox1.AppendText(r+"\n");
            //wake = false;


            if (r == "calculator")
            {
                label4.Visible = true;
                textBox4.Visible = true;
                textBox4.Text = "0";
            }
            if (r == "one")
            {
                if (textBox4.Text == "0")
                    textBox4.Clear();
                textBox4.Text = textBox4.Text + "1";
                isoperationPerformed = true;
            }
            if (r == "two")
            {
                if (textBox4.Text == "0")
                    textBox4.Clear();
                textBox4.Text = textBox4.Text + "2";
                isoperationPerformed = true;
            }
            if (r == "three")
            {
                if (textBox4.Text == "0")
                    textBox4.Clear();
                textBox4.Text = textBox4.Text + "3";
                isoperationPerformed = true;
            }
            if (r == "four" )
            {
                if (textBox4.Text == "0")
                    textBox4.Clear();
                textBox4.Text = textBox4.Text + "4";
                isoperationPerformed = true;
            }
            if (r == "five")
            {
                if (textBox4.Text == "0")
                    textBox4.Clear();
                textBox4.Text = textBox4.Text + "5";
                isoperationPerformed = true;
            }
            if (r == "six" )
            {
                if (textBox4.Text == "0")
                    textBox4.Clear();
                textBox4.Text = textBox4.Text + "6";
                isoperationPerformed = true;
            }
            if (r == "seven" )
            {
                if (textBox4.Text == "0")
                    textBox4.Clear();
                textBox4.Text = textBox4.Text + "7";
                isoperationPerformed = true;
            }
            if (r == "eight" )
            {
                if (textBox4.Text == "0")
                    textBox4.Clear();
                textBox4.Text = textBox4.Text + "8";
                isoperationPerformed = true;
            }
            if (r == "nine" )
            {
                if (textBox4.Text == "0")
                    textBox4.Clear();
                textBox4.Text = textBox4.Text + "9";
                isoperationPerformed = true;
            }
            if (r == "zero" && textBox4.Text!= "0")
            {
                textBox4.Text = textBox4.Text + "0";
                isoperationPerformed = true;
            }
            if (r == "plus" && isoperationPerformed==true)
            {
                resultValue =Double.Parse(textBox4.Text);
                n = 1;
                textBox4.Clear();
                
            }
            if (r == "multiply" && isoperationPerformed == true)
            {
                resultValue = Double.Parse(textBox4.Text);
                n = 3;
                textBox4.Clear();
            }
            if (r == "minius" && isoperationPerformed == true)
            {
                resultValue = Double.Parse(textBox4.Text);
                n = 2;
                textBox4.Clear();
            }

            if (r == "divide" && isoperationPerformed == true)
            {
                resultValue = Double.Parse(textBox4.Text);
                n = 4;
                textBox4.Clear();
            }


            if (r == "equals" )
            {
                switch (n)
                {
                    case 1:
                        textBox4.Text = (resultValue + Double.Parse(textBox4.Text)).ToString();
                        break;
                    case 2:
                        textBox4.Text = (resultValue - Double.Parse(textBox4.Text)).ToString();
                        break;
                    case 3:
                        textBox4.Text = (resultValue * Double.Parse(textBox4.Text)).ToString();
                        break;
                    case 4:
                        textBox4.Text = (resultValue / Double.Parse(textBox4.Text)).ToString();
                        break;

                }
            }

            if (r == "close")
            {
                label4.Visible = false;
                textBox4.Visible = false;
                textBox4.Clear();
            }

            if (r == "clear")
            {
                textBox4.Clear();
                resultValue = 0;
                textBox4.Text = "0";
            }

            if (r == "ana")
            {
                wake = true;
                say("hello, sir. i am waiting for your command.");

                textBox3.Clear();
                textBox3.AppendText("Awake Mode");
            }

            if (r == "sleep")
            {
                wake = false;
                say("ok, have a good day sir");
                textBox3.Clear();
                textBox3.AppendText("Sleep Mode");
            }

            if (wake == true)
            {

                if (r == "maximize")
                {
                    this.WindowState = FormWindowState.Maximized;
                }

                if (r == "normal")
                {
                    this.WindowState = FormWindowState.Normal;
                }

                if (r == "minimize")
                {
                    this.WindowState = FormWindowState.Minimized;
                }

                if (r == "hello" || r=="hi")
                {
                    say("hi, how are you sir?");
                }
                if (r == "what is your name?")
                {
                    say("ana, sir");
                }
                if (r == "i am fine")
                {
                    say("good to hear.");
                }
                if (r == "time")
                {
                    say(DateTime.Now.ToString("hh:mm tt"));
                }
                
                if (r == "what is today?")
                {
                    say(DateTime.Now.ToString("M/d/yyyy"));
                }

                if (r == "how are you?" || r=="kemon aso?")
                {
                    say("fine, sir");
                }

                if (r == "google")
                {
                    Process.Start("http://www.google.com");
                    
                }
                if (r == "youtube")
                {
                    Process.Start("https://www.youtube.com");

                }

                if (r == "search for")
                {
                    search = true;
                }

                if (search)
                {
                    Process.Start("https://www.google.com/#q="+r);
                }

                if (r == "end")
                {
                    search = false;
                }

                if (r == "facebook")
                {
                    Process.Start("http://www.facebook.com");
                }

                if (r == "goodbye")
                {
                    say("goodbye, sir");
                }

                if (r == "update")
                {
                    Process.Start(@"G:\Radim\Ana\Comands.txt");
                }

                if (r == "dictionary")
                {
                    Process.Start(@"C:\Program Files (x86)\Oxford\OALD8\oald8.exe");
                }

                if (r == "clear")
                {
                    textBox1.Clear();
                    textBox2.Clear();
                }

            }   

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public GrammarBuilder[] file { get; set; }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
