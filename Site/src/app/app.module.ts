import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './_components/footer/footer.component';
import { NavbarComponent } from './_components/navbar/navbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { LoadInterceptor } from './_interceptors/loading.interceptor';
import { BaseUiComponent } from './_components/base-ui/base-ui.component';
import { LoginComponent } from './Pages/login/login.component';
import { PerfilListComponent } from './Pages/perfil-list/perfil-list.component';
import { PerfilFormComponent } from './Pages/perfil-form/perfil-form.component';
import { UsuarioListComponent } from './Pages/usuario-list/usuario-list.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FooterComponent,
    NavbarComponent,
    BaseUiComponent,
    LoginComponent,
    PerfilListComponent,
    PerfilFormComponent,
    UsuarioListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgxSpinnerModule

  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: LoadInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
