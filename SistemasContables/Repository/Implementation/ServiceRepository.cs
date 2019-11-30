using SistemasContables.Models;
using SistemasContables.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace SistemasContables.Repository.Implementation
{
    public class ServiceRepository<Entity> : IServicesRepository<Entity> where Entity : class
    {
        private readonly ApplicationDbcontext _context = new ApplicationDbcontext();
        public async Task<bool> Create(Entity entity)
        {
            try
            {
                if (entity!=null)
                {
                    _context.Set<Entity>().Add(entity);
                    await  _context.SaveChangesAsync();
                    return true;             
                }
                else
                {
                    return false;
                }


            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public  async Task<bool> Delete(int? id)
        {

            Entity seleccionado = await _context.Set<Entity>().FindAsync(id);
            try
            {
                if (seleccionado != null)
                {
                    _context.Set<Entity>().Remove(seleccionado);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public async Task<bool> Edit(Entity entity)
        {        
            try
            {
                if (entity != null)
                {
                    _context.Entry<Entity>(entity).State = EntityState.Modified;
                   await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public  IEnumerable<Entity> GetAll()
        {
            try
            {
                return _context.Set<Entity>().ToList();
                
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public async Task<Entity> GetbyId(int? id)
        {
            Entity seleccionado =  await _context.Set<Entity>().FindAsync(id);
            try
            {
                if (seleccionado!=null)
                {
                    return seleccionado;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }
    }
}