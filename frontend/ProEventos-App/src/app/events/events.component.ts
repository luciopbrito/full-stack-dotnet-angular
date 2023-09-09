import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss'],
})
export class EventsComponent implements OnInit {
  public events: any = [];
  widthImg: number = 150;
  marginImg: number = 2;
  showImage: boolean = false;
  filter: string = '';

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEvents();
  }

  public handleShowImage = () => {
    this.showImage = !this.showImage;
  }

  public getEvents(): void {
    this.http.get('http://localhost:5134/api/Eventos').subscribe(
      response => this.events = response,
      error => console.log(error)
    );
  }
}
