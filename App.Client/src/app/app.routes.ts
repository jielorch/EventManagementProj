import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path:'',
        loadComponent: () => import('./features/pages/home/home').then(c => c.Home)
    },
    {
        path:'client',
        loadChildren: () => import('./features/pages/client/client.routes').then(r => r.clientRoutes)
    },
    {
        path:'about',
        loadComponent: () => import('./features/pages/about/about').then(c => c.About)
    }
];
