using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataServiceRelay.IProtoTypes
{
    public abstract class CommandExecuter<IN> : ICommandExecuter<IN>
    {
        protected readonly SqlConnection dbConnection = Adapters.Connection.GetConnection();

        public abstract int Execute(IN param);
    }
}
