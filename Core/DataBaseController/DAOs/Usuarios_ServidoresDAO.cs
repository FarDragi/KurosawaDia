﻿using DataBaseController.Contexts;
using DataBaseController.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseController.DAOs
{
    public sealed class Usuarios_ServidoresDAO
    {
        public async Task<Servidores> Add(Servidores_Usuarios su)
        {
            using (Kurosawa_DiaContext context = new Kurosawa_DiaContext())
            {
                return (await context.Servidores.FromSqlRaw("call CadastrarUsuarioServidor({0}, {1}, {2}, {3})", su.Servidor.ID, su.Usuario.ID, su.Servidor.Nome, su.Usuario.Nome).ToListAsync()).FirstOrDefault();      
            }
        }
    }
}


//IDbContextTransaction transation = await context.Database.BeginTransactionAsync(IsolationLevel.Snapshot);
//await context.Database.ExecuteSqlRawAsync("call CadastrarUsuarioServidor({0}, {1}, {2}, {3})", su.Servidor.ID, su.Usuario.ID, su.Servidor.Nome, su.Usuario.Nome);
//await transation.CommitAsync();
//context.AdmsBots.fro
//MySqlCommand cmd = await context.GetMysqlCommand();
//cmd.CommandText = "call CadastrarUsuarioServidor(@si, @ui, @sn, @un)";
//cmd.Parameters.AddWithValue("@si", su.Servidor.ID);
//cmd.Parameters.AddWithValue("@ui", su.Usuario.ID);
//cmd.Parameters.AddWithValue("@sn", su.Servidor.Nome);
//cmd.Parameters.AddWithValue("@un", su.Usuario.Nome);
//await cmd.ExecuteNonQueryAsync();