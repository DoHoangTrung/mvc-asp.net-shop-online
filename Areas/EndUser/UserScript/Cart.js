
let cart = {
    init: function () {
        cart.registerEvent();
    },

    registerEvent: function () {
        cart.eventClickQuantityUp();
        cart.eventClickQuantityDown();

        cart.eventClickUpdate();

        //chua can dung vi co 1 radio
        cart.radioAlwayChecked();

        cart.checkout();

    },

    //change quantity cartitem when click + - in shopping cart
    eventClickQuantityUp: function () {
        $('.cart_quantity_up').click(function () {
            let price = $(this).data('price');
            let id = $(this).data("id");

            let idCartQuantity = '#cart_quantity_' + id;
            let quantity = parseInt($(idCartQuantity).val());

            $(idCartQuantity).val(quantity + 1);

            /*let idCartTotal = '#cart_total_' + id;
            let totalPrice = price * (quantity + 1);
            $(idCartTotal).text(toVND(totalPrice));*/
        })
    },
    eventClickQuantityDown: function () {
        $('.cart_quantity_down').click(function () {
            var id = $(this).data("id");
            var idCartQuantity = '#cart_quantity_' + id;
            var num = parseInt($(idCartQuantity).val());
            if (num > 1)
                $(idCartQuantity).val(num - 1);
        })
    },

    eventClickUpdate: function () {
        $('#btnUpdate').click(function () {
            cart.updateCart();
        })
    },

    eventClickCheckOut: function () {
        $('')
    },

    updateCart: function () {
        let data = $('.cart_quantity_input').map(function () {
            let id = $(this).data("id");
            let quantity = $(this).val();
            return { idProduct: id, quantity: quantity };
        }).get();

        $.ajax({
            url: '/EndUser/Cart/Update',
            type: 'POST',
            data: { model: JSON.stringify(data) },
            dataType: 'html',
            success: function (response) {
                $('#tableCartItem').html(response);
                cart.init();
            },
            error: function (err) {
                console.log(err.status);
            },
        })
    },

    radioAlwayChecked: function () {
        let radio = 'input:radio[name="payment-option"]';
        $(radio).change(function () {
            if ($(this).val() != '1') {
                $(this).val() = '1';
            }
        })
    },

    checkout: function () {
        $('#btnCheckout').click(function () {
            let model = {
                name: $('#name').val(),
                phone: $('#phone').val(),
                email: $('#email').val(),
                orderAddress: $('#orderAddress').val(),
                note: $('#note').val(),
            };
            $.ajax({
                url: '/EndUser/Cart/Checkout',
                type: 'POST',
                data: { transaction: JSON.stringify(model) },
                dataType: 'json',
            }).done(function (responese) {
                if (responese.status) {
                    alert('Dat hang thanh cong');
                    window.location.href = '/EndUser/Products/Index';
                }
                else {
                    alert(0);
                }
            })
        })
    },
};
cart.init();


function toVND(num) {
    return num = parseFloat(num).toLocaleString('vi-VN', { style: 'currency', currency: 'VND' });
}


