using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaggleCSVCleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
            var fileInputS = File.ReadAllLines(txtFileInput.Text);
            List<string> fileInput = new List<string>(fileInputS).Skip(1).ToList();
            fileInput = fileInput.Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();
            List<string> result = new List<string>();

            for (int i = 0; i < fileInput.Count; i++)
            {
                fileInput[i] = fileInput[i].Replace("\"\"\"", "");

                if (i > 0 && (fileInput[i - 1].EndsWith(",0") || fileInput[i - 1].EndsWith(",1")))
                {
                    result.Add(fileInput[i] + " ");
                    continue;
                }

                if (!StringStartsWithNumbers(fileInput[i]))
                {
                    int lastIndex0 = result.Count - 1;
                    result[lastIndex0] += " " + fileInput[i];
                    continue;
                    
                }

                if (
                    (fileInput[i].EndsWith(",0") || fileInput[i].EndsWith(",1"))
                    &&
                    !StringStartsWithNumbers(fileInput[i])
                    )
                {
                    result.Add(fileInput[i]);
                    continue;
                }
                if (StringStartsWithNumbers(fileInput[i]))
                {
                    result.Add(fileInput[i]);
                    continue;
                }
                int lastIndex = result.Count - 1;
                result[lastIndex] += fileInput[i];
            }


            string[] wordsForRemoval = {"the", "a", "an", "thanks", "jan", "feb", "mar", "apr", "jun", "jul",
                "aug", "sep", "oct", "nov", "dec", "january", "february", "march", "april", "june", "july", "august",
                "september", "october", "november", "december", "utc", "pm", "ok", "please", "be", "hi", "gmt"
            };//words that can't be used for abuse

            string pattern = "\\b" + string.Join("\\b|\\b", wordsForRemoval) + "\\b";
            string replace = "";

            for (int i = 0; i < result.Count; i++)
            {
                string temp = result[i].Trim().ToLower();
                temp = Regex.Replace(temp, pattern, replace);
                int idIdx = temp.IndexOf(",");
                string id = temp.Substring(0, idIdx);

                string refiningPart;
                bool learning = true;
                if (temp.EndsWith(",0") || temp.EndsWith(",1"))
                {
                    refiningPart = temp.Substring(idIdx + 1, temp.Length - idIdx - 1 - 11);
                }
                else
                {
                    refiningPart = temp.Substring(idIdx + 1, temp.Length - idIdx - 1);
                    learning = false;
                }
                
                //result[i] = id + "," + RemoveDuplicates(refiningPart);
                //refiningPart = RemoveDuplicates(refiningPart);

                var splitted = refiningPart.Split(' ', ',', '"', '!', '.', '=', '•', '-', '|').Distinct();

                string truncated = GetString(splitted).ToLower();
                
                truncated = Regex.Replace(truncated, "[^a-z,\\s]", "");

                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);
                truncated = regex.Replace(truncated, " ");

                truncated = RemoveTriples(truncated);

                //int truncLen = 3000;
                //if (truncated.Length > truncLen)
                //{
                //    truncated = truncated.Substring(0, truncLen);
                //}

                result[i] = id + "," + truncated;
                if (learning)
                {
                    result[i] = result[i] + "," + temp.Substring(temp.Length - 11, 11);
                }
                result[i] = result[i].Replace(",,", ",");

                //result[i] = ReplaceWordDuplicates(result[i]);

                if (result[i].Length < 5)
                {
                    txtLog.Text = temp + Environment.NewLine;
                }
            }

            result = result.OrderBy(r => r.Length).ToList();
            int longestString = result.Max(a => a.Length);
            int averageLength = (int)result.Average(r => r.Length);
            

            lblInfo.Text = $"Longest string length = {longestString}, averageLength = {averageLength}";

            File.WriteAllLines(txtFileOutput.Text, result);
            
        }
        
        
        private string GetString(IEnumerable<string> splitted)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var word in splitted)
            {
                var wordToAppend = word;
                int longestWord = 46;
                if (wordToAppend.Length > 46)
                {
                    wordToAppend = word.Substring(0, longestWord);
                }

                sb.Append(wordToAppend);
                sb.Append(" ");
            }
            return sb.ToString();
        }

        private string RemoveTriples(string s)
        {
            s = s.Trim();
            if (s.Length < 3)
            {
                return s;
            }

            StringBuilder result = new StringBuilder();
            result.Append(s[0]);
            result.Append(s[1]);

            int j = 0;

            for (int i = 0; i <= s.Length - 3; i++)
            {
                j = i + 1;
                if (
                    s[i] == s[j] &&
                    s[i] == s[j + 1]
                )
                {
                    continue;
                }
                
                result.Append(s[i + 2]);
            }
            result.Insert(0, " ");
            result.Append(" ");

            return result.ToString();
        }

        private string RemoveDuplicates(string s)
        {

            StringBuilder s1 = new StringBuilder("");
            //s1 += s[0];
            s1.Append(s[0]);

            int j = 0;
            for (int i = 0; i <= s.Length - 1; i++)
            {
                if (s[i] == s1[j]) continue;
                j += 1;
                //s1 += s[I];
                s1.Append(s[i]);
            }
            return s1.ToString();
        }
        

        private bool StringStartsWithNumbers(string s)
        {
            int len = 7;
            if (!s.Contains(","))
            {
                return false;
            }

            if (s.StartsWith("111"))
                return false;
            if (s.StartsWith("333"))
                return false;
            if (s.Length < len)
            {
                return false;
            }
            for (int i = 0; i < len; i++)
            {
                if (!Char.IsDigit(s[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
