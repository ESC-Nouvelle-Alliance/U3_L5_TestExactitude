/* Projet U3_L6_TestExactitude
 * ICS3U, ESC Renaissance
 * Unité 3, Leçon 6
 * Programme en C#
 * Écrit par Mme Northrup
 * 
 * Ce programme demande à l’utilisateur d’entrer 
 * des notes de cours (en pourcentage), ensuite 
 * calcule et affiche la moyenne de ces notes.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3_L6_TestExactitude
{
    internal class Program
    {
        // Méthode pour saisir l'information de l'utilisateur:
        private static string getInfo()
        {
            string reponse = Console.ReadLine();

            if (reponse.ToLower() == "quit")
            {
                Environment.Exit(0);
            }

            return reponse;
        }

        // Méthode pour offrir à l'utilisateur le choix de continuer ou non:
        private static bool Continuer()
        {
            Console.WriteLine("Voulez-vous refaire l'exercice? O/N");

            while (true)
            {
                string reponse = getInfo();
                Console.Clear();
                switch (reponse.ToLower())
                {
                    case "o":
                        return true;
                    case "n":
                        return false;
                    default:
                        Console.WriteLine("\nVous devez répondre avec \"O\" ou \"N\".");
                        continue;
                }
            }
        }

        // ***************************** Méthode MAIN du programme *****************************************************************
        static void Main(string[] args)
        {
            Console.Title = "La moyenne de mes notes de cours";
            bool running = true;
            while (running)
            {
                Console.WriteLine("Ce programme calcule la moyenne d'un certain nombre de notes de cours, en pourcentage.");
                Console.WriteLine("-------------------------------------------------------------------------------");

                Console.Write("\nCombien de notes de cours voulez-vous entrer? ");
                string reponse = getInfo();

                int choix;
                try
                {
                    choix = Int32.Parse(reponse);
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Vous devez entrer un nombre naturel non nul entre 0 et 100.\n");
                    continue;
                }

                int[] valeurs = new int[choix];

                for (int i = 0; i < choix; i++)
                {
                    while (true)
                    {
                        if (i == 0)
                        {
                            Console.Write("\nQuelle est la 1re note?\t");
                            reponse = getInfo();
                        }
                        else
                        {
                            Console.Write("Quelle est la " + (i + 1) + "e note:\t");
                            reponse = getInfo();
                        }

                        int nombre;
                        try
                        {
                            nombre = Int32.Parse(reponse);
                        }
                        catch
                        {
                            Console.WriteLine("Vous devez entrer un nombre naturel entre 0 et 100.");
                            continue;
                        }

                        if (nombre < 0 || nombre > 100)
                        {
                            Console.WriteLine("Vous devez entrer un nombre naturel entre 0 et 100.");
                            continue;
                        }
                        else
                        {
                            valeurs[i] = nombre;
                            break;
                        }
                    }
                }

                double moyenne = 0;
                foreach (var nombre in valeurs)
                {
                    moyenne += nombre;
                }

                moyenne = moyenne / choix;

                Console.WriteLine("\n***********************************************************************");
                Console.WriteLine("La moyenne de vos notes est {0}%.", Math.Round(moyenne, 1));
                Console.WriteLine("***********************************************************************\n");


                if (!Continuer())
                {
                    running = false;
                }

            } // End while loop

        } // End Main method
    }
}
