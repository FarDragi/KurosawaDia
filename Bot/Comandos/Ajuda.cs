﻿using Bot.Extensions;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading;

namespace Bot.Comandos
{
    public class Ajuda
    {
        public void ajuda(CommandContext context, object[] args)
        {
            context.Channel.SendMessageAsync(embed: new EmbedBuilder()
                .WithColor(Color.DarkPurple)
                .WithDescription($"Oii {context.User} você pode usar `{(string)args[0]}comandos` para ver os comandos que eu tenho <:hehe:555914678866280448>")
                .WithFooter("Um projeto by Zuraaa!", "https://i.imgur.com/Cm8grM4.png")
                .Build());
        }

        public void comandos(CommandContext context, object[] args)
        {
            try
            {
                string[] userMessage = (string[])args[1];
            }
            catch
            {
                ((IUserMessage)args[1]).DeleteAsync();
            }
            IUserMessage msg = context.Channel.SendMessageAsync(embed: new EmbedBuilder()
                        .WithTitle("Comandos atacaaaaar 😁")
                        .WithDescription("Use as reações para navegar pelos comandos 👍")
                        .AddField("Modulos:", "❓ Ajuda;\n🛠 Ultilidades;\n⚖ Moderação;\n🔞 NSFW;\n❤ Weeb;\n🖼 Imagens.")
                        .WithImageUrl("https://i.imgur.com/mQVFSrP.gif")
                        .WithColor(Color.DarkPurple)
                .Build()).GetAwaiter().GetResult();

            Emoji[] menu = new Emoji[6];
            menu[0] = new Emoji("❓");
            menu[1] = new Emoji("🛠");
            menu[2] = new Emoji("⚖");
            menu[3] = new Emoji("🔞");
            menu[4] = new Emoji("❤");
            menu[5] = new Emoji("🖼");

            msg.AddReactionsAsync(menu);

            args[1] = msg;
            ReactionControler reaction = new ReactionControler();
            args[2] = reaction;
            reaction.GetReaction(msg, menu[0], context.User, new ReturnMethod(help, context, args));
            reaction.GetReaction(msg, menu[1], context.User, new ReturnMethod(utilidade, context, args));
            reaction.GetReaction(msg, menu[2], context.User, new ReturnMethod(moderacao, context, args));
            reaction.GetReaction(msg, menu[3], context.User, new ReturnMethod(nsfw, context, args));
            reaction.GetReaction(msg, menu[4], context.User, new ReturnMethod(weeb, context, args));
            reaction.GetReaction(msg, menu[5], context.User, new ReturnMethod(img, context, args));

        }

        public void convite(CommandContext context, object[] args)
        {
            context.Channel.SendMessageAsync(embed: new EmbedBuilder()
                    .WithTitle("Aqui estão meus convites: ")
                    .WithDescription("[Me convide para o seu servidor](https://ayura.com.br/links/bot)\n[Entre no meu servidor](https://ayura.com.br/dia)") //shrug
                    .WithColor(Color.DarkPurple)
             .Build());
        }

        public void info(CommandContext context, object[] args)
        {
            DiscordSocketClient client = context.Client as DiscordSocketClient;
            int users = 0;
            foreach (SocketGuild servidor in client.Guilds)
            {
                users = servidor.Users.Count;
            }

            context.Channel.SendMessageAsync(embed: new EmbedBuilder()
                    .WithTitle("Minhas informações:")
                    .AddField("Meus convites", "[Me convide para o seu servidor](https://ayura.com.br/links/bot)\n[Entre no meu servidor](https://ayura.com.br/dia)")
                    .AddField("Informações do bot", "**Criador:** Yummi#1375\n**Projeto:** Zuraaa!\n**Versão:** 1.0.0", true)
                    .AddField("Outras Informações:", $"**Ping:** {client.Latency}ms\n**Servidores:** {client.Guilds.Count}\n**Usuarios:** {users}", true)
                    .WithColor(Color.DarkPurple)
                .Build());
        }

