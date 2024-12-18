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
import { MaterialEdicaoDto } from '../models/materialEdicaoDto';
import { MaterialService } from '../services/material-service/material-service.service';

@Component({
  selector: 'app-lista-salas',
  templateUrl: './lista-materiais.component.html',
  styleUrl: './lista-materiais.component.css',
})
export class ListaMateriaisComponent implements OnInit {
  dataSource = new MatTableDataSource<MaterialEdicaoDto>();
  displayedColumns: string[] = ['nome', 'quantidade', 'tipo', 'actions'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private materialService: MaterialService,
    private router: Router,
    private toastr: ToastrService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.obterMateriais();
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

  deletarMaterial(id: number): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent);

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.toastr.success('Material removido com sucesso', 'Sucesso');
        this.materialService.deletar(id).subscribe(() => {
          this.obterMateriais(); // Atualizar a lista após exclusão
        });
      }
    });
  }

  irParaCadastro(): void {
    this.router.navigate(['/cadastro-material']);
  }

  irParaEditar(id: number): void {
    this.router.navigate(['/editar-material', id]);
  }

  obterMateriais() {
    this.materialService.obterTodos().subscribe((materiais) => {
      console.log('materiais', materiais);
      this.dataSource.data = materiais;
    });
  }
}
