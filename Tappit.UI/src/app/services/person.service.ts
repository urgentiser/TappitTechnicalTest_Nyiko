import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  constructor(private _http: HttpClient) {}

  addPerson(data: any): Observable<any> {
    return this._http.post('https://localhost:7297/api/Person', data);
  }

  updatePerson(id: number, data: any): Observable<any> {
    return this._http.put(`https://localhost:7297/api/Person/${id}`, data);
  }

  getPersonList(): Observable<any> {
    return this._http.get('https://localhost:7297/api/Person');
  }

  deletePerson(id: number): Observable<any> {
    return this._http.delete(`https://localhost:7297/api/Person/${id}`);
  }
}
