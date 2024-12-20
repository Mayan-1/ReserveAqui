﻿namespace ReserveAqui.Application.UseCases.Sala.ObterTodos;

public sealed record ObterTodasSalasResponse
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public int Capacidade { get; set; }
}