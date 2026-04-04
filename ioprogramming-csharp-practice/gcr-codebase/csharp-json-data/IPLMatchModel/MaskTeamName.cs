public class MaskTeamName
{
    public static string Mask(string team)
    {
        var p = team.Split(' ');
        return p[0] + " ***";
    }
}
