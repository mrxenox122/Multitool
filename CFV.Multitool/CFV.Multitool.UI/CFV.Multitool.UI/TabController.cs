using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CFV.Multitool.UI
{
    class TabController : TabbedPage
    {
        public TabController () {
            Children.Add(new Views.DicePage());
            Children.Add(new Views.EncounterPage());
            Children.Add(new Views.CritPage());
            Children.Add(new Views.FailPage());
        }
    }
}
