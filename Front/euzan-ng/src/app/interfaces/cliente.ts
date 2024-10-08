export interface UsersInterface {
    IdClient: number;
    Username: string;
    Password: string;
    Email: string;
    FirstName: string;
    LastName: string;
    Phone: string;
    Province: string;
    Canton: string;
    District: string;
    Role: string;
}

export class Cliente implements UsersInterface {
    IdClient!: number;
    Username!: string;
    Password!: string;
    Email!: string;
    FirstName!: string;
    LastName!: string;
    Phone!: string;
    Province!: string;
    Canton!: string;
    District!: string;
    Role: string;
}
