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

$('.dropdown').dropdown().on("hide.bs.dropdown", function (e) {
	if ($.contains(dropdown, e.target)) {
		e.preventDefault();
		//or return false;
	}
});
