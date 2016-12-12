namespace SolidPresentation.DIP.Bad.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LiteDB;
    using SolidPresentation.DIP.Bad.Business.DbModel;
    using SolidPresentation.DIP.Bad.Business.Models;

    public class LiteDbPersonRepository
    {
        private readonly LiteCollection<DbPerson> dbPersonsCollection;

        public LiteDbPersonRepository(LiteDatabase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            this.dbPersonsCollection = database.GetCollection<DbPerson>("persons");
        }

        public IReadOnlyCollection<Person> GetAll()
        {
            var dbPersons = this.dbPersonsCollection.FindAll();

            var persons =
                dbPersons
                    .Select(p => p.ToPerson())
                    .ToList();
            return persons;
        }

        public void Save(Person person)
        {
            var hasExistingEntry = this.dbPersonsCollection.Exists(p => p.Id == person.Id);
            if (hasExistingEntry)
            {
                this.dbPersonsCollection.Update(person.DbModel);
            }
            else
            {
                var maxId =
                    this.dbPersonsCollection.Count() > 0
                    ? this.dbPersonsCollection.Max(p => p.Id).AsInt64
                    : 0;

                person.DbModel.Id = maxId + 1;
                this.dbPersonsCollection.Insert(person.DbModel);
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
                this.dbPersonsCollection.Delete(id);
            }
        }
    }
}
