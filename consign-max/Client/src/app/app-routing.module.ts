import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ManagementComponent } from './management/management.component';
import { InteractiveAnalyticsComponent } from './interactive-analytics/interactive-analytics.component';
import { PosComponent } from './pos/pos.component';
import { ConsignerDetailsComponent } from './consigner-details/consigner-details.component';

const routes: Routes = [
  { path: '',
    redirectTo: '/dashboard',
    pathMatch: 'full'
  },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'consigner-details/:id', component: ConsignerDetailsComponent },
  { path: 'management', component: ManagementComponent },
  { path: 'interactive-analytics', component: InteractiveAnalyticsComponent },
  { path: 'pos', component: PosComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
