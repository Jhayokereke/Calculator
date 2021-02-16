using Calculator.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private int currentDigit;
        private double currentDouble;
        private int currentDecimalposition;
        private int currentDigitLength;
        private double previous;
        private string currentOperation;
        private bool newOperation;
        public Calculator()
        {
            InitializeComponent();
            currentDigit = 0;
            currentDouble = 0;
            currentDecimalposition = 0;
            currentDigitLength = 1;
            displaybox.Text = "0";
            previous = 0;
            currentOperation = default;
            newOperation = false;
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            displaybox.Text = "0";
            currentDigitLength = 1;
            currentDigit = 0;
            currentDouble = 0;
            previous = 0;
            currentOperation = default;
            newOperation = false;
        }

        private void dot_btn_Click(object sender, EventArgs e)
        {
            if (newOperation)
            {
                Default();
                displaybox.Text = "0";
            }
            if (currentDouble == 0 && currentDigit == 0 && currentDigitLength == 1)
            {
                displaybox.Text += ".";
                currentDigitLength += 1;
                currentDecimalposition = 1;
            }
            else if (currentDigit != 0 && currentDouble == 0)
            {
                currentDouble = (double)currentDigit;
                currentDigit = 0;
                displaybox.Text += ".";
                currentDigitLength += 1;
                currentDecimalposition = 1;
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (newOperation)
            {
                Default();
                displaybox.Text = "0";
            }
            if (currentDigit == 0 && currentDigitLength == 0)
            {
                displaybox.Text += "0";
                currentDigitLength += 1;
            }
            else if (currentDigit != 0)
            {
                currentDigit = Operations.UpdateInt(currentDigit, 0);
                displaybox.Text += "0";
                currentDigitLength += 1;
            }
            else if (currentDigit == 0 && currentDigitLength > 1)
            {
                currentDouble = Operations.UpdateDouble(currentDouble, 0, currentDecimalposition);
                displaybox.Text += "0";
                currentDigitLength += 1;
                currentDecimalposition += 1;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(displaybox.Text))
                {
                    displaybox.Text = displaybox.Text.Substring(0, currentDigitLength);
                }
            }
        }

        private void negator_btn_Click(object sender, EventArgs e)
        {
            if (currentDigitLength > 0 && (currentDigit != 0 || currentDouble != 0))
            {
                if (currentDigit != 0)
                {
                    currentDigit = Operations.NegateInt(currentDigit);
                    displaybox.Text = currentDigit.ToString();
                    currentDigitLength = currentDigit.ToString().Length;
                }
                else
                {
                    currentDouble = Operations.NegateDouble(currentDouble);
                    displaybox.Text = currentDouble.ToString();
                    currentDigitLength = currentDouble.ToString().Length;
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            int num = 1;
            this.EnterNum(num);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            int num = 2;
            this.EnterNum(num);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            int num = 3;
            this.EnterNum(num);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            int num = 4;
            this.EnterNum(num);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            int num = 5;
            this.EnterNum(num);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            int num = 6;
            this.EnterNum(num);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            int num = 7;
            this.EnterNum(num);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            int num = 8;
            this.EnterNum(num);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            int num = 9;
            this.EnterNum(num);
        }

        private void EnterNum(int num)
        {
            if (newOperation)
            {
                Default();
                displaybox.Text = "";
            }
            if (currentDigit == 0)
            {
                if (currentDigitLength > 1)
                {
                    currentDouble = Operations.UpdateDouble(currentDouble, num, currentDecimalposition);
                    currentDecimalposition += 1;
                }
                if (currentDigitLength < 2)
                {
                    if (currentDigitLength == 1)
                    {
                        displaybox.Text = displaybox.Text.Substring(0, currentDigitLength - 1);
                        currentDigitLength -= 1;
                    }
                    currentDigit = Operations.UpdateInt(currentDigit, num);
                }
            }
            else if (currentDigit > 0)
            {
                currentDigit = Operations.UpdateInt(currentDigit, num);
            }
            displaybox.Text += $"{num}";
            currentDigitLength += 1;
        }

        private void ExecuteOperation()
        {
            double current = currentDigit != 0 ? currentDigit : currentDouble;
            try
            {
                if (currentDigitLength != 0 && !newOperation)
                {
                    switch (currentOperation)
                    {
                        case "Add":
                            previous = Operations.AddNumbers(previous, current);
                            Default();
                            break;
                        case "Subtract":
                            previous = Operations.SubtractNumbers(previous, current);
                            Default();
                            break;
                        case "Multiply":
                            previous = Operations.MultiplyNumbers(previous, current);
                            Default();
                            break;
                        case "Divide":
                            previous = Operations.DivideNumbers(previous, current);
                            Default();
                            break;
                        case "Equals":
                            Default();
                            break;
                        default:
                            previous = current;
                            break;
                    }
                }
            }
            catch (DivideByZeroException d)
            {
                MessageBox.Show(d.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Syntax Error!");
            }
            finally
            {
                newOperation = true;
            }
        }

        public void Default()
        {
            currentDigit = 0;
            currentDouble = 0;
            currentDigitLength = 1;
            currentDecimalposition = 0;
            displaybox.Text = previous.ToString();
            newOperation = false;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            ExecuteOperation();
            currentOperation = "Add";
        }

        private void sub_btn_Click(object sender, EventArgs e)
        {
            ExecuteOperation();
            currentOperation = "Subtract";
        }

        private void mult_btn_Click(object sender, EventArgs e)
        {
            ExecuteOperation();
            currentOperation = "Multiply";
        }

        private void div_btn_Click(object sender, EventArgs e)
        {
            ExecuteOperation();
            currentOperation = "Divide";
        }

        private void eqn_btn_Click(object sender, EventArgs e)
        {
            ExecuteOperation();
            currentOperation = "Equals";
        }
    }
}
