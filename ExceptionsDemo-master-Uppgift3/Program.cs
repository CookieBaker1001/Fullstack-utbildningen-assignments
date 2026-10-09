using System.Collections.Concurrent;
using System.ComponentModel;

namespace ExceptionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                string fileName = "numbers.txt";
                Console.WriteLine("=== Start av programmet ===");

                try
                {
                    Console.WriteLine("Försöker läsa fil och räkna...");
                    var path = Path.Combine(AppContext.BaseDirectory, fileName);
                    var result = ProcessFile(path);

                    Console.WriteLine($"\nResultat: {result}");
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine($"Fil {fileName} hittades inte: {ex.Message}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Formatfel: {ex.Message}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Kan inte dividera med noll: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Ogiltig operation: {ex.Message}");
                }
                catch (OutOfMemoryException ex)
                {
                    Console.WriteLine($"Minne fullt: {ex.Message}");
                }
                catch (IOException ex) 
                {
                    Console.WriteLine($"IO-fel: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Okänt fel: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Cleanup: Logging avslutat anrop.");
                }

                Console.WriteLine("Programmet avslutas normalt.");
            }

            static double ProcessFile(string fileName)
            {
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    throw new ArgumentException("Filnamn får inte vara tomt eller null.", nameof(fileName));
                }

                StreamReader? reader = null;
                try
                {
                    reader = new StreamReader(fileName);

                    string? line = reader.ReadLine();
                    if (line == null) throw new InvalidOperationException("Filen är tom.");

                    int number = int.Parse(line);
                    if (number == 0) throw new DivideByZeroException("Talet i filen är noll, kan inte dividera med noll.");

                    return 100.0 / number;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Formatfel i ProcessFile");
                    throw;
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine($"DivideByZeroException i ProcessFile");
                    throw;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Okänt fel i ProcessFile");
                    throw;
                }
                finally
                {
                    reader?.Close();
                    Console.WriteLine("finally i ProcessFile: StreamReader stängd.");
                }
            }
        }
    }
}

