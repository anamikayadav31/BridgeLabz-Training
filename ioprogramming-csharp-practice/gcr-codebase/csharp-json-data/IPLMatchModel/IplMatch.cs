using System.Collections.Generic;

public class IplMatch
{
    public int match_id { get; set; }
    public string team1 { get; set; }
    public string team2 { get; set; }
    public Dictionary<string, int> score { get; set; }
    public string winner { get; set; }
    public string player_of_match { get; set; }
}
