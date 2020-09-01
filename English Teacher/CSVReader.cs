using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Collections;

namespace English_Teacher
{
    class CSVReader
    {
        /* This class allows the application to read a CSV file containing words and definitions and then
         * store that information in a tree for retrieval
         */
        string[] headers = new string[3]; //column headers

        public void readCSV(AVLTree<Entry> tree)
        {
            const int MAX_LINES_FILE = 500000;
            string[] AllLines = new string[MAX_LINES_FILE];
            //set a string variable with the location of the data file. Use ReadAllLines to read the data
            string path = @"dictionary.csv";
            AllLines = File.ReadAllLines(path);
            foreach (string line in AllLines)
            {
                if (line.StartsWith("Word")) //found first line - headers
                {
                    headers = line.Split(',');
                }
                else
                {
                    //split data using commas
                    string[] columns = line.Split(',');
                    Entry entry = new Entry(columns[0], columns[2]);
                    tree.InsertItem(entry);
                }
            }
        }

    }
}