import { BusConfigurationDb } from './busConfigurationDb';
import { ActiveBuses } from './activeBuses';
export class InfoPacket {
    public activeBuses: ActiveBuses[] = [];
    public busesInDB: BusConfigurationDb[] = [];
    public ports: Array<string> = [];
}
