import { Component, EventEmitter, Output } from '@angular/core';
import { ReservaSalaService } from '../services/reserva-sala-service/reserva-sala.service';
import { SalaService } from '../services/sala-service/sala-service.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-editar-sala',
  templateUrl: './editar-sala.component.html',
  styleUrl: './editar-sala.component.css',
})
export class EditarSalaComponent {
  salas: any[] = [];
  sala: any;
  turno: string = '';
  descricao: string = '';

  @Output() reservaConfirmada = new EventEmitter<any>(); // Emissor de evento para enviar os dados

  constructor(
    private reservaService: ReservaSalaService,
    private salaService: SalaService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.salaService.getSalas().subscribe({
      next: (data) => (this.salas = data),
      error: (err) => console.error('Erro ao buscar salas:', err),
    });

    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.reservaService.getReservaPorId(+id).subscribe({
        next: (data) => {
          this.sala = data.sala;
          this.turno = data.turno;
          this.descricao = data.descricao;
        },
        error: (err) => console.error('Erro ao buscar sala:', err),
      });
    }
  }

  onSubmit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (!this.sala || !this.turno || !this.descricao) {
      alert('Preencha todos os campos!');
      return;
    }

    const dadosReserva = {
      sala: this.sala.nome,
      turno: this.turno,
      descricao: this.descricao,
    };

    this.reservaService.setDadosReserva(dadosReserva);
    this.reservaConfirmada.emit(dadosReserva);
    this.router.navigate(['/calendario-editar-reserva-sala', id]);
  }
}
