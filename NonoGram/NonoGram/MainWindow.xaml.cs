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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            board.BoardSize = new Size(10, 10);
            board.HorizontalHeader = new int[][]
            {
                new int[]{2,1,2 },
                new int[]{6 },
                new int[]{4,3 },
                new int[]{1,5 },
                new int[]{1,5 },
                new int[]{5 },
                new int[]{1,3 },
                new int[]{2,3 },
                new int[]{1,2 },
                new int[]{1,2 }
            };
            board.VerticalHeader = new int[][]
            {
                new int[]{1,1,1,4 },
                new int[]{3,1 },
                new int[]{2 },
                new int[]{4,2 },
                new int[]{1,4},
                new int[]{8 },
                new int[]{8 },
                new int[]{4 },
                new int[]{3 },
                new int[]{3 }
            };
        }

        private void ResolveTheGame(object sender, RoutedEventArgs e)
        {

        }

        private void ApplyGame(object sender, RoutedEventArgs e)
        {

        }
    }
}
