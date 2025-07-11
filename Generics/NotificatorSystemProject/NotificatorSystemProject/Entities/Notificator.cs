using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificatorSystemProject.Entities
{
    class Notificator<T> where T : INotificavel
    {
        public void Notificar(T mensagem) 
        {
            Console.WriteLine(mensagem.Enviar());
        }
    }
}
