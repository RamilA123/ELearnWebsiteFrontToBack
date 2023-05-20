$(document).ready(function () {

	$(document).on("click", ".show-more", function () {

		let parent = $(".parentElem")

		let skipCount = $(parent).children().length;

		let courseCount = $("#courses").attr("data-count");

		$.ajax({
			url: `Course/ShowMoreOrLess?skip=${skipCount}`,
			type: "Get",
			success: function (res) {
				$(parent).append(res)
				skipCount = $(parent).children().length;
				if (skipCount >= courseCount) {
					$(".show-more").addClass("d-none")
					$(".show-less").removeClass("d-none")
				}
			}
		})
	})
	$(document).on("click", ".show-less", function () {

		let parent = $(".parentElem")

		let skipCount = 0;

		$.ajax({
			url: `Course/ShowMoreOrLess?skip=${skipCount}`,
			type: "Get",
			success: function (res) {
				$(parent).html("")
				$(parent).append(res)

				$(".show-less").addClass("d-none")
				$(".show-more").removeClass("d-none")

			}
		})
	})
})
