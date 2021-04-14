
let btnAdd = document.getElementById("btnAdd");
let table = document.getElementById("tablaTelefonos");

let telefono = document.getElementById("txtTelefono");

btnAdd.addEventListener('click', () => {
    let tel = telefono.value;
    let contador = table.getElementsByTagName('tr').length;
    let template = `
            <tr>
                <td>${contador}</td>  
                <td>${tel}</td>  
            </tr>`;
    table.innerHTML += template;
});

//function addrow(index) {

//    let tel = telefono.nodeValue;

//    let template = `
//                <td>${tel}</td>  
//                <td>${tel}</td>  `;
//    table.innerHTML += template;
//}

//function addrow(index) {

//    var table = document.getElementById("tablaTelefonos");
//    var row = table.insertRow(index);
//    row.innerHTML = "<td>" + index + "</td>" +
//        "<td>00000000</td>";
//    index++;
//}