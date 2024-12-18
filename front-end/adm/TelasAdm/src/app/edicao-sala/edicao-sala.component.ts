import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfessorEdicaoDto } from '../models/professorEdicaoDto';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { ToastrService } from 'ngx-toastr';
import { SalaEdicaoDto } from '../models/salaEdicaoDto';
import { SalaService } from '../services/salas-service/salas-service.service';

@Component({
  selector: 'app-edicao-sala',
  templateUrl: './edicao-sala.component.html',
  styleUrl: './edicao-sala.component.css',
})
export class EdicaoSalaComponent implements OnInit {
  edicaoSalaForm!: FormGroup;
  salaData!: SalaEdicaoDto;

  constructor(
    private salaService: SalaService,
    private dialog: MatDialog,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit() {
    const salaIdString = this.route.snapshot.params['id'];
    console.log(salaIdString);
    const salaId = +salaIdString;
    this.edicaoSalaForm = this.fb.group({
      salaId,
      salaNome: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(30),
        ],
      ],
      salaTipo: ['', Validators.required],
      salaCapacidade: ['', [Validators.required]],
    });
    if (salaId) {
      this.salaService.obterPorId(salaId).subscribe((sala) => {
        console.log('Professor para atualizar', sala);
        this.edicaoSalaForm.patchValue({
          salaNome: sala.nome,
          salaTipo: sala.tipo,
          salaCapacidade: sala.capacidade,
        });
      });
    }
  }

  editarSala() {
    if (this.edicaoSalaForm.invalid) {
      this.toastr.success('Por favor, preencha todos os campos', 'Erro', {
        timeOut: 2000,
        progressBar: true,
        progressAnimation: 'increasing',
      });
      return;
    }

    // const valoresFormulario = this.edicaoProfessorForm.value;
    const salaId = this.edicaoSalaForm.value.salaId;
    const sala: SalaEdicaoDto = {
      id: salaId,
      nome: this.edicaoSalaForm.value.salaNome,
      tipo: this.edicaoSalaForm.value.salaTipo,
      capacidade: this.edicaoSalaForm.value.salaCapacidade,
    };

    console.log('sala atualizda', sala);
    this.salaService.editar(salaId, sala).subscribe(() => {
      this.toastr
        .success('Sala editada com sucesso', 'Sucesso', {
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
    this.edicaoSalaForm.reset();
  }
}
