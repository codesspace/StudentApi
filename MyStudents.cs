using System.Collections.Generic;

namespace StudentApi
{
    public class MyStudents
    {
        public List<Students> AllStudents()
        {
            List<Students> StudentList = new List<Students>
            {
                new Students
                {
                    Id = 1,
                    Name ="Faruk",
                    Gender ="Male",
                    Class ="Primary 1"
                },
                new Students
                {
                    Id=2,
                    Name = "Hussaina",
                    Gender="Female",
                    Class="Primary 2"
                },
                new Students
                {
                    Id =3,
                    Name ="Halilu",
                    Gender="Male",
                    Class="Primary 3"
                },
                new Students
                {
                    Id=4,
                    Name="Halim",
                    Gender="Male",
                    Class="Primary 1"
                },
                new Students
                {
                    Id=5,
                    Name="Hussaina 2",
                    Gender="Female",
                    Class="Primary 3"
                }
            };
            return StudentList;
        }

    }
}
