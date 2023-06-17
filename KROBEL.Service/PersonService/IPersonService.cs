using KROBEL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KROBEL.Service.PersonService
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAllPersons();
        Person GetPerson(int id);
        void InsertPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(int id);
    }
}
