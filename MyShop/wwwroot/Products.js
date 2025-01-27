<<<<<<< HEAD
ï»¿const products = addEventListener("load", async () => {
    sessionStorage.setItem('Categories', JSON.stringify([]))
    //sessionStorage.setItem('Cart',sessionStorage.getItem('Cart')||JSON.stringify([]))
    //let cart = JSON.parse(sessionStorage.getItem('Cart'))
    //document.getElementById("ItemsCountText").innerHTML = cart.length
    getCategories()
    GetProductList()
    let categoryIdArr = [];
    let myCartArr = JSON.parse(sessionStorage.getItem("cart")) || [];
    sessionStorage.setItem("categoryIds", JSON.stringify(categoryIdArr))
    sessionStorage.setItem("cart", JSON.stringify(myCartArr))
    //sessionStorage.setItem("count")
    document.querySelector("#ItemsCountText").innerHTML = getItemsCountText(myCartArr);
})

const GetAllKirterion = () => {
    const nameSearch = document.querySelector("#nameSearch").value
    const minPrice = document.querySelector("#minPrice").value
    const maxPrice = document.querySelector("#maxPrice").value
    position = 0
    categoryIds = JSON.parse(sessionStorage.getItem('Categories'))
    skip = 0
    return ({ nameSearch, minPrice, maxPrice, position, categoryIds, skip })
}

const GetProductList = async () => {
    document.getElementById("PoductList").innerHTML=''//build url in a different func
    const kriterion = GetAllKirterion()
    let url = `api/product/?position=${kriterion.position}&skip=${kriterion.skip}`
    if (kriterion.nameSearch != '')
        url += `&desc=${kriterion.nameSearch}`
    if (kriterion.minPrice != '')
        url += `&minPrice=${kriterion.minPrice}`
    if (kriterion.maxPrice != '')
        url += `&maxPrice=${kriterion.maxPrice}`
    if (kriterion.categoryIds != '') {
        for (let i = 0; i < kriterion.categoryIds.length; i++) {//map is nicer
            url += `&categoryIds=${kriterion.categoryIds[i]}`
        }
    }
       
    try {
        const responseGet = await fetch(url, {
=======
addEventListener("load", async () => {
    GetProductList()
})

const GetAllKirterion = () => {
    //const nameSearch = document.querySelector("#nameSearch").value
    //nameSearch == null ? "" : nameSearch
    //const minPrice = document.querySelector("#minPrice").value
    //minPrice == null ? "0" : minPrice
    //const maxPrice = document.querySelector("#maxPrice").value
    //maxPrice == null ? "0" : maxPrice
    nameSearch =""
    minPrice = 0
    maxPrice = 0
    position = 0
    categoryIds = []
    desc = "0"
    skip = 0
    alert(nameSearch, minPrice, maxPrice)
    return ({ nameSearch, minPrice, maxPrice,position,categoryIds,desc,skip })
}

const GetProductList = async () => {
    const kriterion = GetAllKirterion()
    try {
        //òãéó ìùøùø ø÷ àú àìä ùéù ìäí òøê àçøú úú÷òé àí áòéåú ùì äùååàä îåì òøëéí øé÷éí
        //æå âí äöåøä äî÷åáìú
        const responsePost = await fetch(`api/Product/?position=${kriterion.position}&skip=${kriterion.skip}&desc=${kriterion.desc}&minPrice=${kriterion.minPrice}&maxPrice=${kriterion.maxPrice}&categoryIds=${kriterion.categoryIds}`, {
>>>>>>> 231949438d950bb2ad7ef89e7e7437b00f7a5808
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
            query: {
<<<<<<< HEAD
                nameSearch:kriterion.nameSearch,
                position: kriterion.minPrice,
                skip: kriterion.skip,
                minPrice: kriterion.minPrice,
                maxPrice: kriterion.maxPrice,
                categoryIds: kriterion.categoryIds
            }

        });
        const dataGet = await responseGet.json()
        showAllProducts(dataGet)
    }
    catch (error) {
        alert(`error: ${error}`)
    }
=======
                nameSearch=kriterion.nameSearch,
                position: kriterion.minPrice,
                skip: kriterion.skip,
                desc: kriterion.desc,
                minPrice: kriterion.minPrice,
                maxPrice: kriterion.maxPrice,
                categoryIds:kriterion.categoryIds
            }

        });
        const dataGet = await responsePost.json()
        console.log(dataGet)
        alert(dataGet)
    }
    catch (error) {
        alert(`error: ${error}`)
    }    
>>>>>>> 231949438d950bb2ad7ef89e7e7437b00f7a5808
}
const filterProducts = () => {
    GetProductList()
}
<<<<<<< HEAD
const showAllProducts = async (products) => {
    for (let i = 0; i < products.length; i++) {
        showOneProduct(products[i]);
    }
}

