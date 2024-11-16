export interface ProvinciaInterface {
    IdEntrepreneurship: number;
    Name: string;
}

export class Province implements ProvinciaInterface {
    IdEntrepreneurship!: number;
    Name!: string;
}

export interface DistritoInterface {
    Name: string;
    Canton: string;
}

export class Distrito implements DistritoInterface {
    Name!: string;
    Canton!: string;
}

export interface CantonInterface {
    Name: string;
    Province: string;
}

export class Canton implements CantonInterface {
    Name!: string;
    Province!: string;
}
