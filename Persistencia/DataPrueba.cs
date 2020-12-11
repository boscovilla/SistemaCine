using Dominio;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
   public class DataPrueba
    {
        public static async Task InsertarData(SistemaCineContext context, UserManager<Usuario> usuarioManager)
        {
            if (!usuarioManager.Users.Any())
            {
                var usuario = new Usuario
                {
                    NombreCompleto = "Juan Bosco",
                    UserName = "boscovilla",
                    Email = "boscovilla@hotmail.com"

                };
                await usuarioManager.CreateAsync(usuario, "Pasword1234$");
            }

        }
    }
}
