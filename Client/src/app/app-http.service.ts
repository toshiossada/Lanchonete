import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AppHttpService {
  private url: string;
  // tslint:disable-next-line:max-line-length
  private token = '';

  constructor(private http: HttpClient) {
    console.log('service-construtor');
  }

  build(url) {
    this.url = `https://localhost:5001/api/v1/${url}`;

    return this;
  }

  list(page = null) {
    let url = this.url;
    if (page) {
      url = `${this.url}`;
    }
    return this.http.get(url);
  }

  search(term, page = 1) {
    let url = `${this.url}?q=${term}`;
    if (page) {
      url += `&page=${page}`;
    }

    return this.http.get(url);
  }

  delete(id) {
    return this.http.delete(`${this.url}/${id}`);
  }

  get(id) {
    return this.http.get(`${this.url}/${id}`);
  }

  update(id, data) {
    return this.http.put(`${this.url}/${id}`, data);
  }

  create(data) {
    return this.http.post(this.url, data);
  }

}
