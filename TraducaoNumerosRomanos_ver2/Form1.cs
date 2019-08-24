using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TraducaoNumerosRomanos_ver2
{
    public partial class Frm_Conversor : Form
    {
        public Frm_Conversor()
        {
            InitializeComponent();
        }

        List<string> _listaLetrasRomanas;
        List<int> _listaNumerosInteiros;


        private void Form1_Load(object sender, EventArgs e)
        {

            _listaLetrasRomanas = new List<string>();
            _listaNumerosInteiros = new List<int>();

            _listaLetrasRomanas.Add("I");
            _listaLetrasRomanas.Add("V");
            _listaLetrasRomanas.Add("X");
            _listaLetrasRomanas.Add("L");
            _listaLetrasRomanas.Add("C");
            _listaLetrasRomanas.Add("D");
            _listaLetrasRomanas.Add("M");

            _listaNumerosInteiros.Add(1);
            _listaNumerosInteiros.Add(5);
            _listaNumerosInteiros.Add(10);
            _listaNumerosInteiros.Add(50);
            _listaNumerosInteiros.Add(100);
            _listaNumerosInteiros.Add(500);
            _listaNumerosInteiros.Add(1000);

        }

        private void Txt_Numero_TextChanged(object sender, EventArgs e)
        {

            if (Txt_Numero.Text == "")
            {

                //MessageBox.Show("Informme o Número Romano que deseja converter!", "Conversor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            int inicio = 0;
            bool resultado = false;

            if (Txt_Numero.Text.Length > 1)
            {
                inicio = Txt_Numero.Text.Length - 1;
            }
            else
            {
                inicio = 0;
            }

            int i = 0;
            for (i = 0; i <= _listaLetrasRomanas.Count - 1; i++)
            {

                if (_listaLetrasRomanas[i] == Txt_Numero.Text.Substring(inicio, 1).ToUpper())
                {
                    resultado = true;
                    break;
                }
                else
                {
                    resultado = false;
                }

            }

            if (resultado == false)
            {
                MessageBox.Show("A letra informada não é válida!", "Conversor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Txt_Numero.Clear();
                Txt_Resultado.Clear();
                return;

            }

        }

        private int ValInt(object value)
        {

            if (value == null)
            {
                value = 0;
            }

            int v;
            if (Int32.TryParse(value.ToString(), out v))
            {
                value = v;
            }
            else
            {
                value = 0;
            }

            return Int32.Parse(value.ToString());

        }

        private void Btn_Converter_Click(object sender, EventArgs e)
        {

            if (Txt_Numero.Text == "")
            {

                MessageBox.Show("Informme o Número Romano que deseja converter!", "Conversor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            Txt_Resultado.Clear();

            bool retorno = ValidaNumeroRomano();

            if (retorno == false)
            {

                Txt_Numero.Clear();
                Txt_Resultado.Clear();

                MessageBox.Show("O número romano informado é inválido!", "Conversor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int contador = 0;

            if ((Txt_Numero.Text.Length - 1) == 0)
            {

                for (int i = 0; i <= _listaLetrasRomanas.Count - 1; i++)
                {

                    if (_listaLetrasRomanas[i] == Txt_Numero.Text.Substring(contador, 1).ToUpper())
                    {

                        Txt_Resultado.Text = Convert.ToString(ValInt(Txt_Resultado.Text) + _listaNumerosInteiros[i]);

                        break;

                    }

                }

            }
            else
            {

                while (contador <= Txt_Numero.Text.Length - 1)
                {

                    for (int i = 0; i <= _listaLetrasRomanas.Count - 1; i++)
                    {

                        if (_listaLetrasRomanas[i] == Txt_Numero.Text.Substring(contador, 1).ToUpper())
                        {

                            if ((_listaLetrasRomanas[i] == "V") || (_listaLetrasRomanas[i] == "X"))
                            {

                                if (contador != 0)
                                {

                                    if (Txt_Numero.Text.Substring(contador - 1, 1).ToUpper() == "I")
                                    {
                                        Txt_Resultado.Text = Convert.ToString((ValInt(Txt_Resultado.Text) - 2) + _listaNumerosInteiros[i]);

                                        break;
                                    }
                                    else
                                    {

                                        Txt_Resultado.Text = Convert.ToString(ValInt(Txt_Resultado.Text) + _listaNumerosInteiros[i]);

                                        break;
                                    }

                                }
                                else
                                {

                                    Txt_Resultado.Text = Convert.ToString(ValInt(Txt_Resultado.Text) + _listaNumerosInteiros[i]);

                                    break;
                                }

                            }

                            else if ((_listaLetrasRomanas[i] == "L") || (_listaLetrasRomanas[i] == "C"))
                            {
                                if (contador != 0)
                                {

                                    if (Txt_Numero.Text.Substring(contador - 1, 1).ToUpper() == "X")
                                    {
                                        Txt_Resultado.Text = Convert.ToString((ValInt(Txt_Resultado.Text) - 20) + _listaNumerosInteiros[i]);

                                        break;
                                    }
                                    else
                                    {

                                        Txt_Resultado.Text = Convert.ToString(ValInt(Txt_Resultado.Text) + _listaNumerosInteiros[i]);

                                        break;
                                    }

                                }
                                else
                                {

                                    Txt_Resultado.Text = Convert.ToString(ValInt(Txt_Resultado.Text) + _listaNumerosInteiros[i]);

                                    break;
                                }
                            }

                            else if ((_listaLetrasRomanas[i] == "D") || (_listaLetrasRomanas[i] == "M"))
                            {
                                if (contador != 0)
                                {

                                    if (Txt_Numero.Text.Substring(contador - 1, 1).ToUpper() == "C")
                                    {
                                        Txt_Resultado.Text = Convert.ToString((ValInt(Txt_Resultado.Text) - 200) + _listaNumerosInteiros[i]);

                                        break;
                                    }
                                    else
                                    {

                                        Txt_Resultado.Text = Convert.ToString(ValInt(Txt_Resultado.Text) + _listaNumerosInteiros[i]);

                                        break;
                                    }

                                }
                                else
                                {

                                    Txt_Resultado.Text = Convert.ToString(ValInt(Txt_Resultado.Text) + _listaNumerosInteiros[i]);

                                    break;
                                }
                            }

                            else
                            {

                                Txt_Resultado.Text = Convert.ToString(ValInt(Txt_Resultado.Text) + _listaNumerosInteiros[i]);

                                break;

                            }

                        }

                    }

                    contador += 1;
                }

            }

        }

        private bool ValidaNumeroRomano()
        {

            if (Txt_Numero.Text.ToUpper().Contains("IIII"))
            {
                return false;
            }


            if (Txt_Numero.Text.ToUpper().Contains("IIV"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("VV"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("VIIII"))
            {
                return false;
            }


            if (Txt_Numero.Text.ToUpper().Contains("VX"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("XXXX"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("IIX"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("XIIII"))
            {
                return false;
            }


            if (Txt_Numero.Text.ToUpper().Contains("IL"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("LIIII"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("VL"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("LL"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("LVV"))
            {
                return false;
            }


            if (Txt_Numero.Text.ToUpper().Contains("IC"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("CIIII"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("VC"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("CVV"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("LC"))
            {
                return false;
            }


            if (Txt_Numero.Text.ToUpper().Contains("CCCC"))
            {
                return false;
            }


            if (Txt_Numero.Text.ToUpper().Contains("CCD"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("ID"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("VD"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("LD"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("DD"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("DCCCC"))
            {
                return false;
            }


            if (Txt_Numero.Text.ToUpper().Contains("MMMM"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("IM"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("VM"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("XM"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("LM"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("DM"))
            {
                return false;
            }
            if (Txt_Numero.Text.ToUpper().Contains("MIIII"))
            {
                return false;
            }
                       
            return true;

        }

    }

}

