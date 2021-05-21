using MyList.Application.Persistence;
using MyList.Domain;
using MyList.Domain.Behaviors;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyList.Application.Lookup
{
    internal class ItemLookup : IItemLookup
    {
        private readonly ItemDb _db;

        public ItemLookup(ItemDb db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Item>> GetCompleted(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return Enumerable.Empty<Item>();                

            return await Task.FromResult(_db.GetWhere(x => x.Completed));
        }

        public async Task<IEnumerable<Item>> GetAll(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return Enumerable.Empty<Item>();

            return await Task.FromResult(_db.All());
        }

        public async Task<Item> GetById(string id, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return null;

            return await Task.FromResult(_db.Get(id));
        }
    }
}
