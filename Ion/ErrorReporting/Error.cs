using Ion.Misc;

namespace Ion.ErrorReporting
{
    public class Error
    {
        public readonly string message;

        public readonly string name;

        public Error(string message, string name = InternalErrorNames.Generic)
        {
            this.message = message;
            this.name = name;
        }

        public static string Create(string message, string name = InternalErrorNames.Generic)
        {
            var capitalizedName = name.Capitalize();

            return $"{capitalizedName}Error: {message}";
        }

        public static void Write(string message, string name = InternalErrorNames.Generic)
        {
            Create(message, name);
        }

        public void Write()
        {
            Write(message, name);
        }

        public override string ToString()
        {
            return Create(message, name);
        }
    }
}