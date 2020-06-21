import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {


  public connection: any;


  constructor() {
    this.startConnection();

  }

  public loginResponse = (resp): void => {
    console.log(resp);

  }

  private login(): void {
    const groupList: Array<string> = [];
    groupList.push('ui');
    this.connection.invoke('Login', 'UI', groupList).catch((err) => {
      console.log(err.toString());
    });
  }

  private startConnection = () => {
    this.connection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Information)
      .withUrl('http://localhost:7300/masterbus')
      .withAutomaticReconnect()
      .build();

    this.connection.start().then(() => {
      console.log('Connected!');
      this.connection.on('ReceiveConfiguration', this.loginResponse);
      this.login();
    }).catch((err) => {
      console.error(err.toString());
      return;
    });
  }
}
