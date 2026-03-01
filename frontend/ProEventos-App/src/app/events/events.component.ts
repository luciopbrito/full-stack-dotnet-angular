import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EventsService } from '../services/events.service';
import { Event } from '../models/Event.interface';

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

  public get filter(): string {
    return this._filter;
  }

  public set filter(value: string) {
    this._filter = value;
    this.eventsFilters = this.filter ? this.listFilter(this.filter) : this.events;
  }

  constructor(
    private http: HttpClient,
    private _eventServices: EventsService
  ) { }

  ngOnInit(): void {
    this.getEvents();
  }

  public handleShowImage = () => {
    this.showImage = !this.showImage;
  }

  public listFilter(filterBy: string): Event[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.events.filter(
      e => e.dateEvent.toString().toLowerCase().indexOf(filterBy) !== -1 ||
      e.id.toString().toLowerCase().indexOf(filterBy) !== -1 ||
      e.imageURL.toString().toLowerCase().indexOf(filterBy) !== -1 ||
      e.local.toString().toLowerCase().indexOf(filterBy) !== -1 ||
      e.qtdPeople.toString().toLowerCase().indexOf(filterBy) !== -1 ||
      e.theme.toString().toLowerCase().indexOf(filterBy) !== -1
    )
  }

  public getEvents(): void {
   this._eventServices.getAllEvents().subscribe(
      response => {
        this.events = response;
        this.eventsFilters = this.events;
      },
      error => console.log(error)
    );
  }
}
