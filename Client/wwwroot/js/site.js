
$.ajax({
    url: "https://pokeapi.co/api/v2/"
}).done

console.log("Test Pokemon")

$.ajax({
    url: "https://pokeapi.co/api/v2/pokemon"
}).done((result) => {
    console.log(result);
    console.log(result.results);
    var text = "";
    $.each(result.results, function (key, val) {
        text += `<tr>
                <td>${key + 1}</td>
                <td>${val.name}</td>
                <td>${val.url}</td>
                <td><button type="button" value= "${val.url}"
                        onclick="getData2(this.value)" class="btn btn-primary" data-toggle="modal" data-target="#getPoke">Detail</td>
                </tr>`;
    });
    $(".tablePoke").html(text);
}).fail((error) => {
    console.log(error);
});

$(document).ready(function () {
    $('#tablePoke').DataTable();
});

function getData(link) {
    $.ajax({
        url: link
    }).done((result) => {
        text = "";
        srcAbility = "";
        $.each(result.abilities, function (key, val) {
            srcAbility += `${val.ability.name + "&nbsp"},`;
        });
        srcHeld = " ";
        $.each(result.types, function (key, val) {
            srcHeld += `<span class="badge badge-secondary">${val.type.name}</span> &nbsp`;
        });
        text += `<div class="container">
            <div class="text-center">
            <img src="${result.sprites.other.dream_world.front_default}" alt="" /></div>
            <div class="row">
                <div class="col">${srcHeld}</div>
            </div>
            <div class="row">
                <div class="col">Name </div>
                <div class="col">: ${result.name}</div>
           </div>
            <div class="row">
                <div class="col">Ability</div>
                <div class="col">: ${srcAbility}</div>
            </div>
            <div class="row">
               <div class="col">Weight</div>
                <div class="col">: ${result.weight} Kg</div>
            </div>
            <div class="row">
                <div class="col">Height</div>
                <div class="col">: ${result.height} Cm</div>
            </div></div>`;

        $(".modal-body").html(text);
    }).fail((error) => {
        console.log(error);
    });
}

function getData2(link) {
    $.ajax({
        url: link
    }).done((result) => {
        console.log(result);
        var ability = "";
        $.each(result.abilities, function (key, val) {
            ability += /*`${val.ability.name}&nbsp|&nbsp`*/ `<span class="ability badge-pill badge-danger" style="text-align">${val.ability.name}</span> &nbsp`;
        });
        var typePoke = "";
        $.each(result.types, function (key, val) {
            typePoke += typePokeColor(val.type.name) + "&nbsp";
        });

        function typePokeColor(val) {
            if (val == "grass") {
                var color = `<span class="badge badge-success" style="text-align: center;">${val}</span>`;
                return color;
            }
            else if (val == "water") {
                var color = `<span class="badge badge-primary" style="text-align: center;">${val}</span>`;
                return color;
            }
            else if (val == "poison") {
                var color = `<span class="badge badge-dark" style="text-align: center;">${val}</span>`;
                return color;
            }
            else if (val == "normal") {
                var color = `<span class="badge badge-light" style="text-align: center;">${val}</span>`;
                return color;
            }
            else if (val == "fire") {
                var color = `<span class="badge badge-danger" style="text-align: center;">${val}</span>`;
                return color;
            }
            else if (val == "electric") {
                var color = `<span class="badge badge-warning" style="text-align: center;">${val}</span>`;
                return color;
            }
            else {
                var color = `<span class="badge badge-secondary" style="text-align: center;">${val}</span>`;
                return color;
            }
        }
        var statPoke = "";
        $.each(result.stats, function (key, val) {
            statPoke += `<div class="row">
                         <div class="col" id="base" style="text-transform:capitalize" ><b>${val.stat.name}</b></div>
                         <div class="baseStat col">: ${val.base_stat}</div></div>`;
        });
        var img = ""
        img += `
            <img src="${result.sprites.other.dream_world.front_default}" alt="" width="250" height="250" style="background-color:lightblue; class="rounded-circle"" /></div>`;
        $(".modalName").html(result.name)
        $(".ability").html(":" + ability);
        $(".height").html(": " + result.height);
        $(".weight").html(": " + result.weight);
        $("#stat").html(statPoke);
        $(".badge").html(typePoke);


        $("#detailImage").html(img);

    }).fail((error) => {
        console.log(error);
    });
}


