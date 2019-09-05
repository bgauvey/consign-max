import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClarityModule } from '@clr/angular';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { DashboardComponent } from './dashboard/dashboard.component';
import { InteractiveAnalyticsComponent } from './interactive-analytics/interactive-analytics.component';
import { ManagementComponent } from './management/management.component';
import { ConsignerDetailsComponent } from './consigner-details/consigner-details.component';
import { PosComponent } from './pos/pos.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    InteractiveAnalyticsComponent,
    ManagementComponent,
    ConsignerDetailsComponent,
    PosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ClarityModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
