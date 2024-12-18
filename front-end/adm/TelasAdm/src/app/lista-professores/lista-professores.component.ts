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

@Component({
  selector: 'app-lista-professores',
  templateUrl: './lista-professores.component.html',
  styleUrl: './lista-professores.component.css',
})
export class ListaProfessoresComponent implements OnInit {
  dataSource = new MatTableDataSource<Professor>();
  displayedColumns: string[] = [
    // 'id',
    'nome',
    'cpf',
    'email',
    'telefone',
    'materia',
    'actions',
  ];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private professorService: ProfessorService,
    private router: Router,
    private toastr: ToastrService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.obterProfessores();
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

  deletarProfessor(id: number): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent);

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.toastr.success('Professor removido com sucesso', 'Sucesso');
        this.professorService.deletarProfessor(id).subscribe(() => {
          this.obterProfessores(); // Atualizar a lista após exclusão
        });
      }
    });
  }

  irParaCadastro(): void {
    this.router.navigate(['/cadastro']);
  }

  irParaEditar(id: number): void {
    this.router.navigate(['/editar', id]);
  }

  obterProfessores() {
    this.professorService.obterProfessores().subscribe((professores) => {
      this.dataSource.data = professores;
    });
  }
}
