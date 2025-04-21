import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ToolComponent } from './tool/tool.component';
import { authGuard } from './_guard/auth.guard';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [authGuard],
        children: [
            { path: 'Tool', component: ToolComponent }
        ]
    }
];
