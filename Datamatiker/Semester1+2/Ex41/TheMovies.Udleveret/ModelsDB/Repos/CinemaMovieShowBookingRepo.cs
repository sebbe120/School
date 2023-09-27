using System;
using System.Collections.Generic;
using System.Linq;
using TheMovies.Models;
using System.Data.SqlClient;

namespace TheMovies.Repos
{
    public class CinemaMovieShowBookingRepo : IRepository<CinemaMovieShowBooking>
    {
        private List<CinemaMovieShowBooking> entries;

        SqlConnection connection = new SqlConnection("Server=10.56.8.35;Database=A_DB18_2020;User Id=A_STUDENT18;Password=A_OPENDB18");

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
            foreach (CinemaMovieShowBooking entry in entries)
            {
                if (entry.ID == id)
                {
                    return entry;
                }
            }
            throw new InvalidOperationException("Item does not exists");
        }

        // Only adds the object in runtime.Does not add the entry to the database
        public void Add(CinemaMovieShowBooking obj)
        {
            entries.Add(obj);
        }

        // Only deletes the object in runtime. Does not delete the entry in the database
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
        }

        public void Update(CinemaMovieShowBooking obj, CinemaMovieShowBooking newValues)
        {
            // Implement this method !

            throw new NotImplementedException();
        }

        private void LoadRepo()
        {
            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM CinemaMovieShowBooking;", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {                    
                    CinemaMovieShowBooking temp = new CinemaMovieShowBooking()
                    {
                        ID = reader[0],
                        CinemaName = reader[1].ToString(),
                        CinemaTown = reader[2].ToString(),
                        ShowDateTime = DateTime.Parse(reader[3].ToString()),
                        MovieTitle = reader[4].ToString(),
                        MovieGenre = reader[5].ToString(),
                        MovieDuration = int.Parse(reader[6].ToString()),
                        MovieDirector = reader[7].ToString(),
                        MovieReleaseDate = DateTime.Parse(reader[8].ToString()),
                        BookingMail = reader[9].ToString(),
                        BookingPhone = reader[10].ToString()
                    };
                    entries.Add(temp);
                }
            }            
        }

        private void SaveRepo()
        {
            // Implement this method !
        }
    }
}
