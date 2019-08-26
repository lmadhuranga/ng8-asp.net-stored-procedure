import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { ContactsComponent } from './pages/list-contacts/list.component'
import { ViewContactComponent } from './pages/view-contact/view.component'
import { EditContactComponent } from './pages/edit-contact/edit.component'
import { AddContactComponent } from './pages/add-contact/add-contact.component'
 

import { ContactsService } from './services/contacts.service';
import { ContactNameComponent } from './components/contact-name/contact-name.component'


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ContactsComponent,
    EditContactComponent,
    ViewContactComponent,
    ContactNameComponent,
    AddContactComponent 
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [ ContactsService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
