function resultDeleteUQuestion(data) {
    if (data.responseJSON) {
        $(this).closest(".unanswered-question").html("");
        $('#exampleModalCenter').modal('show');
        $("#exampleModalCenter .modal-body").text("Вопрос успешно удален.");
    } else {
        $('#exampleModalCenter').modal('show');
        $("#exampleModalCenter .modal-body").text("При удалении произошла ошибка");
    }
}


function resultAnswerUQuestion(data) {
    if (data.responseJSON) {
        $(this).closest(".unanswered-question").html("");
        $('#exampleModalCenter').modal('show');
        $("#exampleModalCenter .modal-body").text("Вопрос успешно обработан.");
    } else {
        $('#exampleModalCenter').modal('show');
        $("#exampleModalCenter .modal-body").text("При отправке произошла ошибка");
    }
}