import { Component, EventEmitter, Output } from '@angular/core';
import { ReservaSalaService } from '../services/reserva-sala-service/reserva-sala.service';
import { Router } from '@angular/router';
import { SalaService } from '../services/sala-service/sala-service.service';

@Component({
  selector: 'app-campos-reserva-sala',
  templateUrl: './campos-reserva-sala.component.html',
  styleUrl: './campos-reserva-sala.component.css',
})
export class CamposReservaSalaComponent {
  salas: any[] = [];
  sala: any;
  turno: string = '';
  descricao: string = '';

  @Output() reservaConfirmada = new EventEmitter<any>(); // Emissor de evento para enviar os dados

  constructor(
    private reservaService: ReservaSalaService,
    private salaService: SalaService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.salaService.getSalas().subscribe({
      next: (data) => {
        this.salas = data;
      },
      error: (err) => {
        console.error('Erro ao buscar salas:', err);
      },
    });
  }

  onSubmit(): void {
    if (!this.sala || !this.turno || !this.descricao) {
      alert('Preencha todos os campos!');
      return;
    }

    const dadosReserva = {
      sala: this.sala.nome,
      turno: this.turno,
      descricao: this.descricao,
    };

    this.reservaService.setDadosReserva(dadosReserva); // Envia os dados para o serviço
    this.reservaConfirmada.emit(dadosReserva); // Opcional: emite o evento para outros componentes

    this.router.navigate(['/calendario']); // Navega para o calendário
  }
}
