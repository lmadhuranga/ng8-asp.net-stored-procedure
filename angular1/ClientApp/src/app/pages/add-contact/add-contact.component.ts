import { Component, OnInit } from '@angular/core';
import { Form } from '@angular/forms';
import { Router } from '@angular/router';


import { ContactsService } from '../../services/contacts.service';
import { Contact } from '../../interfaces/contact'; 


@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.scss']
})
export class AddContactComponent implements OnInit {
  
  constructor(
    private router: Router,
    private contactService: ContactsService, 
    ) { }
    
    contact:Contact; 
    
    ngOnInit() {

      // Set Defualt values
      this.contact = { 
        name:'',
        downloads:0,
        email:''
      };
       
    }
    
    // Post data to server
    addContact(){      
      this.contactService.add(this.contact).subscribe((res)=>{
        console.log('Contact Added Sucessfully'); 
        this.router.navigate(['contacts']);
      });
    } 
  }
  