using System;
using System.Linq;
using ImapX;

namespace DescargaImagenes
{
    class ConectaEmail
    {
        ImapClient client = new ImapClient("imap.gmail.com", true);
        
        public void Conecta(string Usuario, string Password)
        {   
            if (client.Connect())
            {
                //Acceso al login
                if (!client.Login(Usuario, Password))
                {
                    Console.WriteLine("No se pudo conectar por login");
                }
            }
            else
            {
                Console.WriteLine("No se pudo conectar al servidor");
            }
        }

        public void ProcesaEmail(string RutaDescarga, string SetExtenciones, int LimiteEmails)
        {
            var Correos = client.Folders["INBOX"].Search("ALL");
            //var Correos = client.Folders["INBOX"].Search("INBOX");
            string[] GetExtenciones;
            GetExtenciones = SetExtenciones.Split(",".ToCharArray());
            int RecorreEmails=0;
            
            foreach (var Correo in Correos)
            {
                RecorreEmails++;
                if(RecorreEmails > LimiteEmails)
                {
                    Environment.Exit(-1);
                }
                var attachments = Correo.Attachments;

                if (attachments.Count() > 0)
                {
                    foreach (var attachment in attachments)
                    {
                        string FileName = attachment.FileName;
                        FileName = FileName.Substring(FileName.LastIndexOf('.') + 1);
                        FileName = FileName.ToLower();
                        
                        foreach (var extencion in GetExtenciones)
                        {
                            if (extencion == FileName)
                            {
                                attachment.Download();
                                attachment.Save(RutaDescarga);
                            }
                        }                                       
                    }
                }
                Correo.Remove();
            }
        }
    }
}

