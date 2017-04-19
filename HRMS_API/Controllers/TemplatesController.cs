using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using DataServiceRelay.Templates.QueryFetchers;
using DataServiceRelay.Templates.QueryDTO;
using DataServiceRelay.IProtoTypes;
using HRMS_API.Models;
using DataServiceRelay.Templates.CommandExecuters;
using Microsoft.AspNet.Cors;
using System.Net.Http;
using System.Net;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HRMS_API.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("policy")]
    public class TemplatesController : Controller
    {
        [HttpGet]
        public IEnumerable<GetAllTemplatesOUT> GetAllTemplates()
        {
            IQueryFetcher<GetAllTemplatesOUT, GetAllTemplatesIN> queryFetcher = new GetAllTemplatesQueryFetcher();
            return queryFetcher.Fetch(new GetAllTemplatesIN { templateTypeId = 1 });
        }

        #region Old Code
        //// GET: api/templates
        //[HttpGet]
        //public IEnumerable<TemplateColumnOUT> GetTemplateColumns()
        //{
        //    IQueryFetcher<TemplateColumnOUT, TemplateColumnIN> queryFetcher = new GetTemplateColumnsQueryFetcher();
        //    return queryFetcher.Fetch(new TemplateColumnIN { templateId = null, templateTypeId = 1 });
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        ////[HttpPut]
        ////public void Put()
        ////{

        ////}

        //// PUT api/values/5
        //public HttpResponseMessage Options()
        //{
        //    return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        //}

        //[HttpPut]
        //public void Put([FromBody]CreateTemplateIN UITemplates)
        //{
        //    if (UITemplates!=null)
        //    {
        //        ICommandExecuter<CreateTemplateIN> commandExecuter = new CreateTemplateCommandExecuter();
        //        commandExecuter.Execute(UITemplates);
        //    }

        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion

    }
}
