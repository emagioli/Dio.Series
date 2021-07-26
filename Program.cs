using System;

namespace Dio.Series
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5":
                        AccessSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            Console.WriteLine("Thanks for using DIO Series!");
        }


        private static void ListSeries()
        {
            Console.WriteLine();
            Console.WriteLine("Series list:");
            Console.WriteLine();

            var list = repository.List();
            if (list.Count == 0)
            {
                Console.WriteLine("No series have been added yet.");
                return;
            }
            foreach (var series in list)
            {
                if (!series.GetDeleted())
                {
                    Console.WriteLine($"#ID {series.GetId()}: - {series.GetTitle()} {(series.GetDeleted() ? "*DELETED*" : "")}");
                }
            }
        }
        private static void InsertSeries()
        {
            Console.WriteLine();
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} = {Enum.GetName(typeof(Genre), i)}");
            }

            Console.Write("Please, enter the series genre code: ");
            int genreInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the series title: ");
            string titleInput = Console.ReadLine();

            Console.Write("Enter the series release year: ");
            int yearInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the series description: ");
            string descriptionInput = Console.ReadLine();

            Series newSeries = new Series(
                id: repository.NextId(),
                genre: (Genre)genreInput,
                title: titleInput,
                year: yearInput,
                description: descriptionInput
                );

            repository.Insert(newSeries);
        }
        private static void DeleteSeries()
        {
            Console.WriteLine();
            Console.Write("Enter the series id: ");
            int seriesIndex = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write($"Selected series: ");
            Console.WriteLine(repository.GetById(seriesIndex).GetTitle());
            Console.WriteLine();
            Console.Write("Are you sure you want to delete it from the series list? (Y/N): ");
            string deleteConfirmation = Console.ReadLine().ToUpper();

            while (deleteConfirmation != "Y" && deleteConfirmation != "N")
            {
                Console.WriteLine();
                Console.Write("Invalid value, please try again.");
                Console.WriteLine();
                Console.Write("Are you sure you want to delete it from the series list? (Y/N): ");
                deleteConfirmation = Console.ReadLine().ToUpper();
            }

            if (deleteConfirmation == "N")
            {
                return;
            }
            else
            {
                repository.Delete(seriesIndex);
            }
        }
        private static void AccessSeries()
        {
            Console.WriteLine();
            Console.Write("Enter the series id: ");
            int seriesIndex = int.Parse(Console.ReadLine());

            var series = repository.GetById(seriesIndex);
            Console.WriteLine();
            Console.WriteLine("Series info:");
            Console.WriteLine(series);
        }
        private static void UpdateSeries()
        {
            Console.WriteLine();
            Console.Write("Please, enter the series' id: ");
            int seriesIndex = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine($"Selected series: {repository.GetById(seriesIndex).GetTitle()}");
            Console.WriteLine();
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Genre), i)}");
            }
            Console.WriteLine();
            Console.Write("Please, enter the genre code: ");
            int genreInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the series title: ");
            string titleInput = Console.ReadLine();

            Console.Write("Enter the series release year: ");
            int yearInput = int.Parse(Console.ReadLine());

            Console.Write("Enter the series description: ");
            string descriptionInput = Console.ReadLine();

            Series updatedSeries = new Series(
                id: seriesIndex,
                genre: (Genre)genreInput,
                title: titleInput,
                year: yearInput,
                description: descriptionInput
                );
            repository.Update(seriesIndex, updatedSeries);
        }
        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO SERIES");
            Console.WriteLine();

            Console.WriteLine("1- List series");
            Console.WriteLine("2- Add new series");
            Console.WriteLine("3- Update existing series");
            Console.WriteLine("4- Delete existing series");
            Console.WriteLine("5- Access series");
            Console.WriteLine("C- Clean Screen");
            Console.WriteLine("X- Quit");

            Console.WriteLine();
            Console.Write("Enter the desired option: ");

            string userOption = Console.ReadLine().ToUpper();
            return userOption;
        }
    }
}
