# Introduction 
TODO: Give a short introduction of your project. Let this section explain the objectives or the motivation behind this project. 

# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation Docker
2.	Install Docker_Compose
3.	cd in /project_folder

# Build and Run
TODO: Describe and show how to build your code and run the tests. 

docker-compose build

docker-compose up -d

# Postman Verify APIs

- Create Product

[POST] http://localhost:6107/Product

{
    "Id": "ad13295e-68be-48ee-c411-08dc7932678e",
    "Description": "Caraota Negras",
    "DateCreated": "2022-09-25T11:06:11.511Z",
    "Category": "Alimentos",
    "Price": 20.00
}

- Get All Products

[GET] http://localhost:6107/Product


- Create Order

[POST] http://localhost:6107/Order

{
    "dateRegisterSession": "2024-04-25T11:06:11.511Z",
    "productsList": [
        {
            "productId": "420c18ec-38f2-4121-7e4f-08dc794458b9",
            "quantity": 2,
            "priceProduct": 120.00
        },
        {
            "productId": "ef5fe66b-a91b-4729-7e50-08dc794458b9",
            "quantity": 1,
            "priceProduct": 20.00
        }
    ]
}


- Get One Order

[GET] http://localhost:6107/Order/1