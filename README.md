#Nancy.Siren


A library to extend your response payload with the [Siren][1] hypermedia media type

  [1]: https://github.com/kevinswiber/siren

```
{
    "class": [
        "order"
    ],
    "properties": {
        "orderNumber": 45323,
        "itemCount": 2,
        "status": "Pending"
    },
    "entities": [
        {
            "class": [
                "collection"
            ],
            "rel": [
                "http://localhost:8080/order-items/"
            ],
            "href": "http://localhost:8080/45323/items",
        }
    ],
    "actions": [
        {
            "name": "delete-order",
            "title": "Delete Order",
            "method": "DELETE",
            "href": "http://localhost:8080/orders/45323/",
        },
        {
            "name": "add-to-order",
            "title": "Add Item To Order",
            "method": "POST",
            "href": "http://localhost:8080/orders/45323/",
            "type": "application/json",
            "fields": [
                {
                    "name": "productCode",
                    "type": "text",
                },
                {
                    "name": "quantity",
                    "type": "number",
                }
            ]
        }
    ],
    "links": null
}
````