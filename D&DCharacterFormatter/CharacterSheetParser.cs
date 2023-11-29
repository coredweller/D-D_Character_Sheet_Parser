using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_DCharacterFormatter
{
    internal class CharacterSheetParser
    {

        public string GenerateHtml(JObject characterData)
        {
            StringBuilder htmlContent = new StringBuilder();

            // Start HTML document
            htmlContent.AppendLine("<!DOCTYPE html>");
            htmlContent.AppendLine("<html lang=\"en\">");
            htmlContent.AppendLine("<head>");
            htmlContent.AppendLine("<meta charset=\"UTF-8\">");
            htmlContent.AppendLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            htmlContent.AppendLine("<title>Character Sheet</title>");
            htmlContent.AppendLine("</head>");
            htmlContent.AppendLine("<body>");

            // Add character details
            htmlContent.AppendLine("<h1>Character Details</h1>");
            htmlContent.AppendLine("<ul>");
            foreach (var property in characterData.Properties())
            {
                if (property.Value.Type == JTokenType.Object)
                {
                    htmlContent.AppendLine($"  <li><h2>{property.Name}:</h2></li>");
                    if (property.Name == "AbilityScores")
                    {
                        htmlContent.AppendLine("  <ul>");
                        foreach (var abilityScore in ((JObject)property.Value).Properties())
                        {
                            var scoreValue = abilityScore.Value["Score"];
                            var modifierValue = abilityScore.Value["Modifier"];
                            htmlContent.AppendLine($"    <li>{abilityScore.Name}: {scoreValue} ({modifierValue})</li>");
                        }
                        htmlContent.AppendLine("  </ul>");
                    }
                    else
                    {
                        foreach (var nestedProperty in ((JObject)property.Value).Properties())
                        {
                            htmlContent.AppendLine($"  <li><strong>{nestedProperty.Name}:</strong> {nestedProperty.Value}</li>");
                        }
                    }
                }
                else
                {
                    htmlContent.AppendLine($"  <li><strong>{property.Name}:</strong> {property.Value}</li>");
                }
            }
            htmlContent.AppendLine("</ul>");

            // End HTML document
            htmlContent.AppendLine("</body>");
            htmlContent.AppendLine("</html>");

            return htmlContent.ToString();
        }
    }
}
