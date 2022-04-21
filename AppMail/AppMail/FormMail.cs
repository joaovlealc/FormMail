using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace AppMail
{
    public partial class FormMail : Form
    {
        public FormMail()
        {
            InitializeComponent();
        }

        public void SendMail()
        {
            MailMessage message = new MailMessage();
            message.To.Add(txtPara.Text);
            message.CC.Add(txtCc.Text);
            Attachment anexo = new Attachment(txtAnexo.Text);
            message.Attachments.Add(anexo);
            message.Subject = txtAssunto.Text;
            message.From = new MailAddress("XXXX@hotmail.com");
            message.Body = txtMensagem.Text;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            message.Priority = MailPriority.High;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("XXXX@hoymail.com", "password");
            try
            {
                smtp.Send(message);
                MessageBox.Show("E-mail enviado com sucesso!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            SendMail();
        }

        private void btnAnexos_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtAnexo.Text = openFileDialog1.FileName;
        }
    }
}
