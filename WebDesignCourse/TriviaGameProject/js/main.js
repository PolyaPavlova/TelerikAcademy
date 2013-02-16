var serviceRootUrl = "http://trivia-game.apphb.com/api/trivia/"

var userInfo = {
    username: localStorage.getItem("username"),
    authCode: localStorage.getItem("authCode")
}

function onDocumentReady() {
    $("#register-input-button").on("click", onRegistrationButtonClick);
    $("#login-input-button").on("click", onLoginButtonClick);
    
    $("#category-input-add-question").on("click", onAddQuestionButtonClick);
    

    //var me = $.sha1("RalitsaRally"); // 871ab2a56ba505455ce34ead24a1c30ab8ff1c56
    
}

function onRegistrationButtonClick() {

    var username = $("#register-input-username").val();
    var nickname = $("#register-input-nickname").val();
    var authCode = $.sha1(username + nickname);
    alert(authCode);
     
    localStorage.setItem("username", username);
   // localStorage.setItem("nickname", nickname)
    localStorage.setItem("authCode", authCode);

    var newUser = {
        username: localStorage.getItem("username"),
        nickname: nickname,
        authCode: localStorage.getItem("authCode")
    };
    
    performPostRequest(serviceRootUrl + "register-user",
        newUser,
        onRegistrationSuccess,
        onRegistrationError)
};

function onRegistrationSuccess() {
    alert("User added");
}

function onRegistrationError() {
    alert(JSON.stringify(arguments));
}

function onLoginButtonClick() {
    var username = $("#login-input-username").val();
    var authCode = $("#login-input-authcode").val();

    localStorage.setItem("username", username);
    localStorage.setItem("authCode", authCode);
    
    var loginUser = {
        username: username,
        authCode: authCode
    };       

    performPostRequest(
        serviceRootUrl + "login-user",
        loginUser,
        onLoginButtonClickSuccess,
        onLoginButtonClickError
        )
}

function onLoginButtonClickSuccess() {
    var containerHTML = "<p>Success</p>";

    $("#container").html(containerHTML);
}

function onLoginButtonClickError(err) {
    //var containerHTML = "<p>Error</p>";

    alert(JSON.stringify(err));

    //var loginUsername = $("#login-input-username").val();

    //var pattern = /[a-zA-Z0-9_]/;

    //alert(pattern.test(loginUsername));
    
    //  $("#container").html(containerHTML);
}

function showAllUsers() {
    performGetRequest(serviceRootUrl + "users-all", onShowAllUsersSuccess, onShowAllUsersError);
}

function onShowAllUsersSuccess(data) {
    var usersCount = data.length;
    var pagesCount = usersCount / 10;
    var pages = [];

   if (usersCount == 0) {
        $("#users-container").html("No users");
    }
    else
    {
        //var allUsersHTML = '<table id="all-users-list">';

        //allUsersHTML +=
            //'<thead>' +
            //    '<tr>' +
            //        '<th>Nickname</th>' +
            //        '<th>Score</th>' +
            //        '<th>Games</th>' +
            //     '</tr>' +
            //'</thead>' +
            //'<tbody>';

            var start = 0;
            var end = 10;

            for (var i = 0; i < pagesCount; i++) {

                var currPage =
                       '<table id="all-users-list">' +
                            '<thead>' +
                                '<tr>' +
                                    '<th>Nickname</th>' +
                                    '<th>Score</th>' +
                                    '<th>Games</th>' +
                                    '</tr>' +
                            '</thead>' +
                            '<tbody>';


                for (var u = start; u < end; u++) {

                    var user = data[u];

                    if (user == undefined) {
                        break;
                    }

                    // allUsersHTML +=
                    currPage +=
                       '<tr class="user-item">' +
                          '<td><p class="nickname-field" data-id="' + user.nickname + '">' + user.nickname + '</p> </td>' +
                          '<td>' + user.score + '</a> </td>' +
                          '<td>' + user.games + '</a> </td>' +
                       '</tr>';

                    

                }
                
                //console.log(currPage);
                currPage += '</tbody></table>'
                
                pages.push(currPage);

                start += 10;
                end += 10;
            }
        

        
        
        var length = pages.length;
        var pagination = '<ul class="pagination">';
      
        for (var i = 0; i < length; i++) {
            pagination +=
                '<li class="pageItem" data-id="' + i + '">' +
                    '<span>' + (i+1) + '</span>' +
                '</li>';
        }

        pagination += '</ul>';

        $("#users-container").append(pagination);

        $(".pageItem").on("click", function showPage() {
            var clickedPage = $(this).data("id");
            $("#currPage").html(pages[clickedPage]);
            $("#all-users-list p").on("click", onNicknameFieldClick);
        })
        
       $("#currPage").html(pages[0]);
       
       $("#all-users-list p").on("click", onNicknameFieldClick);
        //allUsersHTML += '</tbody></table>'

       //$("#users-container").html(allUsersHTML);
          
       
    }



}



