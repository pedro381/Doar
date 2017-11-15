
function MensagemSucesso() {
    $.notify("Operação realizada com sucesso!", "success");
    /*$.notify("Do not press this button", "info");
    $.notify("Warning: Self-destruct in 3.. 2..", "warn");
    $.notify("BOOM!", "error");
    ExibirMensagem("Operação realizada com sucesso!", "success");*/
}

function MensagemErro(msg) {
    $.notify(msg, "warn");
}

function Validar(data) {
    if (data.valid) {
        window.location = "/";
    } else {
        MensagemErro(data.msg);
    }
}