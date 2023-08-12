using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estore_dotnet.Databases;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace estore_dotnet.Models
{
    /// <summary>
    /// Create log and handle service 
    /// <para>Author: gnohP18</para>
    /// <para>Created: 08/08/2023</para>
    /// </summary>
    public class BaseModel
    {
        protected readonly DataContext _context;
        public BaseModel()
        {
        }

        public BaseModel(IServiceProvider provider)
        {
            DataContext context = provider.GetRequiredService<DataContext>();
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}