using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FirstComplexTxt.ForeColor = SystemColors.GrayText;
            SecondComplexTxt.ForeColor = SystemColors.GrayText;
            FirstComplexTxt.Text = "Введите комплексное число z1";
            SecondComplexTxt.Text = "Введите комплексное число z2";
            this.FirstComplexTxt.Leave += new System.EventHandler(this.FirstComplexTxt_Leave);
            this.SecondComplexTxt.Leave += new System.EventHandler(this.SecondComplexTxt_Leave);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void FirstComplexTxt_Leave(object sender, EventArgs e)
        {
            if (FirstComplexTxt.Text.Length == 0 || FirstComplexTxt.Text == "i")
            {
                FirstComplexTxt.Text = "Введите комплексное число z1";
                FirstComplexTxt.ForeColor = SystemColors.GrayText;
            }
        }

        private void FirstComplexTxt_Click(object sender, EventArgs e)
        {
            if (FirstComplexTxt.Text == "Введите комплексное число z1")
            {
                FirstComplexTxt.Text = "i";
                FirstComplexTxt.ForeColor = Color.White;
            }
        }

        private void FirstComplexTxt_Enter(object sender, EventArgs e)
        {
            if (FirstComplexTxt.Text == "Введите комплексное число z1")
            {
                FirstComplexTxt.Text = "";
                FirstComplexTxt.ForeColor = Color.White;
            }
        }

        private void SecondComplexTxt_Leave(object sender, EventArgs e)
        {
            if (SecondComplexTxt.Text.Length == 0 || SecondComplexTxt.Text == "i")
            {
                SecondComplexTxt.Text = "Введите комплексное число z2";
                SecondComplexTxt.ForeColor = SystemColors.GrayText;
            }
        }

        private void SecondComplexTxt_Click(object sender, EventArgs e)
        {
            if (SecondComplexTxt.Text == "Введите комплексное число z2")
            {
                SecondComplexTxt.Text = "i";
                SecondComplexTxt.ForeColor = Color.White;
            }
        }

        private void SecondComplexTxt_Enter(object sender, EventArgs e)
        {
            if (SecondComplexTxt.Text == "Введите комплексное число z2")
            {
                SecondComplexTxt.Text = "";
                SecondComplexTxt.ForeColor = Color.White;
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CheckError() == false)
                Calculate("+");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FirstComplexTxt.Text = "Введите комплексное число z1";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SecondComplexTxt.Text = "Введите комплексное число z2";
        }

        private void Calculate (string operation)
        {
            try
            {
                var FirstComplex = new Complex(FirstComplexTxt.Text);
                var SecondComplex = new Complex(SecondComplexTxt.Text);

                Complex Result = new Complex("");

                switch (operation)
                {
                    case "+":
                        Result = FirstComplex + SecondComplex;
                        AnswerTxt.Text = Result.Print();
                        break;
                    case "-":
                        Result = FirstComplex - SecondComplex;
                        AnswerTxt.Text = Result.Print();
                        break;
                    case "*":
                        Result = FirstComplex * SecondComplex;
                        AnswerTxt.Text = Result.Print();
                        break;
                    case "/":
                        Result = FirstComplex / SecondComplex;
                        AnswerTxt.Text = Result.Print();
                        break;
                    case "<=":
                        AnswerTxt.Text = Result.ComplexComparison(FirstComplex, SecondComplex);
                        break;
                }
                
            }
            catch (FormatException)
            {

            }

        }

        private bool CheckError () 
        {
            var FirstComplex = new Complex(FirstComplexTxt.Text);
            var SecondComplex = new Complex(SecondComplexTxt.Text);

            //Проверяем на лишние символы
            //если встречаются символы (от a до z) или (от а до я) и это не i, то говорим что плохо иначе возращаем пустую строку
            var regex = new Regex(@"(?(?=[a-z]|[а-я])[^i]|^$)"); 
            var matchesFirst = regex.Matches(FirstComplexTxt.Text);
            var matchesSecond = regex.Matches(SecondComplexTxt.Text);
           

            if (FirstComplexTxt.Text == "Введите комплексное число z1" || SecondComplexTxt.Text == "Введите комплексное число z2")
            {  
                MessageBox.Show(
                    "Одно из полей пустое. Заполните его.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                return true;
            }
            else if (FirstComplex.CheckSuppose() == true || SecondComplex.CheckSuppose() == true)
            {
                MessageBox.Show(
                    "Проблема с мнимой частью в одном из чисел. Проверьте числа еще раз.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                return true;
            }
            else if (matchesFirst.Count != 0 || matchesSecond.Count != 0)
            {
                MessageBox.Show(
                    "Проблема с записью чисел: присутствуют лишние символы. Проверьте числа еще раз.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CheckError() == false)
                Calculate("-");
        }

        private void button5_Click(object sender, EventArgs e)
        {   
            if (CheckError() == false)
                Calculate("*");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (CheckError() == false)
                Calculate("/");
        }

        private int x = 0; private int y = 0;

        //Для возможности двигать форму
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {  
            if (CheckError() == false)
                Calculate("<=");
        }

    }
}
