using DataServiceRelay.Templates.QueryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS_API.Models
{
    public class CreateTemplateModel
    {
        public int TemplateId { get; set; }

        public string TemplateName { get; set; }

        public List<TemplateColumnOUT> TemplateColumns { get; set;}
    }
}
