function github(){
    window.location = "https://github.com/SelyanSel/AppLink"
}

function openLink(link){
    window.location = link
}

var updateIndicator = document.getElementById('updateNeeded');
var updateIndicatorFalse = document.getElementById('updateNotNeeded');

fetch('https://raw.githubusercontent.com/SelyanSel/AppLink/main/updater/version.ref', {})
    .then(response => response.text())
    .then(text => {
        if (text === "1.0.1" || text === "1.0.1\n"){
            updateIndicator.remove();
        }else{
            updateIndicatorFalse.remove();
        }
    }
)