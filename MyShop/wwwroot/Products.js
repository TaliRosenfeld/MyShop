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
        const responsePost = await fetch(`api/Product/?position=${kriterion.position}&skip=${kriterion.skip}&desc=${kriterion.desc}&minPrice=${kriterion.minPrice}&maxPrice=${kriterion.maxPrice}&categoryIds=${kriterion.categoryIds}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
            query: {
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
}
const filterProducts = () => {
    GetProductList()
}
