namespace Fridge.Models.Contracts
{
    /// <summary>
    /// For sorting purpose, to have ability to arrange entities in some way
    /// </summary>
    public interface IPositionable
    {
        int Position { get; set; }
    }
}
