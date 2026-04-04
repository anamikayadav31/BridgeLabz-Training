namespace UnitTestingPractice
{
    public class StringUtils
    {
        public string Reverse(string str)
        {
            if (str == null) return null!;

            char[] chars = str.ToCharArray();
            System.Array.Reverse(chars);
            return new string(chars);
        }

        public bool IsPalindrome(string str)
        {
            if (str == null) return false;

            string reversed = Reverse(str);
            return str.Equals(reversed, System.StringComparison.OrdinalIgnoreCase);
        }

        public string ToUpperCase(string str)
        {
            if (str == null) return null!;
            return str.ToUpper();
        }
    }
}
