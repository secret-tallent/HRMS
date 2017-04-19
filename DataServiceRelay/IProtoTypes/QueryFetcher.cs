using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataServiceRelay.IProtoTypes
{
    public abstract class QueryFetcher<OUT, IN> : IQueryFetcher<OUT, IN>
    {
        protected readonly SqlConnection dbConnection = Adapters.Connection.GetConnection();

        public abstract IEnumerable<OUT> Fetch(IN param);
    }
}
