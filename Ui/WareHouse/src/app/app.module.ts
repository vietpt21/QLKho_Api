import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { NavbarComponent } from './component/navbar/navbar.component';
import { PanelComponent } from './component/panel/panel.component';
import { FooterComponent } from './component/footer/footer.component';
import { KhoComponent } from './component/kho/kho.component';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PanelComponent,
    FooterComponent,
    KhoComponent
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
