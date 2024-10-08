﻿using SalesDatePrediction.Application.Models.Requests;
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Shared.Wrapper;

namespace SalesDatePrediction.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Result<int>> CreateOrderAsync(OrderRequest orderRequest);
        Task<PaginatedResult<OrderResponse>> GetOrderPagedListByCustIdAsync(OrderQueryFilterRequest filterRequest);
    }
}
