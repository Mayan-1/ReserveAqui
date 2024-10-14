﻿namespace ReserveAqui.Models;

public class Administrador
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public string? Cpf { get; set; }
    public string? Telefone { get; set; }
    public Instituicao? Instituicao { get; set; }
}
