import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfessorEdicaoDto } from '../models/professorEdicaoDto';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { ToastrService } from 'ngx-toastr';
import { SalaEdicaoDto } from '../models/salaEdicaoDto';
import { SalaService } from '../services/salas-service/salas-service.service';
import { TurmaEdicaoDto } from '../models/turmaEdicaoDto';
import { TurmaService } from '../services/turma-service/turma-service.service';

@Component({
  selector: 'app-edicao-turma',
  templateUrl: './edicao-turma.component.html',
  styleUrl: './edicao-turma.component.css',
})
export class EdicaoTurmaComponent implements OnInit {
  edicaoTurmaForm!: FormGroup;
  turmaData!: TurmaEdicaoDto;

  constructor(
    private turmaService: TurmaService,
    private dialog: MatDialog,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit() {
    const turmaIdString = this.route.snapshot.params['id'];
    console.log(turmaIdString);
    const turmaId = +turmaIdString;
    this.edicaoTurmaForm = this.fb.group({
      turmaId,
      turmaNome: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(30),
        ],
      ],
      turmaQuantidadeAlunos: ['', Validators.required],
      turmaTurno: ['', [Validators.required]],
      turmaCodigo: ['', [Validators.required]],
    });
    if (turmaId) {
      this.turmaService.obterPorId(turmaId).subscribe((turma) => {
        console.log('Turma para atualizar', turma);
        this.edicaoTurmaForm.patchValue({
          turmaNome: turma.nome,
          turmaQuantidadeAlunos: turma.quantidadeAlunos,
          turmaTurno: turma.turno,
          turmaCodigo: turma.codigo,
        });
      });
    }
  }

  editarTurma() {
    if (this.edicaoTurmaForm.invalid) {
      this.toastr.success('Por favor, preencha todos os campos', 'Erro', {
        timeOut: 2000,
        progressBar: true,
        progressAnimation: 'increasing',
      });
      return;
    }

    // const valoresFormulario = this.edicaoProfessorForm.value;
    const turmaId = this.edicaoTurmaForm.value.turmaId;
    const turma: TurmaEdicaoDto = {
      id: turmaId,
      nome: this.edicaoTurmaForm.value.turmaNome,
      quantidadeAlunos: this.edicaoTurmaForm.value.turmaQuantidadeAlunos,
      turno: this.edicaoTurmaForm.value.turmaTurno,
      codigo: this.edicaoTurmaForm.value.turmaCodigo,
    };

    console.log('turma atualizda', turma);
    this.turmaService.editar(turmaId, turma).subscribe(() => {
      this.toastr
        .success('Turma editada com sucesso', 'Sucesso', {
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
    this.edicaoTurmaForm.reset();
  }
}
