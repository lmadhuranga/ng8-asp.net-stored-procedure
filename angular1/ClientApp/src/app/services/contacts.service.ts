import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'; 
import { MasterService } from './master.service';

@Injectable()
export class ContactsService extends MasterService { 
    
    constructor(http:HttpClient) { 
        super(http, "Contacts");
    } 
}
