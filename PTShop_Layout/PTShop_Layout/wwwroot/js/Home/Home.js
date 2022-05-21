const ViewModal = function () {
    const self = this;

    self.showtoastState = function (msg, title) {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "showDuration": "3000",
            "hideDuration": "3000",
            "timeOut": "3000",
            "extendedTimeOut": "3000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr['success'](title, msg);
    };

    self.convertToKoObject = function (data) {
        var newObj = ko.mapping.fromJS(data);
        return newObj;
    }

    self.formatToVND = function (total) {
        var vnd = parseFloat(total);
        return total().toLocaleString('vi-VN', { style: 'currency', currency: 'VND' });
    };

    self.gotoItem = function (item) {
        window.location.href = '/chi-tiet/' + item.ID() + '-' + self.slugifyLink(item.Name());
    }

    self.slugifyLink = function (str) {
        str = str.replace(/^\s+|\s+$/g, ''); // trim
        str = str.toLowerCase();
        // remove accents, swap ñ for n, etc
        var from = "áàảãạăẵẳằắặâẫẩầấậđéẽèẻèêễếềểệíìỉĩịóòõỏọôỗồổốộơỡởờớợúũùủụưữửừứựýỹỷỳỵ·/_,:;";
        var to = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyy------";
        for (var i = 0, l = from.length; i < l; i++) {
            str = str.replace(new RegExp(from.charAt(i), 'g'), to.charAt(i));
        }
        str = str.replace(/[^a-z0-9 -]/g, '') // remove invalid chars
            .replace(/\s+/g, '-') // collapse whitespace and replace by -
            .replace(/-+/g, '-'); // collapse dashes
        return str;
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

    //Get Prodcut
    self.productList = ko.observableArray();
    self.getProduct = function () {
        const data = {
            name: "",
            status: true,
            sale: true
        }
        $.ajax({
            method: "POST",
            url: backendUrl + "/graphql",
            contentType: "application/json",
            data: JSON.stringify({
                query: `query($data: SearchInput!) {
                          searchProduct(first: ${self.first()},item: $data) {
                            totalCount
                            nodes {
                              id
                              categoryId
                              name
                              description
                              madeIn
                              price
                              manufacturerId
                              createAt
                              updateAt
                              isDelete
                              status
                              productPrices {
                                id
                                productId
                                price
                                createdAt
                              }
                              productMedia {
                                id
                                productId
                                uri
                                product {
                                    name
                                }
                              }
                              category {
                                name
                              }
                            }
                          }
                        }
                       `,
                variables: { data }
            }),
            success: function (res) {
                self.productList([]);
                if (res.data.totalCount != 0) {
                    $.each(res.data.searchProduct.nodes, function (ex, item) {
                        self.productList.push(self.convertToKoObject(item));
                    })
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    //GetBanner
    self.bannerList = ko.observableArray();
    self.getBanner = function () {
        $.ajax({
            method: "POST",
            url: backendUrl + "/graphql",
            contentType: "application/json",
            data: JSON.stringify({
                query: `query {
                          banner(first: 2) {
                            totalCount
                            nodes {
                              id
                              name
                              title
                              uri
                            }
                          }
                        }
                       `
            }),
            success: function (res) {
                self.bannerList([]);
                if (res.data.totalCount != 0) {
                    $.each(res.data.banner.nodes, function (ex, item) {
                        self.bannerList.push(self.convertToKoObject(item));
                    })
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    //GetContact
    self.contactList = ko.observableArray();
    self.getContact = function () {
        $.ajax({
            method: "POST",
            url: backendUrl + "/graphql",
            contentType: "application/json",
            data: JSON.stringify({
                query: `query {
                          contact {
                            totalCount
                            nodes {
                              id
                              name
                              phone
                              email
                              address
                            }
                          }
                        }
                       `
            }),
            success: function (res) {
                self.contactList([]);
                if (res.data.totalCount != 0) {
                    $.each(res.data.contact.nodes, function (ex, item) {
                        self.contactList.push(self.convertToKoObject(item));
                    })
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    //GetMedia
    self.mediaList = ko.observableArray();
    self.getMedia = function () {
        var query = `query {
                      productMedia(first: 100, where: {product:{status: {eq: true}}}) {
                        totalCount
                        nodes {
                          id
                          productId
                          uri
                          product {
                            id
                            categoryId
                            name
                            description
                            madeIn
                            price
                            manufacturerId
                            createAt
                            updateAt
                            isDelete
                            status
                            productPrices {
                                id
                                productId
                                price
                            }
                          }
                        }
                      }
                    }
                    `
        $.ajax({
            method: "POST",
            url: backendUrl + "/graphql",
            contentType: "application/json",
            data: JSON.stringify({
                query: query
            }),
            success: function (res) {
                self.mediaList([]);
                if (res.data.totalCount != 0) {
                    $.each(res.data.productMedia.nodes, function (ex, item) {
                        self.mediaList.push(self.convertToKoObject(item));
                    })
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }


    self.listProductSale = ko.observableArray()
    self.productIsSale = function () {
        const data = {
            name: "",
            status: true,
            sale: true
        }
        $.ajax({
            method: "POST",
            url: backendUrl + "/graphql",
            contentType: "application/json",
            data: JSON.stringify({
                query: `query($data: SearchInput!) {
                          searchProduct(first: ${self.first()},item: $data) {
                            totalCount
                            nodes {
                              id
                              categoryId
                              name
                              description
                              madeIn
                              price
                              manufacturerId
                              createAt
                              updateAt
                              isDelete
                              status
                              productPrices {
                                id
                                productId
                                price
                                createdAt
                              }
                              productMedia {
                                id
                                productId
                                uri
                                product {
                                    name
                                }
                              }
                              category {
                                name
                              }
                            }
                          }
                        }
                       `,
                variables: { data }
            }),
            success: function (res) {
                self.productList([]);
                if (res.data.totalCount != 0) {
                    $.each(res.data.searchProduct.nodes, function (ex, item) {
                        self.productList.push(self.convertToKoObject(item));
                    })
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }


    self.callApi = function () {
        self.getBanner();
        self.getContact();
        self.getProduct();
        self.getCategory();
        self.getMedia();
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
                    self.showtoastState("Đã thêm sản phẩm vào giỏ hàng!")
                }
            });
            if (isFind == false) {
                self.cart.push(item);
                self.showtoastState("Đã thêm mới sản phẩm vào giỏ hàng!")
            }
        }
        else {
            self.cart.push(item);
            self.showtoastState("Đã thêm mới sản phẩm vào giỏ hàng!")
        }
        simpleStorage.set("cart", ko.toJS(self.cart(), { TTL: 1000000 }));
        self.saveCookie(self.cart());
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
                    toastr.info('Đã thêm sản phẩm vào yêu thích!');
                }
            });
            if (isFind == false) {
                self.favorite.push(item);
                toastr.info('Đã thêm mới sản phẩm vào yêu thích!');
            }
        }
        else {
            self.favorite.push(item);
            toastr.info('Đã thêm mới sản phẩm vào yêu thích!');
        }
        simpleStorage.set("favorite", ko.toJS(self.favorite(), { TTL: 100000 }));
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
        //var vnd = parseFloat(total);
        //return total().toLocaleString('vi-VN', { style: 'currency', currency: 'VND' });
    }

    self.saveCookie = function (cart) {
        let d = new Date();
        $(cart).each(function (ex, item) {
            item = JSON.stringify(item);
        });
        document.cookie = "cart=" + cart + "; expires=Thu, 30 Dec 2022 12:00:00 UTC ;path=/";
    }

    self.getCart = function () {
        if (simpleStorage.hasKey("cart")) {
            var listCart = simpleStorage.get("cart");
            $.each(listCart, function (idx, item) {
                self.cart.push(self.convertToKoObject(item));
            });

            console.log(listCart);
        }
    }

    let cookies = document.cookie;
    //console.log(cookies);

}

$(function () {
    const viewModal = new ViewModal();
    viewModal.callApi(); 
    viewModal.getCart();
    ko.applyBindings(viewModal);
})