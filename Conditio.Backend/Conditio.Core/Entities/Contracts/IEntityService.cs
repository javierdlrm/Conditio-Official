using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Core.Entities
{
    public interface IEntityService
    {
        Task<Entity> GetAsync(string id);
        Task<EntitySource> GetWithTermsAsync(string id);

        Task<Entity> GetByDomainAsync(string domain);
        Task<EntitySource> GetWithTermsByDomainAsync(string domain);

        Task AddAsync(Entity entity);
        Task UpdateAsync(string id, Entity entity);
        Task DeleteAsync(string id);
    }
}
