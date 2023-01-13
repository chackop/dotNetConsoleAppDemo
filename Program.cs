// // Solution to programming challenge for "Reverse Date Formats"
// using System.Text.RegularExpressions;

// // Takes a date in the form mm/dd/yyyy and returns the date
// // formatted as yyyy-mm-dd. Month and day can be 1 or 2 digits,
// // and the year can be 2 or 4 digits
// static string ReverseDateFormat(string sourceDate)
// {
//     const int TIMEOUT = 1000;
//     try
//     {
//         return Regex.Replace(sourceDate,
//                @"^(?<mon>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})$",
//               "${year}-${mon}-${day}", RegexOptions.None,
//               TimeSpan.FromMilliseconds(TIMEOUT));
//     }
//     catch (RegexMatchTimeoutException)
//     {
//         return sourceDate;
//     }
// }

// do
// {
//     // Ask the user for the date to convert
//     Console.WriteLine("Date to Convert? (Use mm/dd/yyyy, or 'exit' to quit)");
//     string inputStr = Console.ReadLine();

//     if (inputStr == "exit")
//     {
//         break;
//     }

//     // Make sure it's a valid date before we try to convert it
//     DateTime result;
//     if (DateTime.TryParse(inputStr, out result))
//     {
//         string reverseDate = ReverseDateFormat(inputStr);
//         Console.WriteLine($"The reversed format is {reverseDate}");
//     }
//     else
//     {
//         Console.WriteLine("That's not a valid date, try again");
//     }
// } while (true);


// // Using Timeout settings for RegEx in .NET
// using System.Text.RegularExpressions;
// using System.Diagnostics;

// const int MAX_REGEX_TIME = 1000; // Timeout value in milliseconds
// const string thestr = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

// // Use a Stopwatch to show elapsed time
// Stopwatch sw;

// // Use a Timeout value when executing RegEx to guard against bad input
// TimeSpan Timeout = TimeSpan.FromMilliseconds(MAX_REGEX_TIME);

// // Run the expression and output the result
// try
// {
//     sw = Stopwatch.StartNew();
//     Regex CapWords = new Regex(@"(a+a+)+b", RegexOptions.None, Timeout);
//     MatchCollection mc = CapWords.Matches(thestr);
//     sw.Stop();
//     Console.WriteLine($"Found {mc.Count} matches in {sw.Elapsed} time:");
//     foreach (Match match in mc)
//     {
//         Console.WriteLine($"'{match.Value}' found at position {match.Index}");
//     }
// }
// catch (RegexMatchTimeoutException e)
// {
//     Console.WriteLine($"The Regex took too long to execute! {e.MatchTimeout}");
// }

// // Example file for Replacing content with Regexes 
// using System.Text.RegularExpressions;

// string teststr1 = "The quick brown Fox jumps over the lazy Dog";

// Regex CapWords = new Regex(@"[A-Z]\w+");

// // Regular expressions can be used to replace content in strings
// // in addition to just searching for content
// string result = CapWords.Replace(teststr1, "***");
// Console.WriteLine(teststr1);
// Console.WriteLine(result);

// // Replacement text can be generated on the fly using MatchEvaluator
// // This is a delegate that computes the new value of the replacement
// string MakeUpper(Match m)
// {
//     string s = m.ToString();
//     if (m.Index == 0)
//     {
//         return s;
//     }
//     return s.ToUpper();
// }

// string upperstr = CapWords.Replace(teststr1, new MatchEvaluator(MakeUpper));
// Console.WriteLine(teststr1);
// Console.WriteLine(upperstr);

// // Example file for using Regex to find patterns
// using System.Text.RegularExpressions;

// string teststr1 = "The quick brown Fox jumps over the lazy Dog";
// string teststr2 = "the quick brown fox jumps over the lazy dog";

// // The IsMatch function is used to determine if the content of a string
// // results in a match with the given Regex
// Regex CapWords = new Regex(@"[A-Z]\w+");
// Console.WriteLine(CapWords.IsMatch(teststr1));
// Console.WriteLine(CapWords.IsMatch(teststr2));

// // The RegexOptions argument can be used to perform
// // case-insensitive searches
// Regex NoCase = new Regex(@"fox", RegexOptions.IgnoreCase);
// Console.WriteLine(NoCase.IsMatch(teststr1));

