namespace SolidPresentation.OCP.Example1.Db
{
    using System.Collections;
    using System.Collections.Generic;

    public class DbSet<T> : IReadOnlyCollection<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count { get; }
    }
}
