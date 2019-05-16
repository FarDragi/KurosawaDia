﻿using Bot.Comandos;
using Bot.DAO;
using Bot.Modelos;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Bot.Nucleo.Eventos
{
    public class MessageEvent
    {
        private readonly AyuraConfig config;
        private readonly DiscordSocketClient client;

        public MessageEvent(DiscordSocketClient client, AyuraConfig config)
        {
            this.client = client;
            this.config = config;
        }

        public async Task MessageRecived(SocketMessage mensagem)
        {
            SocketUserMessage mensagemTratada = mensagem as SocketUserMessage;
            CommandContext commandContex = new CommandContext(client, mensagemTratada);

            if (!mensagem.Author.IsBot)
            {
                int argPos = 0;
                if (mensagemTratada.HasStringPrefix(new string(config.prefix), ref argPos))
                {
                    string messageSemPrefix = mensagem.Content.Substring(config.prefix.Length);

                    if (messageSemPrefix != "" && messageSemPrefix[0] != config.prefix[0])
                    {
                        try
                        {
                            //{
                            ApiConfig ApiConfig = new ApiConfig(1);
                            ApiConfigDAO ApiDao = new ApiConfigDAO();
                            ApiConfig = ApiDao.Carregar(ApiConfig);
                            //} refaz
                            string[] comando = messageSemPrefix.Split(' ');
                            var lastClassCommand = new Utility();
                            MethodInfo metodo = lastClassCommand.GetType().GetMethod(comando[0]);
                            object instanced = lastClassCommand;
                            object[] parametros = new object[2];
                            parametros[0] = commandContex;
                            object[] args = new object[3];
                            args[0] = new string(config.prefix);
                            args[1] = comando;
                            args[2] = ApiConfig; //jesus
                            parametros[1] = args;

                            metodo.Invoke(instanced, parametros);
                        }
                        catch
                        {
                            await commandContex.Channel.SendMessageAsync(embed: new EmbedBuilder()
                                    .WithDescription($"**{commandContex.User}** comando não encontrado use `{new string(config.prefix)}comandos` para ver os meus comandos")
                                    .WithColor(Color.DarkPurple)
                                .Build());
                        } 
                    }
                }
                if (commandContex.Message.Content == $"<@{client.CurrentUser.Id}>" || commandContex.Message.Content == $"<@!{client.CurrentUser.Id}>")
                {
                    await commandContex.Channel.SendMessageAsync(embed: new EmbedBuilder()
                            .WithDescription($"Oii {commandContex.User.Username} meu prefixo é: `{new string(config.prefix)}` se quiser ver meus comando é so usar: `{new string(config.prefix)}comandos`")
                            .WithColor(Color.DarkPurple)
                        .Build());
                }
            }
        }
    }
}
