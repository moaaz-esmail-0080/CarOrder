﻿namespace Discount.Grpc.Models;

public class Coupon
{
    public int Id { get; set; }
    public string CarName { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int Amount { get; set; }
}
