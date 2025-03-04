
//const getDetaisChangeUser = () => {
//        const firstName = document.querySelector(".firstName").value
//        const lastName = document.querySelector(".lastName").value
//        const password = document.querySelector(".password").value
//        const email = document.querySelector(".email").value  
//        return ({ firstName, lastName, password, email })
//    }
//const changeUser = async () => {
//    const DetaisChangeUser = getDetaisChangeUser()
//    if (!DetaisChangeUser.email||!DetaisChangeUser.firstName || !DetaisChangeUser.lastName || !DetaisChangeUser.password)
//        return alert("חובה למלא את כל השדות")
//    try {
//        const responsePost = await fetch(`api/users/${sessionStorage.getItem('user')}`, {
//            method: 'PUT',
//            headers: {
//                'Content-Type': 'application/json'
//            },
//            body: await JSON.stringify(DetaisChangeUser)
//        });
//        if (!responsePost.ok) {
//            console.log(responsePost)
//            throw (`http error: status${responsePost.status}`)
//        }
//        const saveTheChanges = responsePost.json()
//        alert("השינויים נשמרו בהצלחה")
//        window.location.href("/product.html")
//    }
//    catch (error) {
//        alert(`oh,now i get a problem...${error}`)
//    }
//}
