import { Component } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent {
  public events: any = [
    {
      Tema: 'Angular',
      Local: 'Belo Horizonte',
    },
    {
      Tema: '.NET 7',
      Local: 'Belo Horizonte',
    },
    {
      Tema: 'Angular e Suas Novidades',
      Local: 'Belo Horizonte',
    },
  ];
}
