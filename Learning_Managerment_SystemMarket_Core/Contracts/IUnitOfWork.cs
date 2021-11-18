using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Core.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        //ICategoryRepository Categories { get; }
        //ITagRepository Tags { get; }
        //IPostRepository Posts { get; }
        Task<bool> Save();
    }
}
