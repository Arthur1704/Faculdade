$(document).read(function(){
    $('.btn-danger').click(function(){

        var id = $(this).data('id');

        $.ajax({
            url: 'excluir_aluno.php',
            type: 'GET',
            data: {id: id},
            success: function(){
                location.reload();
            }
        });
    });  
});