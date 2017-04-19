using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DataServiceRelay.Templates.QueryDTO;
using DataServiceRelay.IProtoTypes;
using DataServiceRelay.Templates.QueryFetchers;
using DataServiceRelay.Templates.CommandDTO;
using DataServiceRelay.Templates.CommandExecuters;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HRMS_API.Controllers
{
    [Route("api/[controller]")]
    public class TemplateColumnsController : Controller
    {
        [HttpGet("{templateId}")]
        public IEnumerable<TemplateColumnOUT> GetTemplateColumns(int templateId)
        {
            IQueryFetcher<TemplateColumnOUT, TemplateColumnIN> queryFetcher = new GetTemplateColumnsQueryFetcher();
            return queryFetcher.Fetch(new TemplateColumnIN { templateId = templateId, templateTypeId = 1 });
        }

        [HttpPut]
        public void Put([FromBody]CreateTemplateIN UITemplates)
        {
            if (UITemplates != null)
            {
                ICommandExecuter<CreateTemplateIN> commandExecuter = new CreateTemplateCommandExecuter();
                commandExecuter.Execute(UITemplates);
            }

        }

    }
}
