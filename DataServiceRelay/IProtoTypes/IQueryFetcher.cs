using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServiceRelay.IProtoTypes
{
    public interface IQueryFetcher<Out, IN>
    {
        IEnumerable<Out> Fetch(IN param);
    }
}
