using System;
using System.Collections.Generic;

#nullable disable

namespace StudentApi.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
    }
}
