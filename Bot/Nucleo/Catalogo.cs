﻿using Bot.Nucleo.Modulos;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weeb.net;

namespace Bot.Nucleo
{
    public class Catalogo
    {
        public async Task IrComando(CommandContext contexto, DiscordSocketClient client, SocketMessage sock, string[] comando, WeebClient weebClient)
        {
            switch(comando[0])
            {
                case "ping":
                    await new Teste(contexto).Ping(client);
                    break;
                case "avatar":
                    await new Teste(contexto).Avatar(client, comando);
                    break;
                case "hug":
                    await new WeebCmds(contexto, comando).Hug(weebClient);
                    break;
                case "weeb":
                    await new WeebCmds(contexto, comando).Weeb(weebClient, comando);
                    break;
            }
        }
    }
}