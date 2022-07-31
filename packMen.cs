using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _13_5GrafickProject.Classes
{
    class PackMen : Creatur
    {
        const bool _isPackMen = true;
        const string _Type = "packMen";
        
        public PackMen( double width, double hight, double top, double left, Canvas canvas, DispatcherTimer timer) 
            : base(_isPackMen, width, hight, top, left, _Type, canvas, timer)
        {
        }
    }
}
