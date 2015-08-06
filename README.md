Nancy.Siren

====================


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
                "http://localhost:8080/orders/45323order-items/"
            ],
            "href": "http://localhost:8080/orders/45323/45323/items",
            "properties": null,
            "links": null
        }
    ],
    "actions": [
        {
            "name": "delete-order",
            "title": "Delete Order",
            "method": "DELETE",
            "href": "http://localhost:8080/orders/45323/45323",
            "type": null,
            "fields": null
        },
        {
            "name": "add-to-order",
            "title": "Add Item To Order",
            "method": "POST",
            "href": "http://localhost:8080/orders/45323/45323",
            "type": "application/json",
            "fields": [
                {
                    "name": "productCode",
                    "type": "text",
                    "value": null
                },
                {
                    "name": "quantity",
                    "type": "number",
                    "value": null
                }
            ]
        }
    ],
    "links": null
}
````