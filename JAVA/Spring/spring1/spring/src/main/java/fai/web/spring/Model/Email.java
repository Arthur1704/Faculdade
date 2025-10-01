package fai.web.spring.Model;

public class Email {

    private int id;
    private String name;
    private String email;
    private String phone;
    private String subject;
    private String message;

    public Email() {}

    public Email(String name, String email, String phone, String subject, String message) {
        this.name = name;
        this.email = email;
        this.phone = phone;
        this.subject = subject;
        this.message = message;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public String getSubject() {
        return subject;
    }

    public void setSubject(String subject) {
        this.subject = subject;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public void persistirEmail(Conexao conexao) {

        String sql = "INSERT INTO contatos (name, email, phone, subject, message) " +
                     "VALUES (?, ?, ?, ?, ?)";

        conexao.executarComando(sql,  this.name,
                                      this.email,
                                      this.phone,
                                      this.subject,
                                      this.message);
             

    }

}
