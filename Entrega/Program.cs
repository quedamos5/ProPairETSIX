namespace Entrega
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ficheros.MakeFile(Ficheros.ERRORFILE);
            if (Ficheros.FileExist(Ficheros.ERRORFILE))
            {
            }
            else
            {
                Console.WriteLine("No se pudo crear errores.log");
            }
            if (!Ficheros.FileExist(Ficheros.FILENAME))
            {
                Ficheros.ReadFile();
                if (Ficheros.ValidateData())
                {
                    Ficheros.MakeFile(Ficheros.MFILENAME);
                    if (Ficheros.FileExist(Ficheros.MFILENAME))
                        Ficheros.WriteFile();
                    else
                    {
                        Ficheros.Errors("No se pudo crear media_poblacion.csv");
                    }
                }
            }
            else
                Ficheros.Errors("No se pudo encontrar edades-medias-de-la-poblacion.csv");
        }
    }
}