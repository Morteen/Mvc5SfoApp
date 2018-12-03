





$.getScript("LoginView.js", function () { })

console.log("Dette er log av skoleId fra VisElever.js filen:", LoginModel.idResultSkoleId())

var ElevModel = {
    elever: ko.observable("hei hei fra elever"),
    Skolenavn: ko.observable()
    


}


////Henter elever



function notify() {
  
    
    console.log("Dette er log av skoleId fra VisElever.js filen etter link:", LoginModel.idResultSkoleId())
    getSkole();
}
$("#ElverLink").on("click", notify);



 






function VisEleverViewModel() {

    this.self = this;
}
function eleverTempl() {

    return '<div>' +
        '<h3 data-bind="text: ElevModel.Skolenavn:"></h3>' +
        '</div>'
}

ko.components.register('elever-component', {
    viewModel: VisEleverViewModel,
    template: eleverTempl()
})
ko.applyBindings(ElevModel, $("#elever")[0]);


//Henter navn på den aktuelle skolen
function getSkole() {




    $.ajax({
        Type: "GET",
        url: "http://localhost:2804/api/Skoler/"+ LoginModel.idResultSkoleId(),
       dataType: "json",
        success: function (result) {
            ElevModel.Skolenavn(result.SkoleNavn)
           console.log("Skole resultater:", result.SkoleNavn)

        },
        error: function(xhr, status, error) {

        koleId
            console.log("Her gikk noe galt i å hente skole!", xhr, status)

        }
    })

}