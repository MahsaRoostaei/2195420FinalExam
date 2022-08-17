
using _2195420FinalExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace _2195420FinalExam.DataAcess
{
    public static class StudentIO
    {

        private static string filePath = Application.StartupPath + @"\student.dat";
        private static string fileTemp = Application.StartupPath + @"\Temp.dat";
        public static void SaveRecord(Student st)
        {
            
            //MessageBox.Show(filePath);
            StreamWriter sWriter = new StreamWriter(filePath, true);
            sWriter.WriteLine(st.StudentId + "," + st.FirstName + "," + st.LastName + "," + st.PhoneNumber);

            sWriter.Close();
            MessageBox.Show("Recorded saved Successfully");

        }

        public static void ListStudents(ListView listViewStudent)
        {
           
            StreamReader sReader = new StreamReader(filePath);
            listViewStudent.Items.Clear();
            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                ListViewItem item = new ListViewItem(fields[0]);
                item.SubItems.Add(fields[1]);
                item.SubItems.Add(fields[2]);
                item.SubItems.Add(fields[3]);
                listViewStudent.Items.Add(item);
                line = sReader.ReadLine(); 
            }
            sReader.Close();
        }
        public static List<Student> ListStudents()
        {
            List<Student> listst = new List<Student>();
            StreamReader sReader = new StreamReader(filePath);
           

            string line = sReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                Student st = new Student();
                st.StudentId = Convert.ToInt32(fields[0]);
                st.FirstName = fields[1];
                st.LastName = fields[2];
                st.PhoneNumber = fields[3];
                listst.Add(st);
                line = sReader.ReadLine();
            }
            sReader.Close(); 
            return listst;
        }
        public static Student SearchRecord(int id)
        {
            Student st = new Student();
            if (File.Exists(filePath))
            {
                StreamReader sReader = new StreamReader(filePath);
                string line = sReader.ReadLine();

                bool found = false;

                while (line != null)
                {
                    string[] fields = line.Split(',');
                    if (Convert.ToInt32(fields[0]) == id)

                    {
                        st.StudentId = Convert.ToInt32(fields[0]);
                        st.FirstName = fields[1];
                        st.LastName = fields[2];
                        st.PhoneNumber= fields[3];

                        found = true;
                        break;
                    }

                    line = sReader.ReadLine();
                }

                sReader.Close();

                
                if (!found)
                {
                    st = null;

                }
            }

            else
            {
                MessageBox.Show("File not Foound!");

            }
            return st;
        }

        public static Student SearchRecord(string input)

        {
            Student st = new Student();

            return st;

        }

        public static void Delete(int stId)
        {
            StreamReader sReader = new StreamReader(filePath);
            string line = sReader.ReadLine();
            StreamWriter sWriter = new StreamWriter(fileTemp, true);
            while (line != null)
            {
                string[] fields = line.Split(',');
                if ((stId) != (Convert.ToInt32(fields[0])))
                {

                    sWriter.WriteLine(fields[0] + "," + fields[1] + "," + fields[2] + "," + fields[3]);


                }
                line = sReader.ReadLine();
            }
            sReader.Close();
            sWriter.Close();

            File.Delete(filePath);
            File.Move(fileTemp, filePath);

        }

    }
}
