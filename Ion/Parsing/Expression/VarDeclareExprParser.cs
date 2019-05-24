using System;
using Ion.CodeGeneration;
using Ion.SyntaxAnalysis;
using Type = Ion.CodeGeneration.Type;

namespace Ion.Parsing
{
    public class VarDeclareExprParser : IParser<VarDeclareExpr>
    {
        public VarDeclareExpr Parse(ParserContext context)
        {
            // Parse the type.
            Type type = new TypeParser().Parse(context);

            // Create the variable declaration & link the type.
            VarDeclareExpr declaration = new VarDeclareExpr(type, null);

            // Invoke identifier parser.
            string identifier = new IdentifierParser().Parse(context);

            // Assign the name.
            declaration.SetName(identifier);

            // Peek next token for value.
            Token nextToken = context.Stream.Peek();

            // Value is being assigned.
            if (nextToken.Type == TokenType.OperatorAssignment)
            {
                // Skip onto the assignment operator
                context.Stream.Skip(TokenType.OperatorAssignment);

                // Skip the assignment operator.
                context.Stream.Skip();

                // Parse value.
                Expr value = new ExprParser().Parse(context);

                // Assign value.
                declaration.Value = value;
            }

            // Return the resulting declaration construct.
            return declaration;
        }
    }
}
