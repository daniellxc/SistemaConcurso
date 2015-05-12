using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using Admin.classes.classes_apoio_leitura;
using stack_concurso.domain.Business;
using stack_concurso.domain.Modelo;

#region Classes de Apoio
namespace Admin.classes.classes_apoio_leitura
{


    public class ERRO
    {
        private int _linha;
        private string _erro;
        private string _conteudo_linha;

        public ERRO(int Linha, string Erro, string Conteudo_Linha)
        {
            _linha = Linha;
            _erro = Erro;
            _conteudo_linha = Conteudo_Linha;
        }

        public int linha { get { return _linha; } }
        public string erro { get { return _erro; } }
        public string conteudo_linha { get { return _conteudo_linha; } }
    }

    public class CARTAO
    {
        public int cod_caderno;
        public string inscricao;
        public string grade;
        public string respostas;
        public string falta;
      //  public string id_caderno;
    }

    public class ARQUIVO
    {
        private string _nome_arquivo;

        public ARQUIVO(string nome_arquivo)
        {
            _nome_arquivo = nome_arquivo;
        }

        public string NOME_ARQUIVO
        {
            get { return _nome_arquivo; }
            set { _nome_arquivo = value; }
        }

    }
}
#endregion

namespace stack_concurso.forms.acessorio
{
   public class Leitura
    {

        private string _arquivo;
        private ArrayList _erros;
        private int tam_inscricao = 10;

        private ArrayList cartoes;

        private const int INICIO_RESPOSTAS = 12;
        private const int FINAL_RESPOSTAS  = 51;
        private const int TAMANHO_LINHA    = 53;
        private const string MARCACAO_DUPLA = "?";
        private const string MARCACAO_BRANCA = " ";
        private const string MARCACAO_FALTA = "F";


        #region Propriedades

        public string arquivo
        {
            get { return _arquivo; }
            set { _arquivo = value; }
        }

        public ArrayList erros
        {
            get { return _erros; }
        }
		



        #endregion

       public Leitura(string Arquivo)
		{
			_erros = new ArrayList();
			if ((_arquivo = Arquivo) != null)
			{		
				if(File.Exists(_arquivo))
				{
					trata_arquivo();
				}
			}
		}


       private bool existe_inscricao(string inscricao)
       {
           for (int i = 0; i < cartoes.Count; i++)
           {
               if (((CARTAO)cartoes[i]).inscricao.Equals(inscricao))
               {
                   return true;
               }
           }

           return false;
       }

       public bool existe_cartao_lido(string inscricao)
       {
           for (int i = 0; i < cartoes.Count; i++)
           {
               if (((CARTAO)cartoes[i]).inscricao.Equals(inscricao))
                   return true;
           }
           return false;
       }


       public bool trata_arquivo()
       {
           _erros.Clear();
           string linha = "";
           int n_linha = 0;
           bool ok = true;

           try
           {
               StreamReader arq = new StreamReader(_arquivo);

               CadernoBO caderno = new CadernoBO();
               CandidatoBO candidato = new CandidatoBO();

               cartoes = new ArrayList();

               while ((linha = arq.ReadLine()) != null)
               {
                   n_linha++;
                   if (linha.Length >= tam_inscricao + 1)
                   {
                       CARTAO cartao = new CARTAO();
                       cartao.inscricao = linha.Substring(0, tam_inscricao);
                      // cartao.id_caderno = linha.Substring(tam_inscricao, 1);
                       cartao.falta = linha.Substring(tam_inscricao, 1);
                       if (!existe_cartao_lido(cartao.inscricao))
                       {
                           if (candidato.buscarCandidato(cartao.inscricao).Count > 0)
                           {
                              //cartao.grade = candidato.COD_GRADE.ToString();
                              
                                   if (linha.Length == TAMANHO_LINHA)
                                   {
                                       cartao.respostas = linha.Substring(INICIO_RESPOSTAS - 1, (FINAL_RESPOSTAS - INICIO_RESPOSTAS) + 1);
                                       cartoes.Add(cartao);
                                   }
                                   else
                                   {
                                       ok = false;
                                       _erros.Add(new ERRO(n_linha, "Tamanho da linha inválido - " + linha.Length.ToString() + " Caracteres", linha));
                                   }
                               
                            
                           }
                           else
                           {
                               ok = false;
                               _erros.Add(new ERRO(n_linha, "Inscrição do candidato não encontrada! - " + cartao.inscricao, linha));
                           }
                       }
                       else
                       {
                           ok = false;
                           _erros.Add(new ERRO(n_linha, "Inscrição do candidato DUPLICADA! - " + cartao.inscricao, linha));
                       }
                   }
                   else
                   {
                       ok = false;
                       _erros.Add(new ERRO(n_linha, "O formato da linha é inválido!", linha));
                   }
               }
               arq.Close();
           }
           catch (System.Exception e)
           {
               _erros.Add(new ERRO(n_linha, "Erro ao tratar arquivo - " + e.Message, linha));
               ok = false;
           }

           return ok;
       }


