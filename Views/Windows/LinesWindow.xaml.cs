using AutoMapper;
using RequestManager.Data.Entities;
using RequestManager.Data.Repositories;
using RequestManager.Infrastructure;
using RequestManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.LinkLabel;
using Line = RequestManager.Data.Entities.Line;

namespace RequestManager.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для LinesWindow.xaml
    /// </summary>
    public partial class LinesWindow : Window
    {
        internal IMapper _mapper;
        public LinesWindow(Request selectedRequest)
        {
            
            InitializeComponent();
            CurrentRequestId.Content = selectedRequest.Id;
            CurrentRequestSender.Content = selectedRequest.Sender;
            CurrentRequestDate.Content = selectedRequest.CreationDate;
            
            var requestRepository = new RequestRepository(new Data.RequestManagerContext());
            var Lines = requestRepository.SelectLinesById(selectedRequest.Id).ToList();
            ((LinesViewModel)this.DataContext).Mapper = MapperConfig.InitializeAutomapper();

            ((LinesViewModel)this.DataContext).LinesDomain =
                ((LinesViewModel)this.DataContext).Mapper.Map<List<Line>, List<LineDomain>>(Lines);
            
        }

        private void AllLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LineProperties.SelectedIndex = 0;
        }

        private void AllLines_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            ResetEnter(AllLines, e);

        }

        /// <summary>
        /// Метод делает так, чтобы при нажатии на Enter, выбиралась следующая ячейка в строке, а при окончании строки выбиралась
        /// первая ячейка следующей строки
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="e"></param>
        private static void ResetEnter(DataGrid grid, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                //Select the first column of the first item.
                var currentCell = grid.CurrentCell;
                var currentIndex = grid.SelectedIndex;
                DataGridCellInfo nextCell;
                if (currentCell.Column.DisplayIndex != grid.Columns.Count - 1)
                {
                    var nextColumn = grid.Columns[currentCell.Column.DisplayIndex + 1];
                    int i = 1;
                    while (nextColumn.Visibility != Visibility.Visible)
                    {
                        i++;
                        nextColumn = grid.Columns[currentCell.Column.DisplayIndex + i];
                    }
                    nextCell = new DataGridCellInfo(grid.Items[grid.SelectedIndex], nextColumn);

                }
                else
                {
                    if (grid.SelectedIndex != grid.Items.Count - 1)
                        nextCell = new DataGridCellInfo(grid.Items[grid.SelectedIndex + 1], grid.Columns[0]);

                }

                var nextIndex = currentIndex + 1;
                grid.SelectionUnit = DataGridSelectionUnit.Cell;
                grid.SelectedCells.Remove(currentCell);
                if (grid.SelectedIndex != -1)
                    grid.SelectedCells.Add(nextCell);
                grid.CurrentCell = nextCell;
                e.Handled = true;
                grid.SelectionUnit = DataGridSelectionUnit.FullRow;
                if (currentCell.Column.DisplayIndex != grid.Columns.Count - 1)
                {
                    grid.SelectedIndex = currentIndex;
                }
                else
                {
                    if (grid.Items[currentIndex] != null)
                        grid.SelectedIndex = nextIndex;



                }

            }
        }

        private void LineProperties_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ResetEnter(LineProperties,e);
        }

        private void TapOffBoxes_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ResetEnter(TapOffBoxes, e);
        }

        private void Reductions_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ResetEnter(Reductions, e);
        }
    }
}
