using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<Type, id>
    {
        void Create(Type obj);
        List<Type> Read();
        Type Read(id id);
        void Update(Type obj);
        bool Delete(id id);
    }
}
