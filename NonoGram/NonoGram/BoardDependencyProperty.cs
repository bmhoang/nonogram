using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NonoGram
{
    public partial class Board
    {

        #region Cells
        public static readonly DependencyProperty CellsProperty = DependencyProperty.Register("Cells", typeof(Cell[][]), typeof(Board), new PropertyMetadata(null));

        public Cell[][] Cells
        {
            get
            {
                return (Cell[][])GetValue(CellsProperty);
            }
            private set
            {
                SetValue(CellsProperty, value);
            }
        }
        #endregion
        #region BoardSize
        public static readonly DependencyProperty BoardSizeProperty = DependencyProperty.Register("BoardSize", typeof(Size), typeof(Board), new PropertyMetadata(new Size(1,1), new PropertyChangedCallback(OnBoardSizeChanged)));
        
        public Size BoardSize
        {
            set
            {
                SetValue(BoardSizeProperty, value);
            }
            get
            {
                return (Size)GetValue(BoardSizeProperty);
            }
        }
        #endregion
        #region VerticalHeader
        public static readonly DependencyProperty VerticalHeaderProperty = DependencyProperty.Register("VerticalHeader", typeof(int[][]), typeof(Board), new PropertyMetadata(null, new PropertyChangedCallback(OnVerticalHeaderChanged)));
        
        public int[][] VerticalHeader
        {
            set
            {
                SetValue(VerticalHeaderProperty, value);
            }
            get
            {
                return (int[][])GetValue(VerticalHeaderProperty);
            }
        }
        #endregion
        #region HorizontalHeader
        public static readonly DependencyProperty HorizontalHeaderProperty = DependencyProperty.Register("HorizontalHeader", typeof(int[][]), typeof(Board), new PropertyMetadata(null, new PropertyChangedCallback(OnHorizontalHeaderChanged)));

        public int[][] HorizontalHeader
        {
            set
            {
                SetValue(HorizontalHeaderProperty, value);
            }
            get
            {
                return (int[][])GetValue(HorizontalHeaderProperty);
            }
        }
        #endregion
        #region HorizontalHeaderHeight
        public static readonly DependencyProperty HorizontalHeaderHeightProperty = DependencyProperty.Register("HorizontalHeaderHeight", typeof(GridLength), typeof(Board), new PropertyMetadata(new GridLength(1,GridUnitType.Star)));

        public GridLength HorizontalHeaderHeight
        {
            get
            {
                return (GridLength)GetValue(HorizontalHeaderHeightProperty);
            }
            private set
            {
                SetValue(HorizontalHeaderHeightProperty, value);
            }
        }
        #endregion
        #region VerticalHeaderWidth
        public static readonly DependencyProperty VerticalHeaderWidthProperty = DependencyProperty.Register("VerticalHeaderWidth", typeof(GridLength), typeof(Board), new PropertyMetadata(new GridLength(1, GridUnitType.Star)));

        public GridLength VerticalHeaderWidth
        {
            get
            {
                return (GridLength)GetValue(VerticalHeaderWidthProperty);
            }
            private set
            {
                SetValue(VerticalHeaderWidthProperty, value);
            }
        }
        #endregion
        #region CellSize
        public static readonly DependencyProperty CellSizeProperty = DependencyProperty.Register("CellSizeWidth", typeof(int), typeof(Board), new PropertyMetadata(20, new PropertyChangedCallback(OnCellSizeChanged)));
        /// <summary>
        /// Width and Height value of a cell on the board
        /// </summary>
        public int CellSize
        {
            get
            {
                return (int)GetValue(CellSizeProperty);
            }
            set
            {
                SetValue(CellSizeProperty, value);
            }
        }
        #endregion
    }
}
