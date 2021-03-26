namespace SpacePark
{
    public interface IPerson
    {
        int Id { get; set; }
        string Name { get; set; }
        Vehicle Vehicle { get; set; }
    }
}