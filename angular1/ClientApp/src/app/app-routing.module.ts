import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddContactComponent } from './pages/add-contact/add-contact.component'
import { ContactsComponent } from './pages/list-contacts/list.component'
import { EditContactComponent } from './pages/edit-contact/edit.component'
import { ViewContactComponent } from './pages/view-contact/view.component'

const routes: Routes = [
  { path: "", redirectTo: 'contacts', pathMatch: 'full' },
  { path: 'add', component: AddContactComponent },
  { path: 'contacts', component: ContactsComponent },
  { path: 'edit/:id', component: EditContactComponent },
  { path: 'view/:id', component: ViewContactComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
