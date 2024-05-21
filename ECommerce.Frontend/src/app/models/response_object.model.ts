import { Employee } from "./employee.model";

export interface ResponceObject {
    IsSuccess: boolean;
    Messange: string;
    Data: Employee;
}