
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
                <td>
                    <a class="btn" href="https://www.google.co.cr/"><i class=" fa fa-edit"></i></a>
                    <a class="btn" href="https://www.youtube.com/"><i class="fa fa-trash"></i></a>
                </td>
            </tr>`;
    table.innerHTML += template;
});