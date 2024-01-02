using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ParcInfo
{
    class NavButton2 : ListBoxItem
    {
        static NavButton2()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavButton2), new FrameworkPropertyMetadata(typeof(NavButton2)));
        }
    }
}
