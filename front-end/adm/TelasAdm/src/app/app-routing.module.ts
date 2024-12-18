import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavBarComponent } from './navbar/nav-bar.component';
import { CadastroProfessorComponent } from './cadastro-professor/cadastro-professor.component';
import { EdicaoProfessorComponent } from './edicao-professor/edicao-professor.component';
import { ListaProfessoresComponent } from './lista-professores/lista-professores.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { TelaConfirmaEmailComponent } from './tela-confirma-email/tela-confirma-email.component';
import { ListaSalasComponent } from './lista-salas/lista-salas.component';
import { CadastroSalaComponent } from './cadastro-sala/cadastro-sala.component';
import { EdicaoSalaComponent } from './edicao-sala/edicao-sala.component';
import { ListaMateriaisComponent } from './lista-materiais/lista-materiais.component';
import { CadastroMaterialComponent } from './cadastro-material/cadastro-material.component';
import { EdicaoMaterialComponent } from './edicao-material/edicao-material.component';
import { ListaTurmasComponent } from './lista-turmas/lista-turmas.component';
import { CadastroTurmaComponent } from './cadastro-turma/cadastro-turma.component';
import { EdicaoTurmaComponent } from './edicao-turma/edicao-turma.component';
import { CadastroAdmComponent } from './cadastro-adm/cadastro-adm.component';
import { TelaPerfilComponent } from './tela-perfil/tela-perfil.component';
import { EdicaoAdministradorComponent } from './edicao-administrador/edicao-administrador.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  {
    path: 'email-confirmado',
    component: TelaConfirmaEmailComponent,
  },
  {
    path: 'cadastro',
    component: CadastroProfessorComponent,
  },
  {
    path: 'editar/:id',
    component: EdicaoProfessorComponent,
  },
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'professores',
    component: ListaProfessoresComponent,
  },
  {
    path: 'salas',
    component: ListaSalasComponent,
  },
  {
    path: 'cadastro-sala',
    component: CadastroSalaComponent,
  },
  {
    path: 'editar-sala/:id',
    component: EdicaoSalaComponent,
  },
  {
    path: 'materiais',
    component: ListaMateriaisComponent,
  },
  {
    path: 'cadastro-material',
    component: CadastroMaterialComponent,
  },
  {
    path: 'editar-material/:id',
    component: EdicaoMaterialComponent,
  },
  {
    path: 'turmas',
    component: ListaTurmasComponent,
  },
  {
    path: 'cadastro-turma',
    component: CadastroTurmaComponent,
  },
  {
    path: 'editar-turma/:id',
    component: EdicaoTurmaComponent,
  },
  {
    path: 'cadastro-adm',
    component: CadastroAdmComponent,
  },
  {
    path: 'tela-perfil',
    component: TelaPerfilComponent,
  },
  {
    path: 'editar-adm/:id',
    component: EdicaoAdministradorComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