// // Use the Match and Matches methods to get information about
// // specific Regex matches for a given pattern

// // The Match method returns a single match at a time
// Match m = CapWords.Match(teststr1);
// while (m.Success)
// {
//     Console.WriteLine($"'{m.Value}' found at position {m.Index}");
//     m = m.NextMatch();
// }

// // The Matches method returns a collection of Match objects
// MatchCollection mc = CapWords.Matches(teststr1);
// Console.WriteLine($"Found {mc.Count} matches:");
// foreach (Match match in mc)
// {
//     Console.WriteLine($"'{match.Value}' found at position {match.Index}");
// }


// // Solution for the Files Programming Challenge

// // the directory we want to enumerate and results file name
// const string folder = "FileCollection";
// const string resultsfile = "results.txt";

// // Variables to hold the results
// long XLSCount = 0, DOCCount = 0, PPTCount = 0;
// long XLSSize = 0, DOCSize = 0, PPTSize = 0;
// long totalfiles = 0;
// long totalsize = 0;

// bool IsOfficeFile(string filename)
// {
//     // if the file ends with a known office suffix, return true
//     if (filename.EndsWith(".xlsx") || filename.EndsWith(".docx")
//         || filename.EndsWith(".pptx"))
//         return true;
//     return false;
// }

// // create a DirectoryInfo for the given folder
// DirectoryInfo di = new DirectoryInfo(folder);

// foreach (FileInfo fi in di.EnumerateFiles())
// {
//     // Is this an Office file? (XLSX, DOCX, PPTX)
//     if (IsOfficeFile(fi.Name))
//     {
//         totalfiles++;
//         totalsize += fi.Length;
//         if (fi.Name.EndsWith(".xlsx"))
//         {
//             XLSCount++;
//             XLSSize += fi.Length;
//         }
//         if (fi.Name.EndsWith(".docx"))
//         {
//             DOCCount++;
//             DOCSize += fi.Length;
//         }
//         if (fi.Name.EndsWith(".pptx"))
//         {
//             PPTCount++;
//             PPTSize += fi.Length;
//         }
//     }
// }

// // Output the results
// using (StreamWriter sw = File.CreateText(resultsfile))
// {
//     sw.WriteLine("~~~~ Results ~~~~");
//     sw.WriteLine($"Total Files: {totalfiles}");
//     sw.WriteLine($"Excel Count: {XLSCount}");
//     sw.WriteLine($"Word Count: {DOCCount}");
//     sw.WriteLine($"PowerPoint Count: {PPTCount}");
//     sw.WriteLine("----");
//     sw.WriteLine($"Total Size: {totalsize:N0}");
//     sw.WriteLine($"Excel Size: {XLSSize:N0}");
//     sw.WriteLine($"Word Size: {DOCSize:N0}");
//     sw.WriteLine($"PowerPoint Size: {PPTSize:N0}");
// }


// // Creating and Deleting Directories

// const string dirname = "TestDir";

// // Create a Directory if it doesn't already exist
// if (!Directory.Exists(dirname))
// {
//     Directory.CreateDirectory(dirname);
// }
// else
// {
//     Directory.Delete(dirname);
// }

// // Get the path for the current directory
// string curpath = Directory.GetCurrentDirectory();
// Console.WriteLine($"Current directory is {curpath}");

// // Just like with files, you can retrieve info about a directory
// DirectoryInfo di = new DirectoryInfo(curpath);
// Console.WriteLine($"{di.Name}");
// Console.WriteLine($"{di.Parent}");
// Console.WriteLine($"{di.CreationTime}");
// Console.WriteLine("---------------");

// // Enumerate the contents of directories
// Console.WriteLine("Just directories:");
// List<string> thedirs = new List<string>(Directory.EnumerateDirectories(curpath));
// foreach (string dir in thedirs)
// {
//     Console.WriteLine(dir);
// }
// Console.WriteLine("---------------");

// Console.WriteLine("Just files:");
// List<string> thefiles = new List<string>(Directory.EnumerateFiles(curpath));
// foreach (string dir in thefiles)
// {
//     Console.WriteLine(dir);
// }
// Console.WriteLine("---------------");

// Console.WriteLine("All directory contents:");
// List<string> thecontents = new List<string>(Directory.EnumerateFileSystemEntries(curpath));
// foreach (string dir in thecontents)
// {
//     Console.WriteLine(dir);
// }


