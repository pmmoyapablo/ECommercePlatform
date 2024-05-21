import { CarSessionDetail } from "./carsessiondetail.model";

export interface CarSession {
    id: string;
    total: number;
    dateRegister: string;
    listDetails: CarSessionDetail[];
}