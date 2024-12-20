﻿using Microsoft.EntityFrameworkCore;
using ReserveAqui.Core.Interfaces.Repositories.AdministradorRepository;
using ReserveAqui.Core.Models;
using ReserveAqui.Infra.Config.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveAqui.Infra.Config.Repositories.AdministradorRepository;

public class AdministradorRepository : BaseRepository<Administrador>, IAdministradorRepository
{
    public AdministradorRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Administrador> ObterAdministradorPorNome(string nome)
    {
        var administrador = await Context.Administrador.FirstOrDefaultAsync(x => x.Nome == nome);
        return administrador;
    }
}