// // Working with file information

// // Make sure the example file exists
// const string filename = "TestFile.txt";

// if (!File.Exists(filename))
// {
//     using (StreamWriter sw = File.CreateText(filename))
//     {
//         sw.WriteLine("This is a text file.");
//     }
// }

// // Get some information about the file
// Console.WriteLine(File.GetCreationTime(filename));
// Console.WriteLine(File.GetLastWriteTime(filename));
// Console.WriteLine(File.GetLastAccessTime(filename));

// File.SetAttributes(filename, FileAttributes.ReadOnly);
// Console.WriteLine(File.GetAttributes(filename));

// // We can also get general information using a FileInfo 
// try
// {
//     FileInfo fi = new FileInfo(filename);
//     Console.WriteLine($"{fi.Length}");
//     Console.WriteLine($"{fi.Directory}");
//     Console.WriteLine($"{fi.IsReadOnly}");
// }
// catch (Exception e)
// {
//     Console.WriteLine($"Exception: {e}");
// }

// // File information can also be manipulated
// DateTime dt = new DateTime(2020, 7, 1);
// File.SetCreationTime(filename, dt);
// Console.WriteLine(File.GetCreationTime(filename));

// // Reading and Writing data from and to files

// // Make sure the example file exists
// const string filename = "TestFile.txt";

// // 1: WriteAllText overwrites a file with the given content
// if (!File.Exists(filename))
// {
//     File.WriteAllText(filename, "This is a text file. ");
// }

// // 3: AppendAllText adds text to an existing file
// File.AppendAllText(filename, "This text gets appended to the file. ");

// // 4: A FileStream can be opened and written to until closed
// using (StreamWriter sw = File.AppendText(filename))
// {
//     sw.WriteLine("Line 1");
//     sw.WriteLine("Line 2");
//     sw.WriteLine("Line 3");
// }

// // 2: ReadAllText reads all the content from a file
// string content;
// content = File.ReadAllText(filename);
// Console.WriteLine(content);

// // Creating and Deleting Files

// const string filename = "TestFile.txt";

// // Create a new file - this will overwrite any existing file
// // Use the "using" construct to automatically close the file stream
// using (StreamWriter sw = File.CreateText(filename))
// {
//     sw.WriteLine("This is a text file.");
// }

// // Determine if a file exists
// Console.WriteLine(File.Exists(filename));
// if (File.Exists(filename))
// {
//     // The Delete function deletes a file
//     File.Delete(filename);
// }
// else
// {
//     using (StreamWriter sw = File.CreateText(filename))
//     {
//         sw.WriteLine("This is a text file.");
//     }
// }
// Console.WriteLine(File.Exists(filename));

// // Solution to Programming Challenge for "How Many Days?"

// string thedate = "";                // holds the user-entered date string
// DateTime today = DateTime.Today;    // holds the current date with time of 12:00:00

// do
// {
//     // print the greeting and ask for a date
//     Console.WriteLine("Which date? (or 'exit')");
//     thedate = Console.ReadLine();

//     // if the user enters the term 'exit' then leave the app
//     if (thedate == "exit")
//     {
//         break;
//     }

//     // try to parse the date
//     DateTime parsedDate;
//     TimeSpan ts;
//     if (DateTime.TryParse(thedate, out parsedDate))
//     {
//         if (parsedDate < today)
//         {
//             // if the date already went by, indicate how many days ago it was
//             ts = today - parsedDate;
//             Console.WriteLine($"That date went by {ts.Days} days ago!");
//         }
//         else if (parsedDate == today)
//         {
//             Console.WriteLine($"That date is today!");
//         }
//         else
//         {
//             // if the date hasn't yet happened, indicate how many days until it does
//             ts = parsedDate - today;
//             Console.WriteLine($"That date will be in {ts.Days} days!");
//         }
//     }
//     else
//     {
//         // If the user didn't enter a valid date, then print an error message
//         Console.WriteLine("That doesn't seem to be a valid date");
//     }
// } while (thedate != "exit");

// // Example file for parsing dates from strings

