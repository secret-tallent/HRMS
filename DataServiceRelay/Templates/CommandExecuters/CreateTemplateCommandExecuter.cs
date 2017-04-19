using DataServiceRelay.IProtoTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Transactions;
using DataServiceRelay.Templates.CommandDTO;

namespace DataServiceRelay.Templates.CommandExecuters
{
    public class CreateTemplateCommandExecuter : CommandExecuter<CreateTemplateIN>
    {
        public string SPName_CreateTemplate = "CreateTemplate";
        public string SPName_UpdateTemplateColumns = "UpdateTemplateColumns";

        public override int Execute(CreateTemplateIN param)
        {
            using (TransactionScope scope = new TransactionScope())
            using (var con = dbConnection)
            {
                con.Open();
                using (var tran = con.BeginTransaction())
                {
                    try
                    {
                        Int16 templateId;

                        int noOfTemplates=0;

                        if (param.TemplateId == 0)
                        {
                            DynamicParameters createTemplateParam = new DynamicParameters();
                            createTemplateParam.Add("@pTemplateTypeId", 1);
                            createTemplateParam.Add("@pTemplateName", param.TemplateName);
                            createTemplateParam.Add("@pTemplateId", param.TemplateId, dbType: DbType.Int16, direction: ParameterDirection.Output);

                            noOfTemplates = con.Execute(SPName_CreateTemplate, createTemplateParam, tran, commandType: System.Data.CommandType.StoredProcedure);

                            templateId = createTemplateParam.Get<Int16>("@pTemplateId");
                        }
                        else
                        {
                            templateId = (Int16)param.TemplateId;
                        }

                        foreach (var col in param.TemplateColumns)
                        {   
                            DynamicParameters updateTemplateColumnsParams = new DynamicParameters();

                            updateTemplateColumnsParams.Add("@pTemplateId", templateId);
                            updateTemplateColumnsParams.Add("@pColumnId", col.Id);
                            updateTemplateColumnsParams.Add("@pMandatory", col.Mandatory);
                            updateTemplateColumnsParams.Add("@pIncluded", col.Included);
                            con.Execute(SPName_UpdateTemplateColumns, updateTemplateColumnsParams, tran, commandType: System.Data.CommandType.StoredProcedure);
                        }

                        tran.Commit();
                        scope.Complete();
                        return noOfTemplates;
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
               
        }
    }
}
