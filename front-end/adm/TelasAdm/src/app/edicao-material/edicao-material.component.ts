import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfessorEdicaoDto } from '../models/professorEdicaoDto';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { ToastrService } from 'ngx-toastr';
import { SalaEdicaoDto } from '../models/salaEdicaoDto';
import { SalaService } from '../services/salas-service/salas-service.service';
import { MaterialService } from '../services/material-service/material-service.service';
import { MaterialEdicaoDto } from '../models/materialEdicaoDto';

@Component({
  selector: 'app-edicao-material',
  templateUrl: './edicao-material.component.html',
  styleUrl: './edicao-material.component.css',
})
export class EdicaoMaterialComponent implements OnInit {
  edicaoMaterialForm!: FormGroup;
  materialData!: MaterialEdicaoDto;

  constructor(
    private materialService: MaterialService,
    private dialog: MatDialog,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit() {
    const materialIdString = this.route.snapshot.params['id'];
    console.log(materialIdString);
    const materialId = +materialIdString;
    this.edicaoMaterialForm = this.fb.group({
      materialId,
      materialNome: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(30),
        ],
      ],
      materialQuantidade: ['', Validators.required],
      materialTipo: ['', [Validators.required]],
    });
    if (materialId) {
      this.materialService.obterPorId(materialId).subscribe((material) => {
        console.log('Material para atualizar', material);
        this.edicaoMaterialForm.patchValue({
          materialNome: material.nome,
          materialQuantidade: material.quantidade,
          materialTipo: material.tipo,
        });
      });
    }
  }

  editarMaterial() {
    if (this.edicaoMaterialForm.invalid) {
      this.toastr.success('Por favor, preencha todos os campos', 'Erro', {
        timeOut: 2000,
        progressBar: true,
        progressAnimation: 'increasing',
      });
      return;
    }

    // const valoresFormulario = this.edicaoProfessorForm.value;
    const materialId = this.edicaoMaterialForm.value.materialId;
    const material: MaterialEdicaoDto = {
      id: materialId,
      nome: this.edicaoMaterialForm.value.materialNome,
      quantidade: this.edicaoMaterialForm.value.materialQuantidade,
      tipo: this.edicaoMaterialForm.value.materialTipo,
    };

    console.log('material atualizda', material);
    this.materialService.editar(materialId, material).subscribe(() => {
      this.toastr
        .success('Material editado com sucesso', 'Sucesso', {
          timeOut: 2000,
          progressBar: true,
          progressAnimation: 'increasing',
        })
        .onHidden.subscribe(() => {
          this.router.navigate(['/materiais']);
        });
    });
  }

  limparCampos() {
    this.edicaoMaterialForm.reset();
  }
}
