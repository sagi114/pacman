using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _13_5GrafickProject.Classes
{
    class BoardGame
    {
        #region properties
        Canvas _canvas;
        Bloak[] _bloaks;
        PackMen _player;
        Enemy[] _enemy;
        DispatcherTimer _timer;
        string _key;
        int _counter;
        int _counterSeconds;
        Money[] _coines;
        const int _MovmentOfCreatur = 5;
        Creatur[] _creaturs;
        TextBlock _packMenPoint;
        Canvas _loss;
        Canvas _winning;
        TextBlock _watch;
        int _counterMm;
        
        public bool _wonVissablety { get; set; }
        public bool _lossVissbletty { get; set; }

        #endregion
        public BoardGame(Canvas canvas, Bloak[] bloaks, PackMen player, Enemy[] enemy, DispatcherTimer timer, Money[] coines,TextBlock packMenPoint,Canvas loss,Canvas winning,TextBlock watch)
        {
            _counterMm = 0;
            _watch = watch;
            _counterSeconds = 0;
            _wonVissablety = false;
            _winning = winning;
            _lossVissbletty = false;
            _loss = loss;
            _packMenPoint = packMenPoint;
            _timer = new DispatcherTimer(); 
            _timer.Interval = new TimeSpan(0,0,0,0,4);
            _timer.Start();
            _timer = timer;
            _canvas = canvas;
            _bloaks = bloaks;
            _player = player;
            _player._point = 0;
            _enemy = enemy;
            _coines = coines;
            _counter = 0;
            Window.Current.CoreWindow.KeyDown += KeyDown;
            _timer.Tick += GameLoop;
            
            
            

        }

        private void GameLoop(object sender, object e)
        {
            _counter++;
            _counterMm++;
            //time spam 0,0,0,0,4 4/1000u seconds
            if(_counterMm%25==0)
            {
                _counterSeconds++;
                _watch.Text =$"{_counterSeconds/60}:{_counterSeconds%60}";//
                
            }
                
            #region playersMove
            _creaturs = new Creatur[1];
            _creaturs[0] = _player;
            
            for (int i = 0; i < _creaturs.Length; i++)
            {
                couldMoveUp();
                if (_creaturs[i]._moveUp && !_creaturs[i]._couldntMoveUp) Canvas.SetTop(_creaturs[i].IMG, Canvas.GetTop(_creaturs[i].IMG) - _MovmentOfCreatur);
                couldMoveLeft();
                if (_creaturs[i]._moveLeft && !_creaturs[i]._couldntMoveLeft) Canvas.SetLeft(_creaturs[i].IMG, Canvas.GetLeft(_creaturs[i].IMG) - _MovmentOfCreatur);
                couldMoveDown();
                if (_creaturs[i]._moveDown && !_creaturs[i]._couldntMoveDown) Canvas.SetTop(_creaturs[i].IMG, Canvas.GetTop(_creaturs[i].IMG) + _MovmentOfCreatur);
                couldMoveRight();
                if (_creaturs[i]._moveRight & !_creaturs[i]._couldntMoveRight) Canvas.SetLeft(_creaturs[i].IMG, Canvas.GetLeft(_creaturs[i].IMG) + _MovmentOfCreatur);

            }
            
            #endregion
            #region enemyMove
            //enemy
            _creaturs = new Creatur[_enemy.Length];
            _creaturs = _enemy;
            couldMoveDown();
            couldMoveUp();
            couldMoveRight();
            couldMoveLeft();


            if (_counter % 3 == 0)
                {
                for (int i = 0; i <_enemy.Length; i++)
                {
                    if (_enemy[i] != null)
                    {
                        if (_player.TOP > _enemy[i].TOP && _enemy[i]._couldntMoveDown == false)
                        {
                            Canvas.SetTop(_enemy[i].IMG, _enemy[i].TOP + _MovmentOfCreatur);
                            _enemy[i]._moveDown = true;
                        }

                        if (_player.TOP < _enemy[i].TOP && _enemy[i]._couldntMoveUp == false)
                        {
                            Canvas.SetTop(_enemy[i].IMG, _enemy[i].TOP - _MovmentOfCreatur);
                            _enemy[i]._moveUp = true;
                        }

                        if (_player.LEFT > _enemy[i].LEFT && _enemy[i]._couldntMoveRight == false)
                        {
                            Canvas.SetLeft(_enemy[i].IMG, _enemy[i].LEFT + _MovmentOfCreatur);
                            _enemy[i]._moveRight = true;
                        }

                        if (_player.LEFT < _enemy[i].LEFT && _enemy[i]._couldntMoveLeft == false)
                        {
                            Canvas.SetLeft(_enemy[i].IMG, _enemy[i].LEFT - _MovmentOfCreatur);
                            _enemy[i]._moveLeft = true;
                        }
                        _enemy[i]._couldntMoveUp = false;
                        _enemy[i]._couldntMoveDown = false;
                        _enemy[i]._couldntMoveRight = false;
                        _enemy[i]._couldntMoveLeft = false;
                    }
                }
            }
            #endregion
            #region playerEatMoney
            Creatur[] packMen=new Creatur[1];
            packMen[0] = _player;
            eat(packMen,_coines);
            for (int j = 0; j < _coines.Length; j++)
            { 
                if (_coines[j]._wasEtean==true&&_coines[j]._point!=0)
                {
                    _player._point++;
                    _coines[j]._point = 0;
                    _packMenPoint.Text = $"packMen Points: {_player._point}";
                    _coines[j]._wasEtean = false;
                }
            }
            if (_player._point == _coines.Length) 
            {
                _winning.Visibility = Visibility.Visible;
                _timer.Stop();
                _wonVissablety = true;

            }
            #endregion
            #region eatPackmen
            eat(_enemy, packMen);
            if (_player._wasEtean)
            {
                _timer.Stop();
                _loss.Visibility = Visibility.Visible;
                _lossVissbletty = true;
            }
            #endregion

        }
        #region funktions
        private void KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            _key = args.VirtualKey.ToString();
            
        }
        private void couldMoveLeft()
        {
            for (int i = 0; i < _creaturs.Length; i++)
            {
                for (int j = 0; j < _bloaks.Length; j++)
                {
                    if (_creaturs[i] != null)
                    {
                        if (_key == "Left" && _creaturs[i] != null)
                        {
                            _creaturs[i]._couldntMoveLeft = false;
                            _creaturs[i]._moveLeft = true;
                            _creaturs[i]._moveUp = false;
                            _creaturs[i]._moveDown = false;
                            _creaturs[i]._moveRight = false;
                        }
                        if (_creaturs[i].LEFT - _MovmentOfCreatur < 0)
                        {
                            _creaturs[i]._couldntMoveLeft = true;
                            _creaturs[i]._moveLeft = false;
                        }
                        if (_creaturs[i].LEFT == _bloaks[j].RIGHT &&
                            _creaturs[i].TOP <= _bloaks[j].LOWER_SIDE &&
                            _creaturs[i].LOWER_SIDE >= _bloaks[j].TOP)
                        {
                            _creaturs[i]._couldntMoveLeft = true;
                            _creaturs[i]._moveRight = false;
                        }
                        if (_creaturs[i]._couldntMoveLeft) break;
                    }

                }
            }
        }
        private void couldMoveRight()
        {
            for  (int i = 0; i < _creaturs.Length; i++)
            {
                for (int j = 0; j < _bloaks.Length; j++)
                {
                    if(_creaturs[i] != null)
                    {
                        if (_key == "Right")
                        {
                            _creaturs[i]._couldntMoveRight = false;
                            _creaturs[i]._moveRight = true;
                            _creaturs[i]._moveUp = false;
                            _creaturs[i]._moveLeft = false;
                            _creaturs[i]._moveDown = false;
                        }
                        if (_creaturs[i].RIGHT + _MovmentOfCreatur > _canvas.ActualWidth)
                        {
                            _creaturs[i]._couldntMoveRight = true;
                            _creaturs[i]._moveRight = false;
                        }
                        if (_creaturs[i].RIGHT == _bloaks[j].LEFT &&
                            _creaturs[i].TOP < _bloaks[j].LOWER_SIDE &&
                            _creaturs[i].LOWER_SIDE > _bloaks[j].TOP)
                        {
                            _creaturs[i]._couldntMoveRight = true;
                            _creaturs[i]._moveRight = false;
                        }
                        if (_creaturs[i]._couldntMoveRight) break;
                    }

                }
            }
        }
        private void couldMoveDown()
        {
            for  (int i = 0; i < _creaturs.Length; i++)
            {
                for (int j = 0; j < _bloaks.Length; j++)
                {
                    if (_creaturs[i] != null)
                    {
                        if (_key == "Down")
                        {
                            _creaturs[i]._couldntMoveDown = false;
                            _creaturs[i]._moveDown = true;
                            _creaturs[i]._moveUp = false;
                            _creaturs[i]._moveLeft = false;
                            _creaturs[i]._moveRight = false;
                        }
                        if (_creaturs[i].LOWER_SIDE + _MovmentOfCreatur > _canvas.ActualHeight)
                        {
                            _creaturs[i]._couldntMoveDown = true;
                            _creaturs[i]._moveDown = false;
                        }
                        if (_creaturs[i].LOWER_SIDE == _bloaks[j].TOP &&
                            _creaturs[i].LEFT < _bloaks[j].RIGHT &&
                            _creaturs[i].RIGHT > _bloaks[j].LEFT)
                        {
                            _creaturs[i]._couldntMoveDown = true;
                            _creaturs[i]._moveDown = false;
                        }
                        if (_creaturs[i]._couldntMoveDown) break;
                    }
                       
                }
                
            }
        }
        private void couldMoveUp()
        {
            for  (int i = 0; i < _creaturs.Length; i++)
            {
                for (int j = 0; j < _bloaks.Length; j++)
                {
                    if (_creaturs[i] != null)
                    {
                        if (_key == "Up" && _creaturs[i] != null)
                        {
                            _creaturs[i]._couldntMoveUp = false;
                            _creaturs[i]._moveUp = true;
                            _creaturs[i]._moveLeft = false;
                            _creaturs[i]._moveDown = false;
                            _creaturs[i]._moveRight = false;
                        }
                        if (_creaturs[i].TOP - _MovmentOfCreatur < 0)
                        {
                            _creaturs[i]._couldntMoveUp = true;
                            _creaturs[i]._moveUp = false;
                        }
                        if (_creaturs[i].TOP>_bloaks[j].TOP&&
                            _creaturs[i].TOP <= _bloaks[j].LOWER_SIDE &&
                            _creaturs[i].LEFT < _bloaks[j].RIGHT &&
                            _creaturs[i].RIGHT > _bloaks[j].LEFT)
                        {
                            _creaturs[i]._couldntMoveUp = true;
                            _creaturs[i]._moveUp = false;
                        }
                        if (_creaturs[i]._couldntMoveUp) break;
                    }

                }
            }
        }
        public void eat(Creatur[] theEaters,ObjectOnTheBoard[]food)
        {
            for (int i = 0; i < theEaters.Length; i++)
            {
                for (int j = 0; j < food.Length; j++)
                {
                    if (theEaters[i] != null)
                    {
                        if (theEaters[i]._moveUp == true &&//enemy atacks from down to up
                        food[j].TOP < theEaters[i].TOP &&
                        theEaters[i].TOP < food[j].LOWER_SIDE &&
                        theEaters[i].RIGHT > food[j].LEFT &&
                        theEaters[i].LEFT < food[j].RIGHT ||

                        (theEaters[i]._moveDown == true &&//enemy atacks from up to down
                        theEaters[i].LOWER_SIDE < food[j].LOWER_SIDE &&
                        theEaters[i].LOWER_SIDE > food[j].TOP &&
                        theEaters[i].RIGHT > food[j].LEFT &&
                        theEaters[i].LEFT < food[j].RIGHT) ||

                        (theEaters[i]._moveLeft == true &&
                        theEaters[i].LEFT > food[j].LEFT &&//enemy atacks from right to left
                        theEaters[i].LEFT < food[j].RIGHT &&
                        theEaters[i].LOWER_SIDE > food[j].TOP &&
                        theEaters[i].TOP < food[j].LOWER_SIDE) ||

                        (theEaters[i]._moveRight == true &&
                        theEaters[i].RIGHT < food[j].RIGHT &&//enemy atacks from left to right
                        theEaters[i].RIGHT > food[j].LEFT &&
                        theEaters[i].LOWER_SIDE > food[j].TOP &&
                        theEaters[i].TOP < food[j].LOWER_SIDE))
                        {
                            food[j]._wasEtean = true;
                            _canvas.Children.Remove(food[j].IMG);
                            theEaters[i]._moveLeft = false;
                            theEaters[i]._moveRight = false;
                            theEaters[i]._moveUp = false;
                            theEaters[i]._moveDown = false;

                        }
                    }
                }
            }
                
            }
        #endregion
    }
}