        private void help(CommandContext contexto, object[] args)
        {
            ((IUserMessage)args[1]).DeleteAsync();
            ((ReactionControler)args[2]).DesligarReaction();
            IUserMessage cmds = contexto.Channel.SendMessageAsync(embed: new EmbedBuilder()
                    .WithTitle("Modulo Ajuda (❓)")
                    .WithDescription("Esse modulo tem comandos para te ajudar na ultilização do bot. \n\nNão tenha medo eles não mordem 😉")
                    .WithColor(Color.DarkPurple)
                    .AddField("Comandos:", $"`{(string)args[0]}ajuda` `{(string)args[0]}comandos` `{(string)args[0]}info`")
                    .WithFooter("Voltar", "https://i.imgur.com/iAnGwW4.png")
                    .WithImageUrl("https://i.imgur.com/XQTVJu9.jpg")
                .Build()).GetAwaiter().GetResult();

            Emoji emoji = new Emoji("⬅");
            cmds.AddReactionAsync(emoji);

            ReactionControler reaction = new ReactionControler();
            args[1] = cmds;
            reaction.GetReaction(cmds, emoji, contexto.User, new ReturnMethod(comandos, contexto, args));
        }
        private void utilidade(CommandContext contexto, object[] args)
        {
            ((IUserMessage)args[1]).DeleteAsync();
            ((ReactionControler)args[2]).DesligarReaction();
            IUserMessage cmds = contexto.Channel.SendMessageAsync(embed: new EmbedBuilder()
                    .WithTitle("Modulo Ultilidades (🛠)")
                    .WithDescription("Esse modulo possui coisas uteis pro seu dia a dia. \n\nAaaaaaa eles são tão legais ☺")
                    .WithColor(Color.DarkPurple)
                    .AddField("Comandos:", $"`{(string)args[0]}videochamada`, `{(string)args[0]}avatar`, `{(string)args[0]}emote`, `{(string)args[0]}say`, `{(string)args[0]}simg`, `{(string)args[0]}setprefix`")
                    .WithFooter("Voltar", "https://i.imgur.com/iAnGwW4.png")
                    .WithImageUrl("https://i.imgur.com/TK7zmb8.jpg")
                .Build()).GetAwaiter().GetResult();

            Emoji emoji = new Emoji("⬅");
            cmds.AddReactionAsync(emoji);

            ReactionControler reaction = new ReactionControler();
            args[1] = cmds;
            reaction.GetReaction(cmds, emoji, contexto.User, new ReturnMethod(comandos, contexto, args));
        }
        private void moderacao(CommandContext contexto, object[] args)
        {
            ((IUserMessage)args[1]).DeleteAsync();
            ((ReactionControler)args[2]).DesligarReaction();
            IUserMessage cmds = contexto.Channel.SendMessageAsync(embed: new EmbedBuilder()
                    .WithTitle("Modulo Moderação (⚖)")
                    .WithDescription("Esse modulo possui coisas para te ajudar moderar seu servidor. \n\nSó não seja malvado com seus amigos 😲")
                    .WithColor(Color.DarkPurple)
                    .AddField("Comandos:", $"`{(string)args[0]}kick`, `{(string)args[0]}ban`, `{(string)args[0]}softban`")
                    .WithFooter("Voltar", "https://i.imgur.com/iAnGwW4.png")
                    .WithImageUrl("https://i.imgur.com/hiu0Vh0.jpg")
                .Build()).GetAwaiter().GetResult();

            Emoji emoji = new Emoji("⬅");
            cmds.AddReactionAsync(emoji);

            ReactionControler reaction = new ReactionControler();
            args[1] = cmds;
            reaction.GetReaction(cmds, emoji, contexto.User, new ReturnMethod(comandos, contexto, args));
        }
        private void nsfw(CommandContext contexto, object[] args)
        {
            ((IUserMessage)args[1]).DeleteAsync();
            ((ReactionControler)args[2]).DesligarReaction();
            IUserMessage cmds = contexto.Channel.SendMessageAsync(embed: new EmbedBuilder()
                    .WithTitle("Modulo NSFW (🔞)")
                    .WithDescription("Esse modulo possui coias para você dar orgulho para sua família. \n\nTenho medo dessas coisa😣")
                    .WithColor(Color.DarkPurple)
                    .AddField("Comandos:", $"`{(string)args[0]}hentai`, `{(string)args[0]}hentaibomb`, `{(string)args[0]}hneko`, `{(string)args[0]}anal`")
                    .WithFooter("Voltar", "https://i.imgur.com/iAnGwW4.png")
                    .WithImageUrl("https://i.imgur.com/iGQ3SI8.png")
                .Build()).GetAwaiter().GetResult();

            Emoji emoji = new Emoji("⬅");
            cmds.AddReactionAsync(emoji);

            ReactionControler reaction = new ReactionControler();
            args[1] = cmds;
            reaction.GetReaction(cmds, emoji, contexto.User, new ReturnMethod(comandos, contexto, args));
        }
        private void weeb(CommandContext contexto, object[] args)
        {
            ((IUserMessage)args[1]).DeleteAsync();
            ((ReactionControler)args[2]).DesligarReaction();
            IUserMessage cmds = contexto.Channel.SendMessageAsync(embed: new EmbedBuilder()
                    .WithTitle("Modulo Weeb (❤)")
                    .WithDescription("Esse modulo é o mais amoroso de todos.  \n\nUse ele para distribuir o amor para seus amigos❤")
                    .WithColor(Color.DarkPurple)
                    .AddField("Comandos:", $"`{(string)args[0]}hug`, `{(string)args[0]}slap`, `{(string)args[0]}kiss`, `{(string)args[0]}punch`, `{(string)args[0]}lick`, `{(string)args[0]}cry`, `{(string)args[0]}megumin`, `{(string)args[0]}rem`")
                    .WithFooter("Voltar", "https://i.imgur.com/iAnGwW4.png")
                    .WithImageUrl("https://i.imgur.com/FmCmErd.png")
                .Build()).GetAwaiter().GetResult();

            Emoji emoji = new Emoji("⬅");
            cmds.AddReactionAsync(emoji);

            ReactionControler reaction = new ReactionControler();
            args[1] = cmds;
            reaction.GetReaction(cmds, emoji, contexto.User, new ReturnMethod(comandos, contexto, args));
        }
        private void img(CommandContext contexto, object[] args)
        {
            ((IUserMessage)args[1]).DeleteAsync();
            ((ReactionControler)args[2]).DesligarReaction();
            IUserMessage cmds = contexto.Channel.SendMessageAsync(embed: new EmbedBuilder()
                    .WithTitle("Modulo Imagem (🖼)")
                    .WithDescription("Esse modulopossui imagens fofinhas para agraciar seu computador.  \n\nKawaiii ❤❤❤")
                    .WithColor(Color.DarkPurple)
                    .AddField("Comandos:", $"`{(string)args[0]}neko`, `{(string)args[0]}cat`, `{(string)args[0]}img`")
                    .WithFooter("Voltar", "https://i.imgur.com/iAnGwW4.png")
                    .WithImageUrl("https://i.imgur.com/cQqTUl1.png")
                .Build()).GetAwaiter().GetResult();

            Emoji emoji = new Emoji("⬅");
            cmds.AddReactionAsync(emoji);

            ReactionControler reaction = new ReactionControler();
            args[1] = cmds;
            reaction.GetReaction(cmds, emoji, contexto.User, new ReturnMethod(comandos, contexto, args));
        }
    }

    //gay
}
