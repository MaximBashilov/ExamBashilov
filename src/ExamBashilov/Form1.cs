using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamBashilov
{
    public partial class Form1 : Form
    {
        public enum Mode
        {
            Ex1,
            Ex2,
            NotStated
        }

        private Mode mode = Mode.NotStated;
        double x0, y0;
        private ToolStripLabel statusLabel;
        public Form1()
        {
            InitializeComponent();
            statusLabel = new ToolStripLabel();
            statusLabel.Text = "Строка состояния";

            statusStrip.Items.Add(statusLabel);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "html files (*.html)|*.html";
                ofd.FilterIndex = 0;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    CheckFunction(ofd.FileName, ofd.SafeFileName);
                }
            }
        }

        private void CheckFunction(string path, string fileName)
        {    
            if (fileName == "site1.html")
            {
                mode = Mode.Ex1;
                this.Size = new Size(1125, 650);
                WebBrowser.Navigate(path);
                ShowTextBoxes();
            }
            else if (fileName == "site2.html")
            {
                mode = Mode.Ex2;
                this.Size = new Size(1125, 650);
                WebBrowser.Navigate(path);
                ShowTextBoxes();
            }
            else
            {
                mode = Mode.NotStated;
                this.Size = new Size(1125, 545);
                HideTextBoxes();
                MessageBox.Show("Для работы программы нужно открыть файл с заданием!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckPointFirst(double x, double y)
        {
            double d = (x * x) + (y * y);
            if (d < 1.0)
            {
                statusLabel.Text = "Точка находится внутри окружности!";
                MessageBox.Show("Точка находится внутри окружности!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (d > 1.0)
            {
                statusLabel.Text = "Точка находится вне окружности!";
                MessageBox.Show("Точка находится вне окружности!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                statusLabel.Text = "Точка находится на границе окружности!";
                MessageBox.Show("Точка находится на границе окружности!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void CheckPointSecond()
        {   
            double a, b, c;
            double x1 = 1.0, x2 = 5.0, x3 = -5.0;
            double y1 = 4.0, y2 = -4.0, y3 = -3.0;

            a = (x1 - x0) * (y2 - y1) - (x2 - x1) * (y1 - y0);
            b = (x2 - x0) * (y3 - y2) - (x3 - x2) * (y2 - y0);  
            c = (x3 - x0) * (y1 - y3) - (x1 - x3) * (y3 - y0);

            if (a == 0.0 || b == 0.0 || c == 0.0)
            {
                statusLabel.Text = "Точка находится на границе треугольника!";
                MessageBox.Show("Точка находится на границе треугольника!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
            {
                statusLabel.Text = "Точка находится внутри треугольника!";
                MessageBox.Show("Точка находится внутри треугольника!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                statusLabel.Text = "Точка находится вне треугольника!";
                MessageBox.Show("Точка находится вне треугольника!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void HideTextBoxes()
        {
            XLabel.Visible = false;
            YLabel.Visible = false;
            XTextBox.Visible = false;
            YTextBox.Visible = false;
            CheckButton.Visible = false;
        }

        private void ShowTextBoxes()
        {
            XLabel.Visible = true;
            YLabel.Visible = true;
            XTextBox.Visible = true;
            YTextBox.Visible = true;
            CheckButton.Visible = true;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программу разработал:\nСтудент группы ПКсп-120\nБашилов Максим Андреевич\nВариант: 11", "О программе",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case Mode.Ex1:
                    try
                    {
                        x0 = double.Parse(XTextBox.Text);
                        y0 = double.Parse(YTextBox.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Введены некорректные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    CheckPointFirst(x0, y0);
                    break;
                case Mode.Ex2:
                    try
                    {
                        x0 = double.Parse(XTextBox.Text);
                        y0 = double.Parse(YTextBox.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Введены некорректные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    CheckPointSecond();
                    break;
            }
        }
    }
}
