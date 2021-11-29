var extension = "";
var file = "";
var LectureData = [];
var CourseContent = [];
var IdFake = 1;

var LectureFormData = new FormData()

$(document).ready(function () {
    //add lecture to array
    $("#lecturefrom").on('submit', function (e) {
        e.preventDefault(e);
        var form = $(this);

        var lecture = {
            IdFake: IdFake,
            Title: $("#lectureTitle").val(),
            File: file.name,
            Description: $("#lectureDescription").val(),
            Volume: $("#lectureVolume").val(),
            Duration: $("#lectureDuration").val(),
            Positon: $("#lecturePosition").val(),
        };

        //kiểm tra dữ liệu
        var inputCheck = $('input[required]');
        $.each(inputCheck, function (index, item) {
            $(item).attr('require');
            //Kiếm tra dữ liệu nhập, nếu trống cảnh báo
            var value = $(this).val();
            if (!value) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Trường này không được phép để trống');
            }
            else {
                $(this).removeClass('border-red');
            }
        });

        LectureData.push(lecture);
        extension = "";
        file = null;

        console.log(LectureData);
        console.log(lecture);

        form[0].reset()
        $("#lectureDescription").val('');

        addLectureToHtml();
    })

    //Create Course
    $('#saveChanges').click(function () {
        var isFree = $('#IsFree').val() == '1' ? true : false;
        var price = isFree ? 0 : $('#price').val()

        var model = {
            Title: $('#Title').val(),
            SubTitile: $('#SubTitile').val(),
            Description: $('#Description').val(),
            IsFree: isFree,
            Status: parseInt($("#status").val()),
            Price: price,
            DiscountPrice: $('#discount_price').val(),
            CategoryId: $('#category').val(),
            SubcategoryId: $('#subCategory').val(),
            LanguageId: $('#LanguageId').val(),
        };
        console.log(model);

        //post Course Content
        CourseContent.forEach((model, index) => {
            $.ajax({
                url: 'https://localhost:44371/Instructor/Course/CreateCourseContent',
                type: 'GET',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: model,
                success: function (data) { },
                failure: function (errMsg) {
                    alert(errMsg);
                    return false;
                }
            });
            console.log(model.Lecture);
            //post Lecture
            model.Lecture.forEach((model, index) => {
                $.ajax({
                    url: 'https://localhost:44371/Instructor/Course/CreateLecture',
                    type: 'GET',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: model,
                    success: function (data) { },
                    failure: function (errMsg) {
                        alert(errMsg);
                        return false;
                    }
                });
            });

        });

        //Kiểm tra ít nhất 1 Course Content
        if (CourseContent.length > 0) {
            //post Course
            $.ajax({
                url: 'https://localhost:44371/Instructor/Course/CreateCourse',
                type: 'GET',
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: model,
                success: function (data) {
                    if (data.code) {
                        toastr.success("Create Course Success")
                    }
                    else {
                        toastr.warning(data.message)
                    }
                },
                failure: function (errMsg) {
                    toastr.warning(errMsg);
                    return false;
                }
            });
        }
        else {
            toastr.warning("Please add at least one Course Content");
        }
    });

    //config toastr
    $(function () {
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-left",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "4000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    });

    //Validate bắt buộc nhập SonNL4
    $('input[required]').blur(function () {
        //Kiếm tra dữ liệu nhập, nếu trống cảnh báo
        var value = $(this).val();
        if (!value) {
            $(this).addClass('border-red');
            $(this).attr('title', 'Trường này không được phép để trống');
        }
        else {
            $(this).removeClass('border-red');
        }
    });

    $('.id_course_description').summernote({
        height: 120,
        toolbar: [
            ['style', ['style']],
            ['font', ['bold', 'underline', 'clear']],
            ['color', ['color']],
            ['para', ['ul', 'ol', 'paragraph']],
            ['table', ['table']],

            ['view', ['fullscreen', 'codeview', 'help']]
        ]
    });

    //lấy subCategory - SonNL4
    $('#category').change(function () {
        var id = $(this).val();

        $('#subCategory').find('option').not(':first').remove();

        $.ajax({
            url: "GetSubCategory" + '/' + id,
            type: 'get',
            dataType: 'json',
            success: function (response) {
                var len = 0;
                if (response != null) {
                    len = response.length;
                }

                if (len > 0) {
                    for (var i = 0; i < len; i++) {
                        var id = response[i].id;
                        var name = response[i].subCategoryName;
                        var option = "<option value='" +
                            id + "'>" + name + "</option>";

                        $("#subCategory").append(option);
                    }
                }
            },
            error: function (xhr, status, error) {
                alert(xhr.responseText);
            }
        })
    });
});

//jquery step
$('#add-course-tab').steps({
    onFinish: function () { }
});

//add Lecture To Html
function addLectureToHtml() {
    var tr = "";
    LectureData.forEach((element, index) => {
        tr += ` <tr>
                    <td class="text-center">${index + 1}</td>
                    <td class="cell-ta">${element.Title}</td>
                    <td class="text-center">${element.Volume}</td>
                    <td class="text-center">${element.Duration}</td>
                    <td class="text-center">${element.Positon}</td>
                    <td class="text-center">  <a href="#">${element.File}</a>   </td>
                    <td class="text-center">
                        <a href="#" title="Delete" class="gray-s" onclick="DeleteLecture(${index})"><i class="uil uil-trash-alt"></i></a>
                    </td>
                </tr>`;
    });
    $("#tbodylecture").html(tr);
}

//validate address file
function onLectureFileChange() {
    file = $('#lectureFileInput')[0].files[0]
    $(this).next('label').text(file);
}

//remove lecture in array
function DeleteLecture(index) {
    LectureData.splice(index, 1);
    addLectureToHtml()
}

//Theem Course Content vào array
function FinalCourseContent() {
    var title = $("#ContentTitle").val();

    if (!title) {
        toastr.warning("Please enter a Course Content Title")
        return false;
    }
    const tn = LectureData.length;
    if (tn < 1) {
        toastr.warning("Please add at least one lecture")
    }
    else {
        var course = {
            IdFake: IdFake,
            Title: title,
            Lecture: LectureData
        };
        IdFake++;
        CourseContent.push(course);
        AddCourseToHtml();
        console.log(CourseContent);
        Refreshtbodylecture();
    }
}

function Refreshtbodylecture() {
    LectureData = [];
    $("#tbodylecture").empty();
    $('#lecturefrom').trigger("reset")
}

function AddCourseToHtml() {
    var tr = "";
    CourseContent.forEach((element, index) => {
        var volumn = 0;
        var duration = 0;
        var lecture = 0;
        var date = new Date();
        element.Lecture.forEach((x) => {
            volumn += parseInt(x.Volume);
            duration += parseInt(x.Duration);
            lecture++;
        });

        tr += ` <tr>
                <td class="text-center">${index + 1}</td>
                <td class="cell-ta">${element.Title}</td>
                <td class="text-center">${lecture}</td>
                <td class="text-center">${volumn}</td>
                <td class="text-center">${duration}</td>
                <td class="text-center">  <a href="#">${date}</a>   </td>
                <td class="text-center">
                    <a href="#" title="Delete" class="gray-s" onclick="DeleteCourse(${index})"><i class="uil uil-trash-alt"></i></a>
                </td>
                </tr>`;
    });
    $("#tbodycourse").html(tr);
}

function DeleteCourse(index) {
    CourseContent.splice(index, 1);
    AddCourseToHtml();
}