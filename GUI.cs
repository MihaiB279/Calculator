using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public struct numbers
        {
            public string number;
            public char symbol;
        };
        private Operations operations = new Operations();
        private Stack<numbers> Numbers = new Stack<numbers>();
        private Stack<char> Signs = new Stack<char>();
        private Stack<string> RadicalOrders = new Stack<string>();
        private string operation, allowedChars = "1234567890+-*()/%^.!√⁰¹²³⁴⁵⁶⁷⁸⁹", symbols1 = "+-*/^.", symbols2 = "().!";
        private int numberParanthesis;
        private int limit;
        public Calculator()
        {
            InitializeComponent();
        }
        /// <summary>
        /// "main" function which will solve the inserted operation 
        /// </summary>
        private void solve()
        {
            numberParanthesis = 0;
            Numbers.Clear(); Signs.Clear(); RadicalOrders.Clear();
            if (textBox1.Text == "")
            {
                Focus("-1");
                return;
            }
            if (radioButton1.Checked == true) limit = 6;
            else limit = Convert.ToInt32(textBox3.Text);

            try
            {
                ProcessExpression();
            }
            catch (CalculatorException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numberParanthesis != 0)
            {
                MessageBox.Show(Errors.paranthesisError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            while (Signs.Count() != 0)
            {
                try
                {
                    oneStepCalculation();
                    if (Signs.Count() != 0)
                        Signs.Pop();
                }
                catch (CalculatorException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Numbers.Clear();
                    RadicalOrders.Clear();
                    Signs.Clear();
                    return;
                }
            }
            showResult();
        }
        /// <summary>
        /// function which will process the operation inserted
        /// will create the postfix form from the infix form
        /// </summary>
        /// <exception cref="CalculatorException"></exception>
        private void ProcessExpression() //urmatorul subprogram imparte operatia citita in numbers si simboluri de calcul
        {
            int i = 0, backwardsCount;
            numbers nr;
            nr.symbol = '+';
            operation = textBox1.Text;
            while (i < operation.Length)
            {
                if (i > 0 && ((symbols1.Contains(operation[i]) == true && symbols1.Contains(operation[i - 1]) == true) || (operation[i - 1] == '%' && symbols2.Contains(operation[i]))))
                {
                    throw new CalculatorException(Errors.wrongOperationError);
                }
                if (operation[i] == '(')
                    numberParanthesis++;
                else if (operation[i] == ')')
                {
                    numberParanthesis--;
                    if (i > 0 && operation[i - 1] == '(')
                    {
                        numberParanthesis = -1;
                        return;
                    }
                }
                if (numberParanthesis < 0)
                    return;
                if (allowedChars.Contains(operation[i]) == false)
                {
                    throw new CalculatorException(Errors.wrongOperationError);
                }
                if (i == 0 && operation[i] == '-')
                {
                    char c = operation[i];
                    i++;
                    nr.number = "";
                    while (i < operation.Length && (char.IsNumber(operation[i]) == true || operation[i] == '.'))
                        i++;
                    backwardsCount = i - 1;
                    while (backwardsCount >= 0 && (char.IsNumber(operation[backwardsCount]) == true || operation[backwardsCount] == '.'))
                    {
                        nr.number = nr.number + operation[backwardsCount];
                        backwardsCount--;
                    }
                    numbers zero;
                    zero.symbol = '+';
                    zero.number = "0";
                    Numbers.Push(zero);
                    Numbers.Push(nr);
                    Signs.Push(c);
                }
                else if (i == 0 && operation[i] == '+')
                {
                    i++;
                    continue;
                }
                else if (i == 0 && (operation[i] == '.' || operation[i] == '*' || operation[i] == '/' || operation[i] == '.' || operation[i] == '!' || operation[i] == '%' || operation[i] == '^'))
                {
                    throw new CalculatorException(Errors.wrongOperationError);
                }
                else if (i < operation.Length && operation[i] >= '0' && operation[i] <= '9')
                {
                    nr.number = "";
                    nr.symbol = '+';
                    while (i < operation.Length && (char.IsNumber(operation[i]) == true || operation[i] == '.'))
                        i++;
                    backwardsCount = i - 1;
                    while (backwardsCount >= 0 && (char.IsNumber(operation[backwardsCount]) == true || operation[backwardsCount] == '.'))
                    {
                        nr.number = nr.number + operation[backwardsCount];
                        backwardsCount--;
                    }
                    Numbers.Push(nr);
                }
                else
                {
                    if (operation[i] == '√' && (i == 0 || (i > 0 && char.IsNumber(operation[i - 1]) == false)))
                    {
                        RadicalOrders.Push("2");
                        if (Signs.Count() == 0)
                            Signs.Push(operation[i]);
                        else Verify(operation[i]);
                    }
                    else if (char.IsNumber(operation[i]) == true)
                    {
                        string c = "";
                        while (char.IsNumber(operation[i]) == true)
                        {
                            if (operation[i] == '⁰') c = c + '0';
                            if (operation[i] == '¹') c = c + '1';
                            if (operation[i] == '²') c = c + '2';
                            if (operation[i] == '³') c = c + '3';
                            if (operation[i] == '⁴') c = c + '4';
                            if (operation[i] == '⁵') c = c + '5';
                            if (operation[i] == '⁶') c = c + '6';
                            if (operation[i] == '⁷') c = c + '7';
                            if (operation[i] == '⁸') c = c + '8';
                            if (operation[i] == '⁹') c = c + '9';
                            i++;
                        }
                        RadicalOrders.Push(operations.Reverse(c));
                        i--;
                    }
                    else if (Signs.Count() == 0)
                        Signs.Push(operation[i]);
                    else if (operation[i - 1] == '(')
                    {
                        numbers zero;
                        zero.symbol = '+';
                        zero.number = "0";
                        Numbers.Push(zero);
                        Signs.Push(operation[i]);
                    }
                    else if (operation[i] == ')')
                    {
                        while (Signs.Peek() != '(')
                        {
                            oneStepCalculation();
                            Signs.Pop();
                        }
                        Signs.Pop();
                    }
                    else Verify(operation[i]);
                    i++;
                }
            }
        }
        /// <summary>
        /// this function identifies next operation to be executed based on its sign 
        /// </summary>
        /// <exception cref="CalculatorException"></exception>
        private void oneStepCalculation()
        {
            numbers a, b;
            switch (Signs.Peek())
            {
                case '√':
                    {
                        numbers ordinRadical;
                        a = Numbers.Peek();
                        Numbers.Pop();
                        ordinRadical.symbol = '+';
                        ordinRadical.number = RadicalOrders.Pop();
                        if (a.symbol == '-')
                        {
                            if (ordinRadical.number[0] != '1' && ordinRadical.number[0] != '3' && ordinRadical.number[0] != '5' && ordinRadical.number[0] != '7' && ordinRadical.number[0] != '9')
                            {
                                throw new CalculatorException(Errors.radicalError);
                            }
                        }
                        numbers z = operations.NthRoot(a, ordinRadical);
                        if (a.symbol == '-') z.symbol = '-';
                        Numbers.Push(z);
                        break;
                    }
                case '%':
                    {
                        b = Numbers.Peek();
                        Numbers.Pop();
                        Numbers.Push(operations.Percentage(b));
                        break;
                    }
                case '!':
                    {
                        b = Numbers.Pop();
                        Numbers.Push(operations.Factorial(b));
                        break;
                    }
                case '+':
                    {
                        a = Numbers.Pop();
                        b = Numbers.Pop();
                        if (a.symbol == '+' && b.symbol == '+')
                            Numbers.Push(operations.Add(a, b));
                        else if (a.symbol == '-' && b.symbol == '+')
                        {
                            if (operations.NumbersMax(b.number, a.number) == 1)
                                Numbers.Push(operations.Substract(b, a));
                            else
                            {
                                numbers c = operations.Substract(a, b);
                                c.symbol = '-';
                                Numbers.Push(c);
                            }
                        }
                        else if (a.symbol == '+' && b.symbol == '-')
                        {
                            if (operations.NumbersMax(a.number, b.number) == 1)
                                Numbers.Push(operations.Substract(a, b));
                            else
                            {
                                numbers c = operations.Substract(b, a);
                                c.symbol = '-';
                                Numbers.Push(c);
                            }
                        }
                        else if (a.symbol == '-' && b.symbol == '-')
                        {
                            numbers c = operations.Add(a, b);
                            c.symbol = '-';
                            Numbers.Push(c);
                        }
                        break;
                    }
                case '-':
                    {
                        a = Numbers.Pop();
                        b = Numbers.Pop();
                        if (b.symbol == '+' && a.symbol == '+')
                        {
                            if (operations.NumbersMax(b.number, a.number) == 1)
                                Numbers.Push(operations.Substract(b, a));
                            else
                            {
                                numbers c = operations.Substract(a, b);
                                c.symbol = '-';
                                Numbers.Push(c);
                            }
                        }
                        else if (b.symbol == '+' && a.symbol == '-')
                            Numbers.Push(operations.Add(b, a));
                        else if (b.symbol == '-' && a.symbol == '+')
                        {
                            numbers c = operations.Add(a, b);
                            c.symbol = '-';
                            Numbers.Push(c);
                        }
                        else if (a.symbol == '-' && b.symbol == '-')
                        {
                            if (operations.NumbersMax(b.number, a.number) == 1)
                            {
                                numbers c = operations.Substract(b, a);
                                c.symbol = '-';
                                Numbers.Push(c);
                            }
                            else Numbers.Push(operations.Substract(a, b));
                        }
                        break;
                    }
                case '*':
                    {
                        a = Numbers.Pop();
                        b = Numbers.Pop();
                        numbers c = operations.Multiply(a, b);
                        Numbers.Push(c);
                        break;
                    }
                case '/':
                    {
                        a = Numbers.Pop();
                        b = Numbers.Pop();
                        if (a.number == "0")
                        {
                            throw new CalculatorException(Errors.divisionError);
                        }
                        Numbers.Push(operations.Divide(a, b));
                        break;
                    }
                case '^':
                    {
                        a = Numbers.Pop();
                        b = Numbers.Pop();
                        if (a.number == "0" && b.number == "0")
                        {
                            throw new CalculatorException(Errors.powError);
                        }
                        numbers c = operations.Pow(b, a);
                        if (b.symbol == '-')
                        {
                            if (a.number[0] != '0' && a.number[0] != '2' && a.number[0] != '4' && a.number[0] != '6' && a.number[0] != '8')
                                c.symbol = '-';
                        }
                        if (a.symbol == '-')
                        {
                            numbers d;
                            d.number = "1";
                            d.symbol = '+';
                            c = operations.Divide(c, d);
                        }
                        Numbers.Push(c);
                        break;
                    }
            }
        }
        /// <summary>
        /// check if the symbol has higher or lower priority than the top of the stack
        /// </summary>
        /// <param name="c">symbol to check</param>
        /// <returns></returns>
        private int VerifyTop(char c)
        {
            if (c == '^')
            {
                if (Signs.Peek() == '^' || Signs.Peek() == '√' || Signs.Peek() == '!')
                    return 0;
                return 1;
            }
            if (c == '*' || c == '/')
            {
                if (Signs.Peek() == '^' || Signs.Peek() == '*' || Signs.Peek() == '/' || Signs.Peek() == '√' || Signs.Peek() == '!' || Signs.Peek() == '%')
                    return 0;
                return 1;
            }
            if (c == '+' || c == '-')
            {
                if (Signs.Peek() == '^' || Signs.Peek() == '+' || Signs.Peek() == '-' || Signs.Peek() == '*' || Signs.Peek() == '/' || Signs.Peek() == '√' || Signs.Peek() == '!' || Signs.Peek() == '%')
                    return 0;
                return 1;
            }
            return 1;
        }
        /// <summary>
        /// while the new stmbol has lower priority than the top of the stack
        /// the function will do the top sign operation and insert the new sign after
        /// </summary>
        /// <param name="c">symbol to check</param>
        private void Verify(char c)
        {
            if (VerifyTop(c) == 1)
            {
                Signs.Push(c);
                return;
            }
            while (Signs.Count() != 0 && VerifyTop(c) == 0)
            {
                oneStepCalculation();
                Signs.Pop();
            }
            Signs.Push(c);
        }
        /// <summary>
        /// divide the result to be more easy to read
        /// ex: 34556 in 34,556
        /// </summary>
        /// <param name="nr"></param>
        /// <returns></returns>
        private string DivideResult(string nr)
        {
            int i = 0, cont = 0;
            int distDot = operations.dotDistance(nr);
            if (distDot > 0)
            {
                i = distDot;
                i++;
            }
            while (i < nr.Length)
            {
                cont++;
                if (cont == 3 && i + 1 < nr.Length)
                {
                    cont = 0;
                    nr = nr.Insert(i + 1, ",");
                    i++;
                }
                i++;
            }
            return nr;
        }
        /// <summary>
        /// round the result
        /// </summary>
        private void showResult()
        {
            string result = Numbers.Peek().number;
            result = operations.Rounding(result, limit);
            if (operations.dotDistance(result) > 0)
                while (result.First() == '0')
                    result = result.Substring(1);
            if (result.First() == '.')
                result = result.Substring(1);
            result = DivideResult(result);
            if (Numbers.Peek().symbol == '-')
                result = result + Convert.ToString(Numbers.Peek().symbol);
            result = result + "=";

            //next 2 rows are used to print the result at the end of the operation in its textbox
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            Focus(operations.Reverse(result));
            listBox1.Items.Insert(0, textBox1.Text);
        }
        /// <summary>
        /// locks the mouse cursor in the place set by the user,
        /// regardless of whether he uses the laptop keyboard or the buttons to enter the operation
        /// add the calculation elements, if these are entered from the computer buttons
        /// </summary>
        /// <param name="c">after what character to put the cursor</param>
        private void Focus(string c)
        {
            label5.Visible = false;
            if (panel1.Visible == true) return;
            textBox1.Focus();
            textBox1.SelectionLength = 0;
            if (c == "-1")
                return;
            int selectionIndex = textBox1.SelectionStart;
            textBox1.Text = textBox1.Text.Insert(selectionIndex, c);
            textBox1.SelectionStart = selectionIndex + c.Length;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                solve();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Focus("-1");

        }

        // next functoins are for handling whatn happens when a button is pressed 
        private void button1_Click(object sender, EventArgs e)
        {
            Focus("1");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Focus("2");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Focus("3");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Focus("4");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Focus("5");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Focus("6");
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Focus("7");
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Focus("8");
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Focus("9");
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Focus("0");
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Focus("+");
        }
        private void buttonSubstract_Click(object sender, EventArgs e)
        {
            Focus("-");
        }
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            Focus("*");
        }
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            Focus("/");
        }
        private void buttonPow_Click(object sender, EventArgs e)
        {
            Focus("^");
        }
        private void buttonPercentage_Click(object sender, EventArgs e)
        {
            Focus("%");
        }
        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            Focus("√");
        }
        private void buttonSqrtN_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show(Errors.radicalBoxError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nr = "", c = textBox2.Text;
            if (c == "0" || c == "1" || c[0] == '0' || c[0] == '-' || !int.TryParse(c, out _))
            {
                MessageBox.Show(Errors.radicalBoxError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == '0') nr = nr + '⁰';
                else if (c[i] == '1') nr = nr + '¹';
                else if (c[i] == '2') nr = nr + '²';
                else if (c[i] == '3') nr = nr + '³';
                else if (c[i] == '4') nr = nr + '⁴';
                else if (c[i] == '5') nr = nr + '⁵';
                else if (c[i] == '6') nr = nr + '⁶';
                else if (c[i] == '7') nr = nr + '⁷';
                else if (c[i] == '8') nr = nr + '⁸';
                else if (c[i] == '9') nr = nr + '⁹';
                else
                {
                    throw new CalculatorException(Errors.radicalBoxError);
                }
            }
            nr = nr + "√";
            Focus(nr);
        }
        private void buttonFactorial_Click(object sender, EventArgs e)
        {
            Focus("!");
        }
        private void buttonDot_Click(object sender, EventArgs e)
        {
            Focus(".");
        }
        private void buttonLeftBracket_Click(object sender, EventArgs e)
        {
            Focus("(");
        }
        private void buttonRightBracket_Click(object sender, EventArgs e)
        {
            Focus(")");
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Visible = false;
            Focus("-1");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Focus("-1");
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Visible = true;
            Focus("-1");
        }
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Focus("-1");
            if (panel1.Visible == true)
            {
                if (!radioButton1.Checked)
                {
                    if (textBox3.Text.Length == 0)
                    {
                        MessageBox.Show(Errors.settingsError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var isNumeric = int.TryParse(textBox3.Text, out int n);
                    if (!isNumeric)
                    {
                        MessageBox.Show(Errors.settingsError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (n > 15)
                    {
                        MessageBox.Show(Errors.settingsError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                panel1.Visible = false;
            }
            else panel1.Visible = true;
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            string c = textBox1.Text;
            int pos = textBox1.SelectionStart - 1;
            if (c == "")
            {
                Focus("-1");
                return;
            }
            if (c.Length > 1)
                c = c.Remove(pos, 1);
            else
                c = "";
            textBox1.Text = c;
            Focus("-1");
            textBox1.SelectionStart = pos;
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Numbers.Clear();
            RadicalOrders.Clear();
            Signs.Clear();
            Focus("-1");
        }
        private void buttonInfo_Click(object sender, EventArgs e)
        {
            Focus("-1");
            if (panel2.Visible == true)
                panel2.Visible = false;
            else panel2.Visible = true;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
            }
            Focus("-1");
        }
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            solve();
        }
    }
}
