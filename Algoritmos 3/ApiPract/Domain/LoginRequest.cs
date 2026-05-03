namespace ApiPract.Domain;

public class LoginRequest
{
    public string email { get; set; }
    public string pass { get; set;}

    public LoginRequest(string email, string pass)
    {
        this.email = email;
        this.pass = pass;
    }

    public LoginRequest(){}

}