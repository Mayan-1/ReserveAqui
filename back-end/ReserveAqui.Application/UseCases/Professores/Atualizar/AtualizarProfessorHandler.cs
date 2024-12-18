using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ReserveAqui.Core.Interfaces;
using ReserveAqui.Core.Interfaces.Repositories.InstituicaoRepository;
using ReserveAqui.Core.Interfaces.Repositories.MateriaRepository;
using ReserveAqui.Core.Interfaces.Repositories.ProfessorRepository;
using ReserveAqui.Core.Models;
using ReserveAqui.Infra.Identity.User;

namespace ReserveAqui.Application.UseCases.Professores.Atualizar;

public class AtualizarProfessorHandler : IRequestHandler<AtualizarProfessorRequest, AtualizarProfessorResponse>
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IMapper _mapper;
    private readonly IMateriaRepository _materiaRepository;
    private readonly IInstituicaoRepository _instituicaoRepository;
    private readonly IUnitOfWork _uof;
    private readonly UserManager<ApplicationUser> _userManager;

    public AtualizarProfessorHandler(IProfessorRepository professorRepository, IMapper mapper, IMateriaRepository materiaRepository, IInstituicaoRepository instituicaoRepository, IUnitOfWork uof, UserManager<ApplicationUser> userManager)
    {
        _professorRepository = professorRepository;
        _mapper = mapper;
        _materiaRepository = materiaRepository;
        _instituicaoRepository = instituicaoRepository;
        _uof = uof;
        _userManager = userManager;
    }

    public async Task<AtualizarProfessorResponse> Handle(AtualizarProfessorRequest request, CancellationToken cancellationToken)
    {
        request.IdInstituicao = 2;
        var professor = await _professorRepository.ObterProfessor(request.Id, cancellationToken);
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (professor == null || user == null)
        {
            return new AtualizarProfessorResponse { Mensagem = "Professor não encontrado" };
        }

        var materia = await _materiaRepository.ObterPorNome(request.Materia);
        if (materia == null)
        {
            return new AtualizarProfessorResponse { Mensagem = "Matéria não encontrada" };
        }

        var instituicao = await _instituicaoRepository.Obter(request.IdInstituicao, cancellationToken);
        if (instituicao == null)
        {
            return new AtualizarProfessorResponse { Mensagem = "Instituição não encontrada" };
        }

        professor.Nome = request.Nome;
        professor.Email = request.Email;
        professor.Cpf = request.Cpf;
        professor.Telefone = request.Telefone;
        professor.Materia = materia;
        professor.Instituicao = instituicao;

        user.Email = request.Email;
        user.UserName = request.Nome;

        _professorRepository.Atualizar(professor);
        await _userManager.UpdateAsync(user);
        await _uof.Commit(cancellationToken);
        return new AtualizarProfessorResponse { Mensagem = "Professor atualizado com sucesso." };

    }
}
