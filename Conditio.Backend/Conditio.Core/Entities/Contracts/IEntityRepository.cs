using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Core.Entities
{
    public interface IEntityRepository : IRepository<Entity>
    {
        Task<EntitySource> GetWithTermsAsync(string id);
        Task<Entity> GetByDomainAsync(string domain);
        Task<EntitySource> GetWithTermsByDomainAsync(string domain);
    }
}
