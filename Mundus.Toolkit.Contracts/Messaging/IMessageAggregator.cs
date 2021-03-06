﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace MToolkit.Messaging
{
    /// <summary>
    ///   Enables loosely-coupled publication of and subscription to events asynchronous.
    /// </summary>
    public interface IMessageAggregator
    {
        /// <summary>
        /// Searches the subscribed handlers to check if we have a handler for
        /// the message type supplied, inherit types of <paramref name="messageType"/> are also consider.
        /// </summary>
        /// <param name="messageType">The message type to check with</param>
        /// <returns><c>true</c> if any handler is found, <c>false</c> otherwise.</returns>
        bool HandlerExistsFor(Type messageType);

        /// <summary>
        ///   Subscribes an instance to all events declared through implementations of <see cref = "IHandleAsync{TMessage}"/> asynchronous.
        /// </summary>
        /// <param name = "subscriber">The instance to subscribe for event publication.</param>
        Task SubscribeAsync(object subscriber);

        /// <summary>
        /// Subscribes an instance to all events declared through implementations of <see cref="IHandleAsync{TMessage}" /> asynchronous.
        /// </summary>
        /// <param name="subscriber">The instance to subscribe for event publication.</param>
        /// <param name="token">The <see cref="CancellationToken"/>.</param>
        /// <returns></returns>
        Task SubscribeAsync(object subscriber, CancellationToken token);

        /// <summary>
        ///   Unsubscribe the instance from all events asynchronous.
        /// </summary>
        /// <param name = "subscriber">The instance to unsubscribe.</param>
        Task UnsubscribeAsync(object subscriber);

        /// <summary>
        ///   Unsubscribe the instance from all events asynchronous.
        /// </summary>
        /// <param name = "subscriber">The instance to unsubscribe.</param>
        /// <param name="token">The <see cref="CancellationToken"/>.</param>
        Task UnsubscribeAsync(object subscriber, CancellationToken token);

        /// <summary>
        ///   Publishes a message on the current thread asynchronous.
        /// </summary>
        /// <param name = "message">The message instance.</param>
        Task PublishAsync(object message);


        /// <summary>
        ///   Publishes a message on the current thread asynchronous.
        /// </summary>
        /// <param name = "message">The message instance.</param>
        /// <param name="token">The <see cref="CancellationToken"/>.</param>
        Task PublishAsync(object message, CancellationToken token);
    }
}
