using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Conditio.Core.Entities;

namespace Conditio.Adapter.API.Entities
{
    public class EntityServiceAdapter : BaseServiceAdapter, IEntityServiceAdapter
    {
        private readonly IEntityService _entityService;

        public EntityServiceAdapter(IEntityService entityService, IMapper mapper) : base(mapper)
        {
            _entityService = entityService;
        }

        public async Task AddAsync(EntityDTO entityDTO)
        {
            await _entityService.AddAsync(Mapper.Map<Entity>(entityDTO));
        }

        public async Task DeleteAsync(string id)
        {
            await _entityService.DeleteAsync(id);
        }

        public async Task<EntityDTO> GetAsync(string id)
        {
            var entity = await _entityService.GetAsync(id);
            return Mapper.Map<EntityDTO>(entity);
        }

        public async Task<EntityWithTermsDTO> GetWithTermsAsync(string id)
        {
            var entity = await _entityService.GetWithTermsAsync(id);
            return Mapper.Map<EntityWithTermsDTO>(entity);
        }

        public async Task<EntityDTO> GetByDomainAsync(string domain)
        {
            var entities = await _entityService.GetByDomainAsync(domain);
            return Mapper.Map<EntityDTO>(entities);
        }

        public async Task<EntityWithTermsDTO> GetWithTermsByDomainAsync(string domain)
        {
            var entities = await _entityService.GetWithTermsByDomainAsync(domain);
            return Mapper.Map<EntityWithTermsDTO>(entities);
        }

        public async Task UpdateAsync(string id, EntityDTO entityDTO)
        {
            await _entityService.UpdateAsync(id, Mapper.Map<Entity>(entityDTO));
        }
    }
}
