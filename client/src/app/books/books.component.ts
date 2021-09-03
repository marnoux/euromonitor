import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css'],
})
export class BooksComponent implements OnInit {
  baseUrl = 'https://localhost:5001/api/';
  books: any;
  subs: any;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getBooks();
  }

  getBooks() {
    const auth_token = 'f';
    const header = new Headers({
      Authorization: `Bearer ${auth_token}`,
    });

    this.http.get(this.baseUrl + 'books').subscribe((response) => {
      this.books = response;
    });
  }

  imageSrc(id) {
    return '../../assets/book-img-' + id + '.jpg';
  }

  addSubscription(id, name) {
    const user = JSON.parse(localStorage.getItem('user'));

    if (confirm('Are you want to subscribe to' + name)) {
      this.http
        .post(this.baseUrl + 'subscriptions', {
          BookId: id,
          AppUserId: user.id,
        })
        .subscribe((response) => {
          this.subs = response;
        });
    }
  }
}
