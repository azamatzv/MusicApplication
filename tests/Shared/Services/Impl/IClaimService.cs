namespace Shared.Services.Impl;

public interface IClaimService
{
    string GetUserId();

    string GetClaim(string key);
}