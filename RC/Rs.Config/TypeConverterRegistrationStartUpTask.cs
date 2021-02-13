using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rs.Common;

namespace Rs.Config
{
    public partial class TypeConverterRegistrationStartUpTask:IStartupTask
    {
        /// <summary>
        /// Executes a task
        /// </summary>
        public Task ExecuteAsync()
        {
            //lists
            //TypeDescriptor.AddAttributes(typeof(List<int>), new TypeConverterAttribute(typeof(GenericListTypeConverter<int>)));
            //TypeDescriptor.AddAttributes(typeof(List<decimal>), new TypeConverterAttribute(typeof(GenericListTypeConverter<decimal>)));
            //TypeDescriptor.AddAttributes(typeof(List<string>), new TypeConverterAttribute(typeof(GenericListTypeConverter<string>)));

            ////dictionaries
            //TypeDescriptor.AddAttributes(typeof(Dictionary<int, int>), new TypeConverterAttribute(typeof(GenericDictionaryTypeConverter<int, int>)));

            ////shipping option
            //TypeDescriptor.AddAttributes(typeof(ShippingOption), new TypeConverterAttribute(typeof(ShippingOptionTypeConverter)));
            //TypeDescriptor.AddAttributes(typeof(List<ShippingOption>), new TypeConverterAttribute(typeof(ShippingOptionListTypeConverter)));
            //TypeDescriptor.AddAttributes(typeof(IList<ShippingOption>), new TypeConverterAttribute(typeof(ShippingOptionListTypeConverter)));

            ////pickup point
            //TypeDescriptor.AddAttributes(typeof(PickupPoint), new TypeConverterAttribute(typeof(PickupPointTypeConverter)));

            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets order of this startup task implementation
        /// </summary>
        public int Order => 1;
    }
}
