using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Data
{
    public partial class StoredModelBase : ModelBase
    {
        public int Status { get; set; }
    }
    public partial class ModelBase
    {
        public DateTime Created_Date { get; set; }
    }
}
