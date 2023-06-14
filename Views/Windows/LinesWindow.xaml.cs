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
using Line = RequestManager.Data.Entities.Line;

namespace RequestManager.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для LinesWindow.xaml
    /// </summary>
    public partial class LinesWindow : Window
    {
        public LinesWindow(Request selectedRequest)
        {
            
            InitializeComponent();
            CurrentRequestId.Content = selectedRequest.Id;
            CurrentRequestSender.Content = selectedRequest.Sender;
            CurrentRequestDate.Content = selectedRequest.CreationDate;
            
            var requestRepository = new RequestRepository(new Data.RequestManagerContext());
            //((LinesViewModel)this.DataContext).Lines = requestRepository.SelectLinesById(selectedRequest.Id).ToList();
            
            


            ((LinesViewModel)this.DataContext).LinesDomain = new List<LineDomain>()
            { new LineDomain() { ConductorsMaterial="Cu", Configuration = "3P+N",
                Finish = "Fin", IP = "68", Name="Line", RatedCurrent=630, RequestId=2, Start="St", 
                Properties = new List<LinePropertiesDomain>() } };

            var mapper = MapperConfig.InitializeAutomapper();
            List<Line> lines = requestRepository.SelectLinesById(1).ToList();
            List<LineDomain> linesDTO = mapper.Map<List<Line>, List<LineDomain>>(lines);
        }
    }
}
