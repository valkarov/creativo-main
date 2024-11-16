export interface InventoryItemsInterface {
    Id: number;
    Name: string;
    Quantity: number;
}

export interface Order {
    Id: number;
    Phone: string;
    Email: string;
    Address: string;
    CityId: number;
    City: string;
    entrepeneurship: string;
    EntrepeneurshipId: number;
    Status: string;
    Date: Date;
    DeliveryDate: Date;
    OrderProducts: OrderProduct[];
}

export interface OrderProduct {
    Id?: number;
    Quantity: number;
    OrderId?: number;
    ProductId: number;
    Product: string;
}
