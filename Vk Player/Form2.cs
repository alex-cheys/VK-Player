using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vk_Player
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://oauth.vk.com/authorize?client_id=6443821&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=friends&response_type=token&v=5.52");
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            toolStripStatusLabel1.Text = "Загрузка...";
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "Загружено";

            try
            {
                string url = webBrowser1.Url.ToString();
                string l = url.Split('#')[1]; // Разделить строку по символу # и запихнуть в массив, получить access token
                if (l[0] == 'a')
                {
                    Settings1.Default.token = l.Split('&')[0].Split('=')[1]; // Выделяем access token из строки
                    Settings1.Default.id = l.Split('=')[3]; // Получаем id
                    Settings1.Default.auth = true;
                    MessageBox.Show(Settings1.Default.token + " " + Settings1.Default.id);
                    this.Close();
                }
            }
            catch { }
        }
    }
}
