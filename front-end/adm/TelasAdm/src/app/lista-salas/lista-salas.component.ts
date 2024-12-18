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

@Component({
  selector: 'app-lista-salas',
  templateUrl: './lista-salas.component.html',
  styleUrl: './lista-salas.component.css',
})
export class ListaSalasComponent implements OnInit {
  dataSource = new MatTableDataSource<SalaEdicaoDto>();
  displayedColumns: string[] = ['nome', 'tipo', 'capacidade', 'actions'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private salaService: SalaService,
    private router: Router,
    private toastr: ToastrService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.obterSalas();
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
        this.toastr.success('Sala removida com sucesso', 'Sucesso');
        this.salaService.deletar(id).subscribe(() => {
          this.obterSalas(); // Atualizar a lista após exclusão
        });
      }
    });
  }

  irParaCadastro(): void {
    this.router.navigate(['/cadastro-sala']);
  }

  irParaEditar(id: number): void {
    this.router.navigate(['/editar-sala', id]);
  }

  obterSalas() {
    this.salaService.obterTodos().subscribe((salas) => {
      console.log('salas', salas);
      this.dataSource.data = salas;
    });
  }
}
