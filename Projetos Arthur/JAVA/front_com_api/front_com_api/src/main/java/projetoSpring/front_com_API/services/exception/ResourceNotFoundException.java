package projetoSpring.front_com_API.services.exception;

public class ResourceNotFoundException extends RuntimeException{

    public ResourceNotFoundException(Object id){
        super("Not found id: " + id);
    }
}
