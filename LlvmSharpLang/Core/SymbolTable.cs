using System.Collections.Generic;
using LLVMSharp;
using LlvmSharpLang.CodeGeneration;

namespace LlvmSharpLang.Core
{
    /// <summary>
    /// Keeps track of emitted entities.
    /// </summary>
    public static class SymbolTable
    {
        public static Dictionary<string, LLVMValueRef> functions = new Dictionary<string, LLVMValueRef>();

        /// <summary>
        /// Contains locally-scoped emitted values.
        /// All values are reset once the scope changes.
        /// </summary>
        public static Dictionary<string, LLVMValueRef> localScope = new Dictionary<string, LLVMValueRef>();

        /// <summary>
        /// The active block being parsed.
        /// </summary>
        public static Block activeBlock;
    }
}