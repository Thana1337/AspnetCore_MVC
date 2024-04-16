

const compareValidation = (element, valueCompare) => {
    if (element.value === valueCompare)
        return true

    return false

}

const emailValidataion = (element) => {
    const regEx = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    formErrorHandler(element, regEx.test(element.value));
}

const passwordValidation = (element) => {
    if (element.dataset.valEqualtoOther !== undefined) {
        let password = document.getElementsByName(element.dataset.valEqualtoOther.replace('*', 'Form'))[0].value;
        if (element.value === password) {
            return formErrorHandler(element, true);
        } else {
            return formErrorHandler(element, false);
        }
    }

    const regEx = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$/;
    return formErrorHandler(element, regEx.test(element.value));
}







const formErrorHandler = (element, validationResult) => {
    let spanElement = document.querySelector(`[data-valmsg-for="${element.name}"]`)
    if (validationResult) {
        element.classList.remove('input-validation-error')
        spanElement.classList.remove('field-validation-error')
        spanElement.classList.add('field-validation-valid')
        spanElement.innerHTML = ''
    }
    else {
        element.classList.add('input-validation-error')
        spanElement.classList.add('field-validation-error')
        spanElement.classList.remove('field-validation-valid')
        spanElement.innerHTML = element.dataset.valRequired
    }
}

const textValidation = (element, minlength = 2) => {
    if (element.value.length >= minlength) {
        formErrorHandler(element, true)
    }


    else {
            formErrorHandler(element, false)
    }

}

const checkboxValidation = (element) => {

    if (element.checked) {
        formErrorHandler(element, true)
    }


    else {
        formErrorHandler(element, false)
    }
}


let forms = document.querySelectorAll('form')
let inputs = forms[0].querySelectorAll('input')

inputs.forEach(input => {
    if (input.dataset.val === 'true') {
        if (input.type === 'checkbox') {
            input.addEventListener('change', (e) => {
                checkboxValidation(e.target)
            })
        }
        else
            input.addEventListener('keyup', (e) => {
                switch (e.target.type) {
                    case 'text':
                        textValidation(e.target)
                        break;
                    case 'email':
                        emailValidataion(e.target)
                        break;
                    case 'password':
                        passwordValidation(e.target)
                        break;
                }
            })
    }
})                