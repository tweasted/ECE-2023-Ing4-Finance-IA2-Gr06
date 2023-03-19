// Licensed to the.NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.ML.Probabilistic.Tutorials
{
    using System;
    using Microsoft.ML.Probabilistic.Distributions;
    using Microsoft.ML.Probabilistic.Models;
    using Microsoft.ML.Probabilistic.Factors.Attributes;

    public class Program
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


    public void Run(string sequence)
        {
            Variable<string> str1 = Variable.StringUniform().Named("str1");
            Variable<string> str2 = Variable.StringUniform().Named("str2");
            Variable<string> text = (str1 + " " + str2).Named("text");
            text.ObservedValue = sequence;

            var engine = new InferenceEngine();

            if (engine.Algorithm is Algorithms.ExpectationPropagation)
            {
                Console.WriteLine("str1: {0}", engine.Infer(str1));
                Console.WriteLine("str2: {0}", engine.Infer(str2));

                var distOfStr1 = engine.Infer<StringDistribution>(str1);
                string[] substrings = sequence.Split(' ');
                string[] subsequence = new string[substrings.Length];

                for (int i = 0; i < substrings.Length; i++)
                {
                    subsequence[i] = sequence.Substring(0, sequence.IndexOf(substrings[i]) + substrings[i].Length);
                }

                foreach (var word in subsequence)
                {
                    Console.WriteLine("P(str1 = '{0}') = {1}", word, distOfStr1.GetProb(word));
                }                
            }
            else
            {
                Console.WriteLine("This example only runs with Expectation Propagation");
            }
        }

               
        static void Main(string[] args)
        {
            var Program = new Program();

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
            Program.Run(sequence);


        }

    }

}   