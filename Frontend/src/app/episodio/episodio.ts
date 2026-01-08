import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { Servicios } from '../servicios/servicios';
import { EpisodioModel, EpisodioResponseModel } from '../models/models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-episodio',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './episodio.html',
  styleUrl: './episodio.css',
})
export class Episodio {
  episodios: EpisodioModel[] = [];
  currentPage = 1;
  totalPages = 1;
  isLoading = signal(false);
  errorMessage = '';

  constructor(private episodiosService: Servicios, private router: Router) {}

  ngOnInit(): void {
    this.loadEpisodios();

  }

  viewDetails(id: number): void {
    this.router.navigate(['/epiDetails', id]);
  }

  loadEpisodios(page: number = 1): void {
    this.isLoading.set(true);
    this.errorMessage = '';
    this.episodiosService.getEpisodios(page)
      .subscribe({
        next: (response) => {
          this.episodios = response.results;
          this.totalPages = response.info.pages;
          this.isLoading.set(false);
        },
        error: () => {
          this.errorMessage = 'Error al cargar episodios';
          this.isLoading.set(false);
        }
      });
  }

  prevPage(): void {
    if (this.currentPage > 1) {
      this.currentPage -= 1;
      this.loadEpisodios(this.currentPage);
    }
  }

  nextPage(): void {
    if (this.currentPage < this.totalPages) {
      this.currentPage += 1;
      this.loadEpisodios(this.currentPage);
    }
  }
}
