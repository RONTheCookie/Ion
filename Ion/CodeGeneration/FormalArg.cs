using LLVMSharp;
using Ion.CodeGeneration.Structure;
using Ion.Misc;

namespace Ion.CodeGeneration
{
    public class FormalArg : Named, IUncontextedEntity<LLVMTypeRef>
    {
        protected readonly Type type;

        public FormalArg(Type type)
        {
            this.type = type;
        }

        public LLVMTypeRef Emit()
        {
            return this.type.Emit();
        }
    }
}
