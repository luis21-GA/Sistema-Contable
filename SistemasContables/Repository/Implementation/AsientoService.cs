using SistemasContables.Models;
using SistemasContables.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemasContables.Repository.Implementation
{
    public class AsientoService : ServiceRepository<AsientoDiario>,AsientoRepository
    {
    }
}