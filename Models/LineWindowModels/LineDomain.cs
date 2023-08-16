using Azure.Core;
using RequestManager.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManager.Data.Entities
{

    internal class LineDomain : ViewModels.Base.ViewModel
    {
        private int requestId;
        private string? name;
        private string? start;
        private string? finish;
        private string configuration;
        private int ratedCurrent;
        private string conductorsMaterial;
        private string iP;
        private IEnumerable<LinePropertiesDomain>? properties;

        public int Id { get; set; }
        public int RequestId {
            get { return requestId; }
            set => Set(ref requestId, value);
        }
        public string? Name
        {
            get { return name; }
            set => Set(ref name, value);
        }
        public string? Start
        {
            get { return start; }
            set => Set(ref start, value);
        }
        public string? Finish
        {
            get { return finish; }
            set => Set(ref finish, value);
        }

        public string Configuration
        {
            get { return configuration; }
            set => Set(ref configuration, value);
        }

        public int RatedCurrent
        {
            get { return ratedCurrent; }
            set => Set(ref ratedCurrent, value);
        }

        public string ConductorsMaterial
        {
            get { return conductorsMaterial; }
            set => Set(ref conductorsMaterial, value);
        }

        public string IP
        {
            get { return iP; }
            set {
                Set(ref iP, value);
                if (Properties != null)
                {
                    foreach (var prop in Properties)
                    {
                        if (value != "Различные")
                            prop.IP = value;
                        else
                            prop.IP = "Требуется ввод";
                    }
                }
                
            } 


        }
        public IEnumerable<LinePropertiesDomain>? Properties
        {
            get { return properties; }
            set => Set(ref properties, value);
        }
        public Request Request { get; set; }
    }
}
