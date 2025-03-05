const visibleRegister = () => {
    const showRegister = document.querySelector(".unvisible")
    showRegister.classList.remove("unvisible")
}

const getDetaisRegister = () => {
    const firstName = document.querySelector(".firstName").value
    const lastName = document.querySelector(".lastName").value
    const password = document.querySelector(".password").value
    const email = document.querySelector(".email").value
    return ({ firstName, lastName,  password, email })
}

const newRegister = async () => {
    const newUser = getDetaisRegister()
    if (!newUser.firstName || !newUser.lastName || !newUser.password || !newUser.email)
       return alert("חובה למלא את כל השדות")
 
    try {
        const responsePost = await fetch("api/users", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: await JSON.stringify(newUser)
        });
        const errorText = await responsePost.text();
        if (errorText == "week password" || errorText == "User already exists") {
            const errorText = await responsePost.text();
            throw (errorText);
            alert(errorText)
        }
        if (responsePost.status == 409) {
            throw (`המשתמש כבר קיים במערכת`)
        }
        if (responsePost.status == 400) {
            throw (`בדוק את תקינות הנתונים שהכנסת`)
        }
        if (!responsePost.ok) {
            throw (`you dont succed register:http error  status ${responsePost}`)
        }
        else { 
            alert("you succed register in succed")
        window.location.href = "Products.html"
        } 
    }
    catch (error) {
        alert(error)
    } 
}

const getDetaisLogin = () => {
    const password = document.querySelector(".passwordLogin").value
    const email = document.querySelector(".emailLogin").value
        return ({ email, password })
}

const NewLogin = async () => {
    const loginUser = getDetaisLogin()
    if (!loginUser.password || !loginUser.email)
        return alert("חובה למלא את כל השדות")
    try {
        const responsePost = await fetch(`api/users/login/?email=${loginUser.email}&password=${loginUser.password}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            query: {
                Email: loginUser.email,
                Password: loginUser.password
            }
        });
        const errorText = await responsePost.text();
        if (errorText == "week password" || errorText == "User already exists") {
            const errorText = await responsePost.text();
            throw (errorText);
            alert(errorText)
        }
        if (!responsePost.ok) {
            if (responsePost.status == 404) {
                throw (` לא נמצא משתמש עם הסיסמא והמייל הנתונים`)
            }
            if (responsePost.status == 400) {
            throw (`בדוק את תקינות הנתונים שהכנסת`)
            }
            throw (`http error: status${responsePost}`)
        }
        if (responsePost.status == 204) {
                throw (`the user is not found`)
            };
        const existUser = await responsePost.json();
        console.log(existUser.userId);
        sessionStorage.setItem('user', existUser.userId)
        sessionStorage.setItem("cart", JSON.stringify([]))
        sessionStorage.setItem("categoryIds", JSON.stringify([]))
        await alert(`hello to ${existUser.firstName}, you can change the datails`)
        window.location.href = "Products.html"

    }
    catch (error) {
        alert(error)
    }
}

const checkPassword=async()=>{
    const password = document.querySelector(".password").value
    try {
        const responsePost = await fetch(`api/users/password`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: await JSON.stringify(password)
           
        });
        const dataPost = await responsePost.json()
        viewLevel(dataPost);
        }
    catch (error) {
        alert(error)
    }
}

const viewLevel = (passwordlevel) => {
        const password = document.querySelector(".levelPassword")
        password.value = passwordlevel
}
const changeUserPage=() => {
    window.location.href ="UserDetails.html"
}
//פרטי שינוי משתמש
const getDetaisChangeUser = () => {
    const firstName = document.querySelector(".firstName").value
    const lastName = document.querySelector(".lastName").value
    const password = document.querySelector(".password").value
    const email = document.querySelector(".email").value
    return ({ firstName, lastName, password, email })
}
//שינוי פרטי משתמש
const changeUser = async () => {
    const DetaisChangeUser = getDetaisChangeUser()
    if (!DetaisChangeUser.email || !DetaisChangeUser.firstName || !DetaisChangeUser.lastName || !DetaisChangeUser.password)
        return alert("חובה למלא את כל השדות")
    try {
        const responsePost = await fetch(`api/users/${sessionStorage.getItem('user')}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: await JSON.stringify(DetaisChangeUser)
        });
        //if (responsePost.status == 204) {
        //    throw (`the user is not found`)
        //};
        
        if (!responsePost.ok) {
            if (responsePost.status == 409) {
                throw (`doplicate user`)
            }
            if (responsePost.status == 400) {
                if (!sessionStorage.getItem('user')) {
                    window.location.href="Home.html"
                    throw (`the user is not found`)
                }
            throw (`בדוק את תקינות הנתונים שהכנסת`)
        }
            console.log(responsePost)
            throw (`http error: status${responsePost.status}`)
        }
        //if (responsePost.status == 400) {
        //    throw (`you need to login or register`)
        //}
        const saveTheChanges = responsePost.json()
        alert("השינויים נשמרו בהצלחה")
        window.location.href = "Products.html"
    }
    catch (error) {
        alert(`oh,now i get a problem...\n${error}`)
    }
   
   
}
const cancel=() => {
    window.location.href = "Products.html"
}