// // Collection of various date string formats to attempt parsing
// string[] sampleDateTimes = {
//     "January 1, 2025 9:30 AM",
//     "1/1/2025",
//     "Jan 1, 2025 7:30PM",
//     "Jan 1, 25",
//     "1/2025",
//     "1/1 7PM",
//     "Jan 1 '15",
// };

// foreach (string datestr in sampleDateTimes)
// {
//     DateTime result;
//     // Use the static class function TryParse to try parsing the dates
//     if (DateTime.TryParse(datestr, out result))
//     {
//         Console.WriteLine($"{datestr,-25} gets parsed as: {result}");
//     }
//     else
//     {
//         Console.WriteLine($"Could not parse '{datestr}'");
//     }
// }


// // Example file for formatting date information
// using System.Globalization;

// // Define a date
// DateTime AprFools = new DateTime(2025, 4, 1, 13, 23, 30);

// // 'd' Short date: mm/dd/yyyy (or dd/mm depending on locale)
// Console.WriteLine($"{AprFools:d}");
// // 'D' Full date: mm/dd/yyyy (or dd/mm depending on locale)
// Console.WriteLine($"{AprFools:D}");

// // 'f' Full date, short time
// Console.WriteLine($"{AprFools:f}");
// // 'F' Full date, long time
// Console.WriteLine($"{AprFools:F}");

// // 'g' General date and time
// Console.WriteLine($"{AprFools:g}");
// // 'G' General date and time
// Console.WriteLine($"{AprFools:G}");

// // Format using a specific CultureInfo
// Console.WriteLine(AprFools.ToString("d", CultureInfo.CreateSpecificCulture("de-DE")));

// // Defining custom date and time formats
// Console.WriteLine($"{AprFools:dddd, MMMM d yyyy}");
// Console.WriteLine($"{AprFools:ddd h:mm:ss tt}");
// Console.WriteLine($"{AprFools:MMM d yyyy}");


// // Example file for working with Dates and Times

// // Use DateTime.Now property to get the current date and time
// DateTime now = DateTime.Now;
// Console.WriteLine(now);

// // DateTime.Today gets just the current date with time set to 12:00:00 AM
// DateTime today = DateTime.Today;
// Console.WriteLine(today);

// // DateOnly and TimeOnly represent just dates and times
// DateOnly dt = DateOnly.FromDateTime(DateTime.Now);
// TimeOnly tm = TimeOnly.FromDateTime(DateTime.Now);
// Console.WriteLine(dt);
// Console.WriteLine(tm);

// // Dates have properties that can be inspected
// Console.WriteLine(today.DayOfWeek);
// Console.WriteLine(today.DayOfYear);

// // Dates also have methods to change their values
// now = now.AddDays(5);
// now = now.AddHours(9);
// now = now.AddMonths(1);
// Console.WriteLine(now);

// // The TimeSpan class represents a duration of time
// DateTime AprilFools = new DateTime(now.Year, 4, 1);
// DateTime NewYears = new DateTime(now.Year, 1, 1);
// TimeSpan interval = AprilFools - NewYears;
// Console.WriteLine(interval);

// // Dates can be compared using regular operators
// Console.WriteLine($"{NewYears < AprilFools}");
// Console.WriteLine($"{NewYears > AprilFools}");


// // Example file for formatting numerical data in .NET

// int[] quarters = { 1, 2, 3, 4 };
// int[] sales = { 100000, 150000, 200000, 225000 };
// double[] intlMixPct = { .386, .413, .421, .457 };
// int val1 = 1234;
// decimal val2 = 1234.5678m;

// // Specifying Numerical formatting
// // General format is {index[,alignment]:[format]}
// // Common types are N (Number), G (General), F (Fixed-point), 
// // E (Exponential), D (Decimal), P (Percent), X (Hexadecimal),
// // C (Currency in local format)
// Console.WriteLine($"{val1:D}, {val1:N}, {val1:F}, {val1:G}");
// Console.WriteLine($"{val2:E}, {val2:N}, {val2:F}, {val2:G}");

// // Add a number after the format to specify precision
// Console.WriteLine($"{val1:D6}, {val1:N2}, {val1:F1}, {val1:G3}");

