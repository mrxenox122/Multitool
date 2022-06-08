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
	public partial class EncounterPage : ContentPage
	{
        public List<Creature> Creatures;
        public List<string> Environments;
        public Random random = new Random();
        public EncounterPage ()
		{
			InitializeComponent ();
            Icon = "MultiToolMonster.png";
            BackgroundImage = "MultiToolBackground.png";
            Assembly _assembly;
            StreamReader _textStreamReader;
            _assembly = Assembly.GetExecutingAssembly();
            //Get Creatures from Bestiary
            _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("CFV.Multitool.UI.Droid.Data.Creatures.bestiary.json"));
            Creatures = JsonConvert.DeserializeObject<List<Creature>>(_textStreamReader.ReadToEnd());
            Environments = new List<string>();
            /*foreach(Creature c in Creatures)
            {
                if (!Environments.Contains(c.Environment))
                    Environments.Add(c.Environment);
            }
            pkrEnvironment.ItemsSource = Environments;
            */
        }
        private void GenerateEncounter ()
        {
            /*List<Creature> EnvironmentCreatures = new List<Creature>();
            foreach (Creature c in Creatures)
            {
                if (c.Environment == Environments[pkrEnvironment.SelectedIndex])
                {
                    EnvironmentCreatures.Add(c);
                }
            }*/
            double CR;
            double.TryParse(txtCR.Text, out CR);
            int draw = random.Next(0, Creatures.Count - 1);
            Creature creature = Creatures[draw];
            int number = 1;
            if (creature.CR < CR)
            {
                double TotalCR = creature.CR;
                while (TotalCR < CR)
                {
                    TotalCR += creature.CR;
                    number++;
                }
                lblNumber.Text = number.ToString() + " ";
                lblCreature.Text = creature.Name + "s";
            }
            else if (creature.CR > CR)
            {
                GenerateEncounter();
            }
            else if (creature.CR == CR)
            {
                lblNumber.Text = "1 ";
                lblCreature.Text = creature.Name;
            }
        }

        private void btnGenerate_Pressed(object sender, EventArgs e)
        {
            GenerateEncounter();
        }
    }
}