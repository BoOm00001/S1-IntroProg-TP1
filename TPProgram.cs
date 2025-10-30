using Microsoft.VisualBasic;
using System;
using System.ComponentModel.Design;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

class Program
{
    #region BATTERY_DISPLAY_CONSTANTS
    const int BATTERY_STARTING_COLUMN = 3;
    const int BATTERY_STARTING_ROW = 1;
    const int NB_BATTERY_CHARGE_ROWS = 10;
    const int TEXT_COLOR_CHARGE_THRESHOLD = 30;

    const string BATTERY_TOP = " ___====___ ";
    const string BATTERY_FILL = "          ";
    const string BATTERY_SIDE = "|";
    const string BATTERY_BOTTOM = " ~~~~~~~~~~ ";
    #endregion
    const string Erreur1 = "Numero de serie Invalide";
    const string Erreur2 = "ID invalide";
    const string Erreur3 = "Numero Invalide";
    const string Erreur4 = "Operation Invalide";
    const string Erreur5 = "Choix Invalide";
    const string Quitte = "Aurevoire";
    const int LongueurNumSerie = 8;
    const int ChargeMax = 100;
    const int ChargeMin = 0;

    const int chargeDepart = 50;
    public static void Main(string[] args)
    {
        Console.Clear();
        string pageAcueille = AffichePageAcueille(" ");
        Console.WriteLine(pageAcueille);
        string extractionNumSerie = ExtractionNumSerie("");
        bool verificationNumSerie = VerificationEntrerUtilisateur(extractionNumSerie);
        ConsoleKeyInfo recommencerOuQuitter;
        bool authentification = AuthentificationID(extractionNumSerie);

        if (verificationNumSerie == true)
        {
            int chargeCourrante = 0;
            while ((authentification == true) && (verificationNumSerie == true))
            {
                Console.Clear();
                PrintBattery(chargeDepart);
                Console.SetCursorPosition(0, 13);
                Console.WriteLine($"Niveau batterie {chargeDepart}%");
                Console.SetCursorPosition(0, 14);
                chargeCourrante = UtilisationOuChargement(50);
                break;
            }
            while (authentification == false)
            {
                Console.Clear();
                Console.WriteLine(Quitte);
            }
            int nouvelleChargeCourante = chargeCourrante;
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("Enter: Recommencer Ou n'importe quelle touche pour: Fermer. ");
            Console.SetCursorPosition(61, 14);

            
            
            recommencerOuQuitter = Console.ReadKey();
            while (recommencerOuQuitter.Key == ConsoleKey.Enter) // J'ai realiser plus tard que je ne peux pas mettre
            {

                int nouvelleCharge = UpdateCharge(nouvelleChargeCourante, 0);
                Console.SetCursorPosition(38, 15);
                PrintBattery(nouvelleCharge);
                Console.SetCursorPosition(61, 13);
                Console.Write(new string(' ', Console.WindowWidth));
                int nouvelleChargeCourante2 = UtilisationOuChargement(nouvelleCharge);
                nouvelleChargeCourante = nouvelleChargeCourante2;
                Console.SetCursorPosition(0, 17);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, 14);
                Console.WriteLine("Entrer: Recommencer Ou n'importe quelle touche pour: Fermer. ");
                Console.SetCursorPosition(34, 14);

                recommencerOuQuitter = Console.ReadKey();
                Console.SetCursorPosition(0, 17);
                Console.Write(new string(' ', Console.WindowWidth));
            }
        }
        Console.WriteLine($"/n{Quitte}");
    }

    private static string ExtractionNumSerie(string numSerie)
    {

        int jsp = 0;
        Console.Write("\nNumero de série: ");
        numSerie = Console.ReadLine();
        while (numSerie.Length == LongueurNumSerie)
        {
            return numSerie;
        }

        while (numSerie.Length != LongueurNumSerie)
        {
            WriteError(Erreur3, 30, 8);
            Console.WriteLine("\nEntrer: Réessayer ou Espace: Quitter");
            ConsoleKeyInfo choixUtilisateur = Console.ReadKey();
            while (choixUtilisateur.Key != ConsoleKey.Enter)
            {
                return numSerie;  
            }

            if (choixUtilisateur.Key == ConsoleKey.Enter)
            {
                Console.SetCursorPosition(36, 7);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(36, 6);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, 6);
            }
            Console.Write("\nNumero de série: ");
            numSerie = Console.ReadLine();
        }
        return numSerie;
    }

    public static void ReinstallationNivBatterie()
    {
        Console.SetCursorPosition(36, 13);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, 13);
    }

    public static int UpdateCharge(int currentCharge, int nouvelleCharge)
    {
        nouvelleCharge = currentCharge;
        return nouvelleCharge;
    }

    private static int UtilisationOuChargement(int nouvelleCharge)
    {
        int chargeUtilisateur = 0;
        int nouvelleCharge2 = 0;
        Console.SetCursorPosition(0, 14);

        Console.Write("C: Charger U: Utiliser Q: Quitter   ");
        Console.SetCursorPosition(34, 14);

        ConsoleKeyInfo ChoixUtilisateur = Console.ReadKey();
        Console.SetCursorPosition(38, 13);
        Console.Write(new string(' ', Console.WindowWidth));

        if (ChoixUtilisateur.Key == ConsoleKey.C)
        {
            Console.SetCursorPosition(0, 14);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 14);
            Console.Write("Combien de charge? : ");
            string chargementUtilisateur = Console.ReadLine();
            bool conversionEntrerUtilisatuer = int.TryParse(chargementUtilisateur, out chargeUtilisateur);
            if (nouvelleCharge < ChargeMax)
            {
                if (chargeUtilisateur <= 14.99)
                {
                    nouvelleCharge = nouvelleCharge + chargeUtilisateur;
                    PrintBattery(nouvelleCharge2);
                    nouvelleCharge = nouvelleCharge2;
                    ReinstallationNivBatterie();
                    Console.WriteLine($"Niveau batterie {nouvelleCharge2}%");
                }

                if ((chargeUtilisateur <= 24.99) && (chargeUtilisateur >= 14.99))
                {
                    nouvelleCharge2 = nouvelleCharge + chargeUtilisateur;
                    PrintBattery(nouvelleCharge2);
                    nouvelleCharge = nouvelleCharge2;
                    ReinstallationNivBatterie();
                    Console.WriteLine($"Niveau batterie {nouvelleCharge2}%");
                }

                if ((chargeUtilisateur <= 34.99) && (chargeUtilisateur >= 24.99))
                {
                    nouvelleCharge2 = nouvelleCharge + chargeUtilisateur;
                    PrintBattery(nouvelleCharge2);
                    nouvelleCharge = nouvelleCharge2;
                    ReinstallationNivBatterie();
                    Console.WriteLine($"Niveau batterie {nouvelleCharge2}%");
                }
                if ((chargeUtilisateur <= 100) && (chargeUtilisateur >= 34.99))
                {
                    nouvelleCharge2 = nouvelleCharge + chargeUtilisateur;
                    PrintBattery(nouvelleCharge2);
                    nouvelleCharge = nouvelleCharge2;
                    ReinstallationNivBatterie();
                    Console.WriteLine($"Niveau batterie {nouvelleCharge2}%");

                }
                if (nouvelleCharge2 >= ChargeMax)
                {
                    ReinstallationNivBatterie();
                    Console.WriteLine($"Niveau batterie {ChargeMax}%");

                }
            }
        }



        if (ChoixUtilisateur.Key == ConsoleKey.U)

        {
            Console.SetCursorPosition(0, 14);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 14);
            Console.Write("Combien de charge? : ");
            string chargementUtilisateur = Console.ReadLine();
            bool conversionEntrerUtilisatuer = int.TryParse(chargementUtilisateur, out chargeUtilisateur);
            if (nouvelleCharge >= ChargeMin)
            {
                if (chargeUtilisateur <= 14.99)
                {
                    nouvelleCharge2 = nouvelleCharge - chargeUtilisateur;
                    PrintBattery(nouvelleCharge2);
                    nouvelleCharge = nouvelleCharge2;
                    ReinstallationNivBatterie();
                    Console.WriteLine($"Niveau batterie {nouvelleCharge2}%");
                }

                if ((chargeUtilisateur <= 24.99) && (chargeUtilisateur >= 14.99))
                {
                    nouvelleCharge2 = nouvelleCharge - chargeUtilisateur;
                    PrintBattery(nouvelleCharge2);
                    nouvelleCharge = nouvelleCharge2;
                    ReinstallationNivBatterie();
                    Console.WriteLine($"Niveau batterie {nouvelleCharge2}%");
                }

                if ((chargeUtilisateur <= 34.99) && (chargeUtilisateur >= 24.99))
                {
                    nouvelleCharge2 = nouvelleCharge - chargeUtilisateur;
                    PrintBattery(nouvelleCharge2);
                    nouvelleCharge = nouvelleCharge2;
                    ReinstallationNivBatterie();
                    Console.WriteLine($"Niveau batterie {nouvelleCharge2}%");
                }
                if ((chargeUtilisateur <= 200) && (chargeUtilisateur >= 34.99))
                {
                    nouvelleCharge2 = nouvelleCharge - chargeUtilisateur;
                    PrintBattery(nouvelleCharge2);
                    nouvelleCharge = nouvelleCharge2;
                    ReinstallationNivBatterie();
                    Console.WriteLine($"Niveau batterie {nouvelleCharge2}%");
                }

                if (nouvelleCharge2 <= ChargeMin)
                {
                    nouvelleCharge2 = ChargeMin;
                    ReinstallationNivBatterie();
                    Console.WriteLine($"Niveau batterie {nouvelleCharge2}%");

                }
            }
        }



        if (nouvelleCharge == ChargeMax)
        {
            nouvelleCharge2 = nouvelleCharge + chargeUtilisateur ;
        }

        if (nouvelleCharge == ChargeMin)
        {
            nouvelleCharge2 = nouvelleCharge - chargeUtilisateur;
        }


        if((nouvelleCharge2 > ChargeMax) &&  (nouvelleCharge < ChargeMin))
        {
            WriteError(Erreur4, 36, 14);
        }
        return nouvelleCharge2;

    }

    private static bool VerificationEntrerUtilisateur(string numSerie)
    {
        int jsp = 0;
        bool conversion = (int.TryParse(numSerie, out jsp));
        while (conversion && numSerie.Length == LongueurNumSerie)
        {
            return true;
        }

        WriteError(Erreur3, 30, 7);

        Console.WriteLine("\nEntrer: Réessayer ou Espace: Quitter");
        ConsoleKeyInfo choixUtilisateur = Console.ReadKey();

        while (choixUtilisateur.Key == ConsoleKey.Enter)
        {
            Console.SetCursorPosition(36, 7);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(36, 6);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 6);
            Console.Write("\nNumero de série: ");
            numSerie = Console.ReadLine();
            conversion = (int.TryParse(numSerie, out jsp));

            while (conversion && numSerie.Length == LongueurNumSerie)
            {
                return true;
            }

            if ((conversion == false) || (numSerie.Length > LongueurNumSerie) || (numSerie.Length < LongueurNumSerie))
            {

                WriteError(Erreur3, 30, 7);

                Console.WriteLine("\nEntrer: Réessayer ou Espace: Quitter");
                choixUtilisateur = Console.ReadKey();
            }
        }
        while (choixUtilisateur.Key != ConsoleKey.Enter)
        {
            return false;
        }

        return true;

        string ExtractionNumSerie(string numSerie, string numSerie1)
        {
            numSerie1 = numSerie;
            return numSerie;
        }
    }


    public static bool AuthentificationID(string numSerie1)
    {
        int jsp = 0;
        Console.Write("Numero ID : ");
        string ID = numSerie1.Substring(4, 4);

        string numID = Console.ReadLine();

        while (numID == ID)
        {
            return true;

        }
        if (numID != ID)
        {
            WriteError(Erreur2, 50, 8);
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("\nEntrer: Réessayer ou Espace: Quitter");
            ConsoleKeyInfo choixUtilisateur = Console.ReadKey();

            while (choixUtilisateur.Key == ConsoleKey.Enter)
            {

                Console.SetCursorPosition(61, 7);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, 8);

                Console.Write("Numero ID : ");
                numID = Console.ReadLine();

                while (numID == ID)
                {
                    return true;
                }

                if (numID != ID)
                {
                    WriteError(Erreur2, 50, 8);
                    Console.SetCursorPosition(50, 7);
                    Console.WriteLine("\nEntrer: Réessayer ou Espace: Quitter");
                    choixUtilisateur = Console.ReadKey();
                }

            }
            while (choixUtilisateur.Key != ConsoleKey.Enter)
            {
                return false;
            }
        }

        return true;
    }
    private static string AffichePageAcueille(string design)
    {
        string ligne1 = "__________ ________ __________  _______  ___________   __________ " +
            "   ________________________________________________.______________\r\n\\______   " +
            "\\\\_____  \\\\______   \\ \\      \\ \\_   _____/   \\______   \\  /  _  \\__   " +
            " ___/\\__    ___/\\_   _____/\\______   \\   \\_   _____/\r\n |    |  _/ /   |   \\|  " +
            "     _/ /   |   \\ |    __)_     |    |  _/ /  /_\\  \\|    |     |    |    |    __)_" +
            "  |       _/   ||    __)_ \r\n |    |   \\/    |    \\    |   \\/    |    \\|        \\ " +
            "   |    |   \\/    |    \\    |     |    |    |        \\ |    |   \\   ||        \\\r\n |______ " +
            " /\\_______  /____|_  /\\____|__  /_______  /    |______  /\\____|__  /____|     |____|   /_______ " +
            " / |____|_  /___/_______  /\r\n        \\/         \\/       \\/         \\/        \\/   " +
            "         \\/         \\/                            \\/         \\/            \\/ ";
        return ligne1;
    }

    // TODO : créer les fonctions nécessaires ici


    #region UTILITY_FUNCTIONS  
    /// <summary>
    /// Permet d'écrire du texte à la console à un endroit précis
    /// </summary>
    /// <param name="text">Le texte à écrire</param>
    /// <param name="x">La colonne à laquelle écrire le texte</param>
    /// <param name="y">La ligne à laquelle écrire le texte.  La première ligne est en haut et le numéro de ligne augmente en descendant</param>
    static void WriteText(string text, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(text);
    }
    /// <summary>
    /// Permet de signaler une erreur à la console à un endroit précis
    /// </summary>
    /// <param name="text">Le texte à écrire</param>
    /// <param name="x">La colonne à laquelle écrire le texte</param>
    /// <param name="y">La ligne à laquelle écrire le texte.  La première ligne est en haut et le numéro de ligne augmente en descendant</param>
    static void WriteError(string text, int x, int y)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        WriteText(text, x, y);
        Console.ForegroundColor = ConsoleColor.White;
    }

    /// <summary>
    /// Permet d'afficher la batterie dans la console à un endroit prédéterminé (vous pourriez le changer).
    /// </summary>
    /// <param name="chargePercentage">Le pourcentage de charge courant de la batterie. Vous devriez le garder à quelque part dans votre application et le passer en paramètre ici</param>
    static void PrintBattery(int chargePercentage)
    {
        const int BATTERY_CONTENT_START = BATTERY_STARTING_ROW + 1;
        int nbFilledLines = Math.Min(NB_BATTERY_CHARGE_ROWS, chargePercentage / NB_BATTERY_CHARGE_ROWS);
        int nbEmptyLines = Math.Max(0, NB_BATTERY_CHARGE_ROWS - nbFilledLines);

        WriteText(BATTERY_TOP, BATTERY_STARTING_COLUMN, BATTERY_STARTING_ROW);
        for (int i = 0; i < nbEmptyLines; i++)
        {
            WriteBatteryEmptyLine(BATTERY_STARTING_COLUMN, BATTERY_CONTENT_START + i);
        }
        for (int i = nbEmptyLines; i < NB_BATTERY_CHARGE_ROWS + 1; i++)
        {
            WriteBatteryChargedLine(chargePercentage, BATTERY_STARTING_COLUMN, BATTERY_CONTENT_START + i);
        }
        WriteText(BATTERY_BOTTOM, BATTERY_STARTING_COLUMN, BATTERY_CONTENT_START + NB_BATTERY_CHARGE_ROWS);
    }

    // PROF : fonctions utilitaires pour rendre la fonction d'affichage de la batterie plus concis.
    static void WriteBatteryChargedLine(int chargePercentage, int x, int y)
    {
        ConsoleColor color = ConsoleColor.White;
        if (chargePercentage >= TEXT_COLOR_CHARGE_THRESHOLD)
            color = ConsoleColor.Green;
        else
            color = ConsoleColor.Red;

        WriteText(BATTERY_SIDE, x, y);
        Console.BackgroundColor = color;
        WriteText(BATTERY_FILL, x + 1, y);
        Console.BackgroundColor = ConsoleColor.Black;
        WriteText(BATTERY_SIDE, x + BATTERY_FILL.Length + 1, y);
    }

    static void WriteBatteryEmptyLine(int x, int y)
    {
        string line = string.Format("{0}{1}{0}", BATTERY_SIDE, BATTERY_FILL);
        WriteText(line, x, y);
    }

    // TODO : vous pouvez ajouter d'autres fonctions utilitaires

    #endregion

}