﻿using Bot.Comandos;
using Bot.Extensions;
using Bot.Singletons;
using ConfigurationControler.Modelos;
using Discord.Commands;
using Discord.WebSocket;
using MainDatabaseControler.DAO;
using MainDatabaseControler.Modelos;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using static MainDatabaseControler.Modelos.ConfiguracoesServidor;

namespace Bot.Nucleo.Eventos
{
    public class MessageEvent
    {
        //MessageEvent v2 by Takasaki Masoquista do krai

        //configuracoes do MessageEvent
        private readonly Especiais lastClassComands = new Especiais();


        //Dependencia do MessagemEvent
        private readonly DiaConfig config;

        public MessageEvent(DiaConfig config)
        {
            this.config = config;
        }

        public Task MessageRecived(SocketMessage mensagem)
        {
            CriarSessaoComandos(mensagem);
            return Task.CompletedTask;
        }

        private void CriarSessaoComandos(SocketMessage message)
        {
            new Thread(() =>
            {
                SocketUserMessage socketUserMessage = message as SocketUserMessage;
                if (socketUserMessage != null)
                {
                    CommandContext contexto = new CommandContext(SingletonClient.client, socketUserMessage);
                    ControlarMensagens(contexto);
                }
            }).Start();
        }

        private void ControlarMensagens(CommandContext contexto)
        {
            if (!contexto.User.IsBot)
            {
                CadastrarServidorUsuarioAsync(contexto);
                PIEvent(contexto);
                Servidores servidores = PegarPrefixo(contexto);
                string comandoSemPrefix = null;
                if (SepararComandoPrefix(contexto, servidores, ref comandoSemPrefix))
                {
                    CallComando(comandoSemPrefix, servidores, contexto);
                }
                else
                {
                    if (IsMentionCall(contexto))
                    {
                        new Ajuda().MentionMessage(contexto, servidores);
                    }
                    else
                    {
                        new CustomReactions().TriggerACR(contexto, servidores);
                    }

                }
            }
        }

        private Servidores PegarPrefixo(CommandContext contexto)
        {
            if (!contexto.IsPrivate)
            {
                Servidores servFinal = new Servidores(contexto.Guild.Id, config.prefix.ToCharArray());
                Servidores servidores = servFinal;
                if (new ServidoresDAO().GetPrefix(ref servidores))
                {
                    servFinal = servidores;
                }
                return servFinal;
            }
            else
            {
                Servidores servidores = new Servidores(0, config.prefix.ToCharArray());
                return servidores;
            }


        }


        private bool SepararComandoPrefix(CommandContext contexto, Servidores servidor, ref string comandoSemPrefix)
        {
            int argPos = 0;
            if (contexto.Message.HasStringPrefix(new string(servidor.Prefix), ref argPos))
            {
                comandoSemPrefix = contexto.Message.Content.Substring(servidor.Prefix.Length);
                return !(comandoSemPrefix == "" || comandoSemPrefix[0] == servidor.Prefix[0]);
            }
            else
            {
                return false;
            }

        }

        private void CadastrarServidorUsuarioAsync(CommandContext context)
        {
            if (!context.IsPrivate)
            {
                new Thread(() =>
                {
                    new Servidores_UsuariosDAO().inserirServidorUsuario(new Servidores_Usuarios(new Servidores(context.Guild.Id, context.Guild.Name), new Usuarios(context.User.Id, context.User.ToString())));
                }).Start();
            }
        }

        private object[] CriadorDoArgs(string messagemSemPrefixo, ref string comando, Servidores servidor)
        {
            string[] stringComando = messagemSemPrefixo.Split(' ');
            comando = stringComando[0];
            object[] args = new object[3];
            args[0] = new string(servidor.Prefix);
            args[1] = stringComando;
            args[2] = new List<object>();
            return args;
        }

        private void CallComando(string comando, Servidores servidor, CommandContext contexto)
        {
            string chamada = null;
            object[] args = CriadorDoArgs(comando, ref chamada, servidor);
            try
            {
                MethodInfo metodoAChamar = lastClassComands.GetType().GetMethod(chamada);
                object[] parametros = new object[2];
                parametros[0] = contexto;
                parametros[1] = args;
                metodoAChamar.Invoke(lastClassComands, parametros);
            }
            catch (Exception e)
            {
                new Ajuda().MessageEventExceptions(e, contexto, servidor);
            }

        }

        private bool IsMentionCall(CommandContext contexto)
        {
            if (contexto.Message.Content == $"<@{SingletonClient.client.CurrentUser.Id}>" || contexto.Message.Content == $"<@!{SingletonClient.client.CurrentUser.Id}>")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void PIEvent(CommandContext contexto)
        {
            new Thread(() =>
            {
                Servidores server = new Servidores(contexto.Guild.Id, contexto.Guild.Name);
                Usuarios usuario = new Usuarios(contexto.User.Id, contexto.User.ToString(), 0);
                Servidores_Usuarios servidores_Usuarios = new Servidores_Usuarios(server, usuario);
                PontosInterativos pontos = new PontosInterativos(servidores_Usuarios, 0);
                PI pI = new PI();
                PontosInterativosDAO dao = new PontosInterativosDAO();
                if (dao.AdicionarPonto(ref pontos, ref pI))
                {
                    StringVarsControler varsControler = new StringVarsControler(contexto);
                    varsControler.AdicionarComplemento(new StringVarsControler.VarTypes("%pontos%", pontos.PI.ToString()));
                    new EmbedControl().SendMessage(contexto.Channel, varsControler.SubstituirVariaveis(pI.MsgPIUp));
                }
            }).Start();
        }
    }
}
