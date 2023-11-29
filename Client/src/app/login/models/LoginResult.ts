export class LoginResult{
  userId: number | null;
  firstName: string;
  lastName: string;
  email: string;
  token: string;

  constructor(userId: number | null,
              firstName: string,
              lastName: string,
              email: string,
              token: string) {
    this.userId = userId;
    this.firstName = firstName;
    this.lastName = lastName;
    this.email = email;
    this.token = token
  }
}
