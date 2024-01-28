using Parser;

namespace CompilerTest;

public class TestSyntaxique
{
    private AbstractSyntaxTree _ast;

    private List<string> correctFilesToRead, wrongFilesToRead, errors; 
    
    [OneTimeSetUp]
    public void Setup()
    {
        correctFilesToRead = new List<string>();
        wrongFilesToRead = new List<string>();
        // Get all files in the directory
        // print current dir
        string[] files = Directory.GetFiles("../../../inputs/Corrects");
        foreach (string file in files)
        {
            correctFilesToRead.Add(file);
        }
        files = Directory.GetFiles("../../../inputs/Erreurs");
        foreach (string file in files)
        {
            wrongFilesToRead.Add(file);
        }
    }
    

    [Test]
    public void TestAllCorrectsFiles()
    {
        Parser.Parser parser;
        foreach (string currentFile in correctFilesToRead)
        {
            _ast = TestInitialiser.InitializeParser(currentFile);
        }
    }
}