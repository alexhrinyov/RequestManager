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
    }
}
