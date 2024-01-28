namespace CompilerTest;
using Lexer;

public class Input2Test
{
    
    private List<Token> tokens;
    
    private Lexer lex;
    
    [OneTimeSetUp]
    public void Setup()
    {
        (List<Token> tokens, Lexer lex) = TestInitialiser.InitializeTokens("input2");
        this.tokens = tokens;
        this.lex = lex;
    }

    [Test]
    public void TestTailleTokens()
    {
        Assert.That(lex.GetErrors(), Has.Count.EqualTo(3));
    }
}