function onNicknameFieldClick() {
    var clickedNickname = $(this).data("id");
    performGetRequest(serviceRootUrl + "user-score?nickname=" + clickedNickname,
        onNicknameFieldClickSuccess,
        onNicknameFieldClickError)
}


function onNicknameFieldClickSuccess(data) {
         

    var nickname = data.nickname;
    var totalScore = data.totalScore;
    var totalGamesPlayed = data.totalGamesPlayed;

    var categoryScores = '<ul class="user-info">';
    //categoryScores += '<li> Nickname' + nickname + '</li>';
    var length = data.categoryScores.length;

    for (var i = 0; i < length; i++) {
        categoryScores +=
            '<li> <span class="user-info-ephasis">Category</span> ' + data.categoryScores[i].category + '</li>' +
            '<li> <span class="user-info-ephasis">Score</span> ' + data.categoryScores[i].score + '</li>' +
            '<li> <span class="user-info-ephasis">Games played</span> ' + data.categoryScores[i].gamesPlayed + '</li>';
    }

    categoryScores += '</ul>';
  

    $('[data-id="' + nickname + '"]').append('<div>' +
        '<div >' +
            categoryScores +
        '</div>' +
        '</div>');

    //$('#modal').reveal({                // The item which will be opened with reveal
    //    animation: 'fade',              // fade, fadeAndPop, none
    //    animationspeed: 600,            // how fast animtions are
    //    closeonbackgroundclick: true,   // if you click background will modal close?
    //    dismissmodalclass: 'close'      // the class of a button or element that will close an open modal
    //});

    //alert(categoryScores)
}

function onNicknameFieldClickError() {
    alert("Error - nickname click");
}

function onShowAllUsersError(err) {
    alert("Show all users error");
}

// Categories 

function showAllCategories() {

    $("#random-questions").on("click", onRandonQuestionsClick);

    performGetRequest(
        serviceRootUrl + "categories",
        onShowAllCategoriesSuccess,
        onShowAllCategoriesError)
}

function onShowAllCategoriesSuccess(data) {
    var categoriesCount = data.length;
    var allCategoriesHTML = '<ol id="all-categories-list">'

    for (var i = 0; i < categoriesCount; i++) {
        var category = data[i];

        allCategoriesHTML+=
            '<li>' +        
                '<p class="category-list-item" data-id='+ category.id +'>'  +
                    category.name +
                 '</p>' +
                 
            '</li>'
    }

    allCategoriesHTML += '</ol>'

    $("#categories-container").html(allCategoriesHTML);
    $(".category-list-item").on("click", onCategoryListItemClick);
}

function onShowAllCategoriesError(err) {
    alert(JSON.stringify(err));
}

////////////////////
////// GLOBAL //////
////////////////////

