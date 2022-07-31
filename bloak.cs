using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _13_5GrafickProject.Classes
{
    class Bloak : ObjectOnTheBoard
    {
        const string _Type="bloak";
        
        public Bloak( double top, double left, Canvas canvas,int num, double width=80, double hight=40) 
            : base(width, hight, top, left,_Type+num, canvas)
        {
        }
    }
}
