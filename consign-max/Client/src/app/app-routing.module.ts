import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ConsignerListComponent } from './consigner/consigner-list.component';
import { ConsignerDetailsComponent } from './consigner/consigner-details.component';
import { ManagementComponent } from './management/management.component';
import { InteractiveAnalyticsComponent } from './interactive-analytics/interactive-analytics.component';
import { PosComponent } from './pos/pos.component';


const routes: Routes = [
  { path: '',
    redirectTo: '/consigners',
    pathMatch: 'full'
  },
  { path: 'consigners', component: ConsignerListComponent },
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
