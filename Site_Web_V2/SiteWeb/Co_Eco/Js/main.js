$(document).ready(function () {
    //Load à chaque refresh de page



    //Événement sur le clic du bouton "Tout sélectionner"
    $('#btn_allCheck').click(function () {
        var tab = document.getElementById('cph_contenu_tab_emp');
        alert(tab.length);
        for (var i = 0; i < tab.length; i++) {
            alert( tab.row[i].cells[1].child.childNodes[0] );
        }
    });


});

// Material Select Initialization
$(document).ready(function () {
    $('.mdb-select').materialSelect();
});
