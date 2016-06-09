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
            .service('cartservice', ['$http', '$q', 'authService', function ($http, $q, authService) {
                var shoppingCart = {
                    items: []
                };
                var cartKey = "cart";
                var username = "";
                var authToken = "";

                function init() {
                    if (authService.getAuthInfo().user !== undefined && authService.getAuthInfo().user !== "" && authService.getAuthInfo().authToken !== "" && authService.getAuthInfo().authToken !== undefined) {
                        username = authService.getAuthInfo().user;
                        authToken = authService.getAuthInfo().authToken;
                        getShoppingCartFromRedis(username).then(function (data) {
                            window.localStorage.setItem(cartKey, JSON.stringify(shoppingCart));
                        });
                    } else {
                        if (window.localStorage.getItem(cartKey) === null) {
                            shoppingCart = {
                                items: []
                            };
                            window.localStorage.setItem(cartKey, JSON.stringify(shoppingCart));
                            console.log("this time" + shoppingCart);
                        } else {
                            shoppingCart = JSON.parse(window.localStorage.getItem(cartKey));
                        }
                    }

                    //if (window.localStorage.getItem(cartKey) === null) {
                    //    shoppingCart = {
                    //        items: []
                    //    };
                    //    if (username !== "" && authToken !== "") {
                    //        getShoppingCartFromRedis(username);
                    //    }
                    //    window.localStorage.setItem(cartKey, JSON.stringify(shoppingCart));
                    //} else {
                    //    shoppingCart = JSON.parse(window.localStorage.getItem(cartKey));
                    //}
                    console.log("cart service start");
                }

                function getShoppingCartFromRedis(username) {
                    var deferred = $q.defer();
                    $http({
                        method: "GET",
                        url: "../api/ShppingCartRedis?username=" + username,
                        headers: { 'Content-type': 'application/json' }
                    }).success(function (data) {
                        if (data == null)
                            return;
                        shoppingCart.items = data.cart;
                        console.log(shoppingCart.items);
                        deferred.resolve(data);
                    })
                    return deferred.promise;
                }

                function saveChange() {
                    window.localStorage.setItem(cartKey, JSON.stringify(shoppingCart));
                    if (authService.getAuthInfo().user !== "" && authService.getAuthInfo().authToken !== "") {
                        username = authService.getAuthInfo().user;
                        authToken = authService.getAuthInfo().authToken;
                        saveChangeToRedis(authService.getAuthInfo().user, authService.getAuthInfo().authToken);
                    }
                }

                function saveChangeToRedis(user, authToken) {
                    var postdata = {
                        userName: username,
                        token: authToken,
                        cart: shoppingCart.items
                    };
                    $http.post('../api/ShppingCartRedis', postdata).success(function (data) {
                        console.log("save shopping cart to redis");
                    });
                }

                function clearCart() {
                    if (window.localStorage.getItem(cartKey) !== null) {
                        shoppingCart.items = [];
                        window.localStorage.setItem(cartKey, JSON.stringify(shoppingCart));
                        if (username !== "" && authToken !== "")
                            clearCartInRedis(username);
                    }
                }

                function clearCartInRedis(username) {
                    $http.post('../api/ShppingCartRedis' + '?key=' + username).success(function (data) {
                        console.log("clear the cart in redis");
                    });
                }

                function cartItem(id, name, qty, price, image) {
                    var item = {
                        productId: id,
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
                        if (items[i].productId === item.productId)
                            return items[i];
                    }
                    return null;
                }

                function minusQuantity(id) {
                    angular.forEach(shoppingCart.items, function (value, key) {
                        if (value.productId === id) {
                            if (value.qty > 1) {
                                value.qty -= 1;
                            } else {
                                removeItem(key);
                            }
                        }
                        return;
                    });
                    saveChange();
                }

                function removeItem(key) {
                    shoppingCart.items.splice(key, 1);
                }

                function getItems() {
                    var items = JSON.parse(window.localStorage.getItem(cartKey));
                    if (items !== undefined && items !== null)
                        return items.items;
                    else
                        return null;
                }

                function getTotalPrice() {
                    var curcart = JSON.parse(window.localStorage.getItem(cartKey));
                    if (curcart.items.length === 0)
                        return 0;
                    else
                        return priceCalculate(curcart.items);
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
                    minusQuantity: minusQuantity,
                    init: init
                }

            }]);