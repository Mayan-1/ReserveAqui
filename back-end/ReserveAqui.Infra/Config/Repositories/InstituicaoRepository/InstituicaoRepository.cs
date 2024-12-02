using ReserveAqui.Core.Interfaces.Repositories.InstituicaoRepository;
using ReserveAqui.Core.Models;
using ReserveAqui.Infra.Config.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveAqui.Infra.Config.Repositories.InstituicaoRepository;

public class InstituicaoRepository : BaseRepository<Instituicao>, IInstituicaoRepository
{
    public InstituicaoRepository(AppDbContext context) : base(context)
    {
    }
}
