$.getScript("LoginView.js", function () { })


var VisRegSide = {
    regAnsvarlig: ko.observable(sessionStorage.AnsattNavn),
    antallElever: ko.observable(),
    elever: ko.observableArray(),
    antallSjekketInn: ko.observable(0),
    antallSjekketUt: ko.observable(0)


    
}


function getRegAnsvarlig() {


    console.log("Logg fra registrering siden", sessionStorage.AnsattNavn)
    VisRegSide.regAnsvarlig(sessionStorage.AnsattNavn);
    getElever();
   VisRegSide.antallElever(VisRegSide.elever().length)

}
$("#regLink").on("click", getRegAnsvarlig);




function VisRegAnsvarligViewModel() {
    this.self = this;
   
}


function RegEleverViewModel() {
    this.self = this;
    self.notSjekkedInn = ko.observable(true)

    self.test = function () {
       
       
    }
  
    self.sjekkInn = function () {
        var button = $(this);
        console.log("log fra sjekkInn function:", this.ElevId, LoginModel.idResultSkoleId(), getFormattedDate())
        VisRegSide.antallSjekketInn(VisRegSide.antallSjekketInn() + 1)
        var test = button.attr("data-customer-id")
        console.log(test)
      

    }
     self.sjekkUt = function () {
         console.log("log fra sjekkUt function:", this.ElevId, LoginModel.idResultSkoleId(), getFormattedDate())
         self.notSjekkedInn = false
         VisRegSide.antallSjekketUt(VisRegSide.antallSjekketUt() + 1)
     }
   
}







function RegAnsvarlig() {
    return '<nav class="navbar navbar-inverse">'+ 
        '<div class="container">' +
        '<div class="navbar-header">' +
        '<ul class="nav navbar-nav" style="margin-top:15px">' +
        '<li class="elevdisplay">Ansvarlig for registrering: </li>' +
        '<li class="elevdisplay" data-bind="text:VisRegSide.regAnsvarlig"></li>' +
       '</ul>' +
     
        '<ul class="nav navbar-nav navbar-right"style="margin-top:15px">' +
        '<li class="elevdisplay">Antall elever: </li><li class="elevdisplay" data-bind="text:VisRegSide. antallElever"></li>' +
        '<li class="elevdisplay">Antall sjekket inn: </li><li class="elevdisplay"data-bind="text:VisRegSide.antallSjekketInn"></li>' +
        '<li class="elevdisplay">Antall sjekket ut: </li><li class="elevdisplay" data-bind="text:VisRegSide.antallSjekketUt"></li>' +
        '</ul>' +
    
    '</div>' +
        '</div>' +
        '</nav>'
}




function RegElever() {

  
    return '<table id="elever"class="table table-condensed">' +
        '<thead>' +
        '<tr><td>Navn</td><td>Klasse</td><td></td></tr>'+
        '</thead>' +
        '<tbody data-bind="foreach:VisRegSide.elever">' +
        '<tr>' +
        '<td>' +
        '<span class="elevdisplay" data-bind="text:Fornavn"></span><span class="elevdisplay"data-bind="text:Etternavn"></span>' +
        '</td>' +
        '<td>' +
        '<span data-bind="text:Trinn"></span><span data-bind="text:Klasse"></span>' +
        '</td>' +
        '<td>' +
        '<button class="btn btn-link js-test" data-customer-id="1"data-bind="click:sjekkInn,click:$parent.test">Sjekk inn elev</button> ' +
        '<button class="btn btn-link"data-bind="click:sjekkUt">Sjekk ut elev</button>' +
        '</td>' +
       
        '</tr>' +
       '</table>'
        
}

$("#elever").on("click", ".js-test", function () {
   
    var test=button.attr("data-customer-id")
   console.log("Hei")

})









ko.components.register('RegAnsvarlig-component', {
    viewModel: VisRegAnsvarligViewModel,
    template: RegAnsvarlig()
})

ko.components.register('Reg-component', {
    viewModel: RegEleverViewModel,
    template: RegElever()
})


ko.applyBindings(VisRegSide, $("#list")[0]);


function getFormattedDate(){
    var d = new Date();

    d = d.getFullYear() + "-" + ('0' + (d.getMonth() + 1)).slice(-2) + "-" + ('0' + d.getDate()).slice(-2) + " " + ('0' + d.getHours()).slice(-2) + ":" + ('0' + d.getMinutes()).slice(-2) + ":" + ('0' + d.getSeconds()).slice(-2);

    return d;
}


function getElever() {


    $.ajax({
        Type: "GET",
        url: "http://localhost:2804/api/Elever?skoleId=" + LoginModel.idResultSkoleId(),
        dataType: "json",
        success: function (result) {

            VisRegSide.elever(result)
            console.log("Elever i regOppmøte:", VisRegSide.elever())
        },
        error: function (xhr, status, error) {


            console.log("Her gikk noe galt i å hente elever!", xhr, status)

        }
    })
}
