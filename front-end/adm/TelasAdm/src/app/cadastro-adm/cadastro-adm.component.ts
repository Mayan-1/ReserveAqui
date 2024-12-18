import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth-service/auth-service.service';
import { Administrador } from '../models/admnistrador';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastro-adm',
  templateUrl: './cadastro-adm.component.html',
  styleUrls: ['./cadastro-adm.component.css'],
})
export class CadastroAdmComponent {
  cadastroAdmForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private toastr: ToastrService,
    private router: Router
  ) {
    this.cadastroAdmForm = this.fb.group({
      nome: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      confirmaEmail: ['', [Validators.required]],
      cpf: [
        '',
        [
          Validators.required,
          Validators.minLength(11),
          Validators.maxLength(14),
        ],
      ],
      telefone: ['', [Validators.required]],
      senha: ['', [Validators.required, Validators.minLength(6)]],
      confirmaSenha: ['', [Validators.required]],
    });
  }

  onSubmit() {
    if (this.cadastroAdmForm.invalid) {
      this.toastr.error(
        'Por favor, preencha todos os campos corretamente.',
        'Erro'
      );
      return;
    }

    const admininstrador: Administrador = {
      Nome: this.cadastroAdmForm.value.nome,
      Cpf: this.cadastroAdmForm.value.cpf,
      Email: this.cadastroAdmForm.value.email,
      Senha: this.cadastroAdmForm.value.senha,
      Telefone: this.cadastroAdmForm.value.telefone,
    };

    this.authService.cadastro(admininstrador).subscribe(
      () => {
        this.toastr
          .success('Administrador cadastrado com sucesso', 'Sucesso', {
            timeOut: 2000,
            progressBar: true,
            progressAnimation: 'increasing',
          })
          .onHidden.subscribe(() => {
            this.router.navigate(['/login']);
          });
      },
      (error) => {
        console.log('dados', admininstrador);
        console.error('erro: ', error);
        this.toastr.error(
          'Ocorreu um erro ao cadastrar. Por favor, tente novamente',
          'Erro'
        );
      }
    );
  }
}
