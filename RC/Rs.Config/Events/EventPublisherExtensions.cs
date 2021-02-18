using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Config
{
    public static partial class EventPublisherExtensions
    {
        /// <summary>
        /// Entity inserted
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="eventPublisher">Event publisher</param>
        /// <param name="entity">Entity</param>
        public static async Task EntityInsertedAsync<T>(this IEventPublisher eventPublisher, T entity) where T : BaseEntity
        {
            await eventPublisher.PublishAsync(new EntityInsertedEvent<T>(entity));
        }

        /// <summary>
        /// Entity updated
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="eventPublisher">Event publisher</param>
        /// <param name="entity">Entity</param>
        public static async Task EntityUpdatedAsync<T>(this IEventPublisher eventPublisher, T entity) where T : BaseEntity
        {
            await eventPublisher.PublishAsync(new EntityUpdatedEvent<T>(entity));
        }

        /// <summary>
        /// Entity deleted
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="eventPublisher">Event publisher</param>
        /// <param name="entity">Entity</param>
        public static async Task EntityDeletedAsync<T>(this IEventPublisher eventPublisher, T entity) where T : BaseEntity
        {
            await eventPublisher.PublishAsync(new EntityDeletedEvent<T>(entity));
        }
    }
}
