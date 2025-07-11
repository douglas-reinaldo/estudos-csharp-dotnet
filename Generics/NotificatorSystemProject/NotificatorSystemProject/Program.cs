using NotificatorSystemProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificatorSystemProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var notificationSMS = new Notificator<Sms>();
            var notificationEmail = new Notificator<Email>();

            var smsMensagem = new Sms("11999999999", "Primeira mensagem SMS");
            var emailMensagem = new Email("usuarioDestinatario@email.com", "Primeira mensagem de Email", "Corpo da mensagem do Email");

            notificationEmail.Notificar(emailMensagem);
        }
    }
}
