using System;
using System.Collections.Generic;
using System.Linq;
using TheMovies.Models;
using System.IO;

namespace TheMovies.Repos
{
    public class CinemaMovieShowBookingRepo : IRepository<CinemaMovieShowBooking>
    {
        private List<CinemaMovieShowBooking> entries;

        public CinemaMovieShowBookingRepo()
        {
            entries = new List<CinemaMovieShowBooking>();
            LoadRepo();
        }

        public IEnumerable<CinemaMovieShowBooking> GetAll()
        {
            // Return a copy of the internal datastructure

            return entries.ToList();
        }

        public CinemaMovieShowBooking GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Add(CinemaMovieShowBooking obj)
        {
            // cinema:0, movie:1, show:2, booking:3
            int addIndex = -1;

            // Check if update cinema
            if (obj.CinemaName != default)
            {
                addIndex = 0;
            }

            // Check if update movie
            else if (obj.MovieTitle != default)
            {
                addIndex = 1;
            }

            // Check if update show
            else if (obj.ShowDateTime != default)
            {
                addIndex = 2;
            }

            // Check if update booking
            else if (obj.BookingMail != default)
            {
                addIndex = 3;
            }

            foreach (CinemaMovieShowBooking cinemaMovieShowBooking in entries)
            {
                switch (addIndex)
                {
                    case 0:
                        if (cinemaMovieShowBooking.CinemaName == obj.CinemaName &&
                            cinemaMovieShowBooking.CinemaTown == obj.CinemaTown)
                        {
                            throw new InvalidOperationException("Item already exists");
                        }
                        break;

                    case 1:
                        if (cinemaMovieShowBooking.MovieTitle == obj.MovieTitle &&
                            cinemaMovieShowBooking.MovieGenre == obj.MovieGenre &&
                            cinemaMovieShowBooking.MovieDuration == obj.MovieDuration &&
                            cinemaMovieShowBooking.MovieDirector == obj.MovieDirector &&
                            cinemaMovieShowBooking.MovieReleaseDate == obj.MovieReleaseDate)
                        {
                            throw new InvalidOperationException("Item already exists");
                        }
                        break;

                    case 2:
                        if (cinemaMovieShowBooking.ShowDateTime == obj.ShowDateTime)
                        {
                            throw new InvalidOperationException("Item already exists");
                        }
                        break;

                    case 3:
                        if (cinemaMovieShowBooking.BookingMail == obj.BookingMail &&
                            cinemaMovieShowBooking.BookingPhone == obj.BookingPhone)
                        {
                            throw new InvalidOperationException("Item already exists");
                        }
                        break;

                    default:
                        break;
                }
            }

            entries.Add(obj);
            SaveRepo();
        }

        public void Delete(CinemaMovieShowBooking obj)
        {
            // cinema:0, movie:1, show:2, booking:3
            int deleteIndex = -1;

            // Check if update cinema
            if (obj.CinemaName != default)
            {
                deleteIndex = 0;
            }

            // Check if update movie
            else if (obj.MovieTitle != default)
            {
                deleteIndex = 1;
            }

            // Check if update show
            else if (obj.ShowDateTime != default)
            {
                deleteIndex = 2;
            }

            // Check if update booking
            else if (obj.BookingMail != default)
            {
                deleteIndex = 3;
            }

            foreach (CinemaMovieShowBooking cinemaMovieShowBooking in entries)
            {
                switch (deleteIndex)
                {
                    case 0:
                        if (cinemaMovieShowBooking.CinemaName == obj.CinemaName &&
                            cinemaMovieShowBooking.CinemaTown == obj.CinemaTown)
                        {
                            cinemaMovieShowBooking.CinemaName = null;
                            cinemaMovieShowBooking.CinemaTown = null;
                        }
                        break;

                    case 1:
                        if (cinemaMovieShowBooking.MovieTitle == obj.MovieTitle &&
                            cinemaMovieShowBooking.MovieGenre == obj.MovieGenre &&
                            cinemaMovieShowBooking.MovieDuration == obj.MovieDuration &&
                            cinemaMovieShowBooking.MovieDirector == obj.MovieDirector &&
                            cinemaMovieShowBooking.MovieReleaseDate == obj.MovieReleaseDate)
                        {
                            cinemaMovieShowBooking.MovieTitle = null;
                            cinemaMovieShowBooking.MovieGenre = null;
                            cinemaMovieShowBooking.MovieDuration = default;
                            cinemaMovieShowBooking.MovieDirector = null;
                            cinemaMovieShowBooking.MovieReleaseDate = default;
                        }
                        break;

                    case 2:
                        if (cinemaMovieShowBooking.ShowDateTime == obj.ShowDateTime)
                        {
                            cinemaMovieShowBooking.ShowDateTime = default;
                        }
                        break;

                    case 3:
                        if (cinemaMovieShowBooking.BookingMail == obj.BookingMail &&
                            cinemaMovieShowBooking.BookingPhone == obj.BookingPhone)
                        {
                            cinemaMovieShowBooking.BookingMail = null;
                            cinemaMovieShowBooking.BookingPhone = null;
                        }
                        break;

                    default:
                        break;
                }
            }
            SaveRepo();
        }

