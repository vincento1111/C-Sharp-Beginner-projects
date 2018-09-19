using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
namespace ConsoleApp11
{
    class Program
    {






        static void Main(string[] args)
        {

            string[] personInfo1 = new string[6];
            personInfo1[0] = "31143143";
            personInfo1[1] = "Vincent Schuurhof";
            personInfo1[2] = "Adresse";
            personInfo1[3] = "2400";
            personInfo1[4] = "Byen";
            personInfo1[5] = "Vincento2009@hotmail.com";

            String personProfil1 = String.Join(";", personInfo1);  // samler array ind i en string
            File.AppendAllText("c:\\d46\\person_db.csv", "\n" + personProfil1);
            //Opretter started på databasen


            while (true) //bliver ved med at indlæse menuen indtil brugeren trykker Q (afslut)
            {
                Console.WriteLine("[O] Opret   [F] Find   [V] Vis alle   [Q] Afslut"); // Menu/Brugeroverflade

                string[] personInfo = new string[6];

                string command = Console.ReadLine();

                if (command == "o" || command == "O") // brugeren har valgt opret
                {
                    // Brugeren indtaster deres oplysninger
                    Console.Write("Indtast Dit Telefonnummmer: ");
                    string telefon = Console.ReadLine();
                    personInfo[0] = telefon;
                    Console.WriteLine(personInfo[0]);

                    if (FindesNr(telefon)) // lukker menuen ned hvis brugeren indtaster et nummer der allerede er inde i databasen
                    {
                        Console.WriteLine("Nummeret findes allerede...");
                        break;
                    } 

                    Console.Write("Indtast Dit Navn: "); // Brugeren bliver bedt om at indtaste deres oplysninger i vilkårlig rækkefølge
                    string navn = Console.ReadLine();
                    personInfo[1] = navn;
                    Console.WriteLine(personInfo[1]);

                    Console.Write("Indtast Din Adresse: ");
                    string adresse = Console.ReadLine();
                    personInfo[2] = adresse;
                    Console.WriteLine(personInfo[2]);

                    Console.Write("Indtast Dit Post nr: ");
                    string postNr = Console.ReadLine();
                    personInfo[3] = postNr;
                    Console.WriteLine(personInfo[3]);

                    Console.Write("Indtast By: ");
                    string by = Console.ReadLine();
                    personInfo[4] = by;
                    Console.WriteLine(personInfo[4]);

                    Console.Write("Indtast Email: ");
                    string email = Console.ReadLine();
                    personInfo[5] = email;
                    Console.WriteLine(personInfo[5]);



                    String personProfil = String.Join(";", personInfo);  // samler array ind i en string



                    File.AppendAllText("c:\\d46\\person_db.csv", "\n" + personProfil);
                    // brugerens input/ gemmes i en excel fil
                }

                else if (command == "f" || command == "F") // små rettelse der inkluderer et stort F
                {
                    // Finder Nummer
                    String[] linjer = File.ReadAllLines("c:\\d46\\person_db.csv");
                    // Console.Write(linjer); unødvendig kode

                    Console.Write("Skriv et telefon nr vi skal finde: ");

                    string findTlf = Console.ReadLine(); // brugeren indtaster nummeret som programmet skal finde



                    foreach (string linje in linjer) // programmet går i gennem alle arrays 1 ad gangen
                    {
                        string[] felter = linje.Split(';'); // skal være semicolon i stedet for komma.

                        if (felter[0] == findTlf) // checker om brugerens input er lig med nummeret forest i et array
                        {
                            foreach (string f in felter)
                            {
                                Console.WriteLine(f);
                            }
                        }
                    }



                }



                else if (command == "v" || command == "V")
                {
                    //viser alle data
                    String[] linjer = File.ReadAllLines("c:\\d46\\person_db.csv");
                    Console.Write(linjer);


                    foreach (string linien in linjer)
                    {
                        Console.WriteLine(linien); // printer alle 
                    }
                }
                // Afslutter programmet
                else if (command == "Q" || command == "q")
                {
                    Console.WriteLine("Farvel");
                    break;
                }
                // Hvis brugeren indtaster et ugyldigt input viser programmet en fejlmeddelse
                else
                {
                    Console.WriteLine("Hov det forstod jeg ikke, prøv igen");



                }

            }




        }

        static bool FindesNr(string nr)
        {
            //File.ReadAllLines("c:\\d46\\person_db.csv");
            String[] linier = File.ReadAllLines("c:\\d46\\person_db.csv");
            foreach (string linje in linier)
            {
                string[] felter = linje.Split(';');
                if (felter[0] == nr)
                {
                    return true;
                }

            }
            return false;
        }
    }
}