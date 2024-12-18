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
import { TurmaService } from '../services/turma-service/turma-service.service';
import { TurmaCriacaoDto } from '../models/turmaCriacaoDto';

@Component({
  selector: 'app-cadastro-turma',
  templateUrl: './cadastro-turma.component.html',
  styleUrl: './cadastro-turma.component.css',
  changeDetection: ChangeDetectionStrategy.Default,
})
export class CadastroTurmaComponent implements OnInit {
  cadastroTurmaForm!: FormGroup;
  constructor(
    private router: Router,
    private turmaService: TurmaService,
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
    this.cadastroTurmaForm = this.fb.group({
      turmaNome: ['', [Validators.required, Validators.minLength(3)]],
      turmaQuantidade: ['', [Validators.required]],
      turmaTurno: ['', [Validators.required]],
      turmaCodigo: ['', [Validators.required]],
    });
  }

  criarTurma() {
    if (this.cadastroTurmaForm.invalid) {
      this.toastr.error('Por favor, preencha todos os campos', 'Erro', {
        timeOut: 2000,
      });
      return;
    }

    const turma: TurmaCriacaoDto = {
      nome: this.cadastroTurmaForm.value.turmaNome,
      quantidadeAlunos: this.cadastroTurmaForm.value.turmaQuantidade,
      turno: this.cadastroTurmaForm.value.turmaTurno,
      codigo: this.cadastroTurmaForm.value.turmaCodigo,
    };
    console.log('turma', turma);
    this.turmaService.criar(turma).subscribe(() => {
      console.log('chegou aqui após o subscribe');
      this.toastr
        .success('Turma cadastrada com sucesso', 'Sucesso', {
          timeOut: 2000,
          progressBar: true,
          progressAnimation: 'increasing',
        })
        .onHidden.subscribe(() => {
          this.router.navigate(['/turmas']);
        });
    });
  }

  limparCampos() {
    this.cadastroTurmaForm.reset();
  }
}
