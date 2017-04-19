using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServiceRelay.IProtoTypes
{
    public interface ICommandExecuter<IN>
    {
        int Execute(IN param);
    }
}
