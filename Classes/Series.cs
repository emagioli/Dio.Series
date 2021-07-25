namespace Dio.Series
{
    public class Series : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }

        public Series(int id, Genre genre, string title, string description, int year)
        {
            Id = id;        //from superclass
            Genre = genre;
            Title = title;
            Description = description;
            Year = year;
        }

        public override string ToString()
        {
            string serieslInfo = $"Genre: {Genre}" +
                $"Title: {Title}" +
                $"Description: {Description}" +
                $"Release year: {Year}";
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

    }
}
