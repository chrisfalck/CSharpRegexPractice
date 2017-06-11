using System;
using System.Text.RegularExpressions;

namespace CSharpRegexPractice
{
    class Program
    {
        // Sample dataset to practice on.
        // We select two groups from each of the 3 Captures below.
        //  Group 1 is the file name
        //  Group 2 is the extension name (. not included).
        static string[] fileNames = {
            ".bash_profile",        // Skip.
            "workspace.doc",        // Skip.
            "img0912.jpg",          // Capture.
            "updated_img0912.jpg",  // Capture.
            "documentation.html",   // Skip.
            "favicon.gif",          // Capture.
            "img0912.jpg.tmp",      // Skip.
            "access.lock"           // Skip.
        };

        static void Main(string[] args)
        {
            // Set up a verbatim string to use as our regex.
            string regex = @"(\w*)\.(jpg|png|gif)[^.]";

            // Apply the regex to the fileNames data set.
            var matches = RegexHelper.FindMatches(fileNames, regex);

            // Print the details of the matches.
            RegexHelper.PrintMatchCollectionDetails(matches);

            System.Threading.Thread.Sleep(100000);
        }
    }

    public static class RegexHelper
    {
        public static MatchCollection FindMatches(string[] strs, string regex)
        {
            // Combine the string array into one string separated by spaces.
            string joinedStrs = String.Join(" ", strs);

            // Use the C# Regex class to obtain a MatchCollection.
            return Regex.Matches(joinedStrs, regex);
        }

        public static void PrintMatchCollectionDetails(MatchCollection matches)
        {
            // Match objects are containers for the details of the regex matches.
            // They contain the interesting capture and group detail collections.
            foreach (Match match in matches)
            {
                // Captures are substrings in the dataset that matched our regex.
                CaptureCollection captures = match.Captures;

                // Groups are subsets of captures that pull out specific details.
                GroupCollection groups = match.Groups;

                foreach (Capture capture in captures)
                {
                    Console.WriteLine($"Capture: {capture.Value}");
                }

                // The first group value is always the whole capture.
                // Therefore groups[0].Value == captures[0].value.
                foreach (Group group in groups)
                {
                    Console.WriteLine($"Group:   {group.Value}");
                }

                Console.Write("\n");
            }
        }
    }
}
