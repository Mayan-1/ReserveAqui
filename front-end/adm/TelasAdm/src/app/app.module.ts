import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarModule } from './navbar/nav-bar.module';
import { FooterModule } from './footer/footer.module';
import { CadastroProfessorModule } from './cadastro-professor/cadastro-professor.module';
import {
  BrowserAnimationsModule,
  NoopAnimationsModule,
} from '@angular/platform-browser/animations';
import { EdicaoProfessorModule } from './edicao-professor/edicao-professor.module';
import { ListaProfessoresModule } from './lista-professores/lista-professores.module';
import { ToastrModule } from 'ngx-toastr';
import { LoginComponent } from './login/login.component';
import { LoginModule } from './login/login.module';
import { HomeComponent } from './home/home.component';
import { NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { TelaConfirmaEmailComponent } from './tela-confirma-email/tela-confirma-email.component';
import { ListaSalasModule } from './lista-salas/lista-salas.module';
import { CadastroSalaComponent } from './cadastro-sala/cadastro-sala.component';
import { EdicaoSalaComponent } from './edicao-sala/edicao-sala.component';
import { CadastroSalaModule } from './cadastro-sala/cadastro-sala.module';
import { MatGridListModule } from '@angular/material/grid-list';
import { EdicaoSalaModule } from './edicao-sala/edicao-sala.module';
import { ListaMateriaisComponent } from './lista-materiais/lista-materiais.component';
import { CadastroMaterialComponent } from './cadastro-material/cadastro-material.component';
import { EdicaoMaterialComponent } from './edicao-material/edicao-material.component';
import { ListaMateriaisModule } from './lista-materiais/lista-materiais.module';
import { CadastroMaterialModule } from './cadastro-material/cadastro-material.module';
import { EdicaoMaterialModule } from './edicao-material/edicao-material.module';
import { ListaTurmasComponent } from './lista-turmas/lista-turmas.component';
import { CadastroTurmaComponent } from './cadastro-turma/cadastro-turma.component';
import { EdicaoTurmaComponent } from './edicao-turma/edicao-turma.component';
import { ListaTurmasModule } from './lista-turmas/lista-turmas.module';
import { CadastroTurmaModule } from './cadastro-turma/cadastro-turma.module';
import { EdicaoTurmaModule } from './edicao-turma/edicao-turna.module';
import { CadastroAdmComponent } from './cadastro-adm/cadastro-adm.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TelaPerfilComponent } from './tela-perfil/tela-perfil.component';
import { EdicaoAdministradorComponent } from './edicao-administrador/edicao-administrador.component';
import { EdicaoAdministradorModule } from './edicao-administrador/edicao-administrador.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    TelaConfirmaEmailComponent,
    CadastroAdmComponent,
    TelaPerfilComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NavBarModule,
    FooterModule,
    CadastroProfessorModule,
    NoopAnimationsModule,
    EdicaoProfessorModule,
    ListaProfessoresModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
    LoginModule,
    ListaSalasModule,
    NgxMaskPipe,
    CadastroSalaModule,
    MatGridListModule,
    EdicaoSalaModule,
    ListaMateriaisModule,
    CadastroMaterialModule,
    EdicaoMaterialModule,
    ListaTurmasModule,
    CadastroTurmaModule,
    EdicaoTurmaModule,
    ReactiveFormsModule,
    EdicaoAdministradorModule,
  ],
  providers: [provideNgxMask()],
  bootstrap: [AppComponent],
})
export class AppModule {}
