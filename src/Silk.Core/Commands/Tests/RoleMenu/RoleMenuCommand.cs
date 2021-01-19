﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Exceptions;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using Silk.Core.Commands.Tests.RoleMenu;
using Silk.Core.Database.Models;
using Silk.Core.Utilities;
using Silk.Extensions;
using Silk.Extensions.DSharpPlus;

namespace Silk.Core.Commands.Tests
{
    [Group("role_menu"), Aliases("rolemenu")]
    public class RoleMenuCommand : BaseCommandModule
    {
        
        [Command("create")]
        [Description("Create a role menu! \n(Note, if you're adding roles with spaces, you must put them in quotes (`\"\"`)!")]
        [RequireFlag(UserFlag.Staff)]
        public async Task CreateCommand(CommandContext ctx, [RemainingText] params DiscordRole[] roles)
        {
            var builder = new DiscordMessageBuilder();
            builder.WithoutMentions();
            
            if (!roles.Any()) throw new ArgumentException("Must provide roles to create role menu!");
            
            // Small easter egg for anyone that tries to add @everyone, I guess. Lol. //
            if (ctx.Message.MentionEveryone) // Not that iterating over a couple of elements is expensive, but checking a bool is still faster, and we use that instead. //
            {
                builder.WithContent("Haha, as much as I'd love to add @everyone to @everyone, everyone already has that role!\n" +
                                    "Anyway, let me see what I can do about the rest of the roles :)")
                    .WithReply(ctx.Message.Id, true)
                    .WithoutMentions();
                await ctx.RespondAsync(builder);
            }
            if (!await ShouldContinueAsync(ctx, roles)) return;


            DiscordMessage confirmationMessage;
            DiscordMessage menuMessage;
            DiscordMessage responseMessage; 
            
            RoleMenuInputResult inputResultObject;
            InteractivityExtension interactivity = ctx.Client.GetInteractivity();
            
            builder.WithContent($"So, {roles.Select(r => r.Mention).Join(", ")}, right?");
            
            confirmationMessage = await ctx.RespondAsync(builder);
            inputResultObject = await RoleMenuInputResult.GetConfirmationAsync(interactivity, ctx, confirmationMessage);
            
            if (!inputResultObject.Succeeded) return;

            await confirmationMessage.DeleteAllReactionsAsync();
            
            builder.WithContent("Alright. This menu should have a name. What should it be?");
            await confirmationMessage.ModifyAsync(builder);
            
            builder.WithContent("Role menu: **Unammed**");
            menuMessage = await ctx.RespondAsync(builder);
            
            inputResultObject = await RoleMenuInputResult.GetInputAsync(interactivity, ctx, confirmationMessage);
            if (!inputResultObject.Succeeded) return;
            
            responseMessage = (DiscordMessage) inputResultObject.Result!;
            builder.WithContent($"Role menu: **{responseMessage.Content}**");
            await responseMessage.DeleteAsync();
            await menuMessage.ModifyAsync(builder);

            IReadOnlyList<DiscordEmoji> emojis = await ctx.Guild.GetEmojisAsync();
            for (int i = 0; i < roles.Length; i++)
            {
                string currentMessage = $"What emoji should I use for {roles[i].Mention}? (React to this message!)";
                
                if (confirmationMessage.Content != currentMessage)
                {
                    builder.WithContent(currentMessage);
                    await confirmationMessage.ModifyAsync(builder);
                }
                inputResultObject = await RoleMenuInputResult.GetReactionAsync(interactivity, ctx, confirmationMessage);
                if (!inputResultObject.Succeeded)
                {
                    try
                    {
                        await responseMessage.DeleteAsync();
                        await confirmationMessage.DeleteAsync();
                    }
                    catch (NotFoundException) { }
                }
                var result = (DiscordEmoji)inputResultObject.Result!;
                if (result.Id is not 0)
                {
                    if (emojis.All(e => e.Id != result.Id))
                    {
                        builder.WithContent($"I can't use that emoji {ctx.User.Mention}!");
                        var forbiddenEmojiMessage = await ctx.RespondAsync(builder);
                        await Task.Delay(4000);
                        await forbiddenEmojiMessage.DeleteAsync();
                        i--;
                        continue;
                    }
                    await menuMessage.CreateReactionAsync(emojis.Single(e => e.Id == result.Id));
                    //Add emoji name + id here //
                }
                else {}
            }
            

            // Cleanup setup message //
            await confirmationMessage.DeleteAsync();
        }
        private async Task<bool> ShouldContinueAsync(CommandContext ctx, DiscordRole[] roles)
        {
            var builder = new DiscordMessageBuilder();
            IEnumerable<DiscordRole> higherBotRoles = roles.Where(r => r.Position >= ctx.Guild.CurrentMember.Hierarchy);
            IEnumerable<DiscordRole> higherUserRoles = roles.Where(r => r.Position > ctx.Member.Hierarchy);
            if (higherBotRoles.Any())
            {
                builder.WithContent($"I can't give out {higherBotRoles.Select(r => r.Mention).Join(", ")}, as they're higher than me!\n" +
                                    $"The rest of the roles will be put into the menu, however.");
                await ctx.RespondAsync(builder);
                roles = roles.Except(higherBotRoles).ToArray();
            }
            
            if (higherUserRoles.Any())
            {
                builder.WithContent($"I can't give out {higherUserRoles.Select(r => r.Mention).Join(", ")}, as they're higher than me!\n" +
                                    "The rest of the roles will be put into the menu, however.");
                await ctx.RespondAsync(builder);
                roles = roles.Except(higherUserRoles).OrderByDescending(r => r.Position).ToArray();
            }
            if (!roles.Any())
            {
                builder.WithContent("Looks like there aren't any roles to add :(");
                await ctx.RespondAsync(builder);
                return false;
            }
            return true;
        }
    }
}