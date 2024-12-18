import { ChangeDetectorRef, Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ReservaSalaService } from '../services/reserva-sala-service/reserva-sala.service';
import { AuthService } from '../services/auth-service/auth.service';
import { ToastrService } from 'ngx-toastr';
import { ReservaMaterialService } from '../services/reserva-material-service/reserva-material-service.service';

@Component({
  selector: 'app-calendario-editar-reserva-material',
  templateUrl: './calendario-editar-reserva-material.component.html',
  styleUrl: './calendario-editar-reserva-material.component.css',
})
export class CalendarioEditarReservaMaterialComponent {
  selected: Date | null = null; // Inicializa corretamente como null ou Date
  reservas: any[] = [];
  diasReservados: string[] = []; // Usado para armazenar as datas reservadas
  material: any;
  materialArmazenado: string = '';
  turno: string = '';
  descricao: string = '';
  idProfessor: number | null = null;

  constructor(
    private router: Router,
    private reservaService: ReservaMaterialService,
    private cdRef: ChangeDetectorRef,
    private authService: AuthService,
    private toastr: ToastrService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.reservaService.dadosReserva$.subscribe((dadosReserva) => {
      if (dadosReserva) {
        this.material = dadosReserva.material;
        this.turno = dadosReserva.turno;
        this.descricao = dadosReserva.descricao;

        if (this.material && this.turno) {
          this.reservaService
            .getReservasComFiltro(this.material, this.turno)
            .subscribe({
              next: (data) => {
                if (Array.isArray(data)) {
                  this.diasReservados = data.map((d) => d.toString()); // Atualiza o array
                  console.log(
                    'Datas reservadas atualizadas:',
                    this.diasReservados
                  );

                  this.cdRef.detectChanges();
                } else {
                  console.error('Resposta da API inválida:', data);
                }
              },
              error: (err) => console.error('Erro ao buscar reservas:', err),
            });
        }
      }
    });
  }

  // Função que retorna a classe CSS para o dia
  getDateClass = (date: Date): string => {
    const formattedDate = date.toISOString().split('T')[0];
    const isReservado = this.diasReservados.some((d) => d === formattedDate);
    console.log(
      `Data: ${formattedDate}, Classe: ${isReservado ? 'reservado' : ''}`
    );
    return isReservado ? 'reservado' : '';
  };

  atualizarReserva(): void {
    const id = +(this.route.snapshot.paramMap.get('id') ?? 0);
    if (isNaN(id)) {
      return;
    }
    console.log('toastr', this.toastr);
    this.idProfessor = this.authService.getIdProfessor();
    if (this.selected && this.material && this.turno && this.descricao) {
      const novaReserva = {
        material: this.material,
        turno: this.turno,
        descricao: this.descricao,
        data: this.selected ? this.selected.toISOString().split('T')[0] : '',
      };

      // Chama o serviço de reserva para fazer a criação
      if (!this.idProfessor) {
        return;
      }
      this.reservaService
        .atualizarReserva(novaReserva, this.idProfessor, id)
        .subscribe({
          next: (resposta) => {
            console.log('cheguei nessa desgraça');
            this.toastr.success('Reserva atualizada com sucesso!', 'Sucesso', {
              timeOut: 2000,
              progressBar: true,
              progressAnimation: 'increasing',
            });
            setTimeout(() => {
              this.router.navigate(['/materiais']);
            }, 2000);
          },
          error: (erro) => {
            console.error('Erro ao criar reserva', erro);
            this.toastr.error('Ocorreu um erro ao criar a reserva.', 'Erro'); // Toastr de erro
          },
        });
    } else {
      this.toastr.warning(
        'Preencha todos os campos antes de criar a reserva.',
        'Aviso'
      );
    }
  }

  dateFilter = (date: Date): boolean => {
    const formattedDate = date.toISOString().split('T')[0];
    return !this.diasReservados.includes(formattedDate); // Impede a seleção se estiver reservada
  };
}
