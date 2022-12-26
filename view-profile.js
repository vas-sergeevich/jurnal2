$("document").ready(function () {

    $("#getContentForm").submit();

    var inputCurrentPage = $("#currentPage");
    var currentPage = parseInt(inputCurrentPage.val());

    $("input[type='button']#prev").bind("click",
        function () {

            inputCurrentPage.val(--currentPage);
            $("#getContentForm").submit();

        });

    $("input[type='button']#next").bind("click",
        function () {
            inputCurrentPage.val(++currentPage);
            $("#getContentForm").submit();
        });


    //formButtons
    $("#postsFormActive").bind("click",
        function () {

            $("#getContentForm").attr("action", "/Profile/GetPostsPartial");
            inputCurrentPage.val(1);
            $("#getContentForm").submit();
        });

    $("#questionsFormActive").bind("click",
        function () {
            $("#getContentForm").attr("action", "/Profile/GetQuestionsPartial");
            inputCurrentPage.val(1);
            $("#getContentForm").submit();
        });
});

function checkEnableButtons() {
    var currentPage = $(this).children("#currentPage").val();
    if (currentPage <= 1) {
        $("input[type='button']#prev").prop("disabled", true);
    } else {
        $("input[type='button']#prev").prop("disabled", false);
    }
    if ($(".wall .post").length < 10) {
        $("input[type='button']#next").prop("disabled", true);
    } else {
        $("input[type='button']#next").prop("disabled", false);
    }
}


//writeSend

function getResultSendAnonymousQuestion(data) {
    var resultBlock = $("#resultSendAnonymousQuestion");
    resultBlock.empty();
    var result = document.createElement("div");
    $(result).attr("role", "alert");
    if (data.responseJSON) {

        $(result).text("Вопрос успешно отправлен");
        $(result).addClass("alert alert-success");

    } else {
        $(result).text("Произошла ошибка при отправке вопроса");
        $(result).addClass("alert alert-danger");
    }
    resultBlock.html(result);
    $(resultBlock).show();
    setTimeout(function () {
        $(resultBlock).hide();
    },2000);
}

function getResultWritePost(data) {
    if (data.responseJSON) {

        $("#postsFormActive").click();
        $("#writePostForm input[type='text']").val("");
    }
}

//getPostQuestion
function getResultDeletePost(data) {
    if (data.responseJSON) {
        $(this).parent(".post").html("");
    } else {
        $(this).find("span").text("При удалении произошла ошибка");
    }
}