var newCategory = {
    category: {
        name: "",
        questions: []
    },
    user: {
        username: localStorage.getItem("username"),
        authCode: localStorage.getItem("authCode")
    }
};

var questionsCount = 0; // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

var currGame = {
    user: {
        username: localStorage.getItem("username"),
        authCode: localStorage.getItem("authCode")
    },
    questions: []
}


var currGameQuestions = [];
var j = 0; // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


function onAddQuestionButtonClick() {
    newCategory.category.name = $("#category-input-name").val();

    var newQuestionHTML =
        '<fieldset id="add-question-fields">' +
            '<legend> Question</legend>' +
            '<label>What is the question?</label>' +
            '<input type="text" id="category-input-question-text" />' +
            '<br>' +
            '<label>Correct answer</label>' +
            '<input type="text" id="category-input-question-correct" class="correctClass" />' +
            '<br>' +
            '<label>Wrong answer 1</label>' +
            '<input type="text" id="category-input-question-wrong1" class="wrongClass" />' +
            '<br>' +
            '<label>Wrong answer 2</label>' +
            '<input type="text" id="category-input-question-wrong2" class="wrongClass" />' +
            '<br>' +
            '<label>Wrong answer 3</label>' +
            '<input type="text" id="category-input-question-wrong3" class="wrongClass"  />' +
            '<br>' +
            '<input type="button" id="addCorectButton" value="Add new correct answer to this question" />' +
            '<input type="button" id="addWrongButton" value="Add new wrong answer to this question" />' +
            '<input type="button" id="nextQuestionButton" value="Next question" />' +
        '</fieldset>';

    
    $("#create-category-form").html(newQuestionHTML);
   
    $("#addCorectButton").on("click", onAddCorrectButtonClick);
    $("#addWrongButton").on("click", onAddWrongButtonClick);
    $("#nextQuestionButton").on("click", onNextQuestionButtonClick);
}


function onAddCorrectButtonClick() {
    $("#add-question-fields").append('<p class="added-answers"><label>Add Correct answer</label>' +
            '<input type="text" class="correctClass"  /> </p>')

    
}

function onAddWrongButtonClick() {
    $("#add-question-fields").append('<p class="added-answers"><label>Add Wrong answer</label>' +
            '<input type="text" class="wrongClass added-answers"  /> </p>')
}

function onNextQuestionButtonClick() {
    questionsCount++;

    // Fill correct answers array    
    var correctAnswersArray = new Array();
    $.each($(".correctClass"), function (i, e) {
        var currField = { "text": e.value };
        correctAnswersArray.push(currField);
    });

    // Fill wrong answers array
    var wrongAnswersArray = new Array();
    $.each($(".wrongClass"), function (i, e) {
        var currField = { "text": e.value };
        wrongAnswersArray.push(currField);
    });


    questionItem = {
        "text": $("#category-input-question-text").val(),
        "correctAnswers": correctAnswersArray,
        "wrongAnswers": wrongAnswersArray
    }

    newCategory.category.questions.push(questionItem);


    if (questionsCount == 2) {
        onReachedEnoughQuestions();
    }

    //alert(JSON.stringify(newCategory));

    // Clear fields
    $.each($("input[type=text]"), function (i, e) {
        e.value = '';
    });

    $.each($(".added-answers"), function (i, e) {
        $(this).remove();
    });
}

function onReachedEnoughQuestions() {
    $("#create-category-form").append(
        '<div id="modal">' +
        '<div id="modal-inside">' +
            '<h2>Enough questions</h2>' +
            '<p> You have entered enough questions to create category. Do you want to add more questions or to create category? </p>' +
            '<input type="button" value="Add more" onclick="onNextQuestionButtonClick()">' +
            '<input type="button" value="Create category" onclick="createCategory()">' +
        '</div>' +
        '</div>'
        );

    $("#add-question-fields").append('<input type="button" id="create-category-button" value="Create category" onclick="createCategory()" >');

    $('#modal').reveal({                // The item which will be opened with reveal
        animation: 'fade',              // fade, fadeAndPop, none
        animationspeed: 600,            // how fast animtions are
        closeonbackgroundclick: true,   // if you click background will modal close?
        dismissmodalclass: 'close'      // the class of a button or element that will close an open modal
    });
}

