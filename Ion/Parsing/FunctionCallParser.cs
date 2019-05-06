using System;
using System.Collections.Generic;
using Ion.CodeGeneration;
using Ion.Core;
using Ion.SyntaxAnalysis;
using LLVMSharp;

namespace Ion.Parsing
{
    public class FunctionCallExprParser : IParser<FunctionCallExpr>
    {
        public FunctionCallExpr Parse(TokenStream stream)
        {
            // Capture identifier.
            string identifier = stream.Get(TokenType.Identifier).Value;

            // Skip the identifier token onto the parentheses start token.
            stream.Skip(TokenType.SymbolParenthesesL);

            // TODO: This should be performed as the last thing, to allow recursive calls (and yet to be parsed functions).
            // Ensure the function has been emitted.
            if (!SymbolTable.functions.ContainsKey(identifier))
            {
                throw new Exception($"Call to a non-existent function named '{identifier}' performed");
            }

            // Retrieve the target.
            LLVMValueRef target = SymbolTable.functions[identifier];

            // Invoke the function call argument parser.
            List<Expr> args = new CallArgsParser().Parse(stream);

            // TODO: Callee.
            // Create the function call expression entity.
            FunctionCallExpr functionCall = new FunctionCallExpr(target, "TestCallee", args);

            // Return the function call expression.
            return functionCall;
        }
    }
}
