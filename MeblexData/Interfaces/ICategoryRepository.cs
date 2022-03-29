using MeblexData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

    }
}
