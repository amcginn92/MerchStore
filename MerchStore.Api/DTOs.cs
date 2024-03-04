namespace MerchStore.Api.DTOs;

public record ProductDTO(
    int Id,
    string Name,
    string Category,
    decimal Price
);

public record CreateProductDTO(
    string Name,
    string Category,
    decimal Price

);

public record UpdateProductDTO(
    string Name,
    string Category,
    decimal Price

);