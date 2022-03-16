using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class MaszynaLosujaca
    {
        List<string> Words = new List<string>();
        readonly Random _rng = new Random();

        public MaszynaLosujaca Add(string word)
        {
            Words.Add(word);
            return this;
        }

        public string GetRandomWord()
            => Words.PopAt(_rng.Next(Words.Count));

        public bool AreThereAnyWords
            => Words.Count > 0;

        public List<string> GetAllWords()
            => Words;
    }

    static class List_Extensions
    {
        public static T PopAt<T>(this List<T> self, int index)
        {
            T result = self[index];
            self.RemoveAt(index);
            return result;
        }
    }
}
