using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObjects
{
    class Program
    {
        static List<Student> records = new List<Student>();

        static void Main(string[] args)
        {




            ReadInFile();
            ListAllRecords();
            bool running = true;
            while (running == true)
            {
                Console.WriteLine();
                Console.WriteLine("---------- Main Menu ----------");
                Console.WriteLine("1 - Find Students of Age");
                Console.WriteLine("0 - Quit");
                Console.Write("Select an option: ");
                char menuChoice = Console.ReadLine().ToCharArray()[0]; //Gets the first character only, as a char
                Console.WriteLine();
                switch (menuChoice)
                {
                    case '1':
                        Console.Write("Enter Required Age: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        FindByAge(age);
                        break;
                    case '0':
                        running = false;
                        break;

                }
            
        }

                    /* Student s1 = new Student(47,"Alex", "Marsh", new DateTime(2000,03,24));
                     s1.Number = 47;
                     s1.FirstName = "Alex";
                     s1.LastName = "Marsh";
                     s1.Grade = 'B';
                     s1.DateOfBirth = new DateTime(2001,06,12);

                     Student s2 = new Student(167,"Izzy", "Smithson", new DateTime(1999,06,03));
                     s2.Number = 167;
                     s2.FirstName = "Izzy";
                     s2.LastName = "Smithson";
                     */


            }


        static void ReadInFile()
        {
            Console.Write("Enter FileName (including extension): ");
            string fileName = Console.ReadLine();
            try
            {
                int number = ReadFileIntoRecordsArray(fileName);
                Console.WriteLine("{0} Records read in", number);
                Console.WriteLine();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File does not exist");
            }
        }


        static int ReadFileIntoRecordsArray(string fileName)
        {
            int i = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var elements = line.Split(',');
                    int number = Convert.ToInt16(elements[0]);
                    string first = elements[1];
                    string last = elements[2];
                    DateTime dob = (Convert.ToDateTime(elements[3].Replace('/',',')));
                    var s = new Student(number, first, last, dob);
                    records.Add(s);
                    i++;
                }
            }   
            return i;
        }

        static void ListAllRecords()
        {
            foreach (var record in records)
            {
                WriteRecord(record);
               
            }
        }
        
        static void WriteRecord(Student record)
        {
            var format = record;
            Console.WriteLine(format);
        }

        static void FindByAge(int requiredAge)
        {

            foreach (var student in records)
            {
                if (student.IsOverAge(requiredAge))
                {
                    WriteRecord(student);
                }
                

            }
        }


     }
}
