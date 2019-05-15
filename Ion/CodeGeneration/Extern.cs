using System;
using Ion.CodeGeneration.Structure;
using Ion.Core;
using LLVMSharp;

namespace Ion.CodeGeneration
{
    public class Extern : IPipe<Module, LLVMValueRef>
    {
        private Prototype Prototype { get; }

        public Extern(Prototype prototype)
        {
            this.Prototype = prototype;
        }

        public LLVMValueRef Emit(PipeContext<Module> context)
        {
            // Ensure prototype is set.
            if (this.Prototype == null)
            {
                throw new Exception("Unexpected external definition's prototype to be null");
            }

            // Emit the formal arguments.
            LLVMTypeRef[] args = this.Prototype.Args.Emit();

            // Emit the return type.
            LLVMTypeRef returnType = this.Prototype.ReturnType.Emit();

            // Emit the function type.
            LLVMTypeRef type = LLVM.FunctionType(returnType, args, this.Prototype.Args.Continuous);

            // Emit the external definition to context and capture the LLVM value reference.
            LLVMValueRef external = LLVM.AddFunction(context.Target.Target, this.Prototype.Name, type);

            // Determine if should be registered on the symbol table.
            if (!context.SymbolTable.functions.ContainsKey(this.Prototype.Name))
            {
                // Register the external definition as a function in the symbol table.
                context.SymbolTable.functions.Add(this.Prototype.Name, external);
            }
            // Otherwise, issue a warning.
            else
            {
                System.Console.WriteLine($"Warning: Extern definition '{this.Prototype.Name}' being re-defined");
            }

            // Return the resulting LLVM value reference.
            return external;
        }
    }
}
