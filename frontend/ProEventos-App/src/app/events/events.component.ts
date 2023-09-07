import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  public events: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEvents();
  }

  public getEvents(): void {
    this.http.get('http://localhost:5134/api/Eventos').subscribe(
      response => {this.events = response; console.log("response:", response)},
      error => console.log(error)
    );
  }
}
