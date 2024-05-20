namespace Linq.Model;

public partial class Sale
{
    public string StorId { get; set; } = null!;

    public string OrdNum { get; set; } = null!;

    public DateTime OrdDate { get; set; }

    public short Qty { get; set; }

    public string Payterms { get; set; } = null!;

    public string TitleId { get; set; } = null!;

    public virtual Store Stor { get; set; } = null!;

    public virtual Title Title { get; set; } = null!;

    public override string ToString()
    {
        return $"StorId: {StorId}, OrdNum: {OrdNum}, OrdDate: {OrdDate}, Qty: {Qty}, Payterms: {Payterms}, TitleId: {TitleId}";
    }
}
