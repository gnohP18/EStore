using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace estore_dotnet.Models
{
    /// <summary>
    /// CRUD with a custom object
    /// <para>Author: gnohP18</para>
    /// <para>Created: 09/08/2023</para>
    /// </summary>
    public interface IGenericService<T>
    {
        Task<List<T>> GetAsync();
        Task<T> GetAsync(string id);
        Task<bool> CreateAsync(T t);
        Task<bool> UpdateAsync(string id, T t);
        Task<bool> DeleteAsync(string id);
    }  
}