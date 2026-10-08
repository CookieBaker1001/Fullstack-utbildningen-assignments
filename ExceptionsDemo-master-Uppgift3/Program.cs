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

                // Exempel 1: try-catch-finally
                try
                {
                    Console.WriteLine("Försöker läsa fil och räkna...");
                    var path = Path.Combine(AppContext.BaseDirectory, fileName);
                    var result = ProcessFile(path);

                    Console.WriteLine($"\nResultat: {result}");
                }
                catch (FileNotFoundException ex)
                {
                    // Specifikt fel om filen inte finns
                    Console.WriteLine($"Fil {fileName} hittades inte: {ex.Message}");
                }
                catch (FormatException ex)
                {
                    // Specifikt fel om texten inte kan tolkas som tal
                    Console.WriteLine($"Formatfel: {ex.Message}");
                }
                catch (DivideByZeroException ex)
                {
                    // Specifikt fel om nolldivision
                    Console.WriteLine($"Kan inte dividera med noll: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    // Specifikt fel om en ogiltig operation försöks utföra
                    Console.WriteLine($"Ogiltig operation: {ex.Message}");
                }
                catch (OutOfMemoryException ex)
                {
                    // Specifikt fel om minnet är fullt
                    Console.WriteLine($"Minne fullt: {ex.Message}");
                }
                catch (IOException ex) 
                {
                    // Specifikt fel om det är problem med filen (t.ex. låst, saknas, etc.)
                    Console.WriteLine($"IO-fel: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Fallback för alla övriga obekanta fel
                    Console.WriteLine($"Okänt fel: {ex.Message}");
                }
                finally
                {
                    // Körs ALLTID, även om det blev undantag
                    Console.WriteLine("Cleanup: Logging avslutat anrop.");
                }

                Console.WriteLine("Programmet avslutas normalt.");
            }

            // Exempel på metod som själv kastar ett undantag (throw)
            static double ProcessFile(string fileName)
            {
                // Om filnamnet är tomt: logiskt fel vi vill signalera
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    throw new ArgumentException("Filnamn får inte vara tomt eller null.", nameof(fileName));
                }

                StreamReader? reader = null;
                try
                {
                    reader = new StreamReader(fileName);

                    string? line = reader.ReadLine();
                    if (line == null)
                        throw new InvalidOperationException("Filen är tom.");

                    // Försöker omvandla text till tal
                    int number = int.Parse(line); // Kan ge FormatException

                    // Division: kan ge DivideByZeroException
                    return 100.0 / number;
                }
                catch (FormatException)
                {
                    // Vi kan logga eller omformulera felet
                    Console.WriteLine($"Formatfel i ProcessFile");
                    // Vi kan välja att låta metoden "kasta upp" felet
                    throw; // När du i `catch` bara vill logga/analysera,
                           // men låta anroparen (t.ex. en högre nivå i applikationen)
                           // bestämma hur man ska återhämta sig. 
                }
                catch (Exception)
                {
                    Console.WriteLine($"Okänt fel i ProcessFile");
                    throw;
                    // Om vi vill ge en mer meningsfull feltyp till anroparen
                    //throw new Exception(
                    //"Det gick inte att processa filen.",
                    //ex); // InnerException = ursprunglig fel
                }
                finally
                {
                    // Garanterad stängning av resurs
                    reader?.Close();
                    Console.WriteLine("finally i ProcessFile: StreamReader stängd.");
                }
            }
        }
    }
}

