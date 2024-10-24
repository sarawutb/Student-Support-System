const uploadInput = document.getElementById('upload-image');
const previewImage = document.getElementById('preview-image');
const removeButton = document.getElementById('btn-remove');
var searchType = 0;

uploadInput.addEventListener('change', function (event) {
    const file = event.target.files[0];
    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            previewImage.src = e.target.result; // Set the image src to the uploaded file
            removeButton.hidden = false; // Show the remove button
        };
        reader.readAsDataURL(file); // Read the file as a data URL
    }
});

removeButton.addEventListener('click', function () {
    uploadInput.value = ''; // Clear the file input
    previewImage.src = '/images/upload_image_std.jpg'; // Reset to default image
    removeButton.hidden = true; // Hide the remove button
});

const radios = document.querySelectorAll('input[name="gridRadios"]');
const otherPersonInput = document.getElementById('other-person-input');

radios.forEach(radio => {
    radio.addEventListener('change', function () {
        if (this.value === '4') {
            otherPersonInput.style.display = 'block'; // Show the input field
        } else {
            otherPersonInput.style.display = 'none'; // Hide the input field
        }
    });
});

const unitTestInput = document.getElementById('unit-test');
unitTestInput.addEventListener('input', function () {
    if (this.value < 1) {
        this.value = 1;
    } else if (this.value >= 3)
        this.value = 3;

});

var dataStd = [];

function initializeSelect2SearchDataStd(selectId) {
    $(document).ready(function () {
        $('#search-data-std').prop('disabled', true);

        $('#search-data-std').select2({
            ajax: {
                url: "https://192.168.10.220/api/GetStudentByNameAndStdId",
                dataType: 'json',
                delay: 250,
                data: function (params) {
                    return {
                        type: searchType,
                        search: params.term,
                    };
                },
                processResults: function (data) {
                    return {
                        results: data.result.map(function (item) {
                            return {
                                id: item.id,
                                text: item.id_std + " - " + item.name_std,
                                data: item
                            };
                        })
                    };
                },
                cache: true
            },
            minimumInputLength: 1, // Minimum characters required to start a search
            placeholder: 'Select a student',
            allowClear: true
        });

        $('#search-data-std').on('select2:select', function (e) {
            let selectedData = e.params.data;
            DotNet.invokeMethodAsync('Student Support System', 'OnSelect2Change', "1234")
                .catch(function (error) {
                    console.error("Error invoking method:", error); // Log any errors
                });        //console.log('Selected student ID:', selectedData.id);
            //console.log('Selected student name:', selectedData.text);
            //console.log('Selected student info:', selectedData.data);

            // You can perform further actions here, such as making an additional API call,
            // updating other parts of your form, or displaying the selected student's details.
        });
    });
}

function SetSelect2SearchStd(state, value) {
    $('#search-data-std').prop('disabled', !state);
    searchType = value;
    console.log(state);
    console.log(searchType);
}
//$("#search-data-std").select2({
//    width: "100%",
//    ajax: {
//        url: "https://192.168.1.41/api/GetStudentByNameAndStdId",
//        dataType: 'json',
//        delay: 250,
//        //data: function (params) {
//        //    return {
//        //        search: params.term,
//        //        page: params.page
//        //    };
//        //},
//        data: dataStd,
//        processResults: function (data, params) {
//            dataStd = data.result;
//            console.log(params);
//            console.log(data.result);
//            //params.page = params.page || 1;

//            //return {
//            //    results: data.items,
//            //    pagination: {
//            //        more: (params.page * 30) < data.total_count
//            //    }
//            //};
//        },
//        cache: true
//    },
//    placeholder: 'ค้นหา',
//    //escapeMarkup: function (markup) { return markup; }, // let our custom formatter work
//    minimumInputLength: 1,
//});