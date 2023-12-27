using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFormApp
{
    public partial class Form1 : Form
    {
        public int counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string data = String.Empty;
                
            Task<String> okuma = ReadFileAsync2();

            richTextBox2.Text = await new HttpClient().GetStringAsync("https://www.google.com");

            data = await okuma;

            richTextBox1.Text = data;

            
        }

        private void BtnCounter_Click(object sender, EventArgs e)
        {
            textBoxCounter.Text = counter++.ToString();
        }

        private string ReadFile()
        {
            string data = string.Empty;
            using(StreamReader s = new StreamReader("dosya.txt"))
            {
                Thread.Sleep(5000);
                data = s.ReadToEnd();

            }

            return data;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async Task<string> ReadFileAsync()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("dosya.txt"))
            {
                Task<string> mytask = s.ReadToEndAsync();

                await Task.Delay(5000);

                data = await mytask;

                return data;
            }
        }

        private Task<string> ReadFileAsync2()
        {
            StreamReader s = new StreamReader("dosya.txt");
            
            return s.ReadToEndAsync();
            
        }

    }
}
