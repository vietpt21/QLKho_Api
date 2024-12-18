import { Component, NgModule } from '@angular/core';

import { RouterModule, Routes } from '@angular/router';
import { PanelComponent } from './component/panel/panel.component';
import { KhoComponent } from './component/kho/kho.component';


const routes: Routes = [
  { path: '', component: PanelComponent },
  { path: 'kho', component: KhoComponent },

];



@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
  
})
export class AppRoutingModule { }
