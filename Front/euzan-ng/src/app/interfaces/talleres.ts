export interface TallerInterface {
    IdEntrepreneurship: string,
    IdWorkshop: number,
    Name: string,
    Price: number,
    Description: string,
    Link: string,
    Type: string
}

export class Taller implements TallerInterface{
    IdEntrepreneurship!: string;
    IdWorkshop!: number;
    Name!: string;
    Price!: number;
    Description!: string;
    Link!: string;
    Type!: string;    
}


export interface TallerClienteInterface {
    IdWorkshop: number,
    IdClient: string
}

export class TallerClient implements TallerClienteInterface{
    IdWorkshop!: number;
    IdClient!: string;
}


export interface TallerPagoInterface {
    Id:number,
    IdClient:string, 
    IdWorkshop:number, 
    LastDigits:number, 
    Owner:string,
    Price:number,
    State:string
}

export class TallerPago implements TallerPagoInterface {
    Id!: number;
    IdClient!: string;
    IdWorkshop!: number;
    LastDigits!: number;
    Owner!: string;
    Price!: number;
    State!: string;

}


