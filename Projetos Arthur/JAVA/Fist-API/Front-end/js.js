$(document).ready(function(){
    $("#form").submit(function (event) {
         event.preventDefault();

        const info = {
            name: $("#name").val(),
            email: $("#email").val(),
            phone: $("#phone").val(),
            age: $("#age").val()
        }

        $.ajax({
            url: "http://localhost:8080/users",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(info),
            success: function (response){
                $("#result").text("Usuário cadastrado com sucesso!!");
                alert("Usuário cadastrado com sucesso!!");
            },
            error: function(error){
                $("#result").text("Erro ao cadastrar usuário: " + error.responseText);
            }
        });
    });
});