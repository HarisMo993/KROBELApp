using KROBEL.Domain.Models;
using KROBEL.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KROBEL.Service.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _repository;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public void DeletePerson(int id)
        {
            Person person = GetPerson(id);
            _repository.Remove(person);
            _repository.SaveChanges();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _repository.GetAll();
        }

        public Person GetPerson(int id)
        {
            return _repository.Get(id);
        }

        public void InsertPerson(Person person)
        {
            _repository.Insert(person);
        }

        public void UpdatePerson(Person person)
        {
            _repository.Update(person);
        }
    }
}
