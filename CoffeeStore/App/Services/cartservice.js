'use strict';

angular.module('coffeeStoreApp')
            .service('cartItem', [function () {
                var item = {
                    id: null,
                    name: null,
                    qty: null,
                    price: null
                }
                function itemConstruct(id, name, qty, price) {
                    item.id = id;
                    item.name = name;
                    item.qty = qty;
                    item.price = price;
                }

                item.prototype.setId = function (id) {
                    if (id)
                        item.id = id;
                }

                item.prototype.setName = function (name) {
                    if (name)
                        item.name = name;
                }

                item.prototype.setQty = function (qty) {
                    if (qty)
                        item.qty = qty;
                }

                item.prototype.setPrice = function (price) {
                    if (price)
                        item.price = price;
                }

                item.prototype.subtotal = function (qty, price) {
                    if (qty && price)
                        item.total = qty * price;
                }

                return item;

            }])
            .service('cartservice', ['$http', '$q', function ($http, $q) {
                var shoppingCart = {
                    userId: null,
                    storeId: null,
                    totalPrice: null,
                    orderTime: null,
                    pickUp: false,
                    puckupTime: null,
                    status: null,
                    items: {}
                };

                function init() {
                    this.shoppingCart = {
                        userId: null,
                        storeId: null,
                        totalPrice: null,
                        orderTime: null,
                        pickUp: false,
                        puckupTime: null,
                        status: null,
                        items: []
                    };
                }

                function cartItem(id, name, qty, price) {
                    var item = {
                        id: id,
                        name: name,
                        qty: qty,
                        price: price
                    }
                    return item;
                }

                function addItem(id, name, qty, price) {
                    var newItem = cartItem(id, name, qty, price);
                    if (newItem.id in shoppingCart.items) {
                        shoppingCart.items[newItem.id].qty += newItem.qty;
                    } else {
                        shoppingCart.items[newItem.id] = newItem;
                    }
                }

                function getItems() {
                    return shoppingCart.items;
                }

                return {
                    addItem: addItem,
                    getItems: getItems
                }

            }]);