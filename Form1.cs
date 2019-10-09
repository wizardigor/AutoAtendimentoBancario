using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAtendimentoBancario
{
    public partial class frmAutoAtendimentoBancario : Form
    {
        Conta xico = new Conta("Xico", 1001, 500);
        Conta maria = new Conta("Maria", 1005, 1000);

        string usuarioLogado;
        
        public frmAutoAtendimentoBancario()
        {
            InitializeComponent();
        }

        private void BtnDepositar_Click(object sender, EventArgs e)
        {
            if (usuarioLogado == "Xico")
            {
                xico.saldo += Convert.ToDouble(txtValor.Text);
                lbValor.Text = Convert.ToString(xico.saldo);
            }
            else
            {
                maria.saldo += Convert.ToDouble(txtValor.Text);
                lbValor.Text = Convert.ToString(maria.saldo);
            }
        }

        private void BtnLogar_Click(object sender, EventArgs e)
        {
            if ((txtUsuario.Text == xico.titular) || (txtUsuario.Text == maria.titular))
            {
                usuarioLogado = txtUsuario.Text;
                btnLogar.Enabled = false;
                btnSair.Enabled = true;
                btnSaldo.Enabled = true;
                btnDepositar.Enabled = true;
                btnSacar.Enabled = true;
                txtValor.Enabled = true;
                lbValor.Text = "";
            }
            else
            {
                MessageBox.Show("Usuario não cadastrado.","Erro!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void BtnSaldo_Click(object sender, EventArgs e)
        {
            if (usuarioLogado == "Xico")
            {
                lbValor.Text = Convert.ToString(xico.saldo);
            }
            else
            {
                lbValor.Text = Convert.ToString(maria.saldo);
            }
        }

        private void BtnSacar_Click(object sender, EventArgs e)
        {
            if (txtValor.Text != "")
            {
                if (usuarioLogado == "Xico")
                {
                    if (xico.chequeEspecial <= 0)
                    {
                        lbValor.Text = "SALDO INSUFICIENTE!";
                    }
                    else if ((xico.saldo - Convert.ToDouble(txtValor.Text)) >= 0)
                    {
                        xico.saldo -= Convert.ToDouble(txtValor.Text);
                        lbValor.Text = Convert.ToString(xico.saldo);
                    }
                    else if ((xico.saldo - Convert.ToDouble(txtValor.Text) <= 0) && (xico.chequeEspecial - (xico.saldo - Convert.ToDouble(txtValor.Text)) >= xico.chequeEspecial))
                    {
                        xico.chequeEspecial += (xico.saldo - Convert.ToDouble(txtValor.Text));
                        xico.saldo = 0;
                        lbValor.Text = Convert.ToString(xico.saldo) + "\nCheque Especial: " + Convert.ToString(xico.chequeEspecial);
                    }
                }
                else
                {
                    if (maria.chequeEspecial <= 0)
                    {
                        lbValor.Text = "SALDO INSUFICIENTE!";
                    }
                    else if ((maria.saldo - Convert.ToDouble(txtValor.Text)) >= 0)
                    {
                        maria.saldo -= Convert.ToDouble(txtValor.Text);
                        lbValor.Text = Convert.ToString(maria.saldo);
                    }
                    else if ((maria.saldo - Convert.ToDouble(txtValor.Text) <= 0) && (maria.chequeEspecial - (maria.saldo - Convert.ToDouble(txtValor.Text)) >= maria.chequeEspecial))
                    {
                        maria.chequeEspecial += (maria.saldo - Convert.ToDouble(txtValor.Text));
                        maria.saldo = 0;
                        lbValor.Text = Convert.ToString(maria.saldo) + "\nCheque Especial: " + Convert.ToString(maria.chequeEspecial);
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe um valor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            usuarioLogado = "";
            btnLogar.Enabled = true;
            btnSair.Enabled = false;
            btnSaldo.Enabled = false;
            btnDepositar.Enabled = false;
            btnSacar.Enabled = false;
            txtValor.Enabled = false;
            lbValor.Text = "";
        }
    }
}
