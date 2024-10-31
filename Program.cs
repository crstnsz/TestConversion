using static System.Console;
using static System.IO.File;

// See https://aka.ms/new-console-template for more information
var test = ReadAllText("Code.txt");

var shouldIndex = test.IndexOf("Should");
var endNameIndex = test.IndexOf("(", shouldIndex);


for (var i = endNameIndex; i < test.Length; i++)
{
    if (test[i] == '=')
    {
        Write("Test(\"");
        Write(test[shouldIndex..(endNameIndex)].Replace("_", " "));
        Write(@""", async fixture");
        WriteLine(test[(endNameIndex + 2)..].Replace("_fixture", "fixture").Replace(";", ");"));
        break;
    }

    if (test[i] == '{')
    {
        Write("Test(\"");
        Write(test[shouldIndex..(endNameIndex)].Replace("_", " "));
        WriteLine(@""", async fixture");
        WriteLine("                    =>");
        Write(test[(i)..].Replace("_fixture", "fixture"));
        Write(");");
        break;
    }
}






