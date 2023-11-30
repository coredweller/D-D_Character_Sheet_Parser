# D-D_Character_Sheet_Parser
Takes D&amp;D character sheets from a specific JSON template (AI Generated) and turns into a HTML page for the DM

It takes Input location in the form of:
  1. Input location: F:\Projects\D&D AI Char Generator Formatter\src\D&DCharacterFormatter\Input\Jaja.txt
  2. Output Location: F:\Projects\D&D AI Char Generator Formatter\src\D&DCharacterFormatter\Output
  3. Output filename: Jaja.html

JSON Template Example:

{
  "CharacterName": "Bog Elemental",
  "Level": 5,
  "Race": "Elemental",
  "Class": "Nature Incarnate",
  "Alignment": "Neutral",
  "Background": "Bog Guardian",
  "HP": "68 (8d10+20 Hit Dice)",
  "AC": 15,
  "Speed": "20 ft., swim 40 ft.",
  "AbilityScores": {
    "Strength": { "Score": 18, "Modifier": "+4" },
    "Dexterity": { "Score": 10, "Modifier": "+0" },
    "Constitution": { "Score": 14, "Modifier": "+2" },
    "Intelligence": { "Score": 6, "Modifier": "-2" },
    "Wisdom": { "Score": 12, "Modifier": "+1" },
    "Charisma": { "Score": 7, "Modifier": "-2" }
  },
  "SavingThrows": {
    "Strength": "+6",
    "Constitution": "+4"
  },
  "Skills": {
    "Perception": "+3",
    "Nature": "+1",
    "Stealth": "+2"
  },
  "Senses": "Darkvision 60 ft., Passive Perception 13",
  "Languages": "Primordial",
  "SpecialTraits": {
    "Amphibious": "Can breathe air and water.",
    "Elemental Resilience": "Immune to poison, exhaustion, and being paralyzed; Resistant to bludgeoning, piercing, and slashing damage from nonmagical attacks."
  },
  "Actions": {
    "Slam": "Melee Weapon Attack: +6 to hit, reach 5 ft., one target. Hit: 2d8 + 4 bludgeoning damage.",
    "Mud Sling": "Ranged Weapon Attack: +3 to hit, range 30/60 ft., one target. Hit: 1d6 + 1 bludgeoning damage. On a hit, the target must succeed on a DC 12 Strength saving throw or be restrained until the start of the elemental's next turn."
  },
  "Features": {
    "Bog Aura": "Creatures within 10 feet of the elemental have their speed reduced by 10 feet and must succeed on a DC 12 Strength saving throw or be restrained if they end their turn in the aura."
  },
  "Equipment": {
    "Description": "None"
  },
  "Notes": "The Bog Elemental is a guardian of the marshlands, embodying the essence of the bog. It moves silently through the muck, using its elemental powers to control mud and water. The elemental is indifferent to the affairs of other creatures but will fiercely protect its swampy domain."
}


AND TURNS IT INTO HTML LIKE THE BELOW:


<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Character Sheet</title>
</head>
<body>
<h1>Character Details</h1>
<ul>
  <li><strong>CharacterName:</strong> Jaja</li>
  <li><strong>Level:</strong> 9</li>
  <li><strong>Race:</strong> Beast (Magical Giant Panther)</li>
  <li><strong>Class:</strong> Beast Companion</li>
  <li><strong>Alignment:</strong> Neutral</li>
  <li><strong>Background:</strong> Magical Creature</li>
  <li><strong>HP:</strong> 90 (9d10 Hit Dice)</li>
  <li><strong>AC:</strong> 14</li>
  <li><strong>Speed:</strong> 50 ft., climb 40 ft.</li>
  <li><h2>AbilityScores:</h2></li>
  <ul>
    <li>Strength: 18 (+4)</li>
    <li>Dexterity: 16 (+3)</li>
    <li>Constitution: 14 (+2)</li>
    <li>Intelligence: 3 (-4)</li>
    <li>Wisdom: 12 (+1)</li>
    <li>Charisma: 7 (-2)</li>
  </ul>
  <li><h2>SavingThrows:</h2></li>
  <li><strong>Strength:</strong> +6</li>
  <li><strong>Dexterity:</strong> +5</li>
  <li><h2>Skills:</h2></li>
  <li><strong>Perception:</strong> +3</li>
  <li><strong>Stealth:</strong> +7</li>
  <li><strong>Athletics:</strong> +6</li>
  <li><strong>Senses:</strong> Darkvision 60 ft., Passive Perception 13</li>
  <li><strong>Languages:</strong> None</li>
  <li><h2>SpecialTraits:</h2></li>
  <li><strong>KeenSmell:</strong> The panther has advantage on Wisdom (Perception) checks that rely on smell.</li>
  <li><strong>Pounce:</strong> If the panther moves at least 20 feet straight toward a creature and then hits it with a claw attack on the same turn, that target must succeed on a DC 14 Strength saving throw or be knocked prone.</li>
  <li><strong>MagicalResistance:</strong> The panther has advantage on saving throws against spells and other magical effects.</li>
  <li><h2>Actions:</h2></li>
  <li><strong>Multiattack:</strong> The panther makes two attacks: one with its bite and one with its claws.</li>
  <li><strong>Bite:</strong> Melee Weapon Attack: +7 to hit, reach 5 ft., one target. Hit: 1d8 + 4 piercing damage.</li>
  <li><strong>Claw:</strong> Melee Weapon Attack: +7 to hit, reach 5 ft., one target. Hit: 2d6 + 4 slashing damage.</li>
  <li><h2>Reactions:</h2></li>
  <li><strong>UncannyDodge:</strong> When an attacker the panther can see hits it with an attack, it can use its reaction to halve the attack's damage against it.</li>
  <li><h2>Features:</h2></li>
  <li><strong>MagicalBond:</strong> Jaja is magically bonded to a specific individual or group and shares a telepathic link with them.</li>
  <li><h2>Equipment:</h2></li>
  <li><strong>Description:</strong> None (but may have magical accessories or items based on the campaign)</li>
  <li><strong>Notes:</strong> Jaja is a magical giant panther with enhanced intelligence and mystical abilities. As a companion, it follows the commands of its bonded ally and acts with loyalty and protectiveness. Customize its background, appearance, and any magical properties based on the narrative and campaign requirements.</li>
</ul>
</body>
</html>


