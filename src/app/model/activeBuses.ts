import { BusType } from './bus-type.enum';

export class ActiveBuses {
    name: string;
    configuration: string;
    groups: Array<string> = [];
    busType: BusType;
    isActive: boolean;
}
