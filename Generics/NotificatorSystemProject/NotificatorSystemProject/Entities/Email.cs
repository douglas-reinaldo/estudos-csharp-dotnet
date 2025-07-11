using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificatorSystemProject.Entities
{
    class Email : INotificavel
    {
        public string Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Corpo { get; set; }

        public Email(string destinatario, string assunto, string corpo)
        {
            Destinatario = destinatario;
            Assunto = assunto;
            Corpo = corpo;
        }

        public string Enviar()
        {
            return $"Destinatário da mensagem: {Destinatario}\nAssunto do Email: {Assunto}\nCorpo do Email: {Corpo}";
        }
    }
}
