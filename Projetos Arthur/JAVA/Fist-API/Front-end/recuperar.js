$(document).ready(function(){
    const url = "http://localhost:8080/users";

    $.getJSON(url, function(dados){
        $.each(dados, function(index, usuario){
            const linha = `
                <tr>
                    <td>${usuario.id}</td>
                    <td>${usuario.name}</td>
                    <td>${usuario.email}</td>
                    <td>${usuario.phone}</td>
                    <td>${usuario.age}</td>
                </tr>
            `;
              
            $("#tb_users tbody").append(linha);
        });
    });
});