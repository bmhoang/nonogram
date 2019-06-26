using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NonoGram
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {
        public Board()
        {
            InitializeComponent();
        }

        private static void OnBoardSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Board).ResetBoard((Size)e.NewValue);
        }
        static Geometry cellData = Geometry.Parse("M0 0V2H2V0Z");

        private void ResetBoard(Size size)
        {
            board.Children.Clear();
            Cells = new Cell[(int)size.Width][];
            for (int i = 0; i < size.Width; i++)
            {
                Cells[i] = new Cell[(int)size.Height];
                for (int j = 0; j < size.Height; j++)
                {
                    Cells[i][j] = new Cell();
                    var cell = new Path() { Data = cellData, Stretch = Stretch.Fill, StrokeThickness = 1, Stroke = Brushes.DarkBlue,
                        HorizontalAlignment=HorizontalAlignment.Left, VerticalAlignment=VerticalAlignment.Top};
                    cell.DataContext = Cells[i][j];
                    cell.Margin = new Thickness(i * CellSize, j * CellSize, 0,0);
                    cell.SetBinding(Shape.FillProperty, new Binding("Status"));
                    cell.SetBinding(WidthProperty, new Binding("CellSize") { Source = this });
                    cell.SetBinding(HeightProperty, new Binding("CellSize") { Source = this });
                    cell.MouseLeftButtonDown += Cell_MouseLeftButtonDown;
                    cell.MouseRightButtonDown += Cell_MouseRightButtonDown;
                    board.Children.Add(cell);
                }
            }
        }

        private void Cell_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var cell = (sender as Path).DataContext as Cell;
            if (cell.Status == Brushes.Black)
            {
                cell.Status = Brushes.White;
            } else if (cell.Status == Brushes.White)
            {
                cell.Status = Brushes.DarkRed;
            } else
            {
                cell.Status = Brushes.Black;
            }
        }

        private void Cell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var cell = (sender as Path).DataContext as Cell;
            if (cell.Status == Brushes.Black)
            {
                cell.Status = Brushes.DarkRed;
            }
            else if (cell.Status == Brushes.White)
            {
                cell.Status = Brushes.Black;
            }
            else
            {
                cell.Status = Brushes.White;
            }
        }

        private static void OnVerticalHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Board).ResizeVerticalHeader((int[][])e.NewValue);
        }

        private void ResizeVerticalHeader(int[][] newValue)
        {
            var maxCount = newValue.Max(a => a.Length);
            HorizontalHeaderHeight = new GridLength(maxCount * CellSize);

            verticalHeader.Children.Clear();
            for (int i = 0; i < newValue.Length; i++)
            {
                for (int j = newValue[i].Length - 1; j >=0; j--)
                {
                    var cell = new TextBlock()
                    {
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Text = newValue[i][j].ToString(),
                        TextAlignment = TextAlignment.Center
                    };
                    cell.Margin = new Thickness((j + maxCount - newValue[i].Length) * CellSize , i * CellSize, 0, 0);
                    verticalHeader.Children.Add(cell);
                }
            }
        }

        private static void OnHorizontalHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Board).ResizeHorizontalHeader((int[][])e.NewValue);
        }

        private void ResizeHorizontalHeader(int[][] newValue)
        {
            var maxCount = newValue.Max(a => a.Length);
            VerticalHeaderWidth = new GridLength(maxCount * CellSize);

            horizontalHeader.Children.Clear();
            for (int i = 0; i < newValue.Length; i++)
            {
                for (int j = newValue[i].Length - 1; j >= 0; j--)
                {
                    var cell = new TextBlock()
                    {
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Text = newValue[i][j].ToString(),
                        TextAlignment = TextAlignment.Center
                    };
                    cell.Margin = new Thickness(i * CellSize, (j + maxCount - newValue[i].Length) * CellSize, 0, 0);
                    horizontalHeader.Children.Add(cell);
                }
            }
        }

        private static void OnCellSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

    }
}
