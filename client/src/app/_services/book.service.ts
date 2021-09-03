import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Book } from '../_models/book';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  baseUrl = 'https://localhost:5001/api/';
  private currentBookSource = new ReplaySubject<Book>(1);
  currentBook$ = this.currentBookSource.asObservable();

  constructor(private http: HttpClient) {}

  getBooks(model: any) {
    return this.http.get(this.baseUrl + 'books', model).pipe(
      map((response: any) => {
        const book = response;
        if (book) {
          this.currentBookSource.next(book);
        }
      })
    );
  }
}
