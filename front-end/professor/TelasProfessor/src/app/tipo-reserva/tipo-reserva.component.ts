import { Component } from '@angular/core';

@Component({
  selector: 'app-tipo-reserva',
  templateUrl: './tipo-reserva.component.html',
  styleUrl: './tipo-reserva.component.css',
})
export class TipoReservaComponent {
  selectedOption: string | null = null;

  onSelectionChange() {
    console.log('Opção selecionada:', this.selectedOption);
  }

  onNext() {
    if (this.selectedOption) {
      alert(`Você escolheu: ${this.selectedOption}`);
      // Adicione a lógica para ir para a próxima etapa
    }
  }
}
