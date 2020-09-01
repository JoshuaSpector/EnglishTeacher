using System;
using System.Collections.Generic;
using System.Text;

namespace English_Teacher
{
    class Entry : IComparable
    /* This class is essentially a simple and IComparable version of a KeyValuePair object
     * To allow a dictionary of words and definitions to be inserted into a tree 
     for the dictionary part of this application */
    {
        private string word;
        private string definition;

        public Entry(string word, string definition)
        {
            Word = word;
            Definition = definition;
        }

        public string Definition { get => definition; set => definition = value; }
        public string Word { get => word; set => word = value; }


        //CompareTo method 
        public int CompareTo(object obj)
        {
            Entry temp = (Entry)obj;
            return word.ToLower().CompareTo(temp.word.ToLower());

        }

        public override string ToString()
        {
            return Definition;
        }
    }
}
