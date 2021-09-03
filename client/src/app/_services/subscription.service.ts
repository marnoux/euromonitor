import { Injectable } from '@angular/core';
import { ReplaySubject, Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SubscriptionService {
  baseUrl = 'https://localhost:5001/api/';
  private currentSubscriptionSource = new ReplaySubject<Subscription>(1);

  constructor() {}
}
