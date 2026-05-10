using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace GetCodeGenieMigrator
{
    // BinaryFormatter bakes the originating assembly name ("GetCodeGenie, Version=6.3.0.0 ...")
    // into every .gcg2p file — including inside generic type arguments such as:
    //   List`1[[GetCodeGenie.StateOneDocument, GetCodeGenie, Version=6.3.0.0, ...]]
    // This binder rewrites every embedded GetCodeGenie assembly reference to point at
    // this assembly before attempting to resolve the type.
    public class GcgSerializationBinder : SerializationBinder
    {
        // Matches "GetCodeGenie, Version=x.x.x.x, Culture=neutral, PublicKeyToken=null"
        // wherever it appears — including inside generic type argument brackets.
        private static readonly Regex AssemblyRef = new Regex(
            @"GetCodeGenie,\s*Version=[0-9.]+,\s*Culture=\w+,\s*PublicKeyToken=\w+");

        private static readonly string ThisAssemblyFullName =
            Assembly.GetExecutingAssembly().FullName;

        public override Type BindToType(string assemblyName, string typeName)
        {
            // Rewrite any embedded GetCodeGenie assembly reference (handles generic types)
            string rewritten = AssemblyRef.Replace(typeName, ThisAssemblyFullName);

            // Direct GetCodeGenie type — find it in this assembly by name
            if (assemblyName.StartsWith("GetCodeGenie,"))
            {
                Type t = Assembly.GetExecutingAssembly().GetType(rewritten);
                if (t != null) return t;
            }

            // Generic or other type whose argument(s) were rewritten — resolve normally
            if (rewritten != typeName)
            {
                Type t = Type.GetType(rewritten);
                if (t != null) return t;
            }

            // Standard fallback for mscorlib, System.Drawing, etc.
            return Type.GetType(string.Format("{0}, {1}", typeName, assemblyName));
        }
    }
}
