const ViewModal = function () {
    const self = this;

    self.convertToKoObject = function (data) {
        var newObj = ko.mapping.fromJS(data);
        return newObj;
    }

    self.formatToVND = function (total) {
        var vnd = parseFloat(total);
        return total().toLocaleString('vi-VN', { style: 'currency', currency: 'VND' });
    };

    //Get URL
    self.totalPage = ko.observable(0);
    self.page = ko.observable(0);
    self.size = ko.observable(12);
    self.resultHome = ko.observable();
    self.getVideoHome = function () {
        var urlArray = window.location.href.substring(window.location.href.lastIndexOf('#') + 1).split("/");
        var id = urlArray[urlArray.length - 1].split("-")[0];
        $.ajax({
            url: "/api/home/course/" + id,
            type: 'GET',
        }).done(function (data) {
            if (data.Tag != null) {
                data.Tag = JSON.parse(data.Tag);
            }
            data.WelcomeSub = self.subString(data.Welcome, 1000);
            self.resultHome(self.convertToKoObject(data));
        });
    }

    //Get Category
    self.first = ko.observable(100);
    self.categoryList = ko.observableArray();
    self.getCategory = function () {
        $.ajax({
            method: "POST",
            url: backendUrl + "/graphql",
            contentType: "application/json",
            data: JSON.stringify({
                query: `query {
                          category(first:  12 ) {
                            nodes {
                              id
                              name
                              parentId
                              createAt
                              updateAt
                            }
                          }
                        }
                       `
            }),
            success: function (res) {
                self.categoryList([]);
                if (res.data.totalCount != 0) {
                    $.each(res.data.category.nodes, function (ex, item) {
                        self.categoryList.push(self.convertToKoObject(item));
                    })
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    self.callApi = function () {
        //self.getBanner();
        //self.getContact();
        //self.getProduct();
        self.getCategory();
        //self.getMedia();
    }

    self.cart = ko.observableArray();
    self.addToCart = function (item) {
        if (item.Count == null) {
            item.Count = ko.observable(1);
        }
        if (self.cart().length != 0) {
            var isFind = false;
            $.each(self.cart(), function (idx, cart) {
                if (item.id() == cart.id()) {
                    var count = cart.Count();
                    cart.Count(count += 1);
                    isFind = true;
                }
            });
            if (isFind == false) {
                self.cart.push(item);
            }
        }
        else {
            self.cart.push(item);
        }
        simpleStorage.set("cart", ko.toJS(self.cart(), { TTL: 100 }));
        self.saveCookie(self.cart());
        toastr.info('Bạn đã thêm vào giỏ hàng thành công!');
    }

    self.getCart = function () {
        if (simpleStorage.hasKey("cart")) {
            var listCart = simpleStorage.get("cart");
            $.each(listCart, function (idx, item) {
                self.cart.push(self.convertToKoObject(item));
            });
        }
    }

    self.favorite = ko.observableArray();
    self.addToFavorite = function (item) {
        if (item.Count == null) {
            item.Count = ko.observable(1);
        }
        if (self.favorite().length != 0) {
            var isFind = false;
            $.each(self.favorite(), function (idx, cart) {
                if (item.id() == cart.id()) {
                    var count = cart.Count();
                    cart.Count(count += 1);
                    isFind = true;
                }
            });
            if (isFind == false) {
                self.favorite.push(item);
            }
        }
        else {
            self.favorite.push(item);
        }
        simpleStorage.set("favorite", ko.toJS(self.favorite(), { TTL: 100000 }));
        toastr.info('Bạn đã thêm vào giỏ hàng thành công!');
    }

    self.totalCart = function () {
        var total = 0;
        $.each(self.cart(), function (idx, cart) {
            if (cart.productPrices()[0].price() != 0) {
                total += cart.productPrices()[0].price() * cart.Count();
            }
            else {
                total += cart.productPrices()[0].price() * cart.Count();
            }
        });
        var vnd = parseFloat(total);
        return vnd.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' });
    }

    self.countPrice = function (cart) {
        var total = 0;
        if (cart.productPrices()[0].price() != 0) {
            total = cart.productPrices()[0].price() * cart.Count();
        }
        else {
            total = cart.price() * cart.Count();
        }
        var vnd = parseFloat(total);
        return vnd.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' });
    }

    self.removeCart = function (item) {
        console.log(item);
        $.each(self.cart(), function (idx, cart) {
            if (cart != null) {
                if (item.id() == cart.id()) {
                    self.cart.remove(cart);
                }
            }
        });
        simpleStorage.set("cart", ko.toJS(self.cart()));
    }

    self.saveCookie = function (cart) {
        let d = new Date();
        $(cart).each(function (ex, item) {
            console.log(item);
            item = JSON.stringify(item);
        });
        document.cookie = "cart=" + cart + "; expires=Thu, 30 Dec 2022 12:00:00 UTC ;path=/";
    }

    self.setchange = function (item) {
        var count = document.getElementById("spin_" + item.id()).value;
        item.Count(count);
    }

    let cookies = document.cookie;
    //console.log(cookies);
}

$(function () {
    const ViewModal = new ViewModal();
    ViewModal.callApi();
    ViewModal.getCart();
    ko.applyBindings(ViewModal);
})