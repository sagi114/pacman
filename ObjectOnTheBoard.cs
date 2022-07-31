using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace _13_5GrafickProject.Classes
{
    class ObjectOnTheBoard
    {
        public bool _moveRight { get; set; }
        public bool _moveLeft { get; set; }
        public int _point { get; set; }
        public bool _wasEtean { get; set; }
        double _width;
        double _hight;
        double _top;
        double _left;
        string _typeUri;
        string _1typeUri;
        public Image _img { get;set; }
        Canvas _canvas;
        DispatcherTimer _timer;
        string _uri;
        string _rightOrLeft;
        bool _isPackmen;
        int _count;
        int _num;


        public ObjectOnTheBoard(double width, double hight, double top, double left, string typeUri, Canvas canvas)
        {
            _point = 1;
            _width = width;
            _hight = hight;
            _top = top;
            _left = left;
            _typeUri = typeUri;
            _uri = "ms-appx:///Assets/" + _typeUri+ ".jpg";
            _img = new Image();
            _img.Source = new BitmapImage(new Uri(_uri));
            _canvas = canvas;
            _img.Height = _hight;
            _img.Width = _width;
            Canvas.SetTop(_img, _top);
            Canvas.SetLeft(_img, _left);
            _canvas.Children.Add(_img);
            
            
        }
        public ObjectOnTheBoard(double width, double hight, double top, double left, string typeUri, Canvas canvas, DispatcherTimer timer,bool isPackmen)
        {
            _isPackmen = isPackmen;
            _point = 1;
            _width = width;
            _hight = hight;
            _top = top;
            _left = left;
            _typeUri = typeUri;
            _uri = "ms-appx:///Assets/" + _typeUri + ".jpg";
            _img = new Image();
            _img.Source = new BitmapImage(new Uri(_uri));
            _canvas = canvas;
            _img.Height = _hight;
            _img.Width = _width;
            Canvas.SetTop(_img, _top);
            Canvas.SetLeft(_img, _left);
            _count = 0;
            _timer = timer;
            _timer.Tick += Animation;
            _canvas.Children.Add(_img);
        }

        private void Animation(object sender, object e)
        {
            if (_isPackmen)
            {
                _canvas.Children.Remove(_img);
                
                _num = (_count < 30)?1:2;
                _rightOrLeft = (_moveRight == true) ? "Right" : "Left";
                _1typeUri = _typeUri + _num + _rightOrLeft;
                _uri = "ms-appx:///Assets/" + _1typeUri + ".jpg";
                _img.Source = new BitmapImage(new Uri(_uri));
                Canvas.SetTop(_img,Canvas.GetTop(_img));
                Canvas.SetLeft(_img,Canvas.GetLeft(_img));
                _canvas.Children.Add(_img);
                _count++;
                if (_count == 60) _count = 0;
                
            }
        }

        public double LEFT { get { return Canvas.GetLeft(_img); } }
        public double RIGHT{ get { return Canvas.GetLeft(_img)+_width; } }
        public double TOP { get { return Canvas.GetTop(_img); } }
        public double LOWER_SIDE { get { return Canvas.GetTop(_img) + _hight; } }
        public Image IMG { get { return _img; } }


    }
}
