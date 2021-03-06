using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Ion.Core;
using Ion.SyntaxAnalysis;
using Ion.ErrorReporting;
using Ion.Tests.Core;

namespace Ion.Tests.SyntaxAnalysis
{
    internal sealed class LexerTests
    {
        private TokenType[] sequence;

        private TokenType[] fileSequence;

        [SetUp]
        public void Setup()
        {
            this.sequence = new TokenType[] {
                TokenType.Identifier,
                TokenType.SymbolParenthesesL,
                TokenType.SymbolComma,
                TokenType.SymbolParenthesesR,
                TokenType.SymbolColon,
                TokenType.SymbolBlockL,
                TokenType.LiteralInteger,
                TokenType.LiteralDecimal,
                TokenType.LiteralString,
                TokenType.LiteralCharacter,
                TokenType.SymbolArrow,
                TokenType.OperatorAssignment,
                TokenType.OperatorEquality,
                TokenType.OperatorLessThan,
                TokenType.OperatorGreaterThan,
                TokenType.OperatorNot,
                TokenType.OperatorAnd,
                TokenType.OperatorOr,
                TokenType.Identifier,
                TokenType.SymbolSemiColon,
                TokenType.SymbolBlockR,
                TokenType.MultiLineComment,
                TokenType.SingleLineComment
            };
        }

        [Test]

        // Normal.
        [TestCase("id ( , ) : { 123 1.23 \"hello world\" 'a' => = == < > ! and or andor; } /*a*/ // abc")]

        // Dense.
        [TestCase("id(,):{123 1.23\"hello world\"'a'=>= ==<>!and or andor;}/*a*///abc")]
        public void Tokenize(string input)
        {
            // Create lexer and tokenize the input.
            Lexer lexer = new Lexer(input, (LexerOptions.IgnoreWhitespace));
            List<Token> tokens = lexer.Tokenize();

            // Ensure length is the same.
            Assert.AreEqual(this.sequence.Length, tokens.Count);

            // Verify sequence.
            for (int i = 0; i < tokens.Count; i++)
            {
                // Compare tokenized token to corresponding token on the sequence.
                Assert.AreEqual(sequence[i], tokens[i].Type);
            }
        }

        [Test]
        [TestCase("~")]
        [TestCase(".")]
        [TestCase("$")]
        [TestCase("#")]
        [TestCase("`")]
        public void NotTokenizeInvalidInput(string input)
        {
            Lexer lexer = new Lexer(input);
            List<Token> tokens = lexer.Tokenize();

            // Ensure tokens length.
            Assert.AreEqual(tokens.Count, 1);

            // Ensure token is unknown.
            Assert.AreEqual(tokens[0].Type, TokenType.Unknown);
        }
    }
}
