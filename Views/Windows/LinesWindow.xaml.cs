using RequestManager.Data.Entities;
using RequestManager.Data.Repositories;
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
            //((LinesViewModel)this.DataContext).Lines = new List<Line>()
            //{ new Line() {RequestId = selectedRequest.Id , ConductorsMaterial= "Cu", Configuration ="dfsaf", Finish = "dfsf",
            //Start = "df", IP = Data.Enums.ProtectionDegree.IP68, Id = 2, RatedCurrent = 5888, Name = "2323"}}; 
            ((LinesViewModel)this.DataContext).Lines = new List<Line>();
        }
    }
}
