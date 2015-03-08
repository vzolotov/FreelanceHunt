using System;
namespace FreelanceHunt.Service
{
    public interface IConfigService
    {
        string Token { get; set; }
        string Secret { get; set; }
    }
}
