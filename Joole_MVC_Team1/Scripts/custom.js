$(function () {
    updateProducts();

    $("#sliders .slider").each(function () {
        let minValue = Number($(this).prev()[0].textContent);
        let maxValue = Number($(this).next()[0].textContent)
        $(this).slider({
            range: true,
            orientation: "horizontal",
            min: minValue,
            max: maxValue,
            values: [minValue, maxValue],
            slide: function (event, ui) {
                $(this).prev()[0].textContent = ui.values[0];
                $(this).next()[0].textContent = ui.values[1];
            },
            change: function (event, ui) {
                updateProducts();
            }

        });
    });

    $(".typeFilter").change(function () {
        updateProducts();
    })

    $(".model-year").change(function () {
        updateProducts();
    })

    $(".dropdown-search").on('show.bs.dropdown', function () {
        $.ajax({
            type: "GET",
            url: '/Search/ShowCategories',
            success: function (data) {
                for (cat of data) {
                    $(".dropdown-search .dropdown-menu").append(`<li role="presentation"><a role="menuitem" value="${cat.id}" tabindex="-1" href="#">${cat.name}</a></li>`);
                }
            }
        });
    });
    $(".dropdown-search").on('hidden.bs.dropdown', function () {
        $(".dropdown-search .dropdown-menu")[0].innerHTML = '';
    });
    $(".dropdown-search").click(function (e) {
        if (e.target.tagName == 'A') {
            $('#categoryMenu')[0].innerHTML = e.target.innerHTML + `   <span class="caret"></span>`;
            $('#categoryId').val(e.target.getAttribute('value'));
        }
    });

    $("#subCategory").autocomplete({
        source: function (request, response) {
            let param = { name: $('#subCategory').val(), category_Id: $('#categoryId').val() };
            $.ajax({
                url: '/Search/AutoCompleteSubCategory',
                data: JSON.stringify(param),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            value: item.name,
                            subCategory: item.id,
                            category: item.categoryId

                        }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var err = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(err.Message)
                    // console.log("Ajax Error!");
                }
            });
        },
        minLength: 2, //This is the Char length of inputTextBox
        select: function (event, ui) {
            window.location.href = "/Search/Search/" + ui.item.category + "/" + ui.item.subCategory;
        }
    });
});

function updateProducts() {
    $.ajax({
        url: '/Search/Products',
        data: JSON.stringify(buildViewModel()),
        dataType: "html",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $("#products")[0].innerHTML = data;
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            var err = eval("(" + XMLHttpRequest.responseText + ")");
            alert(err.Message)
            console.log("Ajax Error!");
        }
    });
}

function buildViewModel() {
    let subCategoryId = Number($("#subCategoryId").val());
    let viewModel = {
        subCategoryId: subCategoryId,
        yearMin: $("#model-year-bottom").val(),
        yearMax: $("#model-year-top").val(),
        typeFilters: $(".typeFilter")
            .filter(function () {
                if ($(this).find('option:selected').val() === '') {
                    return false;
                } else {
                    return true;
                }
            })
            .map(function () {
                return {
                    propertyId: Number(this.id.substring(0, this.id.indexOf('-'))),
                    subCategoryId: subCategoryId,
                    typeName: this.id.substring(this.id.indexOf('-') + 1, this.id.length),
                    value: $(this).find('option:selected').val(),
                    typeOptions: null
                };
            }).get(),
        specFilters: $(".filter")
            .map(function () {
                let min = $(this).find('.min').text();
                let max = $(this).find('.max').text();
                return {
                    propertyId: Number(this.id.substring(0, this.id.indexOf('-'))),
                    subCategoryId: subCategoryId,
                    propertyName: "",
                    min: Number(min),
                    max: Number(max)
                };
            }).get()
    };
    return viewModel;
}