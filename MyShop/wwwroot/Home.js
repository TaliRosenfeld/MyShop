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
            body:await JSON.stringify(newUser)
        });
        if (!responsePost.ok) { 
            throw new error(`http error: status${responsePost}`)
    }
        alert("you succed register in succed")
        
    }
    catch (error) {
        alert("oh,now i get a problem...")
    }
    //console.log(responsePost.JSON)  
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
        if (!responsePost.ok) {
            throw new error(`http error: status${responsePost}`)
        }
        if (responsePost.status == 204) {
            throw new error(`the user is not found`)
        };
        const existUser = await responsePost.json();
        console.log(existUser.userId);

        existUser.firstName
        sessionStorage.setItem('user', existUser.userId)
        await alert(`hello to ${existUser.firstName}, you can change the datails`)
        window.location.href = "UserDetails.html"


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