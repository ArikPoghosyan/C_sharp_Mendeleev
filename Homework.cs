using System;

class Program
{
    static void Main(string[] args)
    {
        List<string> words = new List<string> {"Arik","Samo","Kirakos","Eghishe","Boris"};

        List<string> longestChain = FindLongestWordChain(words);

        if (longestChain.Count > 0)
        {
            Console.WriteLine("The Longest Chain: ");
            foreach (string word in longestChain)
            {
                Console.WriteLine(word);
            }
        }
        else
        {
            Console.WriteLine("Error, Have not found the longest chain");
        }
    }

    static List<string> FindLongestWordChain(List<string> words)
    {
        List<string> longestChain = new List<string>();

        foreach (string word in words)
        {
            List<string> currentChain = new List<string>();
            currentChain.Add(word);

            char lastChar = word[word.Length - 1];
            List<string> remainingWords = new List<string>(words);
            remainingWords.Remove(word);

            FindChain(lastChar, remainingWords, currentChain,ref longestChain);
        }

        return longestChain;
    }

    static void FindChain(char lastChar, List<string> remainingWords, List<string> currentChain, ref List<string> longestChain)
    {
        foreach (string nextWord in remainingWords.ToList())
        {
            if (nextWord[0] == lastChar)
            {
                currentChain.Add(nextWord);
                char newLastChar = nextWord[nextWord.Length - 1];
                remainingWords.Remove(nextWord);

                FindChain(newLastChar, remainingWords, currentChain, ref longestChain);

                if (currentChain.Count > longestChain.Count)
                {
                    longestChain = new List<string>(currentChain);
                }

                currentChain.Remove(nextWord);
                remainingWords.Add(nextWord);
            }
        }
    }
}
