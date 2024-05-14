using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepoPropertyBidding<type,Id>
    {
        type Create(type obj);
        List<type> Read();
        type Read(Id id);
        List<type> Read(string id);
        void Update(type obj);
        List<type> Delete(Id id);
        List<type> Delete(int x, int y);

    }
}
