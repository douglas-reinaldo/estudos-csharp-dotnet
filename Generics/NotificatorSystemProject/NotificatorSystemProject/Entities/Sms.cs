using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificatorSystemProject.Entities
{
    class Sms : INotificavel
    {
        public string Numero { get; set; }
        public string Texto { get; set; }

        public Sms(string numero, string texto)
        {
            Numero = numero;
            Texto = texto;
        }

        public string Enviar()
        {
            return $"Numero: {Numero}\nTexto da mensagem: {Texto}";
        }

        
    }
}
