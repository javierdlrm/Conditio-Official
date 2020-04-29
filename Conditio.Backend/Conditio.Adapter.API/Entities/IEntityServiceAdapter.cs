using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Adapter.API.Entities
{
    public interface IEntityServiceAdapter
    {
        Task<EntityDTO> GetAsync(string id);
        Task<EntityWithTermsDTO> GetWithTermsAsync(string id);

        Task<EntityDTO> GetByDomainAsync(string domain);
        Task<EntityWithTermsDTO> GetWithTermsByDomainAsync(string domain);

        Task AddAsync(EntityDTO entity);
        Task UpdateAsync(string id, EntityDTO entity);
        Task DeleteAsync(string id);
    }
}
