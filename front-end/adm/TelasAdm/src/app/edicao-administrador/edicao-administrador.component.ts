import { Component, OnInit } from '@angular/core';
import { ProfessorService } from '../services/professor.service';
import { MatDialog } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProfessorEdicaoDto } from '../models/professorEdicaoDto';
import { DeleteDialogComponent } from '../delete-dialog/delete-dialog.component';
import { ToastrService } from 'ngx-toastr';
import { AdministradorEdicaoDto } from '../models/administradorEdicao';
import { AuthService } from '../services/auth-service/auth-service.service';

@Component({
  selector: 'app-edicao-admininistrador',
  templateUrl: './edicao-administrador.component.html',
  styleUrl: './edicao-administrador.component.css',
})
export class EdicaoAdministradorComponent implements OnInit {
  edicaoAdministradorForm!: FormGroup;
  administradorData!: AdministradorEdicaoDto;

  constructor(
    private administradorService: AuthService,
    private dialog: MatDialog,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit() {
    const administradorIdString = this.route.snapshot.params['id'];
    console.log('id string', administradorIdString);
    const administradorId = +administradorIdString;
    if (administradorId) {
      this.administradorService
        .getAdministrador(administradorId)
        .subscribe((administrador) => {
          console.log(administradorId);
          console.log('Administrador para atualizar', administrador);
          this.edicaoAdministradorForm.patchValue({
            administradorId,
            administradorNome: administrador.nome,
            administradorCpf: administrador.cpf,
            administradorEmail: administrador.email,
            administradorSenha: administrador.senha,
            administradorTelefone: administrador.telefone,
          });
        });
    }
    this.edicaoAdministradorForm = this.fb.group({
      administradorId,
      administradorNome: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(30),
        ],
      ],
      administradorCpf: ['', Validators.required],
      administradorEmail: ['', [Validators.required, Validators.email]],
      administradorSenha: ['', Validators.required],
      administradorTelefone: ['', Validators.required],
    });
  }

  editarAdministrador() {
    if (this.edicaoAdministradorForm.invalid) {
      this.toastr.success('Por favor, preencha todos os campos', 'Erro', {
        timeOut: 2000,
        progressBar: true,
        progressAnimation: 'increasing',
      });
      return;
    }

    // const valoresFormulario = this.edicaoProfessorForm.value;
    const admininistradorId =
      this.edicaoAdministradorForm.value.administradorId;
    const admininistrador: AdministradorEdicaoDto = {
      id: admininistradorId,
      nome: this.edicaoAdministradorForm.value.administradorNome,
      cpf: this.edicaoAdministradorForm.value.administradorCpf,
      email: this.edicaoAdministradorForm.value.administradorEmail,
      senha: this.edicaoAdministradorForm.value.administradorSenha,
      telefone: this.edicaoAdministradorForm.value.administradorTelefone,
    };

    console.log('professor atualizdo', admininistrador);
    console.log('id administrador', admininistradorId);
    this.administradorService
      .atualizarAdministrador(admininistradorId, admininistrador)
      .subscribe(() => {
        this.toastr
          .success('Administrador editado com sucesso', 'Sucesso', {
            timeOut: 2000,
            progressBar: true,
            progressAnimation: 'increasing',
          })
          .onHidden.subscribe(() => {
            this.router.navigate(['/tela-perfil']);
          });
      });
  }

  limparCampos() {
    this.edicaoAdministradorForm.reset();
  }
}
