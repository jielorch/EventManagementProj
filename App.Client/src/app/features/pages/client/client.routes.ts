import { Routes } from "@angular/router";

export const clientRoutes: Routes =[
    {
        path:'',
        loadComponent: () => import('./client').then(c => c.Client)
    }
]