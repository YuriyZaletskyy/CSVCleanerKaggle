# CSVCleanerKaggle
I've decided to participate in following Kaggle competition:
https://www.kaggle.com/c/jigsaw-toxic-comment-classification-challenge

It has some data set. 
I've created C# application that allows to create cleaner data representation of initial file.
It does the following:
1. Merges all lines related to single id into one line of text
2. Removes non English characters
3. Removes all numbers
4. Removes following words: "the", "a", "an", "thanks", "jan", "feb", "mar", "apr", "jun", "jul", 
"aug", "sep", "oct", "nov", "dec", "january", "february", "march", "april", "june", "july", "august",
"september", "october", "november", "december", "utc", "pm", "ok", "please", "be", "hi", "gmt" 
because IMHO it's impossible to abuse with those words
5. Truncates words that are longer then 50 characters
6. lowercases all characters
7. removes all duplicates of words
for example line like this:

212313, some text some text 
continuation abc some text loooooooooooooooooooooooongstringloooooooooooooooooooooooongstring,
0,0,0,0,0,0

will become like this
212313, some text continuation loooooooooooooooooooooooongstringlooooooooooo, 0,0,0,0,0,0
