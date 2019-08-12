import { Component } from '@angular/core';
import { appConfig } from '../../config/globel.conf';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})

export class AppComponent {
  constructor(private titleService: Title){}
  appName:string = appConfig.app.name;
  
  ngOnInit(): void {
    this.titleService.setTitle(this.appName);
  }
}
