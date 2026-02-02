using System.IO;
using System.Linq;
using System.Collections.Generic;

class CensorIplCsv
{
    static void Main()
    {
        var rows = File.ReadAllLines("ipl.csv").Skip(1);
        List<string> output = new()
        {
            "match_id,team1,team2,score_team1,score_team2,winner,player_of_match"
        };

        foreach (var r in rows)
        {
            var p = r.Split(',');
            p[1] = MaskTeamName.Mask(p[1]);
            p[2] = MaskTeamName.Mask(p[2]);
            p[5] = MaskTeamName.Mask(p[5]);
            p[6] = "REDACTED";

            output.Add(string.Join(",", p));
        }

        File.WriteAllLines("ipl_censored.csv", output);
    }
}
