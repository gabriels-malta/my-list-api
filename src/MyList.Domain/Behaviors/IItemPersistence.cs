using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyList.Domain.Behaviors
{
    public interface IItemPersistence
    {
        Task<string> Create(Item item, CancellationToken cancellationToken);
        Task<int> Update(Item item, CancellationToken cancellationToken);
        Task<int> Remove(string id, CancellationToken cancellationToken);
    }
}
