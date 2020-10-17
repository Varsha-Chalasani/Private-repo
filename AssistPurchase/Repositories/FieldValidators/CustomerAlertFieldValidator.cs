﻿using System;
using System.Collections.Generic;
using AssistPurchase.Models;
using AssistPurchase.Repositories.Implementations;

namespace AssistPurchase.Repositories.FieldValidators
{
    public class CustomerAlertFieldValidator
    {
        private readonly CommonFieldValidator _validator = new CommonFieldValidator();
        private readonly ProductDbRepository _repo = new ProductDbRepository();
        public void ValidateCustomerAlertFields(CustomerAlert alert)
        {
            _validator.IsWhitespaceOrEmptyOrNull(alert.ProductId);
            _validator.IsWhitespaceOrEmptyOrNull(alert.CustomerName);
            _validator.IsWhitespaceOrEmptyOrNull(alert.PhoneNumber);
            _validator.IsWhitespaceOrEmptyOrNull(alert.CustomerEmailId);
            ValidateOldProductId(alert.ProductId);
        }

        private void ValidateOldProductId(string productId)
        {
            var products = _repo.GetAllProducts();
            foreach (var product in products)
            {
                if (product.ProductId == productId)
                {
                    return;
                }
            }

            throw new Exception("Invalid data filed");
        }

        public void ValidateOldCustomerId(string customerId, IEnumerable<CustomerAlert> customers)
        {
            
            foreach (var customer in customers)
            {
                if (customer.CustomerId == customerId)
                {
                    return;
                }
            }

            throw new Exception("Invalid data filed");
        }
    }
}
