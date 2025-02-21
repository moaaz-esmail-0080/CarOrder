using CarCatalog.API.Exceptions;
using MessageCore.Exceptions;

namespace CarCatalog.API.Exceptions
{
    public class CarsNotFoundException : NotFoundException
    {
        public CarsNotFoundException(Guid Id) : base("Cars", Id)
        {
        }
    }
}


