using Dapper;
using DataServiceRelay.IProtoTypes;
using DataServiceRelay.Templates.QueryDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataServiceRelay.Templates.QueryFetchers
{
    public class GetAllTemplatesQueryFetcher : QueryFetcher<GetAllTemplatesOUT, GetAllTemplatesIN>
    {
        public const string SPName = "GetAllTemplates";

        public override IEnumerable<GetAllTemplatesOUT> Fetch(GetAllTemplatesIN param)
        {
            DynamicParameters fetchParameters = new DynamicParameters();
            fetchParameters.Add("@pTemplateTypeId", param.templateTypeId);

            var result = dbConnection.Query<GetAllTemplatesOUT>(SPName, fetchParameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
