namespace SolidPresentation.DIP.Good.Fakes
{
    using System;
    using System.Collections.Generic;
    using SolidPresentation.DIP.Good.Domain.Models;
    using SolidPresentation.DIP.Good.Services;

    public class FakePersonCreationService : IPersonCreationService
    {
        private readonly IReadOnlyList<Person> personsToCreate;
        private int currentIndex;

        public FakePersonCreationService(IReadOnlyList<Person> personsToCreate)
        {
            if (personsToCreate == null)
            {
                throw new ArgumentNullException(nameof(personsToCreate));
            }

            this.personsToCreate = personsToCreate;
        }

        public CancellableResult<Person> Create()
        {
            var result = CancellableResult<Person>.Cancel();

            if (this.currentIndex < this.personsToCreate.Count)
            {
                result = CancellableResult<Person>.Success(this.personsToCreate[this.currentIndex]);
                this.currentIndex++;
            }

            return result;
        }
    }
}
