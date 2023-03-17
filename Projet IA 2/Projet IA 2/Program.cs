using System;
class Program
{

    static void geneSequence(string sequence, string motif)
    {
        int count = 0;
        int index = sequence.IndexOf(motif);

        while (index >= 0)
        {
            count++;
            index = sequence.IndexOf(motif, index + 1);
        }

        Console.WriteLine("Le motif \"{0}\" apparaît {1} fois dans la séquence \"{2}\"", motif, count, sequence);
    }

    static void Main()
    {
        Console.Write("Entrez une séquence de gènes: ");
        string sequence = Console.ReadLine();

        Console.Write("Entrez un motif à rechercher: ");
        string motif = Console.ReadLine();

        geneSequence(sequence, motif);
    }
}