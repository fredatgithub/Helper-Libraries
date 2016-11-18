
namespace KCSoft.Windows.Helpers.Console
{
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    [Guid("9032154E-151C-40C3-9F6F-073D49DB738A")]
    public sealed class ConsoleHelper
    {
        private static bool isArgumentListProcessed = false;
        private static StringDictionary parameters = new StringDictionary();
        private const string CommandLineArgumentSplitterPattern = @"^/|^-{1,2}|=|:";
        private const string CommandLineArgumentRemoverPattern = @"^['""]?(.*?)['""]?$";

        /// <summary>Processes the specified command line argument.</summary>
        /// <param name="args">The arguments passed to the command line parameter.</param>
        public static void Process(string[] args)
        {
            var parameter = string.Empty;
            var spliter = new Regex(CommandLineArgumentSplitterPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            var remover = new Regex(CommandLineArgumentRemoverPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            
            foreach (var arg in args)
            {
                var argParts = spliter.Split(arg, 3);

                switch (argParts.Length)
                {
                    case 1:
                        if (parameter != null && !parameters.ContainsKey(parameter))
                        {
                            argParts[0] = remover.Replace(argParts[0], "$1");
                            parameters.Add(parameter, argParts[0]);
                            parameter = null;
                        }

                        break;

                    case 2:
                        if (parameter != null && !parameters.ContainsKey(parameter))
                        {
                            parameters.Add(parameter, "true");
                        }

                        parameter = argParts[1];
                        break;

                    case 3:
                        if (parameter != null && !parameters.ContainsKey(parameter))
                        {
                            parameters.Add(parameter, "true");
                        }

                        parameter = argParts[1];
                        if (!parameters.ContainsKey(parameter))
                        {
                            argParts[2] = remover.Replace(argParts[2], "$1");
                            parameters.Add(parameter, argParts[2]);
                        }

                        parameter = null;
                        break;
                }
            }

            if (parameter != null)
            {
                if (!parameters.ContainsKey(parameter))
                {
                    parameters.Add(parameter, "true");
                }
            }

            isArgumentListProcessed = true;
        }

        /// <summary>Gets the parameters as <c>StringDictionary</c> object.</summary>
        /// <returns>An object of type <typeparamref name="StringDictionary" /></returns>
        public static StringDictionary GetParameters()
        {
            Debug.Assert(isArgumentListProcessed, "Command line parameters not processed!", "Call 'CommandLineHelper.Process(args)' to process the passed arguments.");
            return parameters;
        }

        /// <summary>Determines whether the specified parameter passed as command line argument.</summary>
        /// <param name="param">The parameter.</param>
        /// <returns>Returns <c>true</c> if the specified parameter passed as argument</returns>
        public static bool ContainsParam(string param)
        {
            Debug.Assert(isArgumentListProcessed, "Command line parameters not processed!", "Call 'CommandLineHelper.Process(args)' to process the passed arguments.");
            return parameters.ContainsKey(param);
        }

        /// <summary>Gets the parameter value.</summary>
        /// <param name="param">The parameter.</param>
        /// <returns>The value as <typeparamref name="string"/></returns>
        public static string GetParamValue(string param)
        {
            Debug.Assert(isArgumentListProcessed, "Command line parameters not processed!", "Call 'CommandLineHelper.Process(args)' to process the passed arguments.");
            return ContainsParam(param) ? parameters[param] : null;
        }

        /// <summary>Compares the parameter passed against the value.</summary>
        /// <param name="paramToCompare">The parameter to compare.</param>
        /// <param name="valueToCompare">The value to compare.</param>
        /// <returns>Returns <c>true</c>, if success</returns>
        public static bool CompareParamValue(string paramToCompare, string valueToCompare)
        {
            Debug.Assert(isArgumentListProcessed, "Command line parameters not processed!", "Call 'CommandLineHelper.Process(args)' to process the passed arguments.");
            return parameters.ContainsKey(paramToCompare) ? parameters[paramToCompare].Equals(valueToCompare) : false;
        }
    }
}
