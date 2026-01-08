import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { EpisodioCharactersModel, EpisodioResponseModel } from '../models/models';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class Servicios {
  private readonly apiUrl = `${environment.apiUrl}/RickAndMorty`;
  private readonly http = inject(HttpClient);
  

  getEpisodios(page: number): Observable<EpisodioResponseModel> {
    return this.http.get<EpisodioResponseModel>(`${this.apiUrl}?page=${page}`);
  }

  getEpisodioById(id: number): Observable<EpisodioCharactersModel> {
    return this.http.get<EpisodioCharactersModel>(`${this.apiUrl}/${id}`);
  }
}
