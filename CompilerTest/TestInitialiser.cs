using Parser;
using Lex = Lexer.Lexer;

namespace CompilerTest;

public class TestInitialiser
{
    public static (List<Token>, Lex) InitializeTokens(string inputFile)
    {
        string programm = System.IO.File.ReadAllText($@"inputs/{inputFile}");
        StringReader sr = new StringReader(programm);
        Console.SetIn(sr);
        
        // create a new lexer
        Lex lexer = new Lex();
        
        // scan the code
        List<Token> tokens = new List<Token>();
        Token t = lexer.Scan();
        Console.WriteLine(t);
        do
        {
            tokens.Add(t);
            t = lexer.Scan();
        } while (t.Tag != 65535);

        // print the tokens
        foreach (Token token in tokens)
        {
            token.PrintToken();
        }
        return (tokens, lexer);
    }
    
    public static bool HasConsecutiveOccurences<T>(IEnumerable<T> seq, T target)
    {
        using (var iterator = seq.GetEnumerator())
        {
            if (!iterator.MoveNext()) return false;

            T previous = iterator.Current;
            while (iterator.MoveNext())
            {
                T current = iterator.Current;
                if (EqualityComparer<T>.Default.Equals(current, target)
                    && EqualityComparer<T>.Default.Equals(previous, target))
                {
                    return true;
                }

                previous = current;
            }
        }

        return false;
    }

    public static AbstractSyntaxTree InitializeParser(string inputFile)
    {
        AbstractSyntaxTree ast;
        // read the file
        string programm = System.IO.File.ReadAllText(inputFile);
        StringReader sr = new StringReader(programm);
        Console.SetIn(sr);
        
        // create a new lexer
        Lex lexer = new Lex();
        Parser.Parser parser = new Parser.Parser(lexer);
        
        // scan the code
        ast = parser.Scan();
        return ast;
    }
}