using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServiceRelay.Templates.QueryDTO
{
    public class TemplateColumnOUT
    {
        public short Id { get; set; }
        public string ColumnDisplayName { get; set; }

        public string ColumnModelName { get; set; }

        public string ColumnDBName { get; set; }

        public bool Included { get; set; }

        public bool Mandatory { get; set; }

    }
}
