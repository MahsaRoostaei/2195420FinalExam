using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2195420FinalExam;

namespace _2195420FinalExam.Validation
{
    public class Validator
    {
        public static bool IsValidID(string input)
        {

            int tempID;
            if ((input.Length != 7) || !(Int32.TryParse(input, out tempID)))
            {
                MessageBox.Show("Invalid StudentID, it must be a 7 digit number");
                return false;
            }
            return true;

        }
        public static bool IsValidID(TextBox text)
        {
            int tempID;
            if ((text.TextLength != 7) || !((Int32.TryParse(text.Text, out tempID))))
            {
                MessageBox.Show("Invalid CustomerID, it must be a 7 digit number");
                text.Clear();
                text.Focus();
                return false;
            }
            return true;
        }
            public static bool IsValidName(TextBox text)
        {
            for (int i = 0; i < text.TextLength; i++)
            {
                if (char.IsDigit(text.Text, i) || (char.IsWhiteSpace(text.Text, i)))
                {
                    MessageBox.Show("Invalid Name,Please enter another name.", "INVALID NAME");
                    text.Clear();
                    text.Focus();
                    return false;
                }

            }
            return true;

        }
      

    }
}

