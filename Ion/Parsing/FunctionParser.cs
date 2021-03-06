using Ion.CodeGeneration;
using Ion.SyntaxAnalysis;

namespace Ion.Parsing
{
    public class FunctionParser : IParser<Function>
    {
        public Function Parse(TokenStream stream)
        {
            // Parse the prototype from the stream, this captures the name, arguments and return type.
            Prototype prototype = new PrototypeParser().Parse(stream);

            // Create the function.
            var function = new Function();

            // Assign the function prototype to the parsed prototype.
            function.Prototype = prototype;

            // Parse the body.
            Block body = new BlockParser().Parse(stream);

            // Set the name of the body block.
            body.SetNameEntry();

            // Assign the body.
            function.Body = body;

            return function;
        }
    }
}