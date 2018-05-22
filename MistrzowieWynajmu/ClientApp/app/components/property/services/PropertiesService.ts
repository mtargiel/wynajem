import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator.map';
import { Property } from '../../../models/property';
import { PropertiesBackendServices } from '../../../services/properties-backend.services';

@Injectable()
export class PropertyService {
    constructor(private propertiesBackendService: PropertiesBackendServices) {

    }
    addProperty(newProperty: Property): Observable<number> {
        return this.propertiesBackendService.addProperty(newProperty);

    }
    getProperty(propertyId: number): Observable<Property> {
        return this.propertiesBackendService.getProperty(propertyId);
    }
    getProperties(): Observable<Property[]> {
        return this.propertiesBackendService.getProperties();

    }
    updateProperty(updateProperty: Property): Observable<Property> {
        return this.updateProperty(updateProperty);
    }
    deleteProperty(propertyId: number): Observable<number> {
        return this.propertiesBackendService.deleteProperty(propertyId);
    }
}