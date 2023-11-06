using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraWindows
{
    public partial class Form1 : Form
    {
        //variáveis
        double numero1 = 0, numero2 = 0;
        bool apertOp = false;
        char operador;
        
        public Form1()
        {
            InitializeComponent();
        }

        //adicionar Números da calculadora
        private void numero_Click(object sender, EventArgs e)
        {
            //obter botão que está chamando o evento
            var botao = (Button)sender;

            //verificar se a operação é zero e receber vazio
            if (txtOperacao.Text == "0")
                txtOperacao.Text = "";

            //executará incondicionalmente
            txtOperacao.Text += botao.Text;

        }
        //botão limpa tudo
        private void btnC_Click(object sender, EventArgs e)
        {
            txtOperacao.Clear();
            lblOpAux.Text = "";
            numero1 = 0;
            numero2 = 0;
            operador = '0';
            
        }

        //adicionar operador
        private void Operador_Click(object sender, EventArgs e)
        {


            // Obter o botão que está chamando o evento
            var botao = (Button)sender;

            //verificar se o operador foi clicado mais de uma vez
            if (apertOp == false && txtOperacao.Text != "" )
            {
                numero1 = double.Parse(txtOperacao.Text);
                txtOperacao.Text = "";
                operador = char.Parse(botao.Text);
                lblOpAux.Text = numero1.ToString() + operador.ToString(); 
                apertOp = true;
                
            }
            //verificar se não está vazio
            else if(txtOperacao.Text != "" && txtOperacao.Text != "0")
            {
                // Simular o botão '=':
                btnIgual.PerformClick();
                numero1 = double.Parse(txtOperacao.Text);
                txtOperacao.Text = "";
                operador = char.Parse(botao.Text);
                lblOpAux.Text = numero1.ToString() + operador.ToString();

            }
            


        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            //Função dos operadores
            try
            {
                numero2 = double.Parse(txtOperacao.Text);

                switch (operador)
                {
                    case 'X':
                        txtOperacao.Text = (numero1 * numero2).ToString();
                        numero1 = double.Parse(txtOperacao.Text);
                        lblOpAux.Text = txtOperacao.Text;
                        lblOpAux.Text = "";
                        numero1 = 0;
                        

                        break;

                    case '+':
                        txtOperacao.Text = (numero1 + numero2).ToString();
                        numero1 = double.Parse(txtOperacao.Text);
                        lblOpAux.Text = txtOperacao.Text;
                        lblOpAux.Text = "";
                        numero1 = 0;
                        


                        break;


                    case '-':

                        txtOperacao.Text = (numero1 - numero2).ToString();
                        numero1 = double.Parse(txtOperacao.Text);
                        lblOpAux.Text = txtOperacao.Text;
                        lblOpAux.Text = "";
                        numero1 = 0;
                        
                        break;



                    case '÷':
                        if (numero2 != 0)
                        {
                            txtOperacao.Text = (numero1 / numero2).ToString();
                            numero1 = double.Parse(txtOperacao.Text);
                            lblOpAux.Text = txtOperacao.Text;
                            lblOpAux.Text = "";
                            numero1 = 0;
                        }
                        else
                        {
                            txtOperacao.Text = "Impossível dividir por zero!";

                        }
                        break;
                }
            }
            catch
            {
                txtOperacao.Text = "0";
                lblOpAux.Text = "";
            }
        }
    }
}
