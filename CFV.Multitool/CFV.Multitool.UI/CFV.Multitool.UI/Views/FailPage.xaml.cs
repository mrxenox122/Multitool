using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CFV.Multitool.UI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FailPage : ContentPage
	{
        public List<CriticalHitEffect> Magic;
        public List<CriticalHitEffect> Ranged;
        public List<CriticalHitEffect> Natural;
        public List<CriticalHitEffect> Melee;
        public Random random = new Random();
        public FailPage ()
		{
			InitializeComponent ();
            Icon = "MultiToolFail.png";
            BackgroundImage = "MultiToolBackground.png";
            Assembly _assembly;
            StreamReader _textStreamReader;
            _assembly = Assembly.GetExecutingAssembly();
            //Get Magic fails
            _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("CFV.Multitool.UI.Droid.Data.Fails.fMg.json"));
            Magic = JsonConvert.DeserializeObject<List<CriticalHitEffect>>(_textStreamReader.ReadToEnd());
            //Get Ranged fails
            _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("CFV.Multitool.UI.Droid.Data.Fails.fRg.json"));
            Ranged = JsonConvert.DeserializeObject<List<CriticalHitEffect>>(_textStreamReader.ReadToEnd());
            //Get Natural fails
            _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("CFV.Multitool.UI.Droid.Data.Fails.fNa.json"));
            Natural = JsonConvert.DeserializeObject<List<CriticalHitEffect>>(_textStreamReader.ReadToEnd());
            //Get Melee fails
            _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("CFV.Multitool.UI.Droid.Data.Fails.fMl.json"));
            Melee = JsonConvert.DeserializeObject<List<CriticalHitEffect>>(_textStreamReader.ReadToEnd());
        }

        private void btnMelee_Pressed(object sender, EventArgs e)
        {
            CriticalHitEffect effect = new CriticalHitEffect();
            int draw = random.Next(0, Melee.Count - 1);
            lblName.Text = Melee.ElementAt(draw).name;
            lblResult.Text = Melee.ElementAt(draw).desc;
        }

        private void btnNatural_Pressed(object sender, EventArgs e)
        {
            CriticalHitEffect effect = new CriticalHitEffect();
            int draw = random.Next(0, Natural.Count - 1);
            lblName.Text = Natural.ElementAt(draw).name;
            lblResult.Text = Natural.ElementAt(draw).desc;
        }

        private void btnRanged_Pressed(object sender, EventArgs e)
        {
            CriticalHitEffect effect = new CriticalHitEffect();
            int draw = random.Next(0, Ranged.Count - 1);
            lblName.Text = Ranged.ElementAt(draw).name;
            lblResult.Text = Ranged.ElementAt(draw).desc;
        }

        private void btnMagic_Pressed(object sender, EventArgs e)
        {
            CriticalHitEffect effect = new CriticalHitEffect();
            int draw = random.Next(0, Magic.Count - 1);
            lblName.Text = Magic.ElementAt(draw).name;
            lblResult.Text = Magic.ElementAt(draw).desc;
        }
    }
}