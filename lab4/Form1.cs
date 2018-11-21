using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        int c1 = 0;
        int[] statArr = new int[10];
        int[] dinArr = new int[0];
        public Form1()
        {
            InitializeComponent();
            
        }
        //add to din
        private void button2_Click(object sender, EventArgs e)
        {
            int a;
            if (!int.TryParse(textBox2.Text, out a))
            {
                textBox2.Text = "";
                MessageBox.Show("Введено не целое число!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int[] tmp = new int[dinArr.Length + 1];
            dinArr.CopyTo(tmp, 0);
            tmp[tmp.Length - 1] = a;
            dinArr = tmp;
            label2.Text += label2.Text == "Массив:" ? " " + a : ", " + a;
           // textBox2.Text = "";
        }
        // reset stat
        private void button3_Click(object sender, EventArgs e)
        {
            c1 = 0;
            statArr = new int[10];
            label1.Text = "Массив:";
            label3.Text = "Результат:";
        }
        // reset din
        private void button4_Click(object sender, EventArgs e)
        {
            dinArr = new int[0];
            label2.Text = "Массив:";
            label4.Text = "Результат:";
        }

        //add to stat
        private void button1_Click(object sender, EventArgs e)
        {
            if (c1 > 9)
            {
                MessageBox.Show("Статический массив заполнен!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int a;
            if (! int.TryParse(textBox1.Text, out a))
            {
                textBox1.Text = "";
                MessageBox.Show("Введено не целое число!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            statArr[c1++] = a;
            label1.Text += label1.Text == "Массив:" ? " " + a : ", " + a;
            //textBox1.Text = "";
            if (c1 == 10)
                count(statArr, label3);
        }
        //counting
        void count(int[] arr, Label result)
        {
            result.Text = "Результат:";
            if (arr.Length == 0)
            {
                MessageBox.Show("Пустой массив!", "Ошибка вычислений", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            result.Text += "\n\nУмножение: ";
            int res = 1;
            bool isSomething = false;
            foreach(var item in arr)
            {
                if(item != 0)
                {
                    isSomething = true;
                    res *= Math.Abs(item);
                    result.Text += Math.Abs(item).ToString() + " * ";
                }
            }
            if (isSomething)
                result.Text = result.Text.Substring(0, result.Text.LastIndexOf("*")) + "= " + res;
            else
                result.Text += 0;
            result.Text += "\n\nCреднеe по модулю: ";
            double s = 0;
            foreach (var item in arr)
                s += Math.Abs(item);
            s = s / arr.Length;
            res = 0;
            result.Text += s.ToString() + "\n\nЧисел меньше среднего по модулю: ";
            foreach (var item in arr)
            {
                if (s > item)
                    res++;
            }
            result.Text += res.ToString() + "\n\nСумма четных на нечетных позициях: ";
            res = 0;
            isSomething = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if(i%2==1 && arr[i] % 2 == 0)
                {
                    res += arr[i];
                    if (arr[i] < 0 && isSomething)
                        result.Text = result.Text.Substring(0, result.Text.LastIndexOf("+")) + "- " + Math.Abs(arr[i]) + " + ";
                    else
                        result.Text += arr[i].ToString() + " + ";
                    isSomething = true;
                }
            }
            if (isSomething)
                result.Text = result.Text.Substring(0, result.Text.LastIndexOf("+")) +
                    "= " + res;
            else
                result.Text += res;
            result.Text += "\n\nЭлементов, меньше половины максимального: ";
            s = int.MinValue;
            res = 0;
            foreach (var item in arr)
                if (item > s)
                    s = item;
            s /= 2;
            foreach (var item in arr)
                if (item < s)
                    res++;
            result.Text += res;
        }
        // count dinArr
        private void button5_Click(object sender, EventArgs e)
        {
            count(dinArr, label4);
        }
    }
}
