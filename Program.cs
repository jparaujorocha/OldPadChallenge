using System.Text;

namespace OldPadChallenge
{
    public static class Program
    {

        // Dictionary with the allowed commands
        private static readonly Dictionary<string, string> dicPad = new()
             {
                                                {"*","*"},
                                                {"#","send"},
                                                {"0"," "},
                                                {"1","&"},
                                                {"11","'"},
                                                {"111","("},
                                                {"2", "a"},
                                                {"22", "b"},
                                                {"222", "c"},
                                                {"3", "d"},
                                                {"33", "e"},
                                                {"333", "f"},
                                                {"4", "g"},
                                                {"44", "h"},
                                                {"444", "i"},
                                                {"5","j"},
                                                {"55","k"},
                                                {"555","l"},
                                                {"6","m"},
                                                {"66","n"},
                                                {"666","o"},
                                                {"7","p"},
                                                {"77","q"},
                                                {"777","r"},
                                                {"7777","s"},
                                                {"8","t"},
                                                {"88","u"},
                                                {"888","v"},
                                                {"9","w"},
                                                {"99","x"},
                                                {"999","y"},
                                                {"9999","z"},
              };

        public static void Main(string[] args)
        {
            bool endProgram;
            do
            {
                try
                {
                    Console.WriteLine("Please write the command(Don't forget the #)");

                    string commandTranslated = OldPhonePad(Console.ReadLine()!);

                    Console.WriteLine($"Command: {commandTranslated}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Try one more time? - 1/Y - YES, 2/N - NO");
                    var response = Console.ReadLine()!.ToLower();

                    endProgram = (!string.IsNullOrWhiteSpace(response) && (response != "1" && response != "y"));

                    if (endProgram)
                    {
                        Console.WriteLine("Thank you. Press any key to exit!");
                        Console.ReadKey();
                    }

                    Console.Clear();
                }
            }
            while (!endProgram);
        }

        /// <summary>
        /// Translate the command sent for a user
        /// </summary>
        /// <param name="input"> Command send for the user</param>
        /// <returns>Translated command</returns>
        public static string OldPhonePad(string input)
        {
            VerifyInput(input);
            var inputList = ReturnInputList(input);
            StringBuilder output = new();

            foreach (var inputCommand in inputList)
            {
                string tempInmputCommand = inputCommand;

                foreach (var key in dicPad.Keys.Where(keys => tempInmputCommand.Contains(keys)).OrderByDescending(keys => keys.Length).ThenByDescending(keys => keys))
                {
                    tempInmputCommand = tempInmputCommand.Replace(key, dicPad[key]);
                }

                tempInmputCommand = DeleteCharacter(tempInmputCommand);
                output.Append(tempInmputCommand);
            }


            return output.ToString();
        }

        /// <summary>
        /// Delete Characteres from input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string DeleteCharacter(string input)
        {
            do
            {
                int indexToDelete = input.IndexOf('*') - 1;

                if (indexToDelete < 0)
                    break;

                input = input.Remove(indexToDelete, 1);
                input = input.Replace("*", "");
            }
            while (input.Contains("*"));

            return input;
        }

        /// <summary>
        /// Return the formated commands
        /// </summary>
        /// <param name="input">Commands sent for the user</param>
        /// <returns>Return the commands in a string array</returns>
        private static string[] ReturnInputList(string input)
        {
            input = input.Trim();
            input = input.Remove(input.LastIndexOf('#'));

            return input.Split(" ");
        }

        /// <summary>
        /// Validate the input
        /// </summary>
        /// <param name="input">Commands sent for the user</param>
        private static void VerifyInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || (!input.Any(a => a != '#' && a != '*')))
                throw new ArgumentException("Input null or Empty!");

            if (input.Last() != '#')
                throw new ArgumentException("Without send command!");

            foreach (var valueChar in input)
            {
                if (!string.IsNullOrWhiteSpace(valueChar.ToString()) && !dicPad.Keys.Contains(valueChar.ToString()))
                    throw new ArgumentException("Invalid Input!");

            }
        }
    }
}
