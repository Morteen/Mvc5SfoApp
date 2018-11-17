



var ElevModel= {
    elever: ko.observable("hei hei fra elever"),
    showLoggedIn: ko.observable(localStorage.getItem("showLoggedIn"))
    
}


function VisEleverViewModel() {

    this.self = this;
}
function eleverTempl() {
    return '<div >' +
        '<h3 data-bind="text:elever">Hei fra elever</h3>' +


        '</div>'
}

ko.components.register('elever-component', {
    viewModel: VisEleverViewModel,
    template: '<h3 data-bind="text:elever">Hei fra elever</h3>' 
})
ko.applyBindings(ElevModel, $("#elever")[0]);
