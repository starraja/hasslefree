
export class ProductListDto implements IProductListDto {
    productListId?: number | undefined;
    productId?: number | undefined;
    quantity?: number | undefined;
    uom?: number | undefined;
    rate?: number | undefined;
    discount?: number | undefined;
    taxAmount?: number | undefined;
    amount?: number | undefined;
    source?: number | undefined;
    referenceId?: number | undefined;
    flagActive?: boolean | undefined;
    createdBy?: number | undefined;
    createdDateTime?: Date | undefined;
    modifiedBy?: number | undefined;
    modifiedDateTime?: Date | undefined;

    constructor(data?: IProductListDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.productListId = data["productListId"];
            this.productId = data["productId"];
            this.quantity = data["quantity"];
            this.uom = data["uom"];
            this.rate = data["rate"];
            this.discount = data["discount"];
            this.taxAmount = data["taxAmount"];
            this.amount = data["amount"];
            this.source = data["source"];
            this.referenceId = data["referenceId"];
            this.flagActive = data["flagActive"];
            this.createdBy = data["createdBy"];
            this.createdDateTime = data["createdDateTime"] ? new Date(data["createdDateTime"].toString()) : <any>undefined;
            this.modifiedBy = data["modifiedBy"];
            this.modifiedDateTime = data["modifiedDateTime"] ? new Date(data["modifiedDateTime"].toString()) : <any>undefined;
        }
    }

    static fromJS(data: any): ProductListDto {
        data = typeof data === 'object' ? data : {};
        let result = new ProductListDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["productListId"] = this.productListId;
        data["productId"] = this.productId;
        data["quantity"] = this.quantity;
        data["uom"] = this.uom;
        data["rate"] = this.rate;
        data["discount"] = this.discount;
        data["taxAmount"] = this.taxAmount;
        data["amount"] = this.amount;
        data["source"] = this.source;
        data["referenceId"] = this.referenceId;
        data["flagActive"] = this.flagActive;
        data["createdBy"] = this.createdBy;
        data["createdDateTime"] = this.createdDateTime ? this.createdDateTime.toISOString() : <any>undefined;
        data["modifiedBy"] = this.modifiedBy;
        data["modifiedDateTime"] = this.modifiedDateTime ? this.modifiedDateTime.toISOString() : <any>undefined;
        return data; 
    }
}

export interface IProductListDto {
    productListId?: number | undefined;
    productId?: number | undefined;
    quantity?: number | undefined;
    uom?: number | undefined;
    rate?: number | undefined;
    discount?: number | undefined;
    taxAmount?: number | undefined;
    amount?: number | undefined;
    source?: number | undefined;
    referenceId?: number | undefined;
    flagActive?: boolean | undefined;
    createdBy?: number | undefined;
    createdDateTime?: Date | undefined;
    modifiedBy?: number | undefined;
    modifiedDateTime?: Date | undefined;
}