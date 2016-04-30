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
                var shoppingCart;
                var cartKey = "cart";

                function init() {
                    if (window.localStorage.getItem(cartKey) === null) {
                        shoppingCart = {
                            //userId: "user",
                            //storeId: "store",
                            //totalPrice: "das",
                            //orderTime: "asd",
                            //pickUp: false,
                            //puckupTime: "asd",
                            //status: "sad",
                            items: []
                        };
                        window.localStorage.setItem(cartKey, JSON.stringify(shoppingCart));
                    } else {
                        shoppingCart = JSON.parse(window.localStorage.getItem(cartKey));
                    }
                }

                function saveChange() {
                    window.localStorage.setItem(cartKey, JSON.stringify(shoppingCart));
                }

                function clearCart() {
                    if (window.localStorage.getItem(cartKey) !== null) {
                        shoppingCart.items = [];
                        window.localStorage.setItem(cartKey, JSON.stringify(shoppingCart));
                        //window.localStorage.removeItem(cartKey);
                    }
                }

                function cartItem(id, name, qty, price, image) {
                    var item = {
                        id: id,
                        name: name,
                        qty: qty,
                        price: price,
                        image: image
                    }
                    return item;
                }

                function addItem(id, name, qty, price, image) {
                    if (window.localStorage.getItem(cartKey) === null)
                        init();
                    var newItem = cartItem(id, name, qty, price, image);
                    var curItem = itemExist(newItem);
                    if (curItem !== null) {
                        curItem.qty += newItem.qty;
                    } else {
                        shoppingCart.items.push(newItem);
                    }
                    saveChange();
                    console.log(shoppingCart);
                }

                function itemExist(item) {
                    var items = shoppingCart.items;
                    for (var i = 0; i < items.length; i++) {
                        if (items[i].id === item.id)
                            return items[i];
                    }
                    return null;
                }

                function getItems() {
                    var items = JSON.parse(window.localStorage.getItem(cartKey));
                    if (items !== undefined && items !== null)
                        return items.items;
                    else
                        return null;
                }

                function getTotalPrice() {
                    if (shoppingCart.items.length === 0)
                        return 0;
                    else
                        return priceCalculate(shoppingCart.items);
                }

                function priceCalculate(items) {
                    var total = 0;
                    for (var i = 0; i < items.length; i++) {
                        total += items[i].price * items[i].qty;
                    }
                    return total;
                }

                //var itemsChange=function() {
                //    var curItemNumber = -1;
                //    var items = JSON.parse(window.localStorage.getItem(cartKey));
                //    if (items.length > curItemNumber)
                //        curItemNumber = items.length;
                //    return curItemNumber;
                //}

                init();

                return {
                    addItem: addItem,
                    getItems: getItems,
                    clearCart: clearCart,
                    getTotalPrice: getTotalPrice,
                }

            }]);