$(document).ready(function () {
    //Load à chaque refresh de page
    //alert("Test");


    //Événement sur le clic du bouton "Tout sélectionner"
    $('#btn_allCheck').click(function () {
        var tab = document.getElementById('cph_contenu_tab_emp');
        //alert("Test");
        if (tab.rows.length !== 0) {
            var btn = document.getElementById('btn_allCheck');
            var ena = false;
            if (btn.value === "Tout désélectionner") {
                btn.value = "Tout sélectionner";
                ena = false;
            }
            else {
                btn.value = "Tout désélectionner";
                ena = true;
            }
            for (var i = 1; i < tab.rows.length; i++) {
                tab.rows[i].cells[1].childNodes[0].childNodes[0].checked = ena;
            }
        }
    });
});


function enr() {
    alert("test");

    page

    $.ajax({
        type: "POST",
        url: 'FeuilleDeTempsADM.aspx/enre',
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            // Do something interesting here.
            alert("Reussi");
        }
    });

}

// Material Select Initialization
$(document).ready(function () {
    $('.mdb-select').materialSelect();
});
