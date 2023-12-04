namespace Domain
{
    public class Specialization
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public string Name { get; init; }
    }
}