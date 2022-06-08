using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace CFV.Multitool.UI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CritPage : ContentPage
	{
        public List<CriticalHitEffect> Blunt;
        public List<CriticalHitEffect> Magic;
        public List<CriticalHitEffect> Pierce;
        public List<CriticalHitEffect> Slash;
        public Random random = new Random();
        public CritPage()
        {
            InitializeComponent();
            Icon = "MultiToolCards.png";
            BackgroundImage = "MultiToolBackground.png";
            Assembly _assembly;
            StreamReader _textStreamReader;
            _assembly = Assembly.GetExecutingAssembly();
            _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("CFV.Multitool.UI.Droid.Data.Hits.hBl.json"));
            //Get Blunt hits
            Blunt = JsonConvert.DeserializeObject<List<CriticalHitEffect>>(_textStreamReader.ReadToEnd());
            //Get Magic hits
            _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("CFV.Multitool.UI.Droid.Data.Hits.hMg.json"));
            Magic = JsonConvert.DeserializeObject<List<CriticalHitEffect>>(_textStreamReader.ReadToEnd());
            //Get Pierce hits
            _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("CFV.Multitool.UI.Droid.Data.Hits.hPi.json"));
            Pierce = JsonConvert.DeserializeObject<List<CriticalHitEffect>>(_textStreamReader.ReadToEnd());
            //Get Slash hits
            _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("CFV.Multitool.UI.Droid.Data.Hits.hSl.json"));
            Slash = JsonConvert.DeserializeObject<List<CriticalHitEffect>>(_textStreamReader.ReadToEnd());
        }

        private void Blunt_Pressed(object sender, EventArgs e)
        {
            CriticalHitEffect effect = new CriticalHitEffect();
            int draw = random.Next(0, Blunt.Count - 1);
            lblName.Text = Blunt.ElementAt(draw).name;
            lblResult.Text = Blunt.ElementAt(draw).desc;
        }

        private void Pierce_Pressed(object sender, EventArgs e)
        {
            CriticalHitEffect effect = new CriticalHitEffect();
            int draw = random.Next(0, Pierce.Count - 1);
            lblName.Text = Pierce.ElementAt(draw).name;
            lblResult.Text = Pierce.ElementAt(draw).desc;
        }

        private void Slash_Pressed(object sender, EventArgs e)
        {
            CriticalHitEffect effect = new CriticalHitEffect();
            int draw = random.Next(0, Slash.Count - 1);
            lblName.Text = Slash.ElementAt(draw).name;
            lblResult.Text = Slash.ElementAt(draw).desc;
        }

        private void Magic_Pressed(object sender, EventArgs e)
        {
            CriticalHitEffect effect = new CriticalHitEffect();
            int draw = random.Next(0, Magic.Count - 1);
            lblName.Text = Magic.ElementAt(draw).name;
            lblResult.Text = Magic.ElementAt(draw).desc;
        }
    }
}