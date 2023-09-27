using System;

namespace Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Academy p = new Academy("UCL", "Seebladsgade");

            Student s1 = new Student("Jens");
            Student s2 = new Student("Niels");
            Student s3 = new Student("Susan");

            p.MessageChanged += s1.Update;
            p.MessageChanged += s2.Update;
            p.MessageChanged += s3.Update;

            p.Message = "Så er der julefrokost!";

            p.MessageChanged -= s2.Update;

            p.Message = "Så er der fredagsbar!";
        }
    }
}
