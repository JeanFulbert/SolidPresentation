namespace SolidPresentation.ISP.Other.Good
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CachedPersonRepository
    {
        private readonly PersonEntityContext context;
        private List<Person> cachedPersons;

        public CachedPersonRepository(PersonEntityContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.context = context;
        }
        
        public IReadOnlyCollection<Person> GetAll()
        {
            if (this.cachedPersons == null)
            {
                this.cachedPersons = this.context.GetAll().ToList();
            }

            return this.cachedPersons;
        }

        public void Save(Person person)
        {
            this.context.Save(person);
            this.cachedPersons.Add(person);
        }
    }

    public class MyAwesomeService
    {
        private readonly CachedPersonRepository cachedPersonRepository;

        public MyAwesomeService(CachedPersonRepository cachedPersonRepository)
        {
            if (cachedPersonRepository == null)
            {
                throw new ArgumentNullException(nameof(cachedPersonRepository));
            }

            this.cachedPersonRepository = cachedPersonRepository;
        }

        public void DoSomethingAwesome(string name)
        {
            var newPerson = new Person(name);

            /*
            var persons = this.cachedPersonRepository.GetAll();
            persons.Add(newPerson);
            /*/
            this.cachedPersonRepository.Save(newPerson);
            //*/
        }
    }
}