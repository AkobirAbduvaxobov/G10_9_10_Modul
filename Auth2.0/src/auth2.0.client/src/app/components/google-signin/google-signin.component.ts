import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service'; // adjust path if needed

declare const google: any;

@Component({
  selector: 'app-google-signin',
  standalone: true,
  imports: [],
  templateUrl: './google-signin.component.html',
  styleUrls: ['./google-signin.component.css']
})
export class GoogleSigninComponent {
  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    google.accounts.id.initialize({
      client_id: this.authService.getClientId(), // 🔥 use service
      callback: (response: any) => this.handleResponse(response)
    });

    google.accounts.id.renderButton(
      document.getElementById('g_id_signin'),
      { theme: 'outline', size: 'large', text: 'signin_with', shape: 'rect' }
    );
  }

  handleResponse(response: any) {
    const idToken = response.credential;

    this.authService.loginWithGoogle({ idToken }).subscribe({
      next: (result) => {
        console.log('✅ Login success:', result);
        // e.g. store JWT, redirect, etc.
      },
      error: (err) => {
        console.error('❌ Login error:', err);
      }
    });
  }
}
