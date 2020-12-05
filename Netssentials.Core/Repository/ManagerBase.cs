using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Netssentials.Core.Repository
{
    public class ManagerBase<TEntity>
    {
        public readonly ILogger<TEntity> Logger;

        public ManagerBase(ILogger<TEntity> logger)
        {
            if (logger != null)
                this.Logger = logger;
        }
    }
}
