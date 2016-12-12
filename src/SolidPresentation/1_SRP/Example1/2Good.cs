namespace SolidPresentation.SRP.Good
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class SimpleFileBookPersistence
    {
        public void Save(Book book)
        {
            var fileName = TempFileManager.GetNewPath(book.Author + " - " + book.Title);
            MyXmlSerializer.Serialize(fileName, book);
        }
    }
}