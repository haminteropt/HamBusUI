import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {


  public connection: any;


  constructor() {
    this.connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl('http://localhost:7300/masterbus')
      .withAutomaticReconnect()
      .build();

    this.connection.start().then(() => {
      console.log('Connected!');
    }).catch((err) => {
      console.error(err.toString());
      return;
    });

    // this.connection.on('BroadcastMessage', this.broadcastMessage);
    this.connection.on('LoginResponse', this.loginResponse);

  }

  public loginResponse = (resp): void => {
    console.log(resp);
  }


}