const showOneProduct = async (product) => {
    let tmp = document.getElementById("temp-card");
    let cloneProduct = tmp.content.cloneNode(true)
    cloneProduct.querySelector("img").src = "./images/" + product.image
    cloneProduct.querySelector("h1").textContent = product.name
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".description").innerText = product.description
    cloneProduct.querySelector("button").addEventListener('click', () => { AddToCart(product) })
    document.getElementById("PoductList").appendChild(cloneProduct)
}
const AddToCart = (product) => {
    if (sessionStorage.getItem("user")) {

        let myCart = JSON.parse(sessionStorage.getItem("cart"))
        let flag = 0;
        myCart.map((item) => {
            if (item.productId == product.id) {
                item.quantity++;
                flag = 1
            }
            return item
        })
        if (flag == 0) {
            let obj = { productId: product.id, quantity: 1 }
            myCart.push(obj)
        }
        sessionStorage.setItem("cart", JSON.stringify(myCart))

        document.querySelector("#ItemsCountText").innerHTML = JSON.parse(document.querySelector("#ItemsCountText").innerHTML) + 1;
    }
    else {
        alert("××™× ×š ×¨×©×•×")
        window.location.href = "home.html"
    }

}

//const AddToCart = (product) => {
//    //if (sessionStorage.getItem('user') == null) {
//    //    alert("××™× ×š ×¨×©×•×, ×× × ×”×¨×©×")
//    //    window.location.href = "Home.html"
//    //}       
//    //else {
//        let cart =JSON.parse(sessionStorage.getItem('Cart'))
//        cart.push(product.id)
//        sessionStorage.setItem('Cart', JSON.stringify(cart))
//        document.getElementById("ItemsCountText").innerHTML = cart.length
//    //}
//}
//category
const getCategories = async () => {
    try {
        const responseGet = await fetch('api/Category', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        const dataGet = await responseGet.json()
        showAllCategories(dataGet)
    }
    catch (error) {
        console.log("error")
        alert(`error: ${error}`)
    }
}
const showAllCategories = async (category) => {
    for (let i = 0; i < category.length; i++) {//map is nicer
        let tmp = document.getElementById("temp-category")
        let clonecategory = tmp.content.cloneNode(true)
        clonecategory.querySelector(".OptionName").textContent = category[i].name
        clonecategory.querySelector(".opt").addEventListener('change', () => { setCategory(category[i].id) })
        document.getElementById("categoryList").appendChild(clonecategory)
    }
}
const setCategory = (category) => {
    let arrCategory = JSON.parse(sessionStorage.getItem('Categories')) 
    let a = arrCategory.indexOf(category)
    a == -1 ? arrCategory.push(category) : arrCategory.splice(a, 1)
    sessionStorage.setItem('Categories', JSON.stringify(arrCategory))
    GetProductList()
}





        
=======
>>>>>>> 231949438d950bb2ad7ef89e7e7437b00f7a5808
