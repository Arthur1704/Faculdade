package com.viana.couseJAVA.services.exception;

public class ResourceNotFoundException extends RuntimeException{

    public ResourceNotFoundException(Object id){
        super("Not Found id: " + id);
    }

}
