using System;
using System.IO;
using System.Text;

namespace D_DCharacterFormatter
{
    public class CharacterSheetGenerator
    {
        public string ReadCharacterFile(string fileLocation)
        {
            StringBuilder characterData = new StringBuilder();
            using (StreamReader reader = new StreamReader(fileLocation))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    characterData.AppendLine(line);
                }
            }
            return characterData.ToString();
        }

        public void GenerateHtml(string characterData)
        {
            string htmlContent = $@"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>{GetCharacterName(characterData)} - Level {GetLevel(characterData)} Magical Giant Panther</title>
    <style>
        body {{
            font-family: 'Arial', sans-serif;
            margin: 20px;
        }}
        h1, h2, h3 {{
            color: #333;
        }}
        table {{
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }}
        th, td {{
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }}
        th {{
            background-color: #f2f2f2;
        }}
    </style>
</head>
<body>
    <h1>{GetCharacterName(characterData)} - Level {GetLevel(characterData)} Magical Giant Panther</h1>
    <h2>Statistics</h2>
    <table>
        <tr>
            <th>HP</th>
            <td>{GetHP(characterData)}</td>
            <th>AC</th>
            <td>{GetAC(characterData)}</td>
        </tr>
        <tr>
            <th>Speed</th>
            <td>{GetSpeed(characterData)}</td>
            <th>Languages</th>
            <td>{GetLanguages(characterData)}</td>
        </tr>
    </table>

    <h2>Abilities</h2>
    <table>
        <tr>
            <th>Strength</th>
            <td>{GetStrength(characterData)}</td>
            <th>Dexterity</th>
            <td>{GetDexterity(characterData)}</td>
        </tr>
        <tr>
            <th>Constitution</th>
            <td>{GetConstitution(characterData)}</td>
            <th>Intelligence</th>
            <td>{GetIntelligence(characterData)}</td>
        </tr>
        <tr>
            <th>Wisdom</th>
            <td>{GetWisdom(characterData)}</td>
            <th>Charisma</th>
            <td>{GetCharisma(characterData)}</td>
        </tr>
    </table>

    <h2>Saving Throws and Skills</h2>
    <table>
        <tr>
            <th>Saving Throws</th>
            <td>{GetSavingThrows(characterData)}</td>
        </tr>
        <tr>
            <th>Skills</th>
            <td>{GetSkills(characterData)}</td>
        </tr>
    </table>

    <h2>Senses</h2>
    <p>{GetSenses(characterData)}</p>

    <h2>Special Traits</h2>
    <p>{GetSpecialTraits(characterData)}</p>

    <h2>Actions</h2>
    <table>
        <tr>
            <th>Actions</th>
            <td>{GetActions(characterData)}</td>
        </tr>
    </table>

    <h2>Reactions</h2>
    <table>
        <tr>
            <th>Reactions</th>
            <td>{GetReactions(characterData)}</td>
        </tr>
    </table>

    <h2>Features</h2>
    <p>{GetFeatures(characterData)}</p>

    <h2>Equipment</h2>
    <p>{GetEquipment(characterData)}</p>

    <h2>Notes</h2>
    <p>{GetNotes(characterData)}</p>
</body>
</html>
";

            string characterName = GetCharacterName(characterData);
            File.WriteAllText($"./Output/{characterName}_character_sheet.html", htmlContent);
        }

        public string GetCharacterName(string characterData)
        {
            return ExtractValue(characterData, "character_name");
        }

        static int GetLevel(string characterData)
        {
            return int.Parse(ExtractValue(characterData, "level"));
        }

        static string GetHP(string characterData)
        {
            return ExtractValue(characterData, "hp");
        }

        static string GetAC(string characterData)
        {
            return ExtractValue(characterData, "ac");
        }

        static string GetSpeed(string characterData)
        {
            return ExtractValue(characterData, "speed");
        }

        static string GetLanguages(string characterData)
        {
            return ExtractValue(characterData, "languages");
        }

        static string GetStrength(string characterData)
        {
            return ExtractValue(characterData, "strength");
        }

        static string GetDexterity(string characterData)
        {
            return ExtractValue(characterData, "dexterity");
        }

        static string GetConstitution(string characterData)
        {
            return ExtractValue(characterData, "constitution");
        }

        static string GetIntelligence(string characterData)
        {
            return ExtractValue(characterData, "intelligence");
        }

        static string GetWisdom(string characterData)
        {
            return ExtractValue(characterData, "wisdom");
        }

        static string GetCharisma(string characterData)
        {
            return ExtractValue(characterData, "charisma");
        }

        static string GetSavingThrows(string characterData)
        {
            return ExtractValue(characterData, "saving_throws");
        }

        static string GetSkills(string characterData)
        {
            return ExtractValue(characterData, "skills");
        }

        static string GetSenses(string characterData)
        {
            return ExtractValue(characterData, "senses");
        }

        static string GetSpecialTraits(string characterData)
        {
            return ExtractValue(characterData, "special_traits");
        }

        static string GetActions(string characterData)
        {
            return ExtractValue(characterData, "actions");
        }

        static string GetReactions(string characterData)
        {
            return ExtractValue(characterData, "reactions");
        }

        static string GetFeatures(string characterData)
        {
            return ExtractValue(characterData, "features");
        }

        static string GetEquipment(string characterData)
        {
            return ExtractValue(characterData, "equipment");
        }

        static string GetNotes(string characterData)
        {
            return ExtractValue(characterData, "notes");
        }

        static string ExtractValue(string text, string key)
        {
            string startTag = $"**{key}**";
            string endTag = $"**/{key}**";
            int startIndex = text.IndexOf(startTag) + startTag.Length;
            int endIndex = text.IndexOf(endTag, startIndex);
            if (startIndex >= 0 && endIndex >= 0)
            {
                return text.Substring(startIndex, endIndex - startIndex);
            }
            return string.Empty;
        }
    }
}
