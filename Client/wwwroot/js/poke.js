$.ajax({
    url:"https://pokeapi.co/api/v2/pokemon/"
}).done((result) => {
  // console.log(result.results)

    var text = "";

    $.each(result.results, function (key, val) {
        text += `<tr>
            <td>${key+1}</td>
            <td>${val.name}</td>
            <td><button class="btn btn-primary" data-toggle="modal" data-target="#pokeModal onclick="getDetails('${val.url}')">Detail</button></td>
        </tr>` 
    })

  //  console.log(text) 

    $(".tabelPoke").html(text)

}).fail((error) => {
    console.log(error)
})

function getDetails(url) {
    console.log(url)
}