        public void Update(CinemaMovieShowBooking obj, CinemaMovieShowBooking newValues)
        {
            // cinema:0, movie:1, show:2, booking:3
            int updateIndex = -1;

            // Check if update cinema
            if (newValues.CinemaName != default)
            {
                updateIndex = 0;
            }

            // Check if update movie
            else if (newValues.MovieTitle != default)
            {
                updateIndex = 1;
            }

            // Check if update show
            else if (newValues.ShowDateTime != default)
            {
                updateIndex = 2;
            }

            // Check if update booking
            else if (newValues.BookingMail != default)
            {
                updateIndex = 3;
            }

            foreach (CinemaMovieShowBooking cinemaMovieShowBooking in entries)
            {
                switch (updateIndex)
                {
                    case 0:
                        if (cinemaMovieShowBooking.CinemaName == obj.CinemaName &&
                            cinemaMovieShowBooking.CinemaTown == obj.CinemaTown)
                        {
                            cinemaMovieShowBooking.CinemaName = newValues.CinemaName;
                            cinemaMovieShowBooking.CinemaTown = newValues.CinemaTown;
                        }
                        break;

                    case 1:
                        if (cinemaMovieShowBooking.MovieTitle == obj.MovieTitle &&
                            cinemaMovieShowBooking.MovieGenre == obj.MovieGenre &&
                            cinemaMovieShowBooking.MovieDuration == obj.MovieDuration &&
                            cinemaMovieShowBooking.MovieDirector == obj.MovieDirector &&
                            cinemaMovieShowBooking.MovieReleaseDate == obj.MovieReleaseDate)
                        {
                            cinemaMovieShowBooking.MovieTitle = newValues.MovieTitle;
                            cinemaMovieShowBooking.MovieGenre = newValues.MovieGenre;
                            cinemaMovieShowBooking.MovieDuration = newValues.MovieDuration;
                            cinemaMovieShowBooking.MovieDirector = newValues.MovieDirector;
                            cinemaMovieShowBooking.MovieReleaseDate = newValues.MovieReleaseDate;
                        }
                        break;

                    case 2:
                        if (cinemaMovieShowBooking.ShowDateTime == obj.ShowDateTime)
                        {
                            cinemaMovieShowBooking.ShowDateTime = newValues.ShowDateTime;
                        }
                        break;

                    case 3:
                        if (cinemaMovieShowBooking.BookingMail == obj.BookingMail &&
                            cinemaMovieShowBooking.BookingPhone == obj.BookingPhone)
                        {
                            cinemaMovieShowBooking.BookingMail = newValues.BookingMail;
                            cinemaMovieShowBooking.BookingPhone = newValues.BookingPhone;
                        }
                        break;

                    default:
                        break;
                }
            }
            SaveRepo();
        }

        private void LoadRepo()
        {
            StreamReader sr = new StreamReader(@"../../../../ModelsCSV/Ex41-TheMovies.csv");
            string line = sr.ReadLine();
            string[] splitRow;

            while (line != null)
            {
                splitRow = line.Split(";");

                if (splitRow[0] != "Biograf")
                {
                    int Moviedur;
                    string[] splitMovieDur = splitRow[5].Split(":");
                    Moviedur = int.Parse(splitMovieDur[0]) * 60 + int.Parse(splitMovieDur[1]);

                    CinemaMovieShowBooking temp = new CinemaMovieShowBooking()
                    {
                        CinemaName = splitRow[0],
                        CinemaTown = splitRow[1],
                        ShowDateTime = DateTime.Parse(splitRow[2]),
                        MovieTitle = splitRow[3],
                        MovieGenre = splitRow[4],
                        MovieDuration = Moviedur,
                        MovieDirector = splitRow[6],
                        MovieReleaseDate = DateTime.Parse(splitRow[7]),
                        BookingMail = splitRow[8],
                        BookingPhone = splitRow[9]
                    }
                    ;
                    entries.Add(temp);
                }
                line = sr.ReadLine();
            }
            sr.Close();
        }

        // Overwrites SavedMovies.CSV the file each time the method is called
        private void SaveRepo()
        {
            StreamWriter sw = new StreamWriter(@"../../../../ModelsCSV/SavedMovies.CSV");

            // Header
            sw.WriteLine("Biograf;By;Forestillingstidspunkt;Filmtitel;Filmgenre;Filmvarighed;Filminstruktør;Premieredato;Bookingmail;Bookingtelefonnummer");

            foreach (CinemaMovieShowBooking entry in entries)
            {
                string showDateTime = entry.ShowDateTime.ToString("yyyy-MM-dd HH:mm");
                string movieDuration = string.Format("{0:00}:{1:00}", entry.MovieDuration / 60, entry.MovieDuration % 60);
                string movieReleaseDate = entry.MovieReleaseDate.ToString("yyyy-MM-dd");

                sw.WriteLine($"{entry.CinemaName};{entry.CinemaTown};{showDateTime};{entry.MovieTitle};{entry.MovieGenre};{movieDuration};{entry.MovieDirector};{movieReleaseDate};{entry.BookingMail};{entry.BookingPhone}");
            }

            sw.Close();
        }
    }
}
