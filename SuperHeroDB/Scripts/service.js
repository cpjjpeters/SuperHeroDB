function getAllHeroes() {
    $.ajax({
        url: "Service/SuperHeroService.svc/GetAllHeroes",
        type: "GET",
        dataType: "JSON",
        success: function (result) {
            heroes = result;
            drawHeroTable(result);
            console.log(result);
        }
    });
}
function addHero() {
    var newHero = {
        "FirstName": $("#addFirstname").val(),
        "LastName": $("#addLastname").val(),
        "HeroName": $("#addHeroname").val(),
        "PlaceOfBirth": $("#addPlaceOfBirth").val(),
        "Combat": $("#addCombatPoints").val()
    };

    $.ajax({
        url: "Service/SuperHeroService.svc/AddHero",
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(newHero),
        success: function () {
            showOverview();
        }
    });
}
