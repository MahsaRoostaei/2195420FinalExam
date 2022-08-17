using _2195420FinalExam.DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2195420FinalExam
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }


        public void SaveStudent(Student st)
        {
            StudentIO.SaveRecord(st);

        }

        public Student SearchStudent(int id)
        {
            return StudentIO.SearchRecord(id);
        }
    }
}
