import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-subscriptions',
  templateUrl: './subscriptions.component.html',
  styleUrls: ['./subscriptions.component.css'],
})
export class SubscriptionsComponent implements OnInit {
  baseUrl = 'https://localhost:5001/api/';
  subs: any;
  user = JSON.parse(localStorage.getItem('user'));

  constructor(
    private http: HttpClient,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit() {
    this.getSubs();
  }

  getSubs() {
    const user = JSON.parse(localStorage.getItem('user'));
    const auth_token = user.token;
    const headers = new HttpHeaders().set(
      'Authorization',
      `Bearer ${auth_token}`
    );
    this.http
      .get(this.baseUrl + 'subscriptions/' + this.user.id, { headers: headers })
      .subscribe(
        (response) => {
          this.subs = response;
          console.log(response);
        },
        (error) => {
          console.log(error);
          this.toastr.error(error.error);
        }
      );
  }

  removeSub(id) {
    const user = JSON.parse(localStorage.getItem('user'));
    const auth_token = user.token;
    const headers = new HttpHeaders().set(
      'Authorization',
      `Bearer ${auth_token}`
    );

    if (confirm('Are you want to delete this subscription?')) {
      this.http
        .delete(this.baseUrl + 'subscriptions/' + id, { headers: headers })
        .subscribe(
          (response) => {
            console.log(response);
            this.toastr.success('Subscription removed successfully');
            this.ngOnInit();
          },
          (error) => {
            console.log(error);
            this.toastr.error(error.error);
          }
        );
    }
  }
}
