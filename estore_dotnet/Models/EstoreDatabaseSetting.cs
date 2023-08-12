using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace estore_dotnet.Models
{
    public class EstoreDatabaseSetting
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ShoesCollectionName { get; set; } = null!;
    }
}