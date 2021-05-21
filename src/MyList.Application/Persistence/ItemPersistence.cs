using MyList.Domain;
using MyList.Domain.Behaviors;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyList.Application.Persistence
{
    internal class ItemPersistence : IItemPersistence
    {
        private readonly ItemDb _db;
        public ItemPersistence(ItemDb db)
        {
            _db = db;
        }


        public async Task<string> Create(Item item, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return string.Empty;

            _db.Save(item);
            return await Task.FromResult(item.Id);
        }

        public async Task<int> Remove(string id, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return -1;

            return await Task.FromResult(_db.Delete(id));
        }

        public async Task<int> Update(Item item, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return -1;

            _db.Save(item);
            return await Task.FromResult(1);
        }
    }
}
