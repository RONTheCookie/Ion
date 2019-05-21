using System;
using Ion.CodeGeneration.Helpers;
using LLVMSharp;

namespace Ion.CodeGeneration
{
    public class LambdaExpr : Expr
    {
        public override ExprType Type => ExprType.Lambda;

        public FormalArgs Args;

        public Type ReturnType;

        public Block Block;

        public override LLVMValueRef Emit(PipeContext<LLVMBuilderRef> context)
        {
            // TODO: Implement.
            throw new NotImplementedException();
        }
    }
}