﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Complex
    {
        private double real; //действительная часть
        private double suppose; //мнимая часть

        public Complex (string complex)
        {
            this.real = RealInComplex(complex);
            this.suppose = SupposeInComplex(complex);
        }

        public Complex (double real, double suppose)
        {
            this.real = real;
            this.suppose = suppose;
        }

        //Поиск действительной части
        public float RealInComplex(string value)
        {
                value = value.Replace(" ", "");

                var realArr = Regex.Split(value, @".?\d[i]");

                float real = 0;

                foreach(var digit in realArr)
                {
                    if (float.TryParse(digit, out float check))
                    {
                        real = float.Parse(digit);
                    }
                }
                return real;          
        }

        //Поиск мнимой части
        public int SupposeInComplex(string value) 
        {
            value = value.Replace(" ", ""); //убираем все пробелы

            var supposeArr = value.ToCharArray(); //разбиваем выражение на массив символов

            var real = 0;

            var regex = new Regex(@"(?(?=[a-z]|[а-я])[^i]|^$)");
            var matchesFirst = regex.Matches(value);

            if (matchesFirst.Count != 0)
            {
                return 0;
            }

            for (int i = 0; i < supposeArr.Length; i++) //цикл в котором ищем i и берем число, которое стоит перед ним
                {
                    if (supposeArr[i] == 'i')
                    {
                        var text = ""; 
                        if (i != 0)
                        {
                            if (i != 1)
                                text = Convert.ToString(supposeArr[i - 2]);
                            text += Convert.ToString(supposeArr[i - 1]);
                            real = int.Parse(text);
                        }
                    }
                }
                return real;
        }

        public static Complex operator +(Complex z1, Complex z2)
        {
            var newReal = z1.real + z2.real;

            var newSuppose = z1.suppose + z2.suppose;

            var Result = new Complex(newReal, newSuppose);

            return Result;
        }
 

        public static Complex operator -(Complex z1, Complex z2)
        {
            var newReal = z1.real - z2.real;

            var newSuppose = z1.suppose - z2.suppose;

            var Result = new Complex(newReal, newSuppose);

            return Result;
        }
         
        public static Complex operator *(Complex z1, Complex z2)
        {
            var newReal = ((z1.real*z2.real) - (z1.suppose * z2.suppose));

            var newSuppose = ((z1.suppose * z2.real) + (z1.real * z2.suppose));

            var Result = new Complex(newReal, newSuppose);

            return Result;
        }  

        public static Complex operator /(Complex z1, Complex z2)
        {
            var newReal = (((z1.real * z2.real) + (z1.suppose * z2.suppose)) / (Math.Pow(z2.real,2) + Math.Pow(z2.suppose,2)));

            var newSuppose = (((z1.suppose * z2.real) - (z1.real * z2.suppose)) / (Math.Pow(z2.real, 2) + Math.Pow(z2.suppose,2)));

            var Result = new Complex(newReal, newSuppose);

            return Result;
        }

        public static string operator <(Complex z1, Complex z2)
        {
            if (z1.real == z2.real && z1.suppose == z2.suppose)
            { //комплексные числа равны только в том случае, если равны их мнимые и дейст. части
                return "z1 равен z2";
            }
            else if (z1.suppose < z2.suppose && z1.real == z2.real)
            {
                return "z2 больше z1";
            }
            else if (z1.suppose > z2.suppose && z1.real == z2.real)
            {
                return "z1 больше z2";
            }
            else if (z1.suppose == z2.suppose && z1.real > z2.real)
            {
                return "z1 больше z2";
            }
            else if (z1.suppose == z2.suppose && z1.real < z2.real)
            {
                return "z2 больше z1";
            }
            else
            {
                return "Сравнение не имеет смысла"; //в противном случае сравнение не имеет смысла
            }
    
        }

        public static string operator >(Complex z1, Complex z2)
        {
            return z2 < z1;
        }

        //Метод для сравнения двух комплексных чисел
        

        public string Print()
        {
            var str = "";
            if (this.suppose >= 0) 
            {
                str = "+";
            }
            return String.Format("{0}"+ str +"{1}i", this.real, this.suppose);
        }

        //Приведение результатов действий над комплексными числами в формат 
       

        public override bool Equals(object obj)
        {
            var Complex = obj as Complex;

            if (Complex == null)
            {
                return false;
            }

            if (this.real != Complex.real || this.suppose != Complex.suppose)
                return false;
            return true;
        }


        public bool CheckSuppose()
        {
            if (this.suppose == 0)
                return true;
            else
                return false;
        }
    }
}
