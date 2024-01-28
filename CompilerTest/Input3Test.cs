namespace CompilerTest;

using Lexer;

public class Input3Test
{

    private List<Token> tokens;
    private List<Token> expectedTokens;
    
    private Lexer lex;

    [OneTimeSetUp]
    public void Setup()
    {
        (List<Token> tokens, Lexer lex) = TestInitialiser.InitializeTokens("input3");
        this.tokens = tokens;
        this.lex = lex;
        
        expectedTokens = new()
        {
            new Token(Tag.PROCEDURE), new Word(Tag.ID, "Hello"), new Token(Tag.IS),
            new Word(Tag.ID, "x"), new Token((int)':'), new Word(Tag.ID, "Integer"), new Token(((int)';')), 
            new Word(Tag.ID, "y"), new Token((int)':'), new Word(Tag.ID, "Integer"), new Token(((int)';')),
            new Token(Tag.BEGIN), 
            new Word(Tag.ID, "x"), new Token(Tag.ASSIGN), new Num(2), new Token((int)';'),
            new Word(Tag.ID, "y"), new Token(Tag.ASSIGN), new Word(Tag.ID, "x"), new Token((int)'+'), new Num(5), 
            new Token((int)';'), new Token(Tag.END), new Word(Tag.ID, "Hello"),
            new Token((int)';')
        };
    }

    
    [Test]
    public void TestNonVide()
    {
        Assert.That(tokens, Is.Not.Empty);
    }

    [Test]
    public void NoWhiteSpace()
    {
        foreach (Token token in tokens)
        {
            Assert.IsTrue(token.Tag > 32 && token.Tag < 331, $"le numéro du token n'est pas reconnu : {token.Tag}" );
        }
        Assert.That(expectedTokens, Has.None.EqualTo(new Token(10))); // Saut de ligne
        Assert.That(expectedTokens, Has.None.EqualTo(new Token(11))); // Tab
        Assert.That(expectedTokens, Has.None.EqualTo(new Token(13))); // Retour chariot
        Assert.That(expectedTokens, Has.None.EqualTo(new Token(32))); // Whitespace
    }

    [Test]
    public void TestNbTokens()
    {
        Assert.That(tokens, Has.Count.EqualTo(expectedTokens.Count));
    }

    [Test]
    public void TestExpectedTokens()
    {
        Assert.That(tokens, Is.EquivalentTo(expectedTokens));
    }
    
    private bool HasConsecutiveOccurences<T>(IEnumerable<T> seq, T target)
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
    
    [Test]
    public void NoComments()
    {
        Assert.IsFalse(TestInitialiser.HasConsecutiveOccurences(tokens,new Token('-')));
    }

    [Test]
    public void Errors()
    {
        
    }
}