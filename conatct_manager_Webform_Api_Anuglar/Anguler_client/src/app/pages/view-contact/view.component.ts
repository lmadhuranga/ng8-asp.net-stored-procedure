import { Component, OnInit } from '@angular/core'; 
import { Router, ActivatedRoute } from '@angular/router';


import { ContactsService } from '../../services/contacts.service';
import { Contact } from '../../interfaces/contact';

@Component({
  selector: 'app-view-contact',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.scss']
})
export class ViewContactComponent implements OnInit {
  
  contact:Contact;
   
  constructor(
    private contactService:ContactsService,  
    private router:Router,
    private route:ActivatedRoute, 
    ) { }
    
    ngOnInit() {
      // Set Defualt values
      this.contact = {
        name: '',
        email: '',
        mobile: ''
      };
      
      this.route.params.subscribe((params)=>{
        let contactId:string = params.id;        
        this.contactService.get(contactId).subscribe((contact:Contact)=>{
          console.log('contact', contact);
          this.contact = contact;
        });
      });
    }
  }
