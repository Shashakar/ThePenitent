namespace ThePenitent.ThePenitentCode.Scale;

public readonly record struct PenitentScale(decimal Value)
{
    public static PenitentScale Neutral => new(0M);

    public decimal Faith => Value > 0M ? Value : 0M;

    public decimal Burden => Value < 0M ? -Value : 0M;

    public bool HasFaith => Faith > 0M;

    public bool HasBurden => Burden > 0M;

    public static PenitentScale FromFaith(decimal amount)
    {
        return amount > 0M ? new PenitentScale(amount) : Neutral;
    }

    public static PenitentScale FromBurden(decimal amount)
    {
        return amount > 0M ? new PenitentScale(-amount) : Neutral;
    }

    public PenitentScale Ascend(decimal amount)
    {
        return amount > 0M ? new PenitentScale(Value + amount) : this;
    }

    public PenitentScale Descend(decimal amount)
    {
        return amount > 0M ? new PenitentScale(Value - amount) : this;
    }
}
