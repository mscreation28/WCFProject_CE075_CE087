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

namespace URLShortnerForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                label1.Text = "URL can't be null..!!";
            }
            else
            {
                ServiceReference1.UrlShortnerClient usc = new ServiceReference1.UrlShortnerClient();
                label1.Text = "Shorted URL : "+usc.GetShortUrl(textBox1.Text);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                label2.Text = "URL can't be null..!!";
            }
            else
            {
                ServiceReference1.UrlShortnerClient usc = new ServiceReference1.UrlShortnerClient();
                label4.Text = usc.GetOriginalUrl(textBox2.Text);
                label2.Text = "Original URL : " + label4.Text;
                Redirect.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Redirect_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(label4.Text);
        }
    }
}
