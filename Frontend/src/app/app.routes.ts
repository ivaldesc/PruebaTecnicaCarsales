import { Routes } from '@angular/router';
import { Episodio } from './episodio/episodio';
import { Details } from './episodio/details/details';

export const routes: Routes = [
    {
        path: '', component: Episodio
    },
    {
        path: 'epiDetails/:id', component: Details
    },
    // {
    //     path: '**', redirectTo: '/episodes'
    // }
];
