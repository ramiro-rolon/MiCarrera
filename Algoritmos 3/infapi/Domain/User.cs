namespace ConAPI.Domain;



public class User
{
    public User(string user_name, 
                string password, 
                int role, 
                int? id = null, 
                string name = "",
                string last_name = "")
    {
        this.user_name = user_name;
        this.password = password;
        this.role = role;

        this.name = name;
        this.last_name = last_name;
    }

    public int? id {get; set;}
    public string name {get; set;}
    public string last_name {get; set;}
    public string user_name {get; set;}
    public int role {get; set;} = 0;
    public string password {get; set;}
}