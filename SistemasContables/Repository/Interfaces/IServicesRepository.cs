using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemasContables.Repository.Interfaces
{
    public interface IServicesRepository<Entity> where Entity: class
    {
        Task<bool> Create(Entity entity);
        Task<bool> Edit(Entity entity);
        Task<bool> Delete(int? id);
       IEnumerable<Entity> GetAll();
        Task<Entity> GetbyId(int? id);

    }
}
