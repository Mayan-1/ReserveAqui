import { Component, EventEmitter, Output } from '@angular/core';
import { ReservaSalaService } from '../services/reserva-sala-service/reserva-sala.service';
import { Router } from '@angular/router';
import { SalaService } from '../services/sala-service/sala-service.service';
import { ReservaMaterialService } from '../services/reserva-material-service/reserva-material-service.service';
import { MaterialService } from '../services/material-service/material-service.service';

@Component({
  selector: 'app-campos-reserva-material',
  templateUrl: './campos-reserva-material.component.html',
  styleUrl: './campos-reserva-material.component.css',
})
export class CamposReservaMaterialComponent {
  materiais: any[] = [];
  material: any;
  turno: string = '';
  descricao: string = '';

  @Output() reservaConfirmada = new EventEmitter<any>(); // Emissor de evento para enviar os dados

  constructor(
    private reservaService: ReservaMaterialService,
    private materialService: MaterialService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.materialService.getMateriais().subscribe({
      next: (data) => {
        this.materiais = data;
      },
      error: (err) => {
        console.error('Erro ao buscar materiais:', err);
      },
    });
  }

  onSubmit(): void {
    if (!this.material || !this.turno || !this.descricao) {
      alert('Preencha todos os campos!');
      return;
    }

    const dadosReserva = {
      material: this.material.nome,
      turno: this.turno,
      descricao: this.descricao,
    };

    this.reservaService.setDadosReserva(dadosReserva); // Envia os dados para o serviço
    this.reservaConfirmada.emit(dadosReserva); // Opcional: emite o evento para outros componentes

    this.router.navigate(['/calendario-material']); // Navega para o calendário
  }
}
