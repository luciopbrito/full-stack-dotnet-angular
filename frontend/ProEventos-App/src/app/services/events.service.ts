import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Event } from '../models/Event.interface';

@Injectable()
export class EventsService {
  /**
   * @description property to get host URL to use as based URL for all methods
   * inside here.
   * @default `http://localhost:5134/api/events`
   */
  private _hostUrl = 'http://localhost:5134/api/events'

  constructor(
    private _httpClient: HttpClient,
  ) { }

  getAllEvents() {
    return this._httpClient.get<Event[]>(`${this._hostUrl}`);
  }

  getEventByTheme(theme: string) {
    return this._httpClient.get<Event[]>(`${this._hostUrl}/${theme}/theme`);
  }

  getEventById(id: number) {
    return this._httpClient.get<Event>(`${this._hostUrl}/${id}`);
  }
}
