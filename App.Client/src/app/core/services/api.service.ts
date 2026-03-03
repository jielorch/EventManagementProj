import { Injectable } from "@angular/core";
import { environment } from "../../../environments/environment";
import { HttpClient, HttpContext, HttpHeaders, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { BYPASS_AUTH } from "../tokens/token";

@Injectable({
  providedIn: 'root'
})
export class ApiService{

    private baseUrl = environment.apiBaseUrl
     private headers = new HttpHeaders().set('content-type', 'application/json; charset=utf-8');
    
    constructor(private httpClient: HttpClient) { }

    post(controller: string, endpoint: string, param: any, withHeaders:boolean = false, shouldByPass = false):Observable<any>{
        const options = withHeaders ? { headers: this.headers, context: new HttpContext().set(BYPASS_AUTH, shouldByPass) } : { context: new HttpContext().set(BYPASS_AUTH, shouldByPass) };
        return this.httpClient.post<any>(`${this.baseUrl}/${controller}/${endpoint}`, param, options);
    }

    put(controller: string, endpoint: string, param: any, withHeaders:boolean = false, shouldByPass = false): Observable<any>{
          const options = withHeaders ? { headers: this.headers, context: new HttpContext().set(BYPASS_AUTH, shouldByPass) } : { context: new HttpContext().set(BYPASS_AUTH, shouldByPass) };
        return this.httpClient.put<any>(`${this.baseUrl}/${controller}/${endpoint}`, param, options);
    }

    get(controller: string, endpoint: string, params?: any, shouldByPass = false): Observable<any>{
        let url = `${this.baseUrl}/${controller}/${endpoint}`;
        let httpParams = new HttpParams();
        if(params){
            if(typeof params === 'object' && params !== null){
                 Object.keys(params).forEach(key => {
                    httpParams = httpParams.set(key, params[key]);
                 });
            }else{
                url += `/${params}`;
            }
        }
        return this.httpClient.get<any>(url, { params: httpParams, context: new HttpContext().set(BYPASS_AUTH, shouldByPass) });
    }
}