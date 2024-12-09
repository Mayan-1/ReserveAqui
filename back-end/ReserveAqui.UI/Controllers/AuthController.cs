using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ReserveAqui.Application.UseCases.Auth.ConfirmEmail;
using ReserveAqui.Application.UseCases.Auth.RefreshToken;
using ReserveAqui.Application.UseCases.Auth.Revoke;
using ReserveAqui.Application.UseCases.Auth.Role.Create;
using ReserveAqui.Application.UseCases.Auth.Role.UserToRole;
using ForgotPasswordRequest = ReserveAqui.Application.UseCases.Auth.ForgotPassword.ForgotPasswordRequest;
using LoginRequest = ReserveAqui.Application.UseCases.Auth.Login.LoginRequest;
using ResetPasswordRequest = ReserveAqui.Application.UseCases.Auth.ResetPassword.ResetPasswordRequest;

namespace ReserveAqui.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create-role")]
        public async Task<ActionResult> CreateRole(CreateRoleRequest request)
        {
            await _mediator.Send(request);
            return Ok($"Role {request.RoleName} added successfully");
        }

        [HttpPost]
        [Route("add-user-to-role")]
        public async Task<ActionResult> AddUserToRole(UserToRoleRequest request)
        {
            await _mediator.Send(request);
            return Ok($"User {request.Email} added to the {request.RoleName} role");
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            var user = await _mediator.Send(request);
            return Ok(user);
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<ActionResult> RefreshToken(RefreshTokenRequest request)
        {
            var token = await _mediator.Send(request);
            return Ok(token);
        }

        [HttpPost]
        [Route("revoke")]
        public async Task<ActionResult> Revoke(RevokeRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpGet("confirm-email")]
        public async Task<ActionResult> ConfirmEmail(ConfirmEmailRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        [Route("forgot-password")]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordRequest request)
        {
            await _mediator.Send(request);
            return Ok("O link para recuperar senha foi encaminhado para o seu e-mail");
        }

        [HttpPost]
        [Route("reset-password")]
        public async Task<ActionResult> ResetPassword(ResetPasswordRequest request)
        {
            await _mediator.Send(request);
            return Ok("Sucesso em recuperar a senha!");
        }




    }
}
