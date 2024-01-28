namespace CompilerTest;

using Lexer;


public class Tests
{

    private List<Token> tokens;

    private Lexer lex; 
    
    [OneTimeSetUp]
    public void Setup()
    { 
        (List<Token> tokens, Lexer lex) = TestInitialiser.InitializeTokens("input1");
        this.tokens = tokens;
        this.lex = lex;
    }

    
    [Test]
    public void TestNonVide()
    {
        Assert.That(tokens, Is.Not.Empty);
    }

    [Test]
    public void TestTailleTokens()
    {
        Assert.That(tokens, Has.Count.EqualTo(25));
    }
}