using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_DCU
{
    public partial class Form1 : Form
    {
        Double result, M_number;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
              
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn5.Text;
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn8.Text;
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn7.Text;
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn6.Text;
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn9.Text;
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn4.Text;
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn3.Text;
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn2.Text;
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn1.Text;
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn0.Text;
        }

        private void Btn_Res_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Res.Text;
        }

        private void Btn_Mult_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Mult.Text;
        }

        private void Btn_Div_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Div.Text;
        }

        private void Btn_Sum_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Sum.Text;
        }

        private void Btn_Sqrt_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Sqrt.Text + "(";
        }

        private void Btn_Par_Op_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Par_Op.Text;
        }

        private void Btn_Par_Cl_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Par_Cl.Text;
        }

        private void Btn_Del_All_Click(object sender, EventArgs e)
        {
            Txt_Show.Clear();
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Del_Ans_Click(object sender, EventArgs e)
        {
            if (Txt_Show.Text!=null && Txt_Show.TextLength!=0)
            {
                Txt_Show.Text = Txt_Show.Text.Substring(0, Txt_Show.Text.Length - 1);
            }
        }

        private void Btn_Point_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Point.Text;
        }

        private String Pre_Evaluate(String expression)
        /*returns true if an string value have alpha chars.*/
        {
            List<String> funcs = new List<String>();
            funcs.Add("e");
            funcs.Add("π");
            funcs.Add("√");
            funcs.Add("^");
            funcs.Add("Sen");
            funcs.Add("Cos");
            funcs.Add("Tan");
            funcs.Add("Log");
            funcs.Add("Ln");
            
            foreach (string func in funcs)
            {
                if (expression.Contains(func))
                {
                    double result_func=0.0;
                    if (func.Equals("π"))                 
                    {
                        expression = expression.Replace(func, Math.PI.ToString());
                    }
                    else if (func.Equals("e"))
                    {
                       expression = expression.Replace(func, Math.E.ToString());
                    }
                    else if (func.Equals("√"))
                    {
                        int start_index = expression.IndexOf(func) + 2;
                        string value = expression.Substring(start_index);
                        int end_index = start_index+value.IndexOf(")")+1;
                        value=value.Substring(0,value.IndexOf(")"));
                        try
                        {
                            result_func = Convert.ToDouble(value);
                            result_func = Math.Sqrt(result_func);
                            expression = expression.Substring(0, expression.IndexOf(func)) + result_func.ToString() +expression.Substring(end_index);
                            Console.WriteLine(expression);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message, "Error en la función " + func);
                        }
                        
                    }
                    else if (func.Equals("^"))
                    {
                        List<string> nums = new List<string>();
                        for (int i = 0; i < 10; i++)
                        {
                            nums.Add(i.ToString());
                        }
                        int char_index = expression.IndexOf(func);
                        String num = "", exp = "";
                        double number = 0, exponent = 0;
                        foreach (char c in expression.Substring(0, char_index))
                        {
                            if (nums.Contains(c.ToString()))
                            {
                                num += c.ToString();
                            }
                            else
                            {
                                num = "";
                            }
                            if (c.ToString()==func)
                            {
                                break;
                            }
                                
                        }
                        if (num.Length!=0)
                        {
                            foreach (char c in expression.Substring(char_index+1))
                            {
                                if (nums.Contains(c.ToString()))
                                {
                                    exp += c.ToString();
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                        if (num.Length!=0 && exp.Length!=0)
                        {
                            double.TryParse(num, out number);
                            double.TryParse(exp, out exponent);
                            if (number!=0 && exponent!=0)
                            {
                                result_func = Math.Pow(number, exponent);
                            }
                        }
                        expression = expression.Replace(num + func + exp, result_func.ToString());
                    }
                    else
                    {
                        try
                        {
                            string value = expression.Substring(expression.IndexOf(func)+func.Length+1);
                            value=value.Remove(value.IndexOf(')'));
                            result_func = Convert.ToDouble(value);
                            if (func.Equals("Cos"))
                            {
                                result_func = Math.Cos(result_func);
                            }
                            else if (func.Equals("Sen"))
                            {
                                result_func = Math.Sin(result_func);
                            }
                            else if (func.Equals("Tan"))
                            {
                                result_func = Math.Tan(result_func);
                            }
                            else if (func.Equals("Log"))
                            {
                                result_func = Math.Log10(result_func);
                            }
                            else if (func.Equals("Ln"))
                            {
                                result_func = Math.Log(result_func);
                            }
                            expression = expression.Substring(0, expression.IndexOf(func)) + result_func.ToString() + expression.Substring(expression.IndexOf(func) + func.Length + 2 + value.Length);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show(error.Message, "Error en la función " + func);
                        }

                    }
                }
            }

            return expression;
        }
        private void BtnResult_Click(object sender, EventArgs e)
        {
            String expression = Txt_Show.Text;
            if (expression == null || String.IsNullOrEmpty(expression))
            {
                MessageBox.Show("Error en la expresión.", "La caja está vacía.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    expression = Pre_Evaluate(expression);
                    Console.WriteLine(expression);
                    result = Eval(expression);
                    Txt_Show.Text = result.ToString();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error en la expresión.", error.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Double Eval(String expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            return Convert.ToDouble(table.Compute(expression, String.Empty));
        }

        private void Btn_Pi_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Pi.Text;
        }

        private void Btn_Sen_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Sen.Text + "(";
        }

        private void Btn_Ln_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Ln.Text + "(";
        }

        private void Btn_Log_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Log.Text + "(";
        }

        private void Btn_Euler_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Euler.Text;
        }

        private void Btn_Cos_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Cos.Text + "(";
        }

        private void Btn_Tan_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += Btn_Tan.Text + "(";
        }

        private void BtnAns_Click(object sender, EventArgs e)
        {
            if (result!=0.0)
            {
                Txt_Show.Text += result.ToString();
            }
        }

        private void Btn_Pow_Click(object sender, EventArgs e)
        {
            Txt_Show.Text += "^";
        }

        private void Btn_Del_Click(object sender, EventArgs e)
        {
            Txt_Show.Text = Txt_Show.Text.Substring(0, Txt_Show.TextLength - 1);
        }

        private void Btn_mrc_Click(object sender, EventArgs e)
        {
            BtnResult_Click(sender, new EventArgs());
            M_number = result;
            MessageBox.Show("Se ha guardado el número.", "Guardado en la memoria.", MessageBoxButtons.OK);
        }

        private void Btn_Mpos_Click(object sender, EventArgs e)
        {
            result += M_number;
            Txt_Show.Text = result.ToString();
        }

        private void Btn_Mneg_Click(object sender, EventArgs e)
        {
            result -= M_number;
            Txt_Show.Text = result.ToString();
        }

        private void Btn_Prc_Click(object sender, EventArgs e)
        {
            BtnResult_Click(sender, new EventArgs());
            M_number = result/100;
            Txt_Show.Text = result.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}