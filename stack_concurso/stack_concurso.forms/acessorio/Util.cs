using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stack_concurso.domain.Modelo;
using stack_concurso.domain.Business;
using System.Windows.Forms;
using System.Net.Mail;

namespace stack_concurso.forms.acessorio
{
   public class Util
    {
       public static void ClearForm(System.Windows.Forms.Control parent)
       {
           foreach (System.Windows.Forms.Control ctrControl in parent.Controls)
           {
               //Loop through all controls
               if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.TextBox)))
               {
                   //Check to see if it's a textbox
                   ((System.Windows.Forms.TextBox)ctrControl).Text = string.Empty;
                   //If it is then set the text to String.Empty (empty textbox)
               }
               else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.RichTextBox)))
               {
                   //If its a RichTextBox clear the text
                   ((System.Windows.Forms.RichTextBox)ctrControl).Text = string.Empty;
               }
               else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.ComboBox)))
               {
                   //Next check if it's a dropdown list
                   ((System.Windows.Forms.ComboBox)ctrControl).SelectedIndex = 0;
                   //If it is then set its SelectedIndex to 0
               }
               else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.CheckBox)))
               {
                   //Next uncheck all checkboxes
                   ((System.Windows.Forms.CheckBox)ctrControl).Checked = false;
               }
               else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.RadioButton)))
               {
                   //Unselect all RadioButtons
                   ((System.Windows.Forms.RadioButton)ctrControl).Checked = false;
               }
               else if (object.ReferenceEquals(ctrControl.GetType(), typeof(System.Windows.Forms.MaskedTextBox)))
               {
                   ((System.Windows.Forms.MaskedTextBox)ctrControl).Text = "";
               }
               if (ctrControl.Controls.Count > 0)
               {
                   //Call itself to get all other controls in other containers
                   ClearForm(ctrControl);
               }
           }
       }

       public static void ExportCandidatos()
       {
           tb_concurso concurso = new tb_concurso();

           //string caminho = ;
           //MemoryStream ms = new MemoryStream();
           //StreamWriter sw = new StreamWriter("D:\\teste.txt",true);
           //StreamWriter sw = new StreamWriter(ms);

           string nomeArquivo = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\dados_candidatos.bin";
           //string nomeArquivo = System.IO.Path.GetDirectoryName(Application.StartupPath + @"\\Candidatos");
           System.IO.File.Create(nomeArquivo).Close();
           System.IO.TextWriter sw = System.IO.File.AppendText(nomeArquivo);

            List<tb_concurso> concurso_lista = new ConcursoBO().GetAll().ToList<tb_concurso>();
           foreach (tb_concurso concurso_indice in concurso_lista)
           {
               sw.WriteLine("A|" + concurso_indice.cod_concurso + "|" + concurso_indice.descricao_concurso);
               List<tb_candidato> candidato_lista = new CandidatoBO().CandidatosConcurso(concurso_indice.cod_concurso).ToList();
               foreach (tb_candidato candidato_indice in candidato_lista)
               {
                   sw.WriteLine("B|" + candidato_indice.cod_candidato + "|" + candidato_indice.num_inscricao
                               + "|" + candidato_indice.data_inscricao + "|" + candidato_indice.nome
                               + "|" + candidato_indice.endereco + "|" + candidato_indice.numero
                               + "|" + candidato_indice.bairro + "|" + candidato_indice.cod_cidade
                               + "|" + candidato_indice.cep + "|" + candidato_indice.complemento
                               + "|" + candidato_indice.uf + "|" + candidato_indice.data_nascimento
                               + "|" + candidato_indice.telefone + "|" + candidato_indice.celular
                               + "|" + candidato_indice.rg + "|" + candidato_indice.orgao_rg
                               + "|" + candidato_indice.uf_rg + "|" + candidato_indice.cpf
                               + "|" + candidato_indice.sexo + "|" + candidato_indice.deficiencia
                               + "|" + candidato_indice.email + "|" + candidato_indice.cod_opcao
                               + "|" + candidato_indice.nome_mae + "|" + candidato_indice.observacao
                               + "|" + candidato_indice.falta + "|" + candidato_indice.nota
                               + "|" + candidato_indice.estado_civil + "|" + candidato_indice.nome_pai
                               + "|" + candidato_indice.naturalidade + "|" + candidato_indice.atendimento_especial);
               }
           }
           sw.WriteLine("C|"+DateTime.Now);
           sw.Close();
       }

       public static void ExportCandidatos(string _filename)
       {
           tb_concurso concurso = new tb_concurso();

           //string caminho = ;
           //MemoryStream ms = new MemoryStream();
           //StreamWriter sw = new StreamWriter("D:\\teste.txt",true);
           //StreamWriter sw = new StreamWriter(ms);

           string nomeArquivo = _filename; //System.IO.Path.GetFullPath(diretorio) + @"\dados_candidatos.bin";
           //string nomeArquivo = System.IO.Path.GetDirectoryName(Application.StartupPath + @"\\Candidatos");
          // if (!System.IO.File.Exists(nomeArquivo))
           //    System.IO.File.Create(nomeArquivo).Close();
           
           System.IO.TextWriter sw = System.IO.File.AppendText(nomeArquivo);

           List<tb_concurso> concurso_lista = new ConcursoBO().GetAll().ToList<tb_concurso>();
           foreach (tb_concurso concurso_indice in concurso_lista)
           {
               sw.WriteLine("A|" + concurso_indice.cod_concurso + "|" + concurso_indice.descricao_concurso);
               List<tb_candidato> candidato_lista = new CandidatoBO().CandidatosConcurso(concurso_indice.cod_concurso).ToList();
               foreach (tb_candidato candidato_indice in candidato_lista)
               {
                   sw.WriteLine("B|" + candidato_indice.cod_candidato + "|" + candidato_indice.num_inscricao
                               + "|" + candidato_indice.data_inscricao + "|" + candidato_indice.nome
                               + "|" + candidato_indice.endereco + "|" + candidato_indice.numero
                               + "|" + candidato_indice.bairro + "|" + candidato_indice.cod_cidade
                               + "|" + candidato_indice.cep + "|" + candidato_indice.complemento
                               + "|" + candidato_indice.uf + "|" + candidato_indice.data_nascimento
                               + "|" + candidato_indice.telefone + "|" + candidato_indice.celular
                               + "|" + candidato_indice.rg + "|" + candidato_indice.orgao_rg
                               + "|" + candidato_indice.uf_rg + "|" + candidato_indice.cpf
                               + "|" + candidato_indice.sexo + "|" + candidato_indice.deficiencia
                               + "|" + candidato_indice.email + "|" + candidato_indice.cod_opcao
                               + "|" + candidato_indice.nome_mae + "|" + candidato_indice.observacao
                               + "|" + candidato_indice.falta + "|" + candidato_indice.nota
                               + "|" + candidato_indice.estado_civil + "|" + candidato_indice.nome_pai
                               + "|" + candidato_indice.naturalidade + "|" + candidato_indice.atendimento_especial);
               }
           }
           sw.WriteLine("C|" + DateTime.Now);
           sw.Close();
           
       }

       public static void SendCandidatos(string _filename)
       {
            SmtpClient smtp = new SmtpClient("mail.stacksoftware.com.br");
            MailMessage mailSend = new MailMessage();
            mailSend.From = new MailAddress("pss@stacksoftware.com.br");
            mailSend.To.Add("carlosl@iesp.edu.br");
            mailSend.Subject = "Dados Processo Seletivo : "+DateTime.Now.ToShortDateString();
            mailSend.SubjectEncoding = System.Text.Encoding.UTF8;
            mailSend.Body = "Segue em anexo, dados referentes ao Processo Seletivo do dia "+DateTime.Now.ToShortDateString();
            mailSend.BodyEncoding = System.Text.Encoding.UTF8;
            mailSend.IsBodyHtml = true;
            mailSend.Attachments.Add(new Attachment(_filename));
            smtp.Send(mailSend);
       }

    }
}
