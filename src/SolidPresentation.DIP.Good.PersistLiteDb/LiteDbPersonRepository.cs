namespace SolidPresentation.DIP.Good.PersistLiteDb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LiteDB;
    using SolidPresentation.DIP.Good.Domain.Models;
    using SolidPresentation.DIP.Good.PersistLiteDb.DbModel;
    using SolidPresentation.DIP.Good.Services.Repositories;

    public class LiteDbPersonRepository : IPersonRepository
    {
        private readonly LiteCollection<DbPerson> dbPersons;

        public LiteDbPersonRepository(LiteDatabase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            this.dbPersons = database.GetCollection<DbPerson>("persons");
        }

        public IReadOnlyCollection<Person> GetAll()
        {
            var allDbPersons = this.dbPersons.FindAll();

            var persons =
                allDbPersons
                    .Select(p => p.ToPerson())
                    .ToList();

            return persons;
        }

        public void Save(Person person)
        {
            var newValue = DbPerson.FromPerson(person);

            var hasExistingEntry = this.dbPersons.Exists(p => p.Id == person.Id);
            if (hasExistingEntry)
            {
                this.dbPersons.Update(newValue);
            }
            else
            {
                var maxId =
                    this.dbPersons.Count() > 0
                    ? this.dbPersons.Max(p => p.Id).AsInt64
                    : 0;

                newValue.Id = maxId + 1;
                this.dbPersons.Insert(newValue);
            }
        }

        public void Remove(IReadOnlyCollection<Person> personsToRemove)
        {
            var idsToRemove =
                personsToRemove
                    .Select(p => p.Id)
                    .ToList();

            foreach (var id in idsToRemove)
            {
                this.dbPersons.Delete(id);
            }
        }
    }
}
