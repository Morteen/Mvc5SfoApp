





$.getScript("LoginView.js", function () { })

console.log("Dette er log av skoleId fra VisElever.js filen:", LoginModel.idResultSkoleId())

var ElevModel = {
    elever: ko.observable("hei hei fra elever"),
    showLoggedIn: ko.observable(localStorage.getItem("showLoggedIn")),
    ElevSkoleId: ko.observable("Hei")
    


}


////Henter elever



function notify() {
    var Id = $("#hiddenSkoleId").val()
    //LoginModel.idResultSkoleId(Id)
    console.log("Log fra elever link:", $("#hiddenSkoleId").val());
    console.log("Dette er log av skoleId fra VisElever.js filen etter link:", LoginModel.idResultSkoleId())
}
$("#ElverLink").on("click", notify);



 
if (ElevModel.ElevSkoleId() !== '') {
    console.log("SkoleId ", ElevModel.ElevSkoleId())
    /* $.ajax({
        Type: "GET",
        url: "/SfoViews/GetElever",
        data: {
            skoleId:1//sessionStorage.SkoleId

        },
        dataType: "json",
        success: function(result) {
        console.log("Elev resultater:",result)

        },
        error: function(xhr, status, error) {

        koleId
            console.log("Her er noe galt i Viselever!", xhr, status)

        }
    })*/
} else {
    console.log("SkoleId er null")
}





function VisEleverViewModel() {

    this.self = this;
}
function eleverTempl() {

    return '<div >' +
        '<h3 data-bind="text: elever:"></h3>' +
        '</div>'
}

ko.components.register('elever-component', {
    viewModel: VisEleverViewModel,
    template: eleverTempl()
})
ko.applyBindings(ElevModel, $("#elever")[0]);
