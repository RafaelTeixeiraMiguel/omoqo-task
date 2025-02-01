import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class ShipService {
  private baseUrl = '';
  constructor(private _http: HttpClient, @Inject('BASE_URL') private url: string) { 
    this.baseUrl = url + '/Ships';
  }

  create(data: any): Observable<any>{
    return this._http.post(this.baseUrl, data);
  }

  listAll(): Observable<any>{
    return this._http.get(this.baseUrl);
  }

  delete(id: Guid): Observable<any>{
    return this._http.delete(this.baseUrl + `/${id}`);
  }

  update(data: any): Observable<any>{
    return this._http.put(this.baseUrl, data);
  }
}
