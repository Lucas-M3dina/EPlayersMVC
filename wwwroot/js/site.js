// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

chamandoAnalise = document.getElementById("input_file");

chamandoAnalise.addEventListener("change", analiseForm);

function analiseForm(){
    var analise = document.getElementById("input_file").value;

    if (analise == "") {
    }
    else{
        var estilo = document.getElementById("label_file");
        estilo.textContent = "Emblema Escolhido"
        estilo.style.color = "#fff";
        estilo.style.backgroundColor = "#258c00";
    }
}