// // Formatting with alignment and spacing
// Console.WriteLine("Sales by Quarter:");
// Console.WriteLine($"{quarters[0],12} {quarters[1],12} {quarters[2],12} {quarters[3],12}");
// Console.WriteLine($"{sales[0],12:C0} {sales[1],12:C0} {sales[2],12:C0} {sales[3],12:C0}");
// Console.WriteLine("International Sales:");
// Console.WriteLine($"{intlMixPct[0],12:P0} {intlMixPct[1],12:P0} {intlMixPct[2],12:P1} {intlMixPct[3],12:P2}");


// // Example file for parsing numerical data from strings

// string[] NumStrs = { "  1 ", " 1.45  ", "-100", "5e+04 " };

// int testint;
// float testfloat;
// bool result;

// // The Parse method attempts to parse a string to a number and
// // throws an exception if the parse is unsuccessful
// foreach (string str in NumStrs)
// {
//     try
//     {
//         testfloat = float.Parse(str);
//         Console.WriteLine($"Parsed number is {testfloat}");
//         testint = int.Parse(str);
//         Console.WriteLine($"Parsed number is {testint}");
//     }
//     catch (FormatException e)
//     {
//         Console.WriteLine($"Could not parse '{str}' : {e.Message}");
//     }
// }

// // The TryParse method returns 'true' if the parse is successful
// result = int.TryParse(NumStrs[0], out testint);
// Console.WriteLine($"{result} -- '{NumStrs[0]}' : {testint}");

// result = float.TryParse(NumStrs[1], out testfloat);
// Console.WriteLine($"{result} -- '{NumStrs[1]}' : {testfloat}");

// result = int.TryParse(NumStrs[2], out testint);
// Console.WriteLine($"{result} -- '{NumStrs[2]}' : {testint}");

// result = float.TryParse(NumStrs[3], out testfloat);
// Console.WriteLine($"{result} -- '{NumStrs[3]}' : {testfloat}");

// // Example file for searching string content

// string teststr = "The quick brown Fox jumps over the lazy Dog";

// // Contains determines whether a string contains certain content
// Console.WriteLine($"{teststr.Contains("fox")}");
// Console.WriteLine($"{teststr.Contains("fox", StringComparison.CurrentCultureIgnoreCase)}");

// // StartsWith and EndsWith determine if a string starts 
// // or ends with a given test string
// Console.WriteLine($"{teststr.StartsWith("the")}");
// Console.WriteLine($"{teststr.StartsWith("the", StringComparison.CurrentCultureIgnoreCase)}");
// Console.WriteLine($"{teststr.EndsWith("dog")}");
// Console.WriteLine($"{teststr.EndsWith("dog", StringComparison.CurrentCultureIgnoreCase)}");

// // IndexOf, LastIndexOf finds the index of a substring
// Console.WriteLine($"{teststr.IndexOf("the")}");
// Console.WriteLine($"{teststr.IndexOf("the", StringComparison.CurrentCultureIgnoreCase)}");
// Console.WriteLine($"{teststr.LastIndexOf("the")}");

// // Determining empty, null, or whitespace
// string str1 = null;
// string str2 = "   ";
// string str3 = String.Empty;
// Console.WriteLine($"{String.IsNullOrEmpty(str1)}");
// Console.WriteLine($"{String.IsNullOrEmpty(str3)}");
// Console.WriteLine($"{String.IsNullOrWhiteSpace(str2)}");


// Example file for manipulating string content

// string str1 = "The quick brown fox jumps over the lazy dog.";
// string str2 = "This is a string";
// string str3 = "THIS is a STRING";
// string[] strs = { "one", "two", "three", "four" };

// // Length of a string 
// Console.WriteLine(str1.Length);

// // Access individual characters
// Console.WriteLine(str1[14]);

// // Iterate over a string like any other sequence of values
// foreach (Char ch in str1)
// {
//     Console.Write(ch);
//     if (ch == 'b')
//     {
//         Console.WriteLine();
//         break;
//     }
// }

// // String Concatenation         
// string outstr;
// outstr = String.Concat(strs);
// Console.WriteLine(outstr);

// // Joining strings together with Join
// outstr = String.Join('.', strs);
// Console.WriteLine(outstr);
// outstr = String.Join("---", strs);
// Console.WriteLine(outstr);

// // String Comparison

// // Equals just returns a regular Boolean
// bool isEqual = str2.Equals(str3);
// Console.WriteLine($"{isEqual}");

