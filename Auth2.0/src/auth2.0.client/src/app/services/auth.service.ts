import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class AuthService {

  // 🔥 Hardcoded values directly in BLL logic
  private readonly googleClientId =
    '1000188758058-vmdfqkl1kn7r5e1arqakpc9mvdu1aadu.apps.googleusercontent.com';
  private readonly backendBaseUrl = 'https://localhost:7189';

  constructor(private http: HttpClient) {}

  getClientId(): string {
    return this.googleClientId;
  }

  loginWithGoogle(payload: { idToken: string }) {
    const url = `${this.backendBaseUrl}/api/auth/google/login`;
    return this.http.post(url, payload);
  }

  registerWithGoogle(payload: { idToken: string }) {
    const url = `${this.backendBaseUrl}/api/auth/google/register`;
    return this.http.post(url, payload);
  }
}
