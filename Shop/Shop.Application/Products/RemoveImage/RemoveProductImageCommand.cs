using Common.Application;

namespace Shop.Application.Products.RemoveImage;

public record RemoveProductImageCommand(long productId, long imageId) : IBaseCommand;
