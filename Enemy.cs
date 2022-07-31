using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _13_5GrafickProject.Classes
{
    class Enemy : Creatur
    {
        const bool isPackmen = false;
        const string _type = "enemy";
        public Enemy( double width, double hight, double top, double left, Canvas canvas,int num) 
            : base( width, hight, top, left, _type+num, canvas)
        {
        }
    }
}
