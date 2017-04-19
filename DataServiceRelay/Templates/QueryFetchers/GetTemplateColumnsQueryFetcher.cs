using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServiceRelay.IProtoTypes;
using DataServiceRelay.Templates.QueryDTO;
using Dapper;
using System.Data;

namespace DataServiceRelay.Templates.QueryFetchers
{
    public class GetTemplateColumnsQueryFetcher : QueryFetcher<TemplateColumnOUT, TemplateColumnIN>
    {
        public const string SPName = "GetTemplateColumns";

        public override IEnumerable<TemplateColumnOUT> Fetch(TemplateColumnIN param)
        {
            DynamicParameters fetchParameters = new DynamicParameters();
            fetchParameters.Add("@pTemplateId", param.templateId);
            fetchParameters.Add("@pTemplateTypeId", param.templateTypeId);

            var result = dbConnection.Query<TemplateColumnOUT>(SPName, fetchParameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
