using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyList.Domain.Behaviors
{
    public interface IItemLookup
    {
        Task<IEnumerable<Item>> GetCompleted(CancellationToken cancellationToken);
        Task<Item> GetById(string id, CancellationToken cancellationToken);
        Task<IEnumerable<Item>> GetAll(CancellationToken cancellationToken);
    }
}
