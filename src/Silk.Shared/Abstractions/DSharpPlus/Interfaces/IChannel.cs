﻿using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace Silk.Shared.Abstractions.DSharpPlus.Interfaces
{
    /// <summary>
    ///     Represents a mockable abstraction of a <see cref="DiscordChannel" />.
    /// </summary>
    public interface IChannel
    {
        /// <summary>
        ///     The id of the current channel.
        /// </summary>
        public ulong Id { get; }

        public string Mention => $"<#{Id}>";

        /// <summary>
        /// Whether the channel is a DM or server channel.
        /// </summary>
        public bool IsPrivate { get; }

        /// <summary>
        /// The Guild this channel belongs to, if any. 
        /// </summary>
        public IGuild? Guild { get; }

        /// <summary>
        ///     Gets a specific message from the channel.
        /// </summary>
        /// <param name="id">The Id of the message to retrieve.</param>
        /// <returns>An <see cref="IMessage" /> if the message exists, otherwise null.</returns>
        public Task<IMessage?> GetMessageAsync(ulong id);


    }
}