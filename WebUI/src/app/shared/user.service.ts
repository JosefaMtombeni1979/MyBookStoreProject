import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user.model';
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class UserService {

 
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  readonly rootUrl = environment.baseUrl;
 
  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();

   }
   public get currentUserValue(): User {
    return this.currentUserSubject.value;
   }
  registerUser(user: User) {
    console.log(user);
    const body: User = {
      UserName: user.UserName,
      Password: user.Password,
      Email: user.Email,
      FirstName: user.FirstName,
      LastName: user.LastName
    }
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.post(this.rootUrl + '/api/authentication/Register', body,{headers : reqHeader});
  }

  login(username: string, password: string) {
    alert('got here..')
    return this.http.post<any>(this.rootUrl + '/api/authentication/login', { username, password })
        .pipe(map(user => {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem('currentUser', JSON.stringify(user));
            console.log("User",  localStorage.setItem('currentUser', JSON.stringify(user)))
            this.currentUserSubject.next(user);
           // console.log(user);
            return user;

        }));
       
}

  userAuthentication(userName, password) {
   // alert(userName + password);
   var person = {
    username: userName,
    password: password,
    
  };

    var data = "username=" + userName + "&password=" + password + "&grant_type=password";
   // var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded','No-Auth':'True' });

    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.post(this.rootUrl + '/api/authentication/login', person,{headers : reqHeader});
    //return this.http.post(this.rootUrl + '/api/authentication/login', person, { headers: reqHeader });
  }


  get isLoggedIn(): boolean {
    const authToken = localStorage.getItem('access_token');
    return (authToken !== null) ? true : false;
  }


  getLoggedInUser(): Observable<any> {
    const authToken = localStorage.getItem('access_token');
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    const headers = new Headers({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${authToken}`
    })
    return this.http.get(this.rootUrl + '/api/authentication/login', { headers: reqHeader })
  }

 // getUsername() {
   // return JSON.parse(localStorage.getItem('currentUser'));
 // }

   getUserClaims(){
    // alert('claims');
    // const authToken = localStorage.getItem('currentUser');
    // return authToken;
    return  this.http.get(this.rootUrl+'/api/authentication/login',
    {headers : new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('currentUser')})});
    //var reqHeader = new HttpHeaders({'No-Auth':'True'});
   // return this.http.post(this.rootUrl + '/api/authentication/login', localStorage.getItem('currentUser'),{headers : reqHeader});
   
  }

  handleError(error: HttpErrorResponse) {
    let msg = '';
    if (error.error instanceof ErrorEvent) {
      // client-side error
      msg = error.error.message;
    } else {
      // server-side error
      msg = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(msg);
  }

}
