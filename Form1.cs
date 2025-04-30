using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeHavaDurumu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            cmbCities.Items.Add("Paris");
            cmbCities.Items.Add("Istanbul");
            cmbCities.Items.Add("Ankara");
            cmbCities.Items.Add("London");
            cmbCities.Items.Add("New York");
            cmbCities.Items.Add("Berlin");
            cmbCities.Items.Add("Tokyo");
            cmbCities.Items.Add("Madrid");
            cmbCities.Items.Add("Rome");
            cmbCities.Items.Add("Dubai");

        }
            
            

        private async void  btnSec_Click(object sender, EventArgs e)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/{selectedCity}/EN"),
                Headers =
    {
        { "x-rapidapi-key", "8b31bcd7d3mshf5e27fef1894cd4p159f16jsn2cce8e1da0b3" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);
                var fahrenheit = json["main"]["feels_like"].ToString();
                var windSpeed = json["wind"]["speed"].ToString();
                var humidity = json["main"]["humidity"].ToString();

                lblFahrenheit.Text = fahrenheit;
                lblWindSpeed.Text = windSpeed;
                lblNem.Text = humidity;
                decimal celcius = (decimal.Parse(fahrenheit) - 32) / (9 / 5);
                lblCelcius.Text = celcius.ToString();

                string sehir = json["name"].ToString();
                string ulke = json["sys"]["country"].ToString();
                lblsehir.Text = sehir + "," + ulke;
                lblsehir2.Text = sehir + "," + ulke;

                var weatherCondition = json["weather"][0]["main"].ToString();
                switch (weatherCondition)
                {
                    case "Clouds":
                        pictureBox2.Image = Image.FromFile(@"C:\Users\ceren\OneDrive\Desktop\icon\cloudy.png");
                        break;
                    case "Rain":
                        pictureBox2.Image = Image.FromFile(@"C:\Users\ceren\OneDrive\Desktop\icon\rainy-day.png");
                        break;
                    case "Snow":
                        pictureBox2.Image = Image.FromFile(@"C:\Users\ceren\OneDrive\Desktop\icon\snowy.png");
                        break;
                    case "Sunny":
                        pictureBox2.Image = Image.FromFile(@"C:\Users\ceren\OneDrive\Desktop\icon\sun.png");
                        break;
                    case "Clear":
                        pictureBox2.Image = Image.FromFile(@"C:\Users\ceren\OneDrive\Desktop\icon\clear.png");
                        break;
                }
            }









        }
 
    
    
    
    
    
    }
        


}
    

