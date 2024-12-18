import { Component, ChangeDetectionStrategy, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  AbstractControl,
  ValidatorFn,
  FormControl,
  ValidationErrors,
} from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ProfessorCriacaoDto } from '../models/professorCriacaoDto';
import { ToastrService } from 'ngx-toastr';
import { timeout } from 'rxjs';
import { Router } from '@angular/router';
import { SalaService } from '../services/salas-service/salas-service.service';
import { SalaCriacaoDto } from '../models/salaCriacaoDto';
import { MaterialCriacaoDto } from '../models/materialCriacaoDto';
import { MaterialService } from '../services/material-service/material-service.service';

@Component({
  selector: 'app-cadastro-material',
  templateUrl: './cadastro-material.component.html',
  styleUrl: './cadastro-material.component.css',
  changeDetection: ChangeDetectionStrategy.Default,
})
export class CadastroMaterialComponent implements OnInit {
  cadastroMaterialForm!: FormGroup;
  constructor(
    private router: Router,
    private materialService: MaterialService,
    private dialog: MatDialog,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) {}

  equalsTo(otherField: string): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      if (!control.root || !(control.root instanceof FormGroup)) {
        return null;
      }

      const formGroup = <FormGroup>control.root;
      const field = formGroup.get(otherField);

      if (!field) {
        return null;
      }

      return field.value !== control.value ? { equalsTo: otherField } : null;
    };
  }

  ngOnInit() {
    this.cadastroMaterialForm = this.fb.group({
      materialNome: ['', [Validators.required, Validators.minLength(3)]],
      materialQuantidade: ['', [Validators.required]],
      materialTipo: ['', [Validators.required]],
    });
  }

  criarMaterial() {
    if (this.cadastroMaterialForm.invalid) {
      this.toastr.error('Por favor, preencha todos os campos', 'Erro', {
        timeOut: 2000,
      });
      return;
    }

    const material: MaterialCriacaoDto = {
      nome: this.cadastroMaterialForm.value.materialNome,
      quantidade: this.cadastroMaterialForm.value.materialQuantidade,
      tipo: this.cadastroMaterialForm.value.materialTipo,
    };
    console.log('material', material);
    this.materialService.criar(material).subscribe(() => {
      console.log('chegou aqui após o subscribe');
      this.toastr
        .success('Mateial cadastrado com sucesso', 'Sucesso', {
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
    this.cadastroMaterialForm.reset();
  }
}
