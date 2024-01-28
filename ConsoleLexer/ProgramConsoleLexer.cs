using Lexer;
using Lex = Lexer.Lexer;
using Pars = Parser.Parser;
using System;

public static class ProgramConsoleLexer
{

    public static void Main(string?[] args)
    {
        string? inputFile;
        string? whatToTest;
        
        if (args.Length < 1)
        {
            do
            {
                Console.WriteLine("-----------------------------------------------------------\n" +
                                  "Entrez help pour voir quels tests effectuent les fichiers\n" +
                                  "Veuillez entrer le nom du programme à analyser");

                inputFile = Console.ReadLine();
                if (inputFile == "help")
                {
                    Console.WriteLine("input1 : programme basique\n" +
                                      "input2 : commentaires\n" +
                                      "input3 : caractères non reconnus");
                }
            } while (inputFile == "help");
            
        }
        else
        {
            inputFile = args[0];
        }

        if (args.Length < 2)
        {
            do
            {
                Console.WriteLine("-----------------------------------------------------------\n" +
                                  "Entrez \"Lexer\" ou \"Parser\" pour indiquez ce que vous voulez afficher");

                whatToTest = Console.ReadLine();
            } while (whatToTest is null || !whatToTest.Equals("parser") && !whatToTest.Equals("lexer"));
        }
        else
        {
            whatToTest = args[1];
        }



        string programm = System.IO.File.ReadAllText($@"inputs/{inputFile}");
        StringReader sr = new StringReader(programm);
        Console.SetIn(sr);

        if (whatToTest.ToLower().Equals("lexer"))
            TestLexer();
        else if (whatToTest.ToLower().Equals("parser"))
            TestParser();

        
        
       
            

    }


    private static void TestLexer()
    {
        // create a new lexer
        Lex lexer = new Lex();
            
        // scan the code
        List<Token> tokens = new List<Token>();
        List<String> errors = new List<string>();
        (tokens, errors) = lexer.ScanAll();

        if(errors.Count > 0)
            foreach (string error in errors)
                Console.WriteLine(error);
            
        // print the tokens
        foreach (Token token in tokens)
        {
            token.PrintToken();
        }
    }


    private static void TestParser()
    {
        Lex lexer = new Lex();
        Pars parser = new Pars(lexer);

        parser.Scan();

    }
}