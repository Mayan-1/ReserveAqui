import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { Professor } from '../models/professor';
import { ProfessorService } from '../services/professor.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSort } from '@angular/material/sort';
import { Route, Router } from '@angular/router';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { NgxMaskDirective } from 'ngx-mask';
import { SalaService } from '../services/salas-service/salas-service.service';
import { SalaEdicaoDto } from '../models/salaEdicaoDto';
import { TurmaEdicaoDto } from '../models/turmaEdicaoDto';
import { TurmaService } from '../services/turma-service/turma-service.service';

@Component({
  selector: 'app-lista-turmas',
  templateUrl: './lista-turmas.component.html',
  styleUrl: './lista-turmas.component.css',
})
export class ListaTurmasComponent implements OnInit {
  dataSource = new MatTableDataSource<TurmaEdicaoDto>();
  displayedColumns: string[] = [
    'nome',
    'quantidadeAlunos',
    'turno',
    'codigo',
    'actions',
  ];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private turmaService: TurmaService,
    private router: Router,
    private toastr: ToastrService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.obterTurmas();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  deletarSala(id: number): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent);

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.toastr.success('Turma removida com sucesso', 'Sucesso');
        this.turmaService.deletar(id).subscribe(() => {
          this.obterTurmas(); // Atualizar a lista após exclusão
        });
      }
    });
  }

  irParaCadastro(): void {
    this.router.navigate(['/cadastro-turma']);
  }

  irParaEditar(id: number): void {
    this.router.navigate(['/editar-turma', id]);
  }

  obterTurmas() {
    this.turmaService.obterTodos().subscribe((turmas) => {
      console.log('turmas', turmas);
      this.dataSource.data = turmas;
    });
  }
}
