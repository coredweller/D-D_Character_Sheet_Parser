using System;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace D_DCharacterFormatter
{
    public class CharacterSheetConverter
    {
        public string ReadCharacterSheet(string fileLocation)
        {
            string characterSheetText;
            try
            {
                characterSheetText = File.ReadAllText(fileLocation);
            }
            catch (IOException e)
            {
                throw new IOException($"Error reading the file: {e.Message}");
            }

            return characterSheetText;
        }

        public string ConvertToHtml(string characterSheetText)
        {
            StringBuilder htmlContent = new StringBuilder();

            // Start HTML content
            htmlContent.AppendLine($"<!DOCTYPE html>");
            htmlContent.AppendLine($"<html lang=\"en\">");
            htmlContent.AppendLine($"<head>");
            htmlContent.AppendLine($"    <meta charset=\"UTF-8\">");
            htmlContent.AppendLine($"    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">");
            htmlContent.AppendLine($"    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            htmlContent.AppendLine($"    <title>Character Sheet</title>");
            htmlContent.AppendLine($"    <style>");
            htmlContent.AppendLine($"        body {{");
            htmlContent.AppendLine($"            font-family: 'Arial', sans-serif;");
            htmlContent.AppendLine($"            margin: 20px;");
            htmlContent.AppendLine($"        }}");
            htmlContent.AppendLine($"    </style>");
            htmlContent.AppendLine($"</head>");
            htmlContent.AppendLine($"<body>");

            // Process and append the rest of the content here
            AppendTag(htmlContent, characterSheetText, "CharacterName", "Character Name");
            AppendTag(htmlContent, characterSheetText, "Level", "Level");
            AppendTag(htmlContent, characterSheetText, "Race", "Race");
            AppendTag(htmlContent, characterSheetText, "Class", "Class");
            AppendTag(htmlContent, characterSheetText, "Alignment", "Alignment");
            AppendTag(htmlContent, characterSheetText, "Background", "Background");
            AppendTag(htmlContent, characterSheetText, "HP", "Hit Points");
            AppendTag(htmlContent, characterSheetText, "AC", "Armor Class");
            AppendTag(htmlContent, characterSheetText, "Speed", "Speed");

            AppendSection(htmlContent, characterSheetText, "AbilityScores", "Ability Scores");
            AppendSection(htmlContent, characterSheetText, "SavingThrows", "Saving Throws");
            AppendSection(htmlContent, characterSheetText, "Skills", "Skills");

            AppendTag(htmlContent, characterSheetText, "Senses", "Senses");
            AppendTag(htmlContent, characterSheetText, "Languages", "Languages");

            AppendSection(htmlContent, characterSheetText, "SpecialTraits", "Special Traits");
            AppendSection(htmlContent, characterSheetText, "Actions", "Actions");
            AppendSection(htmlContent, characterSheetText, "Reactions", "Reactions");
            AppendSection(htmlContent, characterSheetText, "Features", "Features");

            //TODO: This can be a Section b/c it SHOULD have multiple rows
            AppendTag(htmlContent, characterSheetText, "Equipment", "Equipment");
            AppendTag(htmlContent, characterSheetText, "Notes", "Notes");

            // End HTML content
            htmlContent.AppendLine($"</body>");
            htmlContent.AppendLine($"</html>");

            return htmlContent.ToString();
        }

        public void AppendTag(StringBuilder htmlContent, string text, string tag, string label)
        {
            string value = ExtractValue(text, tag);
            htmlContent.AppendLine($"    <p><strong>{label}:</strong> {value}</p>");
        }

        //public void AppendSection1(StringBuilder htmlContent, string text, string tag, string label)
        //{
        //    string value = ExtractValue(text, tag);
        //    htmlContent.AppendLine($"    <h2>{label}</h2>");
        //    htmlContent.AppendLine($"    <p>{value}</p>");
        //}

        //public void AppendSection2(StringBuilder htmlContent, string text, string tag, string label)
        //{
        //    string sectionContent = ExtractValue(text, tag);
        //    if (!string.IsNullOrWhiteSpace(sectionContent))
        //    {
        //        htmlContent.AppendLine($"    <h2>{label}</h2>");
        //        htmlContent.AppendLine($"    <ul>");

        //        string[] items = sectionContent.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        //        foreach (var item in items)
        //        {
        //            htmlContent.AppendLine($"        <li>{item}</li>");
        //        }

        //        htmlContent.AppendLine($"    </ul>");
        //    }
        //}

        public void AppendSection(StringBuilder htmlContent, string text, string tag, string label)
        {
            string sectionContent = ExtractValueSection(text, tag);

            if (!string.IsNullOrWhiteSpace(sectionContent))
            {
                htmlContent.AppendLine($"    <h2>{label}</h2>");
                htmlContent.AppendLine($"    <ul>");

                string[] lines = sectionContent.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    // Assuming each line has the format "Ability: Value"
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string ability = parts[0].Trim();
                        string value = parts[1].Trim();
                        htmlContent.AppendLine($"        <li><strong>{ability}:</strong> {value}</li>");
                    }
                }

                htmlContent.AppendLine($"    </ul>");
            }
        }

        public string ExtractValueSection(string text, string sectionTag)
        {
            string startTag = $"**{sectionTag}**\n";
            string endTag = "\n";
            int startIndex = text.IndexOf(startTag) + startTag.Length;
            int endIndex = text.IndexOf(endTag, startIndex);

            if (startIndex >= 0 && endIndex >= 0)
            {
                string sectionContent = text.Substring(startIndex, endIndex - startIndex).Trim();
                return sectionContent;
            }

            return string.Empty;
        }

        public string ExtractValue(string text, string tag)
        {
            string startTag = $"**{tag}** - ";
            string endTag = "\n";
            int startIndex = text.IndexOf(startTag) + startTag.Length;
            int endIndex = text.IndexOf(endTag, startIndex);
            if (startIndex >= 0 && endIndex >= 0)
            {
                return text.Substring(startIndex, endIndex - startIndex).Trim();
            }
            return string.Empty;
        }
    }

}
