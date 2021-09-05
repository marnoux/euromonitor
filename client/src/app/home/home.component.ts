import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  registerMode = false;
  isLoggedIn = false;

  constructor() {}

  ngOnInit() {
    this.checkLogin();
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

  checkLogin() {
    const user = JSON.parse(localStorage.getItem('user')!);

    if (user) this.isLoggedIn = true;
    else this.isLoggedIn = false;
  }
}
