using _2195420FinalExam.DataAcess;
using _2195420FinalExam.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2195420FinalExam
{
   
    public partial class Form1 : Form
    {  
        List<Student>listst = new List<Student>();
        public Form1()
        {
            InitializeComponent();
        }
        private void ClearAll()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();
            textBox1.Focus();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // button add students
        private void button1_Click(object sender, EventArgs e)
        {
            if ((Validator.IsValidID(textBox1)) && (Validator.IsValidName(textBox2)) && (Validator.IsValidName(textBox3)))
                {


                Student stu = new Student();

                //Store data in the object
                stu.StudentId = Convert.ToInt32(textBox1.Text);
                stu.FirstName = textBox2.Text;
                stu.LastName = textBox3.Text;
                stu.PhoneNumber = maskedTextBox1.Text;
                listst.Add(stu);
                MessageBox.Show("Student Info has been added to the list.", "Confirmation");
                button5.Enabled = true;
                ListViewItem item = new ListViewItem(stu.StudentId.ToString());
                item.SubItems.Add(stu.FirstName);
                item.SubItems.Add(stu.LastName);
                item.SubItems.Add(stu.PhoneNumber);
                listViewStudent.Items.Add(item);
            }

        }
        //button list students
        private void button5_Click(object sender, EventArgs e)
        {
            listViewStudent.Items.Clear();
            StudentIO.ListStudents(listViewStudent);

            foreach (Student st in listst)
            {
                //List the object from the LIST listst
                ListViewItem item = new ListViewItem(Convert.ToString(st.StudentId));
                item.SubItems.Add(st.FirstName);
                item.SubItems.Add(st.LastName);
                item.SubItems.Add(st.PhoneNumber);

            }

        }
        //button save
        private void button2_Click(object sender, EventArgs e)
        {
            List<Student> listst = StudentIO.ListStudents();

            Student st = new Student();

            st.StudentId = Convert.ToInt32(textBox1.Text);
            st.FirstName = textBox2.Text;
            st.LastName = textBox3.Text;
            st.PhoneNumber = maskedTextBox1.Text;

            StudentIO.SaveRecord(st);

            ClearAll();

        }
        //button Exit
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Are you sure to exit the application?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //button Search by StudentId
        private void button4_Click(object sender, EventArgs e)
        {
            int choice = comboBox1.SelectedIndex;

            switch (choice)
            {
                case -1: 

                    MessageBox.Show("Please, select at least one Search Option( Student ID)");
                    break;

                case 0:
                    Student st = StudentIO.SearchRecord(Convert.ToInt32(textBox5.Text));

                    if (st != null)
                    {
                        textBox1.Text =(st.StudentId).ToString();
                        textBox2.Text =st.FirstName;
                        textBox3.Text =st.LastName;
                        maskedTextBox1.Text =st.PhoneNumber;
                    }
                    else
                    {

                        MessageBox.Show("Student not found!");
                    }
                    break;


                default:   
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int choice = comboBox1.SelectedIndex;
            switch (choice)
            {
                case 0:
                    label6.Text = "Please enter the Student ID";
                    textBox5.Focus();
                    break;
            
                default:
                    break;
            }
        }
        //button Delete
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                StudentIO.Delete(Convert.ToInt32(textBox1.Text));
                MessageBox.Show("Student record has been deleted successfully", "Delete");
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Student ID field is empty", "Delete");
            }
        }
    }
}
