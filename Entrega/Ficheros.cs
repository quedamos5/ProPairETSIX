using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega
{
    internal class Ficheros
    {
        public const string FILENAME = "edades-medias-de-la-poblacion.csv",
                            MFILENAME = "media_poblacion.csv",
                            ERRORFILE = "errores.log";
        static List<string> lines = new(), data = new();
        static int indexOfMun, numOfData;

        public static bool FileExist(string fileName) => File.Exists(fileName);

        public static bool ReadFile()
        {
            try
            {
                lines = File.ReadAllLines(FILENAME).ToList();
                indexOfMun = Funciones.IndexOfMun(lines[0].Split(';'));
                numOfData = lines[0].Split(';').Length;

                return true;
            }
            catch (Exception ex)
            {
                Errors(ex.Message);
                return false;
            }
        }

        public static bool ValidateData()
        {

            string[] line;
            for (int i = 1; i < lines.Count - 1; i++)
            {
                List<double> numbs = new();
                line = lines[i].Split(';');
                for (int j = 2; j < line.Length; j++)
                {
                    if (line.Length == numOfData)
                    {
                        if (Funciones.IsNumb(line[j]))
                            if (Funciones.ValidNumb(line[j]))
                                numbs.Add(Convert.ToDouble(line[j]));
                            else
                            {
                                Errors($"Línea {i}. {line[j]} no es un número válido");
                                return false;
                            }
                        else
                        {
                            Errors($"Línea {i}. {line[j]} no es un número");
                            return false;
                        }
                    }
                    else
                    {
                        Errors($"Línea {i}. No hay datos para todos los años");
                        return false;
                    }
                }
                data.Add($"{line[0]};{line[indexOfMun].TrimStart()};{numbs.Average():f2}");
            }
            return true;
        }

        public static bool MakeFile(string fileName)
        {
            bool valor = true;
            StreamWriter sw;

            try
            {
                sw = File.CreateText(fileName);
                sw.Close();
                Console.Clear();
                Console.WriteLine("Fichero creado vacío");
                Console.WriteLine("Pulsa una tecla para continuar");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Errors(ex.Message);
                valor = false;
            }

            return valor;
        }

        public static bool WriteFile()
        {
            StreamWriter sw;
            bool value = true;

            try
            {
                sw = new StreamWriter(MFILENAME);
                sw.WriteLine("CodMunicipio;Municipio;Media");
                
                for (int i = 0; i < data.Count; i++)
                    sw.WriteLine(data[i]);
                sw.Close();
                Process.Start("notepad.exe", MFILENAME);
            }
            catch(Exception ex)
            {
                Errors(ex.Message);
                value = false;
            }

            return value;
        }

        public static bool Errors(string msg)
        {
            StreamWriter sw;

            try
            {
                sw = new StreamWriter(ERRORFILE);
                sw.WriteLine(msg);
                sw.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

    }
}
