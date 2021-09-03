import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Sub } from '../_models/sub';

@Injectable({
  providedIn: 'root',
})
export class SubscriptionService {
  baseUrl = 'https://localhost:5001/api/';
  private currentSubscriptionSource = new ReplaySubject<Sub>(1);
  currentSubscription$ = this.currentSubscriptionSource.asObservable();

  constructor(private http: HttpClient) {}

  addSub(model: Sub) {
    return this.http.post(this.baseUrl + 'subscriptions', model).pipe(
      map((sub: Sub) => {
        if (sub) {
          this.currentSubscriptionSource.next(sub);
        }
        return sub;
      })
    );
  }
}
