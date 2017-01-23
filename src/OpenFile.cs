using System;
using System.IO;

namespace DescargaImagenes
{
    class OpenFile
    {
        public static string DatoUser { get; set; }
        public static string DatoPass { get; set; }
        public static int DatoRevisaCada { get; set; }
        public static string DatoExtencionDescarga { get; set; }
        public static string DatoRutaDescarga { get; set; }
        public static int Clave { get; set; }
        public static int CantidadRevisaEmails { get; set; }

        public void AbrirArchivo(out string usuario, out string password, out int RevisaCada, out string ExtencionDescarga, out string RutaDescarga, out int LimiteEmails)
        {
            string linea;
            string[] correo,pass,revisaCada,extencionDescarga,rutaDescarga,cantidadEmails;
            
            //Obtiene el dir donde esta el exe
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            string RutaArchivo = dir + "/DescargaImagenes.txt";
            RutaArchivo = RutaArchivo.Replace("\\", "/");
            //La variable 'RutaArchivo' se modifica antes ya que la clase StreamReader no acepta cadenas '\\'
            StreamReader leerArchivo = new StreamReader(RutaArchivo);
            while((linea = leerArchivo.ReadLine()) != null)
            {
                Clave++;
                switch (Clave)
                {
                    case 1:
                        correo = linea.Split("=".ToCharArray());
                        DatoUser = correo[1];
                        break;

                    case 2:
                        pass = linea.Split("=".ToCharArray());
                        DatoPass = pass[1];
                        break;

                    case 3:
                        revisaCada = linea.Split("=".ToCharArray());
                        DatoRevisaCada = Int32.Parse(revisaCada[1]);
                        break;

                    case 4:
                        extencionDescarga = linea.Split("=".ToCharArray());
                        DatoExtencionDescarga = extencionDescarga[1];
                        break;

                    case 5:
                        rutaDescarga = linea.Split("=".ToCharArray());
                        DatoRutaDescarga = rutaDescarga[1];
                        break;

                    case 6:
                        cantidadEmails = linea.Split("=".ToCharArray());
                        CantidadRevisaEmails = Int32.Parse(cantidadEmails[1]);
                        break;
                }
            }
            usuario = DatoUser;
            password = DatoPass;
            RevisaCada = DatoRevisaCada;
            ExtencionDescarga = DatoExtencionDescarga;
            RutaDescarga = DatoRutaDescarga;
            LimiteEmails = CantidadRevisaEmails;
        }

    }
}
