using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public class Checkers
    {
        public string PointReplace(string text)
        {
            char c = ',';
            if (text.Contains(c.ToString()))
            {
                text = text.Replace(',', '.');
            }
            return text;
        }

        public string UnPointReplace(string text)
        {
            char c = '.';
            if (text.Contains(c.ToString()))
            {
                text = text.Replace('.', ',');
            }
            return text;
        }


        public bool Firmness(TextBox t)
        {
            if (t.Text == "")
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool Firmness(string t)
        {
            if (t == "")
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool Firmness(ComboBox t)
        {
            if (t.Text == "")
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        public bool FIOvalidation(string text)
        {
            if (!Regex.IsMatch(text, @"\w+\s\w+\s\w+"))
            {
                MessageBox.Show("Неверно заполнено поле \"ФИО\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        public bool TexboxValidation(string amount)
        {
            if (!Regex.IsMatch(amount, @"\d*"))
            {
                MessageBox.Show("В поле допустимы только числа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public bool IntegerValidation(int? integ)
        {
            if (integ==null)
            {
                MessageBox.Show("Не выбран курс обучения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        public bool TexboxPriceValidation(TextBox price, TextBox amount)
        {
            if (!Regex.IsMatch(price.Text, @"^\d{1,5}(\.)?[0-9]{0,2}$"))
            {
                MessageBox.Show("Цена должна содержать не более 5 цифр до запятой и не более 2 после", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!Regex.IsMatch(amount.Text, @"\d*"))
            {
                MessageBox.Show("В поле \"Количество\" допустимы только числа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
