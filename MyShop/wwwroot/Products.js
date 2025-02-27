//const loadProducts = addEventListener("load", async () => {
//    sessionStorage.setItem('Categories', JSON.stringify([]))
//    //sessionStorage.setItem('Cart',sessionStorage.getItem('Cart')||JSON.stringify([]))
//    //let cart = JSON.parse(sessionStorage.getItem('Cart'))
//    //document.getElementById("ItemsCountText").innerHTML = cart.length
//    getCategories()
//    GetProductList()
//    let categoryIdArr = [];
//    let myCartArr = JSON.parse(sessionStorage.getItem("cart")) || [];
//    sessionStorage.setItem("categoryIds", JSON.stringify(categoryIdArr))
//    sessionStorage.setItem("cart", JSON.stringify(myCartArr))
//    //sessionStorage.setItem("count")
//    document.querySelector("#ItemsCountText").innerHTML = getItemsCountText(myCartArr);
//})
//const getItemsCountText = (myCartArr) => {
//    let sum = 0;
//    myCartArr.map((item) => {
//        sum += item.quantity
//    })
//    return sum;
//}


//const GetAllKirterion = () => {
//    const nameSearch = document.querySelector("#nameSearch").value
//    const minPrice = document.querySelector("#minPrice").value
//    const maxPrice = document.querySelector("#maxPrice").value
//    position = 0
//    categoryIds = JSON.parse(sessionStorage.getItem('Categories'))
//    skip = 0
//    return ({ nameSearch, minPrice, maxPrice, position, categoryIds, skip })
//    //nameSearch = ""
//    //minPrice = 0
//    //maxPrice = 0
//    //position = 0
//    //categoryIds = []
//    //desc = "0"
//    //skip = 0
//    //alert(nameSearch, minPrice, maxPrice)
//    //return ({ nameSearch, minPrice, maxPrice, position, categoryIds, desc, skip })
//}

//const buildUrl = (kriterion) = {
//let productUrl = `api/product/?position=${kriterion.position}&skip=${kriterion.skip}`
//    if (kriterion.nameSearch != '')
//        productUrl += `&desc=${kriterion.nameSearch}`
//    if (kriterion.minPrice != '')
//        productUrl += `&minPrice=${kriterion.minPrice}`
//    if (kriterion.maxPrice != '')
//        productUrl += `&maxPrice=${kriterion.maxPrice}`
//    if (kriterion.categoryIds != '') {
//        kriterion.categoryIds.map(productUrl += `&categoryIds=${kriterion.categoryIds[i]}`)

//}
//const GetProductList = async () => {
//    document.getElementById("PoductList").innerHTML=''
//    const kriterion = GetAllKirterion()
//    let url = buildUrl(kriterion);

//    try {
//        const responseGet = await fetch( url , {
//            //addEventListener()
//            method: 'GET',
//            headers: {
//               'Content-Type': 'application/json'
//            },
//            query: {
//                nameSearch:kriterion.nameSearch,
//                position: kriterion.minPrice,
//                skip: kriterion.skip,
//                minPrice: kriterion.minPrice,
//                maxPrice: kriterion.maxPrice,
//                categoryIds: kriterion.categoryIds
//            }
//        });
//        const dataGet = await responseGet.json()
//        showAllProducts(dataGet)
//        console.log(dataGet)
//        alert(dataGet)
//    }
//    catch (error) {
//        alert(`error: ${error}`)
//    }
//}
//const filterProducts = () => {
//    GetProductList()
//}
//const showAllProducts = async (products) => {
//    for (let i = 0; i < products.length; i++) {
//        showOneProduct(products[i]);
//    }
//}

//const showOneProduct = async (product) => {
//    let tmp = document.getElementById("temp-card");
//    let cloneProduct = tmp.content.cloneNode(true)
//    cloneProduct.querySelector("img").src = "./images/" + product.image
//    cloneProduct.querySelector("h1").textContent = product.name
//    cloneProduct.querySelector(".price").innerText = product.price
//    cloneProduct.querySelector(".description").innerText = product.description
//    cloneProduct.querySelector("button").addEventListener('click', () => { AddToCart(product) })
//    document.getElementById("PoductList").appendChild(cloneProduct)
//}
//const AddToCart = (product) => {
//    if (sessionStorage.getItem("user")) {

//        let myCart = JSON.parse(sessionStorage.getItem("cart"))
//        let flag = 0;
//        myCart.map((item) => {
//            if (item.productId == product.id) {
//                item.quantity++;
//                flag = 1
//            }
//            return item
//        })
//        if (flag == 0) {
//            let obj = { productId: product.id, quantity: 1 }
//            myCart.push(obj)
//        }
//        sessionStorage.setItem("cart", JSON.stringify(myCart))

//        document.querySelector("#ItemsCountText").innerHTML = JSON.parse(document.querySelector("#ItemsCountText").innerHTML) + 1;
//    }
//    else {
//        alert("אינך רשום")
//        window.location.href = "home.html"
//    }

//}

