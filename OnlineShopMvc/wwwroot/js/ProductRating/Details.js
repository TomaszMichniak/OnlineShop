const RenderProductRatings = (services, container) => {
    container.empty();
    container.append(`
        <p> 
           Wszystkie opinie ${services.totalItemsCount}
        </p>
    `)

    for (const service of services.items) {
        if (service.description == null) {
            service.description = "";
        }
        var ratingStars = "";
        var i = 0;
        while (i < service.rating) {
            ratingStars += ' <i class="fa-solid fa-star yellowColor"></i> ';
            i++;
        }
        var momentDate = moment(service.createdAt);
        var formattedDate = momentDate.format('DD.MM.YYYY');

        if (service.isDeleted) {
            container.append(
                `<div class="media mb-4">
				<div class="media-body border-bottom">
                    <h5 class="mt-0">${service.userName}</h5>
	                <p class="text-muted">${formattedDate}</p>
	                <p>${ratingStars}</p>
	                <p>${service.description}</p>
                    <input type="button" onclick="deleteRating(this)" class="btn btn-danger" data-id="${service.id}" value="Usuń">
	            </div>
	        </div>`)
        } else {
            container.append(
                `<div class="media mb-4">
				<div class="media-body">
                    <h5 class="mt-0">${service.userName}</h5>
	                <p>${service.description}</p>
	                <p>${ratingStars}</p>
	                <p class="text-muted">${formattedDate}</p>
	            </div>
	        </div>`)
        }
    }
    container.append(`
    <ul class="pagination pagination-lg" id="padding">
        <li class="page-item">
	        <input type="button" onclick="get(this)" class="page-link" tabindex="-1" value=1></input>
	    </li>
    </ul`)
    const list = $("#padding")
    if (services.totalPages > 1) {
        for (var i = services.pageNumber - 1; i < services.pageNumber + 2; i++) {
            if (i > 1 && i < services.totalPages) {
                list.append(` 
                    <li class="page-item">
                        <input type="button" onclick="get(this)" class="page-link"  tabindex="-1" value="${i}"></input>
                    </li> 

                `)
            }
        }

        list.append(` 
                    <li class="page-item">
                         <input type="button" onclick="get(this)" class="page-link"  tabindex="-1" value="${services.totalPages}"></input>
                    </li>
                 
                `)
    }
}


function deleteRating(e) {
    const container = $("#services")
    const encodedname = container.data("encoded-name");
    var id = e.getAttribute('data-id');
    $.ajax({
        url: `/Produkty/${encodedname}/Komentarze/Delete/${id}`,
        type: `get`,
        success: function () {
            toastr["success"]("Komentarz został usuniety")
            LoadProductRatings()
        },
        error: function () {
            toastr["error"]("Komentarz nie został usuniety")
        }
    })
}

function get(e) {

    const container = $("#services")
    const encodedname = container.data("encoded-name");
    var pagenumber = e.getAttribute('value');
    $.ajax({
        url: `/Produkty/${encodedname}/Komentarze/?PageNumber=${pagenumber}`,
        type: `get`,
        data: $(this).serialize(),
        success: function (data) {
            if (!data.items.length) {
                container.html("Brak opinii")
            } else {
                RenderProductRatings(data, container)
            }

        },
        error: function () {
            container.html("Brak opinii")
        }
    })

}



const LoadProductRatings = () => {
    const container = $("#services")
    const encodedname = container.data("encoded-name");
    const pagenumber = container.data("page-number");

    $.ajax({
        url: `/Produkty/${encodedname}/Komentarze/?PageNumber=${pagenumber}`,
        type: `get`,
        data: $(this).serialize(),
        success: function (data) {
            if (!data.items.length) {
                container.html("Brak opinii")
            } else {
                RenderProductRatings(data, container)
            }

        },
        error: function () {
            container.html("Brak opinii")
        }
    })

}
LoadProductRatings()
$(document).ready(function () {
    $("#createProductRating form").submit(function (event) {
        event.preventDefault();
        LoadProductRatings()
        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Komentarz został dodany")
                LoadProductRatings()
            },
            error: function () {
                toastr["error"]("Komentarz nie został dodany")
            }
        })
    });



})
