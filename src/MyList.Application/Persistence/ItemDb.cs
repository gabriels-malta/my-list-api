using MyList.Domain;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MyList.Application.Persistence
{
    internal class ItemDb
    {
        private readonly object objLock = new object();
        private readonly ConcurrentDictionary<string, Item> _db;

        public ItemDb()
        {
            if (_db == null)
            {
                lock (objLock)
                {
                    if (_db == null)
                        _db = new ConcurrentDictionary<string, Item>();
                }
            }
        }

        public IEnumerable<Item> GetWhere(Func<Item, bool> whereFunction) => _db.Values.Where(whereFunction);
        public IEnumerable<Item> All() => _db.Values;

        public Item Get(string id) => _db.TryGetValue(id, out Item item) ? item : null;

        public void Save(Item item) => _db.AddOrUpdate(item.Id, item, updateValueFactory: (key, oldValue) => oldValue = item);

        public int Delete(string id) => _db.TryRemove(id, out _) ? 1 : -1;
    }
}
