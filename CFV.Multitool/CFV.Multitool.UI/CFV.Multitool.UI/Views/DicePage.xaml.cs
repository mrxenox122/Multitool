using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CFV.Multitool.UI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DicePage : ContentPage
	{
		public DicePage ()
		{
			InitializeComponent ();
            Icon = "MultiToolDice.png";
            BackgroundImage = "MultiToolBackground.png";
        }

        private void Roll_Pressed(object sender, EventArgs e)
        {
            String number = txtNumber.Text;
            String sides = txtSides.Text;
            int n;
            int s;
            int.TryParse(number, out n);
            int.TryParse(sides, out s);
            lblResult.Text = Dice.Roll(n, s).ToString();
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load("MultiToolDice.mp3");
            player.Play();
        }
    }
}