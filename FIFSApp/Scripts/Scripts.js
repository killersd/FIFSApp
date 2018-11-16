$(function () {
    $('#loaderbody').addClass('hide');

    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
        });;
});

//Script para mostrar a prévia da imagem
function MostrarImagemPrevia(imageUploader, preVisualizacao) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(preVisualizacao).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}

//função geral jquery ajax post que pode ser usada por qualquer tipo de formulario
//com ou sem upload de imagem
function jQueryAjaxPost(form)
{
    $.validator.unobtrusive.parse(form);
    if ($(form).valid())
    {
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),           
            success: function (response) {
                if (response.success) {
                    $("#primeiraTab").html(response);
                    atualizarNovaTabAdd($(form).attr('data_restUrl'), true);
                    $.notify(response.message, "Successfully")
                    if (typeof ativarTabelaJQuery !== 'undefined' && $.isFunction(ativarTabelaJQuery)) {
                        ativarTabelaJQuery();
                    }
                } else
                {
                    $.notify(response.message, "Error")
                }              
            }
        }
    }
    if ($(form).attr('enctype') == "multipart/form-data") {
        ajaxConfig["contentType"] = false;
        ajaxConfig["processData"] = false;
    }
    $.ajax(ajaxConfig);
}

//Função para limpar o formulário ao adicionar uma equipe
function atualizarNovaTabAdd(resetUrl,showViewTab)
{
    $.ajax({
        type: 'GET',
        url: resetUrl,
        success: function (response) {
            $("#segundaTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Adicionar');
            if (showViewTab) {
                $('ul.nav.nav-tabs a:eq(0)').tab('show');
            }
        }
    });
}

function Edit(url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            $("#segundaTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Editar');            
            $('ul.nav.nav-tabs a:eq(1)').tab('show');            
        }
    });

}

function Delete(url) {
    if (confirm('Tem certeza que quer deletar?') == true) {
        $.ajax({
            type: 'POST',
            url: url,
            success: function (response) {
                if (response.success) {
                    $("#primeiraTab").html(response.html);
                    $.notify(response.message, "warn")
                    if (typeof ativarTabelaJQuery !== 'undefined' && $.isFunction(ativarTabelaJQuery)) {
                        ativarTabelaJQuery();
                    }
                }
                else {
                    $.notify(response.message, "error")
                }
            }
        });
    }

    
}