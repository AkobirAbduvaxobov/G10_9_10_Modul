import { Component } from '@angular/core';
import { GoogleSigninComponent } from './components/google-signin/google-signin.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [GoogleSigninComponent],
  template: `<app-google-signin></app-google-signin>`,
  styleUrls: ['./app.component.css']
})
export class AppComponent {}
