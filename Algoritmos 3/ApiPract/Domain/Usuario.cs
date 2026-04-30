public class Usuario{
    public int? id{get; set;}
    public string nombre { get; set; }
    public string mail {get; set;}
    public string pass {get; set;}

    public Usuario(int id, string nombre, string mail, string pass){
        this.id = id;
        this.nombre = nombre;
        this.mail = mail;
        this.pass = pass;
    }
}