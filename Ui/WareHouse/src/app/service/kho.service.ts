import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class KhoService {
  private apiUrl = 'https://localhost:7076/api/Kho';

  constructor(private http: HttpClient) { }

  getKho(): Observable<any> {
    return this.http.get<any>(this.apiUrl, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
}
