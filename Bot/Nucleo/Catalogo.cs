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
        public async Task IrComando(CommandContext contexto, DiscordSocketClient client, SocketMessage sock, string[] comando)
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
                    await new weebCmds(contexto, comando).Hug(); //mano olha o quanto isso ai ta andando em 200 classes pra n ter usooooooo (erronea)
                    break;
                case "weeb":
                    await new weebCmds(contexto, comando).Weeb(comando); // dnv aki
                    break;
            }
        }
    }
}
