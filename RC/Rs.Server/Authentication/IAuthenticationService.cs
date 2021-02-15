using Rs.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rs.Server
{
    public partial interface IAuthenticationService
    {
        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="isPersistent">Whether the authentication session is persisted across multiple requests</param>
        Task SignInAsync(Customer customer, bool isPersistent);

        /// <summary>
        /// Sign out
        /// </summary>
        Task SignOutAsync();

        /// <summary>
        /// Get authenticated customer
        /// </summary>
        /// <returns>Customer</returns>
        Task<Customer> GetAuthenticatedCustomerAsync();
    }
}
