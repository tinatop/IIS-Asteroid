using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class LoginForm : Form
    {
        private string token;

        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Uri uri = new Uri("http://localhost:5005/api/Login");
                WebRequest webRequest = WebRequest.Create(uri);
                webRequest.ContentType = "application/json";
                webRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    string json = "{\"username\":\"" + txtUsername.Text + "\"," +
                      "\"password\":\"" + txtPassword.Text + "\"}";
                    streamWriter.Write(json);
                }

                var response = (HttpWebResponse)webRequest.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    dynamic data = JObject.Parse(result);
                    token = data.token;
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    this.Hide();
                    MainForm mainForm = new MainForm(token);
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
