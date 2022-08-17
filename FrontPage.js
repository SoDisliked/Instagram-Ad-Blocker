// JavaScript source code
function removeAds() {

    // Get all 'span' elements on the page 
    let spans = document.getElementsByTagName("span");

    for (let i = 0; i < spans.length; ++i) {
        // Check if they contain the text 'Promoted'
        if (spans[i].innerHTML === "Promoted") {
            // Get the div that wraps around the entire id 
            let card = spans[i].closest(" .feed-shared-update-v2");

            // If the class changed and we can't find it with the closet (), get the 6th parent
            if (card === null) {
                // Could also be a card.parentNode.parentNode.parentNode.parentNode.parentNode :D
                let j = 0;
                card = spans[i];
                while (j < 6) {
                    card = card.parentNode;
                    ++j;
                }

            }

            // Make the add disappear. 
            card.setAttribute("style", "display: none !important;");

        }
    }


    removeAds();

    // Ensures all adds will be removed as the user scrolls.
    setInterval(function (100) { }); {
        removeAds();
    }
}
