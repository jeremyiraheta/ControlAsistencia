﻿function selectDpto(id, element)
{    
    fetch("/Ajax/ajaxDepartamentos.ashx?action=select&coddpto=" + id).
        then(resp => resp.text()).
        then(data => {
            var s = document.getElementsByClassName("active")
            s[0].classList.remove("active")
            element.classList.add("active")
            var t = document.getElementById("table")
            t.innerHTML = data
        })
}

function validateEmp()
{
    var inputs = document.getElementsByClassName("input")
    var msg = document.getElementById("msgerror")
    for (var i = 0; i < inputs.length; i++) {
        if(inputs[i].value.trim() == "")
        {
            msg.innerText = "Faltan datos en el formulario!!!"
            return false;
        }
    }    
    if (document.getElementsByClassName("select")[0].value == 0)
    {
        msg.innerText = "Seleccione un departamento!!!"
        return false;
    }
    if (document.getElementById("txtpass") != undefined && document.getElementById("txtpass").value != document.getElementById("txtpass2").value)
    {
        msg.innerText = "Los password no coinciden!!!"
        return false;
    }
    let mtel = /[2876]\d{3}[\s-]*\d{4}/g
    if (!mtel.test(document.getElementById("txttel").value))
    {
        msg.innerText = "El telefono no tiene el formato correcto"
        return false;
    }
    let year = document.getElementById('txtDate').value.substring(0,4)
    if (year > new Date().getFullYear() - 17 || year < 1800)
    {
        msg.innerText = "La fecha no es valida!!!"
        return false;
    }
    let mdui = /\d{8}-\d/g
    if (!mdui.test(document.getElementById("txtdui").value))
    {
        msg.innerText = "El dui no es valido!!!"
        return false;
    }
    let mnit = /\d{4}-\d{6}-\d{3}-\d/g
    if(!mnit.test(document.getElementById("txtnit").value))
    {
        msg.innerText = "El nit no es valido!!!"
        return false;
    }
    let mafp = /\d{12}/g
    if (!mafp.test(document.getElementById("txtafp").value))
    {
        msg.innerText = "El afp no es valido!!!"
        return false;
    }
    if (document.getElementById("txtpass") != undefined && document.getElementById("txtpass").value.length < 5)
    {
        msg.innerText = "La pass es muy corta"
        return false;
    }
    return true;
}