////const AddToCart = (product) => {
////    //if (sessionStorage.getItem('user') == null) {
////    //    alert("אינך רשום, אנא הרשם")
////    //    window.location.href = "Home.html"
////    //}
////    //else {
////        let cart =JSON.parse(sessionStorage.getItem('Cart'))
////        cart.push(product.id)
////        sessionStorage.setItem('Cart', JSON.stringify(cart))
////        document.getElementById("ItemsCountText").innerHTML = cart.length
////    //}
////}
////category
//const getCategories = async () => {
//    try {
//        const responseGet = await fetch('api/Category', {
//            method: 'GET',
//            headers: {
//                'Content-Type': 'application/json'
//            }
//        });
//        const dataGet = await responseGet.json()
//        showAllCategories(dataGet)
//    }
//    catch (error) {
//        console.log("error")
//        alert(`error: ${error}`)
//    }
//}
//const showAllCategories = async (category) => {
//    for (let i = 0; i < category.length; i++) {
//        let tmp = document.getElementById("temp-category")
//        let clonecategory = tmp.content.cloneNode(true)
//        clonecategory.querySelector(".OptionName").textContent = category[i].name
//        clonecategory.querySelector(".opt").addEventListener('change', () => { setCategory(category[i].id) })
//        document.getElementById("categoryList").appendChild(clonecategory)
//    }
//}
//const setCategory = (category) => {
//    let arrCategory = JSON.parse(sessionStorage.getItem('Categories'))
//    let a = arrCategory.indexOf(category)
//    a == -1 ? arrCategory.push(category) : arrCategory.splice(a, 1)
//    sessionStorage.setItem('Categories', JSON.stringify(arrCategory))
//    GetProductList()
//}
const productList = addEventListener("load", async () => {
    GetproductList()
    GetCategoriesList()
    let categoryIdArr = [];
    let myCartArr = JSON.parse(sessionStorage.getItem("cart")) || [];
    sessionStorage.setItem("categoryIds", JSON.stringify(categoryIdArr))
    sessionStorage.setItem("cart", JSON.stringify(myCartArr))
    document.querySelector("#ItemsCountText").innerHTML = getItemsCountText(myCartArr);
})
const getItemsCountText = (myCartArr) => {
    let sum = 0;
    myCartArr.map((item) => {
        sum += item.quantity
    })
    return sum;
}
const filterProducts = () => {
    GetproductList()
}
const getAllFilter = () => {
    document.getElementById("PoductList").innerHTML = ''

    const filter = {
        minPrice: document.querySelector("#minPrice").value,
        maxPrice: document.querySelector("#maxPrice").value,
        desc: document.querySelector("#nameSearch").value,
        categoryIds: JSON.parse(sessionStorage.getItem("categoryIds")) || [],
        position: 0,
        skip: 0
    }
    return filter
}
const buildUrl = (filterItems) => {
    let url = `api/product/?position=${filterItems.position}&skip=${filterItems.skip}`
    if (filterItems.desc != '')
        url += `&desc=${filterItems.desc}`
    if (filterItems.minPrice != '')
        url += `&minPrice=${filterItems.minPrice}`
    if (filterItems.maxPrice != '')
        url += `&maxPrice=${filterItems.maxPrice}`
    if (filterItems.categoryIds != '')
        filterItems.categoryIds.map(item => {
            url += `&categoryIds=${item}`
        })
    return url;
}
const GetproductList = async () => {
    const filterItems = getAllFilter()
    let url = buildUrl(filterItems);

    try {
        console.log(filterItems)
        const responseGet = await fetch(url, {
            method: 'GET',
            headers: {
                "Content-Type": "application/json"
            },
            query: {
                position: filterItems.position, skip: filterItems.skip, desc: filterItems.desc,
                minPrice: filterItems.minPrice, maxPrice: filterItems.maxPrice, categoryIds: filterItems.categoryIds
            }
        })
        if (responseGet.status == 204)
            return alert("משתמש לא מזוהה")
        const dataPost = await responseGet.json();
        console.log(dataPost)
        showAllProducts(dataPost);
    }
    catch (error) {
        console.log(error)
    }
}

const showAllProducts = async (products) => {
    products.map(item => {
        showOneProduct(item);
    })
}

const showOneProduct = async (product) => {
    let tmp = document.getElementById("temp-card");
    let cloneProduct = tmp.content.cloneNode(true)
    cloneProduct.querySelector("img").src = "./Images/" + product.image
    cloneProduct.querySelector("h1").textContent = product.name
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".description").innerText = product.description
    cloneProduct.querySelector("button").addEventListener('click', () => { addToCart(product) })
    document.getElementById("PoductList").appendChild(cloneProduct)
}
const addToCart = (product) => {
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
        alert("אינך רשום")
        window.location.href = "home.html"
    }

}
const GetCategoriesList = async () => {
    try {
        const responseGet = await fetch("api/category", {
            method: 'GET',
            headers: {
                "Content-Type": "application/json"
            },
        })
        const dataGet = await responseGet.json();
        console.log(dataGet)
        showAllCategories(dataGet);
    }
    catch (error) {
        console.log(error)
    }
}

const showAllCategories = async (categories) => {
    categories.map(item => {
        showOneCategory(item);
    })
}
const showOneCategory = async (category) => {
    let tmp = document.getElementById("temp-category");
    let cloneCategory = tmp.content.cloneNode(true)
    cloneCategory.querySelector(".OptionName").textContent = category.name
    cloneCategory.querySelector(".opt").addEventListener('change', () => { addCategory(category.id) })
    document.getElementById("categoryList").appendChild(cloneCategory)
}

const addCategory = async (id) => {
    let categories = JSON.parse(sessionStorage.getItem("categoryIds"))
    let index = categories.indexOf(id)
    index == -1 ? categories.push(id) : categories.splice(index, 1)
    sessionStorage.setItem("categoryIds", JSON.stringify(categories))
    console.log(categories)
    GetproductList()
}






        