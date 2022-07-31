using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _13_5GrafickProject.Classes
{
    class Money : ObjectOnTheBoard
    {
        const string _Type = "money";
        const int _width = 20;
        const int _hight = 20;
        public Money(  double top, double left, Canvas canvas)
            : base(_width,_hight, top, left,_Type, canvas)
        {
        }
    }
}
