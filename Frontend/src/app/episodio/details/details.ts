import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Servicios } from '../../servicios/servicios';
import { Observable, switchMap } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { EpisodioCharactersModel } from '../../models/models';

@Component({
  selector: 'app-details',
  standalone: true,
  imports: [AsyncPipe],
  templateUrl: './details.html',
  styleUrl: './details.css',
})
export class Details {

  episode$!: Observable<EpisodioCharactersModel>;
  // episode: any;
  constructor(private route: Router, private Acroute: ActivatedRoute, private service: Servicios) {
    this.episode$ = this.Acroute.paramMap.pipe(
      switchMap(params => {
        const id = Number(params.get('id'));
        return this.service.getEpisodioById(id);
      })
    );
  }

  ngOnInit() {
    
  }

  goBack(): void {
    this.route.navigate(['']);
  }
}
