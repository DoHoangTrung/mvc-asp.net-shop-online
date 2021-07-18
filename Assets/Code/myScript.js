$(document).ready(function () {

    // load image when chose file in edit product
    $('#fileImg0').change(function (event) {
        console.log(event.target.files[0]);
        if (event.target.files[0] != null) {
            var source = URL.createObjectURL(event.target.files[0]);
            $('#img0Update').attr('src', source);
        }
        //no file chosen
        else {
            $('#img0Update').attr('src', '');
        }
    })

    $('#fileImg1').change(function (event) {
        if (event.target.files[0] != null) {
            var source = URL.createObjectURL(event.target.files[0]);
            $('#img1Update').attr('src', source);
        }
        //no file chosen
        else {
            $('#img1Update').attr('src', '');
        }
    })

    $('#fileImg2').change(function (event) {
        if (event.target.files[0] != null) {
            var source = URL.createObjectURL(event.target.files[0]);
            $('#img2Update').attr('src', source);
        }
        //no file chosen
        else {
            $('#img2Update').attr('src', '');
        }
    })

    
})



