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

        private void limpaText()
        {
            txtNumero.Text = "";
            txtVlrBebida.Text = "";
            txtVlrPrato.Text = "";
            cbxBebida.Text = "";
            cbxPrato.Text = "";

            dgvDados.DataSource = null;
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string dados;
            if(txtNumero.Text == "")
            {
                dados = $"INSERT INTO bd_avaliacao.tb_comanda values (null,'{cbxPrato.Text}','{txtVlrPrato.Text}','{cbxBebida.Text}','{txtVlrPrato.Text}')";
                
                if (con.Executa(dados))
                {
                    MessageBox.Show("Cadastrado com sucesso!");
                    limpaText();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar!");
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
                    limpaText();
                }
                else
                {
                    MessageBox.Show("Erro ao deletar!");
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
                    limpaText();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar!");
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira a chave que deseja deletar");
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

            try { 
                DataTable dt = con.Retorna($"SELECT * FROM bd_avaliacao.tb_comanda WHERE numero = {txtNumero.Text}");

                dgvDados.DataSource = dt;

                txtVlrBebida.Text = dt.Rows[0]["valor_bebida"].ToString();
                txtVlrPrato.Text = dt.Rows[0]["valor_prato"].ToString();
                cbxBebida.Text = dt.Rows[0]["nome_bebida"].ToString();
                cbxPrato.Text = dt.Rows[0]["nome_prato"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaText();
        }
    }
}
