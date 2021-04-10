using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WindowsFormsApp_for_task_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PostRequestAsync(textBox1.Text.ToString(), textBox3.Text.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void PostRequestAsync( string x, string y)
        {
            WebRequest request = WebRequest.Create("http://172.16.193.234:40919/lab1/handler.bks/4");
            request.Method = "POST";
//http://localhost:56367/handler/bks/4
            string data = "X="+ x+"&Y="+ y;

            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);

            request.ContentType = "application/x-www-form-urlencoded";

            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            WebResponse response =  request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    textBox2.Text = reader.ReadToEnd().ToString();
                  //  MessageBox.Show(reader.ReadToEnd());
                }
            }
            response.Close();
        }
    }
}
