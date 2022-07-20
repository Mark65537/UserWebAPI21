$(document).ready(function () {

    GetAllUsers();

    $("#editUser").click(function (event) {
        event.preventDefault();
        EditUser();
    });

    $("#addUser").click(function (event) {
        event.preventDefault();
        AddUser();
    });

});
// Получение всех книг по ajax-запросу
function GetAllUsers() {

    $("#createBlock").css('display', 'block');
    $("#editBlock").css('display', 'none');
    $.ajax({
        url: '/api/values',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
// Добавление нового пользователя
function AddUser() {
    // получаем значения для добавляемого пользователя
    var user = {
        Name: $('#addName').val(),
        Year: $('#addYear').val()
    };

    $.ajax({
        url: '/api/values',
        type: 'POST',
        data: JSON.stringify(user),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllUsers();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
// Удаление пользователя
function DeleteUser(id) {

    $.ajax({
        url: '/api/values/' + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllUsers();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
// редактирование пользователя
function EditUser() {
    var id = $('#editId').val()
    // получаем новые значения для редактируемого пользователя
    var user = {
        Id: $('#editId').val(),
        Name: $('#editName').val(),
        Year: $('#editYear').val()
    };
    $.ajax({
        url: '/api/values/' + id,
        type: 'PUT',
        data: JSON.stringify(user),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            GetAllUsers();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
// вывод полученных данных на экран
function WriteResponse(users) {
    var strResult = "<table><th>ID</th><th>Имя</th><th>Год</th>";
    $.each(users, function (index, user) {
        strResult += "<tr><td>" + user.id + "</td><td> " + user.name + "</td><td>" + user.year + "</td><td>" +

            "</td><td><a id='editItem' data-item='" + user.id + "' onclick='EditItem(this);' >Редактировать</a></td>" +
            "<td><a id='delItem' data-item='" + user.id + "' onclick='DeleteItem(this);' >Удалить</a></td></tr>";
    });
    strResult += "</table>";
    $("#tableBlock").html(strResult);
}
// обработчик удаления
function DeleteItem(el) {

    // получаем id удаляемого объекта
    var id = $(el).attr('data-item');
    DeleteUser(id);
}
// обработчик редактирования
function EditItem(el) {
    // получаем id редактируемого объекта
    var id = $(el).attr('data-item');
    GetUser(id);
}
// вывод данных редактируемого пользователя в поля для редактирования
function ShowUser(user) {
    if (user != null) {
        $("#createBlock").css('display', 'none');
        $("#editBlock").css('display', 'block');
        $("#editId").val(user.id);
        $("#editName").val(user.name);
        $("#editYear").val(user.year);
    }
    else {
        alert("Такого пользователя не существует");
    }
}
// запрос на редактирование пользователя
function GetUser(id) {

    $.ajax({
        url: '/api/values/' + id,
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            ShowUser(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}
