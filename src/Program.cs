using System.Diagnostics;
using System.Threading;
using System;
/*
Para que una cuenta se pueda conectar con exito, la cuenta debe ser imap y entrar a la url:
https://www.google.com/settings/security/lesssecureapps para activar a que se loguen las cuentas
de las aplicaciones menos seguras como esta.
*/

namespace DescargaImagenes
{
    class Program
    {
        //Para ocultar la ventana de la consola
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private extern static int ShowWindow(System.IntPtr hWnd, int nCmdShow);

        static void Main(string[] args)
        {
            //Para ocultar la ventana de la consola
            //ShowWindow(Process.GetCurrentProcess().MainWindowHandle, 0);

            string user, pass, extencionDescarga, rutaDescarga;
            int revisaCada,limiteEmails;
            OpenFile Valores = new OpenFile();
            ConectaEmail Procesos = new ConectaEmail();

            Valores.AbrirArchivo(out user, out pass, out revisaCada, out extencionDescarga, out rutaDescarga, out limiteEmails);
            extencionDescarga = extencionDescarga.ToLower();
            Procesos.Conecta(user, pass);
            int conteo = 0;
            while (1 < 2)
            {
                Procesos.ProcesaEmail(rutaDescarga,extencionDescarga, limiteEmails);
                conteo++;
                Console.WriteLine("Proceso: " + conteo);
                Thread.Sleep(revisaCada);
            }
            
        }
    }
}
