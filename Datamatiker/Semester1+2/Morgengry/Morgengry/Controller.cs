using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Morgengry
{
    public class Controller
    {
        public ValuableRepository ValuableRepo = new ValuableRepository();

        public interface IValueable{
            double GetValue();
        }

        public interface IPersistable
        {
            void Save(string fileName);
            void Load(string fileName);
        }

        public class ValuableRepository : IPersistable
        {
            private List<IValueable> valuables = new List<IValueable>();
            public void AddValuable(IValueable valuable)
            {
                valuables.Add(valuable);
            }

            public IValueable GetValuable(string id)
            {
                foreach (IValueable valuable in valuables)
                {
                    var tempM = valuable as Merchandise;
                    if (tempM != null)
                    {
                        if (tempM.ItemId == id)
                            return valuable;
                    }

                    var tempC = valuable as Course;
                    if (tempC != null)
                    {
                        if (tempC.Name == id)
                            return valuable;
                    }
                }
                return null;
            }

            public double GetTotalValue()
            {
                double value = 0.0;
                foreach (IValueable valuable in valuables)
                {
                    value += valuable.GetValue();
                }

                return value;
            }

            public int Count()
            {
                return valuables.Count;
            }           

            public void Save(string fileName = @"C:\home-projects\Semester_1+2\Programmering\Morgengry\Morgengry\ValuableRepository.txt")
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    foreach (IValueable valuable in valuables)
                    {
                        var tempA = valuable as Amulet;
                        if (tempA != null)
                        {
                            sw.WriteLine("Amulet;" + tempA.ItemId + ";" + tempA.Design + ";" + tempA.Quality);
                        }

                        var tempB = valuable as Book;
                        if (tempB != null)
                        {
                            sw.WriteLine("Book;" + tempB.ItemId + ";" + tempB.Title + ";" + tempB.Price);
                        }

                        var tempC = valuable as Course;
                        if (tempC != null)
                        {
                            sw.WriteLine("Course;" + tempC.Name + ";" + tempC.DurationInMinutes);
                        }
                    }
                }
            }
            
            public void Load(string fileName = @"C:\home-projects\Semester_1+2\Programmering\Morgengry\Morgengry\ValuableRepository.txt")
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string row;
                    do
                    {
                        string[] splitRow;
                        row = sr.ReadLine();
                        if (row != null)
                        {
                            splitRow = row.Split(";");
                            if (splitRow[0] == "Amulet")
                            {
                                Level level;
                                string levelStr = splitRow[3];
                                if (levelStr == "low")
                                    level = Level.low;
                                else if (levelStr == "medium")
                                    level = Level.medium;
                                else
                                    level = Level.high;

                                valuables.Add(new Amulet(splitRow[1], level, splitRow[2]));
                            }

                            else if (splitRow[0] == "Book")
                            {
                                valuables.Add(new Book(splitRow[1], splitRow[2], Convert.ToDouble(splitRow[3].Replace(".", ","))));
                            }
                            else if (splitRow[0] == "Course")
                            {
                                valuables.Add(new Course(splitRow[1], int.Parse(splitRow[2].Replace(".", ","))));
                            }
                        }
                    } while (row != null);
                }
            }
        }
    }
}
