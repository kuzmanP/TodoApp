using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        //Fields for Repository
        IPersonRepository PersonRepository { get; }
        ITaskRepository TaskRepository { get; }
       

        void Save();

    }
}
