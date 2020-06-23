import { InfoPacket } from './../../model/info-packet';
import { DispatchService } from './../dispatch/dispatch.service';
import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {


  public connection: any;


  constructor(private dispatcher: DispatchService) {
    this.startConnection();

  }

  public loginResponse = (resp: InfoPacket): void => {
    this.dispatcher.loginPacket(resp);
  }

  private login(): void {
    const groupList: Array<string> = [];
    groupList.push('ui');
    this.connection.invoke('Login', 'control', groupList).catch((err) => {
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
      this.setupResponses();
      this.login();
    }).catch((err) => {
      console.error(err.toString());
      return;
    });
  }

  private setupResponses(): void {
    this.connection.on('InfoPacket', this.loginResponse);
  }
}
