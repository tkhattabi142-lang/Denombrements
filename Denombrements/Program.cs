using System;

namespace Denombrements
{
    class Program
    {
        static void Main(string[] args)
        {
            int choix = 1;
            while (choix != 0)
            {
                Console.WriteLine("Permutation ...................... 1");
                Console.WriteLine("Arrangement ...................... 2");
                Console.WriteLine("Combinaison ...................... 3");
                Console.WriteLine("Quitter .......................... 0");
                choix = LireEntier("Choix : ");

                try
                {
                    if (choix == 1)
                    {
                        // Permutation : nombre de façons d'ordonner 'nombre' éléments (n!)
                        int nombre = LireEntier("nombre total d'éléments à gérer = ");
                        long resultat = Multiplier(1, nombre);
                        Console.WriteLine(nombre + "! = " + resultat);
                    }
                    else if (choix == 2)
                    {
                        // Arrangement : listes ordonnées de 'taille' éléments pris parmi 'total'
                        int total = LireEntier("nombre total d'éléments à gérer = ");
                        int taille = LireEntier("nombre d'éléments dans le sous ensemble = ");

                        if (taille > total)
                        {
                            Console.WriteLine("Le sous-ensemble ne peut pas dépasser le total.");
                        }
                        else
                        {
                            long resultat = Multiplier(total - taille + 1, total);
                            Console.WriteLine("A(" + total + "/" + taille + ") = " + resultat);
                        }
                    }
                    else if (choix == 3)
                    {
                        // Combinaison : sous-ensembles non ordonnés de 'taille' éléments parmi 'total'
                        int total = LireEntier("nombre total d'éléments à gérer = ");
                        int taille = LireEntier("nombre d'éléments dans le sous ensemble = ");

                        if (taille > total)
                        {
                            Console.WriteLine("Le sous-ensemble ne peut pas dépasser le total.");
                        }
                        else
                        {
                            long numerateur = Multiplier(total - taille + 1, total);
                            long denominateur = Multiplier(1, taille);
                            Console.WriteLine("C(" + total + "/" + taille + ") = " + (numerateur / denominateur));
                        }
                    }
                    else if (choix != 0)
                    {
                        Console.WriteLine("Choix invalide.");
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Résultat trop grand pour être calculé.");
                }

                if (choix != 0)
                {
                    // Pause pour lire le résultat avant de réafficher le menu
                    Console.WriteLine("Appuyez sur Entrée pour continuer...");
                    Console.ReadLine();
                }
            }
        }

        // Demande un entier positif ou nul et recommence tant que la saisie est invalide
        static int LireEntier(string message)
        {
            int valeur;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out valeur) || valeur < 0)
            {
                Console.Write("Saisie invalide. " + message);
            }
            return valeur;
        }

        // Multiplie les entiers de 'debut' à 'fin' inclus (ex. 4 à 6 : 4*5*6 = 120)
        static long Multiplier(int debut, int fin)
        {
            long resultat = 1;
            for (int i = debut; i <= fin; i++)
            {
                resultat = checked(resultat * i); // lève OverflowException si dépassement
            }
            return resultat;
        }
    }
}