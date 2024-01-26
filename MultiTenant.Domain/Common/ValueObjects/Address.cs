namespace MultiTenant.Domain.Common.ValueObjects;

public sealed class Address : ValueObject
{
    public string LineOne { get; set; } = string.Empty;
    public string LineTwo { get; set; } = string.Empty;
    public string LineThree { get; set; } = string.Empty;
    public string PostCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return LineOne;
        yield return LineTwo;
        yield return LineThree;
        yield return PostCode;
        yield return Country;
    }
}