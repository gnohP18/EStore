using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estore_dotnet.Databases;

namespace estore_dotnet.Models.Items.Schemas
{
    public class Shoes
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int Size { get; set; } 
        public int Quantity { get; set; }
        public string Slug { get; set; } = null!;
        public string Thumbnail { get; set; } = null!;
    }
}