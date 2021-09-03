import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Book } from '../_models/book';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css'],
})
export class BooksComponent implements OnInit {
  baseUrl = 'https://localhost:5001/api/books';
  books: any;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getBooks();
  }

  getBooks() {
    const auth_token = 'f';
    const header = new Headers({
      Authorization: `Bearer ${auth_token}`,
    });

    this.http.get(this.baseUrl).subscribe((response) => {
      this.books = response;
    });
  }

  randomSrc() {
    const rnd = Math.floor(Math.random() * 7 + 1);
    return '../../assets/book-img-' + rnd + '.jpg';
  }
}