       public bool corrigir_questoes()
       {
           _erros.Clear();
           
           
               string resp = "";
               float peso_prova = 0;
               CadernoBO caderno = new CadernoBO();
               CARTAO cartao;
               tb_resposta resposta;
               tb_questao questao;
               CandidatoBO candidatoBO = new CandidatoBO();
               List<tb_resposta> respostasCandidatos = new List<tb_resposta>();
           
               List<tb_questao_caderno> questoes_caderno = new List<tb_questao_caderno>();
               try
               {
                   for (int i = 0; i < cartoes.Count; i++)
                   {
                       cartao = (CARTAO)cartoes[i];
                       // TbCandidato candidato = new TbCandidato(cartao.inscricao);
                       tb_candidato candidato = candidatoBO.buscarCandidato(cartao.inscricao).First<tb_candidato>();
                       
                       candidatoBO.atribuir_falta(candidato, cartao.falta.Equals("F"));

                       if (candidatoBO.apagar_respostas(candidato.cod_candidato))
                       {

                           // caderno.pegar_no_banco(cartao.cod_caderno);
                           questoes_caderno = caderno.get_questoes_caderno(cartao.inscricao);


                           for (int j = 0; j < questoes_caderno.Count; j++)
                           {
                               questao = new QuestaoBO().getQuestao(((tb_questao_caderno)questoes_caderno[j]).cod_questao);//(((QUESTAO_CADERNO)questoes_caderno[j]).COD_QUESTAO);
                               resp = cartao.respostas.Substring(j, 1);
                               resposta = new tb_resposta();

                               // peso_prova = new PROVA_CONCURSO(questao.COD_PROVA_CONCURSO).peso_prova();
                               //if (new TIPO_QUESTAO(questao.COD_TIPO_QUESTAO).SUBJETIVO)
                               //{
                               //    if (resp.Equals("A"))
                               //    {
                               //        resp = "10";
                               //    }

                               //    if (!cartao.falta.Equals("F"))
                               //    {
                               //        if (resp.Equals("?") || resp.Equals(" "))
                               //        {
                               //            return false;
                               //        }
                               //    }
                               //    else
                               //    {
                               //        resp = "0";
                               //    }
                               //    resposta.NOTA = int.Parse(resp) * questao.PESO;
                               //}


                               if (resp.Equals(questao.resposta_correta)|| questao.resposta_correta.Equals("Z"))
                               {
                                   resposta.nota = 1;
                               }
                               else resposta.nota = 0;

                               resposta.resposta = resp;
                               resposta.cod_questao = questoes_caderno[j].cod_questao;
                               resposta.cod_candidato = candidato.cod_candidato;
                              // new RespostaBO().Salvar(resposta);
                               respostasCandidatos.Add(resposta);
                           }

                         

                       }

                   }
                   for (int r = 0; r < respostasCandidatos.Count; r++)
                   {
                       new RespostaBO().Salvar((tb_resposta)respostasCandidatos[r]);
                   }
                   return true;
               }
               catch (Exception e)
               {
                   string teste = e.Message;
                   teste = teste;
                   return false;
               }
       }


       public bool conferir_cartoes()
       {
           int i = 0;
           bool ok = true;
           _erros.Clear();
           List<tb_candidato> rs = new CandidatoBO().GetAll().ToList<tb_candidato>();
           foreach(tb_candidato candidato in rs)
           {
               if (!existe_inscricao(candidato.num_inscricao))
               {
                   i++;
                   //_erros.Add(new ERRO(i, "O candidato '" + candidato.nome+ "'(" + candidato.num_inscricao + ") não está no arquivo.", ""));
                   //ok = false;
                   new CandidatoBO().atribuir_falta(candidato, true);
                   //candidato.falta = 1;
                   //new CandidatoBO().Salvar(candidato);
               }
           }
           return ok;
       }





    }
}
