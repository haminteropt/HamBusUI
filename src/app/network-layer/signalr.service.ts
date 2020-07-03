import { BusConfigurationDb } from '../model/busConfigurationDb';
import { InfoPacket } from '../model/info-packet';
import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { HamBusError } from 'src/app/model/master-status';
import { DispatchService } from './dispatch.service';

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
  public saveResponse = (resp: HamBusError): void => {
    this.dispatcher.saveConfigStatus(resp);
  }

  private login(): void {
    const groupList: Array<string> = [];
    groupList.push('ui');
    const emptyPortList = [];
    this.connection.invoke('Login', 'control', groupList, emptyPortList).catch((err) => {
      console.log(err.toString());
    });
  }
  public saveConfig(name: string, conf: BusConfigurationDb): void {
    // console.log(`name: ${name}`);
    // this.connection.invoke('SaveConfiguration', name).catch((err) => {
    //   console.log(err.toString());
    // });
    this.connection.invoke('SaveConfiguration', name, conf).catch((err) => {
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

      // TODO: This should be called someplace else
      this.login();
    }).catch((err) => {
      console.error(err.toString());
      return;
    });
  }

  private setupResponses(): void {
    this.connection.on('InfoPacket', this.loginResponse);
    this.connection.on('SaveResults', this.saveResponse)
  }
}
