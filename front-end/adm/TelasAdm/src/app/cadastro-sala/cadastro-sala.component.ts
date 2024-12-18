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

@Component({
  selector: 'app-cadastro-sala',
  templateUrl: './cadastro-sala.component.html',
  styleUrl: './cadastro-sala.component.css',
  changeDetection: ChangeDetectionStrategy.Default,
})
export class CadastroSalaComponent implements OnInit {
  cadastroSalaForm!: FormGroup;
  constructor(
    private router: Router,
    private salaService: SalaService,
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
    this.cadastroSalaForm = this.fb.group({
      salaNome: ['', [Validators.required, Validators.minLength(3)]],
      salaTipo: ['', [Validators.required]],
      salaCapacidade: ['', [Validators.required]],
    });
  }

  criarSala() {
    if (this.cadastroSalaForm.invalid) {
      this.toastr.error('Por favor, preencha todos os campos', 'Erro', {
        timeOut: 2000,
      });
      return;
    }

    const sala: SalaCriacaoDto = {
      nome: this.cadastroSalaForm.value.salaNome,
      tipo: this.cadastroSalaForm.value.salaTipo,
      capacidade: this.cadastroSalaForm.value.salaCapacidade,
    };
    console.log('sala', sala);
    this.salaService.criar(sala).subscribe(() => {
      console.log('chegou aqui após o subscribe');
      this.toastr
        .success('Sala cadastrada com sucesso', 'Sucesso', {
          timeOut: 2000,
          progressBar: true,
          progressAnimation: 'increasing',
        })
        .onHidden.subscribe(() => {
          this.router.navigate(['/salas']);
        });
    });
  }

  limparCampos() {
    this.cadastroSalaForm.reset();
  }
}
