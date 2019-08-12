import { Component, OnInit } from '@angular/core';
import { Contact } from '../../interfaces/contact';

// Configuration file
import { appConfig } from '../../config/globel.conf'

import { ContactsService } from '../../services/contacts.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ContactsComponent implements OnInit {
  contacts:Contact[] = [];
  constructor(private contactService: ContactsService) {}
  
  ngOnInit() {
    this.listAll()
  }
  
  listAll(){
    this.contactService.get().subscribe((contacts:Contact[]) =>{
      console.log(contacts);
      
      this.contacts = contacts;
    });
  }
  
  remove(contact:Contact){
    if(confirm("Are you sure to delete this")) { 
      this.contactService.delete(contact.id).subscribe((res) => {
        this.listAll();
      });
    } 
  }
  
  details(contact){
    if(!contact.details) {
      this.countDownloads(contact);
      contact.details = true;
    }      
    else {
      contact.details = !contact.details;
    }    
  }

  countDownloads(contact:Contact){
    contact.downloads = contact.downloads+1;
    this.contactService.update(contact).subscribe((res)=>{
      console.log('Update Successfull');
    })
  }
  
  /* To copy Text from Textbox */
  // copyInputMessage(inputElement){
  //   inputElement.select();
  //   document.execCommand('copy');
  //   inputElement.setSelectionRange(0, 0);
  // }  
}
