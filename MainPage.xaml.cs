using _13_5GrafickProject.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _13_5GrafickProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DispatcherTimer _timer;
        Bloak[] _bloak;
        PackMen _packMen;
        Enemy[] _enemys;
        Money[] _coines;
        BoardGame _lvl1;
        Random _rand;
        Score _score;
        
        public MainPage()
        {
            _rand = new Random();
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            _timer.Start();
            this.InitializeComponent();
            _bloak = new Bloak[10];
            _bloak[0]=new Bloak( 280, 650, board,2,40,80);
            _bloak[1] = new Bloak(200, 475, board,1);
            _bloak[2] = new Bloak(400, 475, board, 1);
            _bloak[3] = new Bloak(200, 200, board,1);
            _bloak[4] = new Bloak(200, 750, board,1);
            _bloak[5] = new Bloak(400,200, board,1);
            _bloak[6] = new Bloak(400,750, board,1);
            _bloak[7] = new Bloak(280,880, board,2,40,80);
            _bloak[8] = new Bloak(280,350, board,2,40,80);
            _bloak[9] = new Bloak(280,100,board,2,40,80);
            _packMen = new PackMen(50, 50, 100, 900, board, _timer);
            _score = new Score(_packMen);
            _enemys = new Enemy[5];
            _enemys[0] = new Enemy(50, 50, 0, 0, board,1);
            _coines = new Money[3];
            _coines[0] = new Money( 300, 500, board);
            _coines[1] = new Money( 300, 800, board);
            _coines[2] = new Money( 300, 200, board);
            _lvl1 = new BoardGame(board, _bloak, _packMen, _enemys, _timer, _coines,packMenPoint, loss,youWon,timer);
            
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            GamePaused.Visibility = Visibility.Visible;
        }

        private void btn_return_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
            GamePaused.Visibility = Visibility.Collapsed;
        }

        private void btnTryAgain_Click(object sender, RoutedEventArgs e)
        {
            if(_lvl1._lossVissbletty==true)
            {
                _lvl1._lossVissbletty = false;
                loss.Visibility = Visibility.Collapsed;
                Canvas.SetTop(_packMen.IMG, _rand.Next(0, (int)board.ActualHeight));
                Canvas.SetLeft(_packMen.IMG, _rand.Next(0,(int)board.ActualWidth));
                _packMen._wasEtean = false;
                _timer.Start();
                
            }
        }

        private void finishGame_Click(object sender, RoutedEventArgs e)
        {
            if (_lvl1._lossVissbletty == true)
            {
                Frame.Navigate(typeof(Results1));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_lvl1._wonVissablety==true)
            {
                Frame.Navigate(typeof(Results1));
            }
        }
    }
}
