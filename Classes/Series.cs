namespace Dio.Series
{
    public class Series : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        public Series(int id, Genre genre, string title, string description, int year)
        {
            Id = id;        //from superclass
            Genre = genre;
            Title = title;
            Description = description;
            Year = year;
            Deleted = false;
        }

        public override string ToString()
        {
            string serieslInfo = $"Genre: {Genre} \n" +
                $"Title: {Title}\n" +
                $"Description: {Description}\n" +
                $"Release year: {Year}\n" +
                $"Deleted: {Deleted}";
            return serieslInfo;

        }
        public string GetTitle()
        {
            return Title;
        }
        public int GetId()
        {
            return Id;
        }
        public bool GetDeleted()
        {
            return Deleted;
        }
        public void Delete()
        {
            Deleted = true;
        }

    }
}