function createCategory() {

    alert(JSON.stringify(newCategory));

    performPostRequest(
        serviceRootUrl + "add-category",
        newCategory,
        function () { alert("Object sended") },
        function(err) {alert(JSON.stringify(err))})
}

function onRandonQuestionsClick() {

    performPostRequest(
        serviceRootUrl + "start-game/",
        userInfo,
        onCategoryListItemClickSuccess,
        onCategoryListItemClickError)
}


function onCategoryListItemClick() {
    var categoryId = $(this).data("id");

    performPostRequest(
        serviceRootUrl + "start-game/" + categoryId,
        userInfo,
        onCategoryListItemClickSuccess,
        onCategoryListItemClickError)
}


function onCategoryListItemClickSuccess(data) {
   
    var questionHTML = '<ul>';
        
    if (currGameQuestions.length == 0) {

        for (var i = 0; i < 10; i++) {
            var currQuestionItem =
                    '<li>' +
                            '<p>' + data.questions[i].text + '</p>' +
                            '<input type="hidden" value="' + data.questions[i].id + '">' +
                            '<input type="hidden" value="' + data.id + '" >' +

                            '<form>' +
                                '<ul class="question-answers">' +
                                '<li><input type="radio" name="answer" value="' + data.questions[i].answers[0].id + '" >' + data.questions[i].answers[0].text + '</li>' +
                                '<li><input type="radio" name="answer" value="' + data.questions[i].answers[1].id + '" >' + data.questions[i].answers[2].text + '</li>' +
                                '<li><input type="radio" name="answer" value="' + data.questions[i].answers[2].id + '" >' + data.questions[i].answers[2].text + '</li>' +
                                '<li><input type="radio" name="answer" value="' + data.questions[i].answers[3].id + '" >' + data.questions[i].answers[3].text + '</li>' +
                                '</ul>' +
                            '</form>' +
                        '</li>';

            currGameQuestions.push(currQuestionItem);
        }
        
        questionHTML += currGameQuestions[j];
        j++;
    }
    else
    {
        questionHTML += currGameQuestions[j];
        j++;
    }
   
    questionHTML += '</ul>';
     
  
   questionHTML += '<input type="button" value="Next question" id="game-next-question-button">';

   $("#game-container").html(questionHTML);
   $("#game-next-question-button").on("click", onGameNextQuestionButtonClick);
   
}

function onGameNextQuestionButtonClick() {

    currGame.questions.push(
        {
            questionId: $("input[type=hidden]").val(),
            answerId: $("input[type=radio]:checked").val(),
        }
    );

    if (j == 10) {
        var gameId = $("input[type=hidden]:last").val();
        
        //alert(JSON.stringify(currGame));
        performPostRequest(
            serviceRootUrl + "post-answers/" + gameId,
            currGame,
            onGameSuccess,
            onGameOver)
    }
    else {
        onCategoryListItemClickSuccess();
    }
    
    
}

function onGameSuccess() {
    $("#game-container").html("Game ended");
}

function onGameOver(err) {
    alert(JSON.stringify(err));
}


function onCategoryListItemClickError(err) {
    alert(err);
}

// Perform

function performGetRequest(serviceUrl,onSuccess,onError) {
    $.ajax({
        url: serviceUrl,
        type: "GET",
        timeout: 5000,
        dataType: "json",
        success: onSuccess,
        error: onError
    });
}

function performPostRequest(serviceUrl, data, onSuccess, onError) {
    $.ajax({
        url: serviceUrl,
        type: "POST",
        timeout: 5000,
        dataType: "json",
        data: data,
        success: onSuccess,
        error: onError
    });
}
