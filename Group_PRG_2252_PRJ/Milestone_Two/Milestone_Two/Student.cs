using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_Two
{
    class Student
    {
        int studentNumber;
        string name;
        string surname;
        byte[] studentImage;
        DateTime dob;
        string gender;
        string phone;
        string address;
        string moduleCode;

        public Student(int studentNumber, string name, string surname, byte[] studentImage, DateTime dob, string gender, string phone, string address, string moduleCode)
        {
            StudentNumber = studentNumber;
            Name = name;
            Surname = surname;
            StudentImage = studentImage;
            Dob = dob;
            Gender = gender;
            Phone = phone;
            Address = address;
            ModuleCode = moduleCode;
        }

        public Student()
        {

        }

        public Student(int studentNumber, string name, string surname, byte[] studentImage, DateTime dob, string gender, string phone, string address)
        {
            StudentNumber = studentNumber;
            Name = name;
            Surname = surname;
            StudentImage = studentImage;
            Dob = dob;
            Gender = gender;
            Phone = phone;
            Address = address;
        }

        public int StudentNumber { get => studentNumber; set => studentNumber = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public byte[] StudentImage { get => studentImage; set => studentImage = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string ModuleCode { get => moduleCode; set => moduleCode = value; }
    }
}
