namespace SolidPresentation.SRP.Bad
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public void Save()
        {
            var fileName = TempFileManager.GetNewPath(this.Author + " - " + this.Title);
            MyXmlSerializer.Serialize(fileName, this);
        }
    }
}