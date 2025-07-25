package com.viana.couseJAVA.resources.exception;

import java.time.Instant;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;

import com.viana.couseJAVA.services.exception.ResourceNotFoundException;

import jakarta.servlet.http.HttpServletRequest;

@ControllerAdvice
public class ResourceExceptionHanller {

    @ExceptionHandler(ResourceNotFoundException.class)
    public ResponseEntity<StandardError> resoruceNotFound (ResourceNotFoundException e, HttpServletRequest request){
        String error = "Not Found";
        HttpStatus http = HttpStatus.NOT_FOUND;
        StandardError err = new StandardError(Instant.now(), http.value(), error, e.getMessage(), request.getRequestURI());
        return ResponseEntity.status(http).body(err);
    }

}
