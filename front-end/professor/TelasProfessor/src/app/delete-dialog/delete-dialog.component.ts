import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatDialogRef } from '@angular/material/dialog';
import { ReservaSalaService } from '../services/reserva-sala-service/reserva-sala.service';

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrl: './delete-dialog.component.css',
})
export class DeleteDialogComponent {
  constructor(
    private reservaService: ReservaSalaService,
    public dialogRef: MatDialogRef<DeleteDialogComponent>
  ) {}

  // deletarProfessor() {
  //   console.log('Deletando professor com ID:', this.data.professorId);
  //   this.professorService
  //     .deletarProfessor(this.data.professorId)
  //     .subscribe(() => {
  //       console.log('Professor deletado com sucesso');
  //     });
  // }

  onNoClick(): void {
    this.dialogRef.close(false);
  }

  onYesClick(): void {
    this.dialogRef.close(true);
  }
}
