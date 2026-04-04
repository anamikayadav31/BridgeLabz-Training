using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

class CensorIplJson
{
    static void Main()
    {
        var matches = JsonConvert.DeserializeObject<List<IplMatch>>
            (File.ReadAllText("ipl.json"));

        foreach (var m in matches)
        {
            m.team1 = MaskTeamName.Mask(m.team1);
            m.team2 = MaskTeamName.Mask(m.team2);
            m.winner = MaskTeamName.Mask(m.winner);
            m.player_of_match = "REDACTED";

            var newScore = new Dictionary<string, int>();
            foreach (var s in m.score)
                newScore[MaskTeamName.Mask(s.Key)] = s.Value;

            m.score = newScore;
        }

        File.WriteAllText("ipl_censored.json",
            JsonConvert.SerializeObject(matches, Formatting.Indented));
    }
}
