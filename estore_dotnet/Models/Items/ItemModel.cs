using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estore_dotnet.Databases;
using modelShoes = estore_dotnet.Models.Items.Schemas;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using dbShoes = estore_dotnet.Databases.Shoes;
using System.Runtime.CompilerServices;
using estore_dotnet.Common;

namespace estore_dotnet.Models.Items
{
    public interface IItemModel
    {
        /// <summary>
        /// Get list of Shoes
        /// <para>Created at: 09/08/2023</para>
        /// <para>Created by: gnohP18</para>
        /// </summary>
        /// <returns>list of Shoes</returns>
        Task<List<Items.Schemas.Shoes>> GetAsync();

        /// <summary>
        /// Get shoes by id
        /// <para>Created at: 09/08/2023</para>
        /// <para>Created by: gnohP18</para>
        /// </summary>
        /// <returns>list of Shoes</returns>
        Task<Items.Schemas.Shoes> GetAsync(string id);
        
        /// <summary>
        /// Create Shoes
        /// <para>Created at: 09/08/2023</para>
        /// <para>Created by: gnohP18</para>
        /// </summary>
        /// <returns>true if created successfully else false</returns>
        Task<ResponseInfo> CreateAsync(Items.Schemas.Shoes shoes);

        /// <summary>
        /// Update Shoes
        /// <para>Created at: 09/08/2023</para>
        /// <para>Created by: gnohP18</para>
        /// </summary>
        /// <returns>true if updated successfully else false</returns>
        Task<ResponseInfo> UpdateAsync(string id, Items.Schemas.Shoes shoes);
        
        /// <summary>
        /// Delete SHoes
        /// <para>Created at: 09/08/2023</para>
        /// <para>Created by: gnohP18</para>
        /// </summary>
        /// <returns>true if delete successfully else false</returns>
        Task<ResponseInfo> DeleteAsync(string[] ids);
    }

    public class ItemModel : BaseModel, IItemModel
    {
        /// <summary>
        /// Data query
        /// </summary>
        private readonly DataContext _context;
        
        private readonly ILogger<ItemModel> _logger;
        /// <summary>
        /// Class name of the model
        /// </summary>
        private string _className = "";
        
        /// <summary>
        /// Collection name in Database
        /// </summary>
        private string _collectionName;

        public ItemModel(
            ILogger<ItemModel> logger,
            DataContext context,
            IOptions<EstoreDatabaseSetting> estoreDatabaseSettings)
        {
            _logger = logger;
            _context = context;
            _className = GetType().Name;
            _collectionName = estoreDatabaseSettings.Value.ShoesCollectionName;
        }

        static string GetActualAsyncMethodName([CallerMemberName] string name = null) => name;

