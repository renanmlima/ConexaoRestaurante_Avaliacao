using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avaliacao
{
    public partial class TelaComanda : Form
    {
        public TelaComanda()
        {
            InitializeComponent();
        }
        Conexao con = new Conexao();
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string dados;
            if(txtNumero.Text == "")
            {
                dados = $"INSERT INTO bd_avaliacao.tb_comanda values (null,'{cbxPrato.Text}','{txtVlrPrato.Text}','{cbxBebida.Text}','{txtVlrPrato.Text}')";
                
                if (con.Executa(dados))
                {
                    MessageBox.Show("Cadastrado com sucesso");
                }
                else
                {
                    MessageBox.Show("Erro!");
                }
            }
            else
            {
                MessageBox.Show("O campo número, não pode haver registros ao salvar");
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string dados;
            if (txtNumero.Text != "")
            {
                dados = $"DELETE FROM bd_avaliacao.tb_comanda WHERE numero = '{txtNumero.Text}' ";

                if (con.Executa(dados))
                {
                    MessageBox.Show($"Registro {txtNumero.Text} deletado com sucesso.");
                }
                else
                {
                    MessageBox.Show("Erro!");
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira a chave que deseja deletar");
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string dados;
            if (txtNumero.Text != "")
            {
                dados = $"UPDATE bd_avaliacao.tb_comanda SET nome_prato = '{cbxPrato.Text}', nome_bebida = '{cbxBebida.Text}', valor_prato = '{txtVlrPrato.Text}', valor_bebida = '{txtVlrBebida.Text}' WHERE numero = '{txtNumero.Text}'";

                if (con.Executa(dados))
                {
                    MessageBox.Show($"Registro {txtNumero.Text} atualizado com sucesso.");
                }
                else
                {
                    MessageBox.Show("Erro!");
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira a chave que deseja deletar");
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esse botão não funciona");
            
        }
    }
}
