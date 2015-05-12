using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using stack_concurso.domain.Business;
using stack_concurso.domain.Modelo;
using stack_concurso.forms.acessorio;

namespace stack_concurso.forms.cenarios.cadastro
{
    public partial class criarProva : cenarios.common.masterPage
    {
        public criarProva()
        {
            InitializeComponent();
            //screenAdjust();
            //headerName("Cadastro", "Prova");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cargo = Int32.Parse(textBox1.Text);
            var query = new OpcaoBO().Find(a=> a.cod_cargo == cargo && a.cod_concurso == 3);
            //entidades entidades = new entidades();
            foreach (tb_opcao opc in query){
                // CRIAR PROVA
                tb_prova prova = new tb_prova();
                prova.cod_opcao = opc.cod_opcao;
                prova.descricao = "Prova de " + opc.cod_cargo;
                prova.num_questoes = 40;
                new ProvaBO().Salvar(prova);
                // PROVA CRIADA

                // CRIAR CADERNO
                tb_caderno caderno = new tb_caderno();
                caderno.cod_opcao = opc.cod_opcao;
                caderno.descricao = "Caderno de " + opc.cod_cargo;
                new CadernoBO().Salvar(caderno);
                // CADERNO CRIADO


                // CRIAR QUESTAO
                for (int i = 0; i < prova.num_questoes; i++)
                {
                    tb_questao questao = new tb_questao();
                    questao.cod_prova = prova.cod_prova;
                    questao.descricao = "Q" + (i+1);
                    questao.peso = 1;
                    questao.resposta_correta = textBox3.Text[i]+"";
                    new QuestaoBO().Salvar(questao);

                    tb_questao_caderno questaoCaderno = new tb_questao_caderno();
                    questaoCaderno.cod_caderno = caderno.cod_caderno;
                    questaoCaderno.cod_questao = questao.cod_questao;
                    questaoCaderno.numero = i+1;
                    new QuestaoCadernoBO().Salvar(questaoCaderno);
                }                
                // QUESTÕES CRIADAS

               
            }
            textBox3.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string trocar = textBox2.Text.Replace("\r\n", "	");
            string[] a = trocar.Split('	');
            for (int i=0;i<a.Count();i++){
                try
                {
                    if (char.IsLetter(a[i], 0))
                        textBox3.Text += a[i];
                }
                catch (Exception) { }
            }
            label1.Text = textBox3.Text.Count().ToString();
            textBox2.Text = "";
        }
    }
}
