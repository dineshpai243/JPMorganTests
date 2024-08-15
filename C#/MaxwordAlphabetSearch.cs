
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMorganTests
{
    /*
     """
            Problem 1:

            Given a long statement and a input letter, find the word which contains the most number of the given character. 
            If more than one word has the exact same number of the given letter, it should return the word with the most number of
            total letters, if more than one words have equal number of given character and total number of characters return the 
            word that appeared first in the given statement.


            Examples:

            Statement : This is a very long sentence and I want to educate everyone in this whole crazy world….

            Case 1:

            Input character : z
            Expected result : crazy
            Explanation: z is only present in the word crazy

            Case 2:

            Input character : I
            Expected result : I
            Explanation: case sensitive letter I comes only once

            Case 3:

            Input character : e
            Result : sentence
            Explanation: Both sentence and everyone have 3 occurrences of letter e and total length of the words are 8, but sentence occurred first in the input so the expected result is sentence.

            """

            """
            ASSUMPTIONS:
            If the input is null or empty, Exception is not thrown and treated as a empty sentence therby returning a empty result in find
            operations.

            Approach:
            The sentence is first parsed into words inside a Heap with the longest words taking priority and words with equal length
            have the priority of parsing in the order of processing such that the first occurance is given the priority in case of
            multiple strings with same length returning the same character count.



            """
     * */
    public class MaxwordAlphabetSearch
    {
        IList<string> _wordsOrderedList = new List<string>();
        private PriorityQueue<string, (int, int)> CreateNavigatingOrder(string[] words)
        {
            var priorityQueue = new PriorityQueue<string, (int, int)>();
            //Build Max Heap Behaviour 
            for (int i = words.Length - 1; i >= 0; i--)

            {
                priorityQueue.Enqueue(words[i], (-words[i].Length, i));
            }

            return priorityQueue;
        }

        public void AddOrUpdateSentence(string sentence)
        {
            if (sentence == null || sentence.Trim().Length == 0)
            {
                Console.WriteLine("Sentence is empty");
                return;
            }

            var words = sentence.Trim().Split(' ', StringSplitOptions.TrimEntries);

            var maxHeapWordStore = CreateNavigatingOrder(words);
            _wordsOrderedList.Clear();
            while (maxHeapWordStore.Count > 0)
            {
                var word = maxHeapWordStore.Dequeue();
                _wordsOrderedList.Add(word);
            }
        }

        public string FindChar(char toFind)
        {

            int maxcharCount = 0;
            string maxcharWord = string.Empty;

            foreach (string word in _wordsOrderedList)
            {


                // If a words length is less than the maxcharcount, then there is no need to navigate through the rest of the elements
                //given the items are retrieved in descending order of length and the order of occurance
                if (word.Length <= maxcharCount)
                    break;
                int count = word.Count(x => x == toFind) ;

                if (count > 0  && (count > maxcharCount || (count == maxcharCount && word.Length > maxcharWord.Length)))
                {
                    maxcharCount = count;
                    maxcharWord = word;
                }

            }

            return maxcharWord;
        }

        


    }
}
