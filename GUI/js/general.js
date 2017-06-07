/* general javascript for site functionality */
// initialize the tooltips
$(function () {
	$('[data-toggle="tooltip"]').tooltip();
});

// to flip the shadow on the navbar after scrolling. 
$(window).scroll(function () {
	if ($(this).scrollTop() === 0) {
		$('#main-header').removeClass("headerscrolled");
		$('#main-header').addClass("headerattop");
	} else {
		$('#main-header').addClass("headerscrolled");
		$('#main-header').removeClass("headerattop");
	}
});

// for remembering the collapse state of panels that can be collapsed. Stored in local storage. 
$(document).ready(function () {
	$('pre code').each(function (i, block) {
		hljs.highlightBlock(block);
	});

	$('.collapse')
		.on('hidden.bs.collapse', function () {
			if (this.id) {
				localStorage[this.id] = 'true';
			}
		})
		.on('shown.bs.collapse', function () {
			if (this.id) {
				localStorage.removeItem(this.id);
			}
		})
		.each(function () {
			if (this.id && localStorage[this.id] === 'true') {
				$(this).collapse('hide');
			}
		});
});

// Used for injecting the CSRF anti forgery token in an Ajax call. requires an empty form on the page with an anti forgery token.
function injectToken(data) {
	data.__RequestVerificationToken = $('#__AjaxAntiForgeryForm input[name=__RequestVerificationToken]').val();
	return data;
}

// Used for making a POST ajax call to the url specified in urlToPostTo. 
// expects the json method to return on success a JSON result object with a flag 'success' and a flag 'newstate' with the new state of the flag toggled.
function performAjaxToggleCall(urlToPostTo, successCallback) {
	$.ajax({
		url: urlToPostTo,
		data: injectToken({}),
		contenttype: "application/json; charset=utf-8",
		success: successCallback,
		error: function (xhr) {
			//'An AJAX error happened!. Server reported status: ' + xhr.status + 
			alert(xhr.responseText);
		},
		dataType: 'json',
		type: 'POST'
	});
}

