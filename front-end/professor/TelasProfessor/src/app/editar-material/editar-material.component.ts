import { Component, EventEmitter, Output } from '@angular/core';
import { ReservaSalaService } from '../services/reserva-sala-service/reserva-sala.service';
import { SalaService } from '../services/sala-service/sala-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ReservaMaterialService } from '../services/reserva-material-service/reserva-material-service.service';
import { MaterialService } from '../services/material-service/material-service.service';

@Component({
  selector: 'app-editar-material',
  templateUrl: './editar-material.component.html',
  styleUrl: './editar-material.component.css',
})
export class EditarMaterialComponent {
  materiais: any[] = [];
  material: any;
  turno: string = '';
  descricao: string = '';

  @Output() reservaConfirmada = new EventEmitter<any>(); // Emissor de evento para enviar os dados

  constructor(
    private reservaService: ReservaMaterialService,
    private materialService: MaterialService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.materialService.getMateriais().subscribe({
      next: (data) => (this.materiais = data),
      error: (err) => console.error('Erro ao buscar salas:', err),
    });

    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.reservaService.getReservaPorId(+id).subscribe({
        next: (data) => {
          this.material = data.material;
          this.turno = data.turno;
          this.descricao = data.descricao;
        },
        error: (err) => console.error('Erro ao buscar material:', err),
      });
    }
  }

  onSubmit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (!this.material || !this.turno || !this.descricao) {
      alert('Preencha todos os campos!');
      return;
    }

    const dadosReserva = {
      material: this.material.nome,
      turno: this.turno,
      descricao: this.descricao,
    };

    this.reservaService.setDadosReserva(dadosReserva);
    this.reservaConfirmada.emit(dadosReserva);
    this.router.navigate(['/calendario-editar-reserva-material', id]);
  }
}
