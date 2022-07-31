using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _13_5GrafickProject.Classes
{
    class Creatur : ObjectOnTheBoard

    {
        
        public bool _moveUp { get; set; }
        public bool _moveDown { get; set; }
        public bool _isCreaturPackMen;
        public bool _couldntMoveLeft;
        public bool _couldntMoveRight;
        public bool _couldntMoveUp;
        public bool _couldntMoveDown;
        
        public Creatur(bool isCreaturPackMen, double width, double hight, double top, double left, string typeUri, Canvas canvas, DispatcherTimer timer) 
            : base(width, hight, top, left, typeUri, canvas, timer,isCreaturPackMen)
        {
            _isCreaturPackMen = isCreaturPackMen;
        }
        public Creatur( double width, double hight, double top, double left, string typeUri, Canvas canvas)
            : base(width, hight, top, left, typeUri, canvas)
        {
            
        }
    }
}
