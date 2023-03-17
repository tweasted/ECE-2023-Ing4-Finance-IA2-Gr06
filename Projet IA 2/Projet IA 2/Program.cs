using System;
class Program
{
  
    static void geneSequence(string sequence, string motif)
    {
        int count = 0;
        int index = sequence.IndexOf(motif);

        // Calcule le nombre d'occurrences du motif dans la séquence de gènes et affiche le résultat à la console
        while (index >= 0)
        {
            count++;
            index = sequence.IndexOf(motif, index + 1);
        }

        Console.WriteLine("Le motif \"{0}\" apparaît {1} fois dans la séquence \"{2}\"", motif, count, sequence);
    }


    static void Main()
    {
        // demande à l'utilisateur d'entrer une séquence de gène
        Console.Write("Entrez une séquence de gènes: ");
        string sequence = Console.ReadLine();

        // Vérifie si la chaîne entrée est nulle ou vide
        while (string.IsNullOrEmpty(sequence))
        {
            Console.WriteLine("Veuillez entrer une chaîne de caractères valide.");
            sequence = Console.ReadLine();
            
        }

        //demande à l'utilisateur d'entrer un motif à rechercher dans cette séquence
        Console.Write("Entrez un motif à rechercher: ");
        string motif = Console.ReadLine();


        // Vérifie si la chaîne entrée est nulle ou vide
        while (string.IsNullOrEmpty(motif))
        {
            Console.WriteLine("Veuillez entrer une chaîne de caractères valide.");
            motif = Console.ReadLine();
            
        }


        geneSequence(sequence, motif);
    }
}
