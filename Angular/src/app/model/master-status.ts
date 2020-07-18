

export enum HamBusError { NoError = 0, NoConfigure, Unknown }

export class MasterStatus {
    public message: string;
    public errorNum: HamBusError;
}
