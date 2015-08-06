#Nancy.Siren


A library to extend your response payload with the [Siren][1] hypermedia media type

  [1]: https://github.com/kevinswiber/siren

```
{
    "class": [
        "order"
    ],
    "properties": {
        "orderNumber": 6534,
        "itemCount": 6,
        "status": "Completed"
    },
    "entities": [
        {
            "class": [
                "collection"
            ],
            "rel": [
                "http://localhost:8080/rels/order-items/"
            ],
            "href": "http://localhost:8080/orders/6534/items"
        }
    ],
    "actions": [
        {
            "name": "delete-order",
            "title": "Delete Order",
            "method": "DELETE",
            "href": "http://localhost:8080/orders/6534/"
        },
        {
            "name": "add-to-order",
            "title": "Add Item To Order",
            "method": "POST",
            "href": "http://localhost:8080/orders/6534/",
            "type": "application/json",
            "fields": [
                {
                    "name": "productCode",
                    "type": "text"
                },
                {
                    "name": "quantity",
                    "type": "number"
                }
            ]
        }
    ],
    "links": [
        {
            "rel": [
                "self"
            ],
            "href": "http://localhost:8080/orders/6534"
        }
    ]
}
````