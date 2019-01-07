$.getScript("LoginView.js", function () { })


var VisRegSide = {
    regAnsvarlig: ko.observable(sessionStorage.AnsattNavn),
    antallElever: ko.observable(),
    dato:ko.observable(),
    antallSjekketInn: ko.observable(0),
    antallSjekketUt: ko.observable(0),
    tempArray:[]


    
}






function getRegAnsvarlig() {


    console.log("Logg fra registrering siden", sessionStorage.AnsattNavn)
    VisRegSide.regAnsvarlig(sessionStorage.AnsattNavn);
    VisRegSide.dato(getDato())
    if (elever().length == 0) {
        getElever();
        MapElever();
    }
    
    console.log("Elever i regOppmøte etter mapping:", elever())
   VisRegSide.antallElever(elever().length)

}
$("#regLink").on("click", getRegAnsvarlig);




function VisRegAnsvarligViewModel() {
    this.self = this;
   
}


function RegEleverViewModel() {
    this.self = this;
    self.elever = ko.observableArray()
    //
    self.elev =function(_ElevId, _navn, _Klasse, _Trinn) {
        this.ElevId = ko.observable(_ElevId)
        this.Navn = ko.observable(_navn),
        this.Klasse = ko.observable(_Klasse),
        this.Trinn = ko.observable(_Trinn),
        this.SjekketInn=ko.observable(false);
        this.SjekketUt = ko.observable(false);
        this.InnTime = ko.observable();
        this.UtTime = ko.observable()
    }


    //

    self.MapElever=() =>{
        for (var i = 0; i < VisRegSide.tempArray.length; i++) {
           elever.push(new elev(VisRegSide.tempArray[i].ElevId, VisRegSide.tempArray[i].Fornavn + " " + VisRegSide.tempArray[i].Etternavn, VisRegSide.tempArray[i].Klasse, VisRegSide.tempArray[i].Trinn))
        }
    }

  
    
    
    
  
    self.sjekkInn = function () {



        if (this.SjekketInn()) {
            alert("Denne eleven er allerede sjekket inn")
            
        } else {
            this.SjekketInn(true);
            this.InnTime(getTime())
            console.log("log fra sjekkInn function:", this.ElevId(), LoginModel.idResultSkoleId(), getTime(), getDato(), sessionStorage.getItem("AnsattId"))
            VisRegSide.antallSjekketInn(VisRegSide.antallSjekketInn() + 1)
        }
        
        
      
     
      

    }
     self.sjekkUt = function () {
         console.log("log fra sjekkUt function:", this.ElevId(), LoginModel.idResultSkoleId(), getTime())
         this.SjekketUt(true)
         this.UtTime(getTime())
         VisRegSide.antallSjekketUt(VisRegSide.antallSjekketUt() + 1)
     }
   
}







function RegAnsvarlig() {
    return '<nav class="navbar navbar-inverse">'+ 
        '<div class="container">' +
        '<div class="navbar-header">' +
        '<ul class="nav navbar-nav" style="margin-top:15px">' +
        '<li class="elevdisplay">Dato: </li>' +
        '<li class="elevdisplay"data-bind="text:VisRegSide.dato"> </li>' +
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
        '<tr><td>Navn</td><td>Klasse</td><td>Sjekket inn</td></tr>'+
        '</thead>' +
        '<tbody data-bind="foreach:elever">' +
        '<tr data-bind="css:{SjekketInnStyle:SjekketInn()===true,SjekketUtStyle:SjekketUt()===true}">' +
        '<td>' +
        '<span class="elevdisplay" data-bind="text:Navn">' +
        '</td>' +
        '<td>' +
        '<span data-bind="text:Trinn"></span><span data-bind="text:Klasse"></span>' +
        '</td>' +
        '<td data-bind="text:InnTime"></td>' +
        '<td data-bind="text:UtTime"></td>' +
        '<td>' +
        '<button class="btn btn-link"data-bind="click:sjekkInn,ifnot:SjekketInn()">Sjekk inn elev</button> ' +
        '<button class="btn btn-link"data-bind="click:sjekkUt,visible:SjekketInn()">Sjekk ut elev</button>' +
        '</td>' +
       
        '</tr>' +
       '</table>'
        
}











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
function getTime() {
    var date= new Date()
    var time= date.getHours()+":"+date.getMinutes()
    return time
}

function getDato() {
    var date = new Date()
    var time = date.getDate() +  (":"+(date.getMonth() + 1)).slice(-2)
    return time
}



function getElever() {


    $.ajax({
        Type: "GET",
        url: "http://localhost:2804/api/Elever?skoleId=" + LoginModel.idResultSkoleId(),
        dataType: "json",
        success: function (result) {

            VisRegSide. tempArray=result
            console.log("Elever i regOppmøte:", VisRegSide.tempArray)
        },
        error: function (xhr, status, error) {


            console.log("Her gikk noe galt i å hente elever!", xhr, status)

        }
    })
}
