import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  public events: Event[] = [];
  public eventsFilters: Event[] = [];
  widthImg: number = 150;
  marginImg: number = 2;
  showImage: boolean = false;
  private _filter: string = '';

  public get filter() {
    return this._filter;
  }

  public set filter(value: string) {
    this._filter = value;
    this.eventsFilters = this.filter ? this.listFilter(this.filter) : this.events;
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEvents();
  }

  public handleShowImage = () => {
    this.showImage = !this.showImage;
  }

  public listFilter(filterBy: string): any {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      e => e.dataEvento.toString().toLowerCase().indexOf(filterBy) !== -1 ||
      e.eventoId.toString().toLowerCase().indexOf(filterBy) !== -1 ||
      e.imagemURL.toString().toLowerCase().indexOf(filterBy) !== -1 ||
      e.local.toString().toLowerCase().indexOf(filterBy) !== -1 ||
      e.qtdPessoas.toString().toLowerCase().indexOf(filterBy) !== -1 ||
      e.tema.toString().toLowerCase().indexOf(filterBy) !== -1
    )
  }

  public getEvents(): void {
    this.http.get<Event[]>('http://localhost:5134/api/Eventos').subscribe(
      response => {
        this.events = response;
        this.eventsFilters = this.events;
      },
      error => console.log(error)
    );
  }
}

type Event = {
  eventoId: number,
  local: string,
  dataEvento: string,
  tema: string,
  qtdPessoas: number,
  lote: string,
  imagemURL: string
}
