import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';  
import { appConfig } from '../config/globel.conf'
const hostUrl = appConfig.company.host.url;

@Injectable()
export class ContactsService { 
    
    constructor(private http:HttpClient) {
    } 

    // Post data
	add(formData) {
		let updateUrl = `${hostUrl}/updateAndCreate`;
		let body =  `id=0&name=${formData.name}&email=${formData.email}&mobile=${formData.mobile}`
		let options = {
		    headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
		};

		return this.http.post(updateUrl, body, options);
	}  

	// List all 
	get(id=null) {
		let getUrl:string = `${hostUrl}/contacts`;
		if (id!=null) {
			getUrl = `${hostUrl}/contact?id=${id}`;
		}

		return this.http.get(getUrl);
	}  

	// Update data
	update(formData) {      
		let updateUrl = `${hostUrl}/updateAndCreate`;
		let body =  `id=${formData.id}&name=${formData.name}&email=${formData.email}&mobile=${formData.mobile}`
		let options = {
		    headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
		};

		return this.http.post(updateUrl, body, options);
	}     

	// Delete data
	delete(id: Number) { 
		let deleteUrl = `${hostUrl}/contactDeleteById?id=${id}`
		return this.http.get(deleteUrl);
	}

}
