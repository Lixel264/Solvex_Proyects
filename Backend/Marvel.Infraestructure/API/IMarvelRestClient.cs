using Marvel.Domain.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Marvel.Infraestructure.API
{
    public interface IMarvelRestClient<T>
    {

        public Task<dynamic> GetAllAsync(string requestedUri);
        
        public Task GetAsync(string requestedUri);


    }
}
