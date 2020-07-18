import { BusType } from './bus-type.enum';

export class BusConfigurationDb {
    public id?: number = null;
    public name: string;
    public version: number;
    public busType: BusType;
    public configuration: string;

}
