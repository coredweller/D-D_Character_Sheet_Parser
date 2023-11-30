using Newtonsoft.Json.Linq;

namespace D_DCharacterFormatter
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter the text file location (e.g., character_sheet.txt): ");
            string fileLocation = Console.ReadLine();
            Console.Write("Enter the location where you want the html output: ");
            string outLocation = Console.ReadLine();
            Console.Write("Enter the desired file name of the html output: ");
            string desiredOutputFileName = Console.ReadLine();

            var finalName = $"{outLocation}\\{desiredOutputFileName}";

            ParserPath(fileLocation, finalName);
            //ConverterPath(fileLocation);
            //GeneratorPath(fileLocation);
        }

        private static void WriteHtmlToFile(string htmlContent, string outputName)
        {
            File.WriteAllText(outputName, htmlContent);
        }

        private static void ParserPath(string fileLocation, string finalName)
        {
            // Read the JSON character template from a file
            string jsonContent = File.ReadAllText(fileLocation);

            // Parse JSON content
            JObject characterData = JObject.Parse(jsonContent);

            var parser = new CharacterSheetParser();
            // Create HTML content
            string htmlContent = parser.GenerateHtml(characterData);

            // Write HTML content to a file
            WriteHtmlToFile(htmlContent, finalName);

            Console.WriteLine($"HTML file generated successfully");
        }

        private static void ConverterPath(string fileLocation)
        {
            try
            {
                var converter = new CharacterSheetConverter();
                string characterSheetText = converter.ReadCharacterSheet(fileLocation);
                string htmlContent = converter.ConvertToHtml(characterSheetText);
                var fileName = "F:\\Projects\\D&D AI Char Generator Formatter\\src\\D&DCharacterFormatter\\Output\\character_sheet.html";
                WriteHtmlToFile(htmlContent, fileName);
                Console.WriteLine("HTML character sheet generated successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private static void GeneratorPath(string fileLocation)
        {
            try
            {
                var generator = new CharacterSheetGenerator();
                string characterData = generator.ReadCharacterFile(fileLocation);
                generator.GenerateHtml(characterData);
                Console.WriteLine($"HTML character sheet generated successfully: {generator.GetCharacterName(characterData)}_character_sheet.html");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}