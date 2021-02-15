using Rs.Config;
using Rs.Config.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Server.Customers
{
    public static partial class RsCustomerServicesDefaults
    {
        /// <summary>
        /// Gets a password salt key size
        /// </summary>
        public static int PasswordSaltKeySize => 5;

        /// <summary>
        /// Gets a max username length
        /// </summary>
        public static int CustomerUsernameLength => 100;

        /// <summary>
        /// Gets a default hash format for customer password
        /// </summary>
        public static string DefaultHashedPasswordFormat => "SHA512";

        /// <summary>
        /// Gets default prefix for customer
        /// </summary>
        public static string CustomerAttributePrefix => "customer_attribute_";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : system name
        /// </remarks>
        public static CacheKey CustomerBySystemNameCacheKey => new CacheKey("Rs.customer.bysystemname.{0}");

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer GUID
        /// </remarks>
        public static CacheKey CustomerByGuidCacheKey => new CacheKey("Rs.customer.byguid.{0}");
        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer attribute ID
        /// </remarks>
        public static CacheKey CustomerAttributeValuesByAttributeCacheKey => new CacheKey("Rs.customerattributevalue.byattribute.{0}");
        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : show hidden records?
        /// </remarks>
        public static CacheKey CustomerRolesAllCacheKey => new CacheKey("Rs.customerrole.all.{0}", RsEntityCacheDefaults<CustomerRole>.AllPrefix);

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : system name
        /// </remarks>
        public static CacheKey CustomerRolesBySystemNameCacheKey => new CacheKey("Rs.customerrole.bysystemname.{0}", CustomerRolesBySystemNamePrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string CustomerRolesBySystemNamePrefix => "Rs.customerrole.bysystemname.";

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer identifier
        /// {1} : show hidden
        /// </remarks>
        public static CacheKey CustomerRoleIdsCacheKey => new CacheKey("Rs.customer.customerrole.ids.{0}-{1}", CustomerCustomerRolesPrefix);

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer identifier
        /// {1} : show hidden
        /// </remarks>
        public static CacheKey CustomerRolesCacheKey => new CacheKey("Rs.customer.customerrole.{0}-{1}", CustomerCustomerRolesByCustomerPrefix, CustomerCustomerRolesPrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string CustomerCustomerRolesPrefix => "Rs.customer.customerrole.";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        /// <remarks>
        /// {0} : customer identifier
        /// </remarks>
        public static string CustomerCustomerRolesByCustomerPrefix => "Rs.customer.customerrole.{0}";
        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer identifier
        /// </remarks>
        public static CacheKey CustomerAddressesCacheKey => new CacheKey("Rs.customer.addresses.{0}", CustomerAddressesPrefix);

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : customer identifier
        /// {1} : address identifier
        /// </remarks>
        public static CacheKey CustomerAddressCacheKey => new CacheKey("Rs.customer.addresses.address.{0}-{1}", CustomerAddressesByCustomerPrefix, CustomerAddressesPrefix);

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        public static string CustomerAddressesPrefix => "Rs.customer.addresses.";

        /// <summary>
        /// Gets a key pattern to clear cache
        /// </summary>
        /// <remarks>
        /// {0} : customer identifier
        /// </remarks>
        public static string CustomerAddressesByCustomerPrefix => "Rs.customer.addresses.{0}";
        /// <summary>
        /// Gets a key for caching current customer password lifetime
        /// </summary>
        /// <remarks>
        /// {0} : customer identifier
        /// </remarks>
        public static CacheKey CustomerPasswordLifetimeCacheKey => new CacheKey("Rs.customerpassword.lifetime.{0}");
    }
}
