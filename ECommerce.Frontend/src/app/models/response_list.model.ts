import { Employee } from "./employee.model";

export interface ResponceList {
    IsSuccess: boolean;
    Messange: string;
    Data: Employee[];
}