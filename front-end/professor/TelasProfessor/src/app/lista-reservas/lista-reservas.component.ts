import { Component, OnInit } from '@angular/core';
import { ReservaSalaService } from '../services/reserva-sala-service/reserva-sala.service';
import { AuthService } from '../services/auth-service/auth.service';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lista-reservas',
  templateUrl: './lista-reservas.component.html',
  styleUrl: './lista-reservas.component.css',
})
export class ListaReservasComponent implements OnInit {
  reservas: any[] = [];
  idProfessor: number | null = null;

  constructor(
    private reservaService: ReservaSalaService,
    private authService: AuthService,
    public dialog: MatDialog,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.idProfessor = this.authService.getIdProfessor(); // Pega o id do professor logado
    console.log('idprofessor', this.idProfessor);
    if (this.idProfessor != null) {
      this.carregarReservas();
    } else {
      console.error('Professor não autenticado');
    }
  }
  carregarReservas(): void {
    this.reservaService.getReservas(this.idProfessor!).subscribe(
      (dados) => {
        console.log('Reservas', dados);
        this.reservas = dados;
      },
      (erro) => {
        console.error('Erro ao carregar reservas:', erro);
      }
    );
  }

  deletarReserva(id: number): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent);
    console.log(id);

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.toastr.success('Reserva deletada com sucesso', 'Sucesso');
        this.reservaService.excluirReserva(id).subscribe(() => {
          this.carregarReservas();
        });
      }
    });
  }

  irParaEditar(id: number) {
    this.router.navigate(['/editar-reserva-sala', id]);
  }

  getStatusClass(status: string): string {
    switch (status.toLowerCase()) {
      case 'agendado':
        return 'bg-green-300';
      case 'cancelado':
        return 'bg-red-300';
      case 'pendente':
        return 'bg-yellow-300';
      default:
        return 'bg-gray-300';
    }
  }
}
