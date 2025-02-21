﻿using CarBasket.API.Models;

namespace CarBasket.API.Data;

public interface ICarBasketRepository
{
    Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default);
    Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default);
    Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default);
}
