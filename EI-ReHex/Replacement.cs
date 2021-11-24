namespace EIReHex
{
    public class Replacement
    {
        public string Name { get; private set; }
        public string Subject { get; private set; }
        public string Substitution { get; private set; }
        public int Offset { get; private set; }

        public Replacement(string name, string subject, string substitution, int offset = 0)
        {
            Name = name;
            Subject = subject;
            Substitution = substitution;
            Offset = offset;
        }
    }
}
