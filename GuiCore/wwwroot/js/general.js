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

	// a fix for the # jump issue in Firefox (see: https://stackoverflow.com/a/31919635 combined with https://stackoverflow.com/a/8611751)
	// In chrome this works without the script below, but in FF, the browser first scrolls and reflows of the HTML layout due to 
	// CSS being applied it will make the browser end up showing the wrong post. This script fixes it.
	//dom not only ready, but everything is loaded
	if (window.location.hash.length > 0) {
		window.scrollTo(0, $(window.location.hash).offset().top);
	}
});

// Used for injecting the CSRF anti forgery token in an Ajax call. requires an empty form on the page with an anti forgery token.
function injectToken(data) {
	data.__RequestVerificationToken = $('#__AjaxAntiForgeryForm input[name=__RequestVerificationToken]').val();
	return data;
}


// Used for making a POST ajax call to the url specified in urlToPostTo. 
// expects the json method to return on success a JSON result object
function performAjaxMethodCall(urlToPostTo, successCallback, errorCallback) {
	$.ajax({
		url: urlToPostTo,
		data: injectToken({}),
		contenttype: "application/json;charset=utf-8",
		success: successCallback,
		error: errorCallback, 
		dataType: 'json',
		type: 'POST'
	});
}

// Used for making a POST ajax call to the url specified in urlToPostTo, with no callbacks. 
// expects the json method to return on success a JSON result object
function performAjaxMethodCallWithData(urlToPostTo, dataObject) {
	$.ajax({
		url: urlToPostTo,
		data: JSON.stringify(dataObject),
		contentType: 'application/json;charset=utf-8',
		headers: { "RequestVerificationToken": $('#__AjaxAntiForgeryForm input[name=__RequestVerificationToken]').val() },
		dataType: 'json',
		type: 'POST',
		error: (jqXHR , err) => { displayErrorModal(jqXHR.responseJSON) },
		success: (result, status, jqXHR) => {},
	});
}


// this function requires a div on the page with id 'jsErrorMessageContainer', which contains a span with id 'jsErrorMessageTitle' and a
// an element with id 'jsErrorMessageDetail'.
function displayErrorModal(responseJson)
{
	$("#jsErrorMessageTitle").text(responseJson.title);
	$("#jsErrorMessageDetail").text(responseJson.detail);
	$("#jsErrorMessageContainer").removeClass("hidden");
}