// // Compare will perform an ordinal comparison and return:
// // < 0 : first string comes before second in sort order
// // 0 : first and second strings are same position in sort order
// // > 0 : first string comes after the second in sort order
// int result = String.Compare(str2, "This is a string");
// Console.WriteLine($"{result}");

// // Replacing content
// outstr = str1.Replace("fox", "cat");
// Console.WriteLine($"{outstr}");


// // Example file for formatting string content

// float f1 = 123.4f;
// int i1 = 2000;

// // Spacing and Alignment: Indexes
// Console.WriteLine("{0,-15} {1,10}", "Float Val", "Int Val");
// Console.WriteLine("{0,-15} {1,10}", f1, i1);

// // Spacing and Alignment: Interpolation
// Console.WriteLine("{0,-15} {1,10}", "Float Val", "Int Val");
// Console.WriteLine($"{f1,-15} {i1,10}");


// String Interpolation is a feature that enables the easy insertion of data
// and expression values into a string variable

// int a = 100;
// float b = 250.0f;
// string c = "CSharp";

// // String output the old way - using placeholders
// Console.WriteLine("The values are {0}, {1} and {2}", a, b, c);

// // Using string interpolation, the code is much easier to read
// Console.WriteLine($"The values are {a}, {b} and {c}");

// // Interpolated strings can contain expressions as well
// Console.WriteLine($"(a + b)/b is {(a + b) / b}");
// Console.WriteLine($"{c} in upper-case is {c.ToUpper()}");

// // Complex objects can be embedded in strings this way as well
// DateTime now = DateTime.Now;
// Console.WriteLine($"Today is {now}");

// // Demonstration of Garbage Collection

// void DoSomeBigOperation()
// {
//     // create a large memory allocation that's only used in this function
//     byte[] myArray = new byte[1000000];

//     Console.WriteLine($"Allocated memory is: {GC.GetTotalMemory(false)}");
//     Console.ReadLine();
// }

// // Retrieve and print the total memory allocated
// Console.WriteLine($"Allocated memory is: {GC.GetTotalMemory(false)}");
// Console.ReadLine();

// // Call the function that allocates a large memory chunk
// DoSomeBigOperation();
// // After the function completes, force a Garbage Collection 
// GC.Collect();

// // Retrieve and print the updated total memory amount
// Console.WriteLine($"Allocated memory is: {GC.GetTotalMemory(false)}");
// Console.ReadLine();

// // Example file for .NET Data Types

// // Declare some types with values
// int a = 1;
// char c = 'A';
// float f = 123.45f;
// decimal d = 400.85m;
// int b = default;
// bool tf = default;

// Console.WriteLine($"{a}, {b}, {tf}, {c}, {f}, {d}");

// // implicit type conversion
// Console.WriteLine($"{c + a}");
// Console.WriteLine($"{(char)(c + a)}");
// Console.WriteLine($"{f + a}");
// Console.WriteLine($"{f + c}");

// // Create an instance of a struct (which is a value type)
// s s1;
// s1.a = 5;
// s1.b = false;

// // Perform an operation on a struct
// void StructOp(s theStruct)
// {
//     // Modify the struct properties inside the function
//     theStruct.a = 10;
//     theStruct.b = true;
//     Console.WriteLine($"{theStruct.a}, {theStruct.b}");
// }

// Console.WriteLine("Structs are passed by copy, since they are value types:");
// Console.WriteLine($"{s1.a}, {s1.b}");
// StructOp(s1);
// Console.WriteLine($"{s1.a}, {s1.b}");

// // Create an object instance of a class (which is a reference type)
// MyClass cl = new MyClass { a = 5, b = false };

// // Perform an operation on the class
// void ClassOp(MyClass theClass)
// {
//     // Modify some of the properties of the class inside the function
//     theClass.a = 10;
//     theClass.b = true;
//     Console.WriteLine($"{theClass.a}, {theClass.b}");
// }

// Console.WriteLine("Objects are passed by reference, since they are reference types:");
// Console.WriteLine($"{cl.a}, {cl.b}");
// ClassOp(cl);
// Console.WriteLine($"{cl.a}, {cl.b}");

// // These are declared at the bottom of the file because C# requires
// // top-level statements to come before type declarations
// class MyClass
// {
//     public int a;
//     public bool b;
// }

// struct s
// {
//     public int a;
//     public bool b;
// }


