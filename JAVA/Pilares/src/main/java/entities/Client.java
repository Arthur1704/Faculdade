package entities;

import java.util.ArrayList;
import java.util.List;

public class Client extends People{

    private final List<Service> services = new ArrayList<>();

    public Client(String name, String phone) {
        super(name, phone);
    }

    public Client(String name, String phone, Service service) {
        super(name, phone);
        services.add(service);
    }

    public List<Service> getServices() {
        return services;
    }

    public void newService(Service service){
        services.add(service);
    }

    @Override
    public String toString(){
        return  "Client: " + getName() + ", Services: \n" + services.toString();
    }
}
