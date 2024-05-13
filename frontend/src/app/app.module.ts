import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { PanelComponent } from './components/panel/panel.component';
import { ButtonComponent } from './components/button/button.component';
import { LoginComponent } from './pages/login/login.component';
import { TabComponent } from './components/tab/tab.component';
import { TodayComponent } from './pages/today/today.component';
import { TomorrowComponent } from './pages/tomorrow/tomorrow.component';
import { AllComponent } from './pages/all/all.component';
import { CardComponent } from './components/card/card.component';
import { NewComponent } from './pages/new/new.component';

import { AngularFireAuthModule } from "@angular/fire/compat/auth";
import { AngularFireModule } from '@angular/fire/compat';

import { environment } from '../environments/environment';

import { HttpClientModule } from '@angular/common/http';

import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PanelComponent,
    ButtonComponent,
    LoginComponent,
    TabComponent,
    TodayComponent,
    TomorrowComponent,
    AllComponent,
    CardComponent,
    NewComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AngularFireAuthModule,
    HttpClientModule,
    ReactiveFormsModule,
    AngularFireModule.initializeApp(environment.firebaseConfig)
  ],
  providers: [
    provideClientHydration(),
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
