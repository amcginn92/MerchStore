using MerchStore.Api.DTOs;

namespace MerchStore.Api.Entities;

public static class EntityExtensions
{
    public static ProductDTO AsDTO(this Product prod)
    {
        return new ProductDTO(
            prod.Id,
            prod.Name,
            prod.Category,
            prod.Price
        );
    }

}