        public async Task<List<Items.Schemas.Shoes>> GetAsync()
        {
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                var filter = new BsonDocument();
                var listDbShoes = await _context.GetCollection<dbShoes>(_collectionName).Find(_ => true).ToListAsync();
                var listShoes = listDbShoes != null ? listDbShoes.Select(
                    x => new Items.Schemas.Shoes()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Color = x.Color,
                        Size = x.Size,
                        Quantity = x.Quantity,
                        Slug = x.Slug,
                        Thumbnail = x.Thumbnail
                    }).ToList()
                    : new List<Items.Schemas.Shoes>();
                _logger.LogInformation($"Found [{listShoes.Count} items]");
                _logger.LogInformation($"[{_className}][{method}] End");
                return listShoes;
            }
            catch (Exception e)
            {
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                throw;
            }

        }

        public async Task<Items.Schemas.Shoes> GetAsync(string id)
        {
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                var dbShoes = await _context.GetCollection<dbShoes>(_collectionName).Find(x => x.Id == id).FirstOrDefaultAsync();
                var shoes = dbShoes != null ? new Items.Schemas.Shoes()
                {
                    Id = dbShoes.Id,
                    Name = dbShoes.Name,
                    Size = dbShoes.Size,
                    Color = dbShoes.Color,
                    Quantity = dbShoes.Quantity,
                    Slug = dbShoes.Slug,
                    Thumbnail = dbShoes.Thumbnail,
                } : new Items.Schemas.Shoes();
                _logger.LogInformation($"Found [{shoes.Id}]");
                _logger.LogInformation($"[{_className}][{method}] End");
                return shoes;
            }
            catch (Exception e)
            {
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                throw;
            }
        }

        public async Task<ResponseInfo> CreateAsync(Items.Schemas.Shoes t)
        {
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                var responseInfo =  new ResponseInfo();

                var dbShoes = new dbShoes()
                {
                    Name = t.Name,
                    Color = t.Color,
                    Size = t.Size,
                    Quantity = t.Quantity,
                    Slug = t.Slug,
                    Thumbnail = t.Thumbnail,
                };
                try
                {                
                    await _context.GetCollection<dbShoes>(_collectionName).InsertOneAsync(dbShoes);
                    responseInfo.Code = CodeResponse.OK;
                    responseInfo.Msg = "Success";
                }
                catch (Exception e)
                {
                    _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                    responseInfo.Code = CodeResponse.HAVE_ERROR;
                    responseInfo.Msg = e.Message;
                    throw;
                }
                responseInfo.Msg = $"{MsgResponse.SUCCESS} {MsgResponse.CREATE}";
                _logger.LogInformation($"{MsgResponse.SUCCESS} {MsgResponse.CREATE}");
                _logger.LogInformation($"[{_className}][{method}] End");
                return responseInfo;
            }
            catch (Exception e)
            {
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                throw;
            }
        }

        public async Task<ResponseInfo> UpdateAsync(string id, modelShoes.Shoes t)
        {
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                var responseInfo =  new ResponseInfo();
                var filter = Builders<dbShoes>.Filter.Eq("_id", new ObjectId(id));
                Console.WriteLine($"{filter.ToBsonDocument()}");
                
                var update = Builders<dbShoes>.Update
                    .Set("name", t.Name)
                    .Set("color", t.Color)
                    .Set("size", t.Size)
                    .Set("quantity", t.Quantity)
                    .Set("slug", t.Slug)
                    .Set("thumbnail", t.Thumbnail);

                var options = new FindOneAndUpdateOptions<dbShoes>
                {
                    ReturnDocument = ReturnDocument.After
                };

                var updatedDocument = await  _context.GetCollection<dbShoes>(_collectionName).FindOneAndUpdateAsync(filter, update, options);
                responseInfo.Msg = $"[{id}] {MsgResponse.SUCCESS} {MsgResponse.UPDATE}";
                _logger.LogInformation($"[{id}] {MsgResponse.SUCCESS} {MsgResponse.UPDATE}");
                _logger.LogInformation($"[{_className}][{method}] End");
                return responseInfo;
            }
            catch (Exception e)
            {   
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                throw;
            }
        }

        public async Task<ResponseInfo> DeleteAsync(string[] ids)
        {
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                var responseInfo = new ResponseInfo();
                var countDelete = 0;
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i].Length > 0)
                    {
                        var filter = Builders<dbShoes>.Filter.Eq("_id", new ObjectId(ids[i]));
                        await _context.GetCollection<dbShoes>(_collectionName).DeleteOneAsync(filter);
                        countDelete++;
                        _logger.LogInformation($"{MsgResponse.SUCCESS} {MsgResponse.DELETE} [{ids[i]}]");
                    }
                }
                _logger.LogInformation($"{MsgResponse.SUCCESS} {MsgResponse.DELETE} {countDelete} document");
                _logger.LogInformation($"[{_className}][{method}] End");
                responseInfo.Msg = $"{MsgResponse.SUCCESS} {MsgResponse.DELETE} {countDelete} document";
                return responseInfo;
            }
            catch (Exception e)
            {   
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                throw;
            }
        }
    }
}