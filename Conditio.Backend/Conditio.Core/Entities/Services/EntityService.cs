using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conditio.Core.Entities
{
    public class EntityService : IEntityService
    {
        private readonly IEntityRepository _entityRepository;

        public EntityService(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        #region CRUD

        public async Task AddAsync(Entity entity)
        {
            await _entityRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _entityRepository.DeleteAsync(id);
        }

        public async Task<Entity> GetAsync(string id)
        {
            return await _entityRepository.GetAsync(id);
        }

        public async Task UpdateAsync(string id, Entity entity)
        {
            await _entityRepository.UpdateAsync(id, entity);
        }

        #endregion

        public async Task<EntitySource> GetWithTermsAsync(string id)
        {
            return await _entityRepository.GetWithTermsAsync(id);
        }

        public async Task<Entity> GetByDomainAsync(string domain)
        {
            return await _entityRepository.GetByDomainAsync(domain);
        }

        public async Task<EntitySource> GetWithTermsByDomainAsync(string domain)
        {
            return await _entityRepository.GetWithTermsByDomainAsync(domain);
        }
    }
}
