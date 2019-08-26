import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-contact-name',
  templateUrl: './contact-name.component.html',
  styleUrls: ['./contact-name.component.css']
})
export class ContactNameComponent implements OnInit {
  @Input() contact;
  constructor() { 

  }

  ngOnInit() {
    // console.log('contact name', this.contact)
  }

}
