document.getElementById("light-theme-btn").addEventListener("click", function () {
    document.body.classList.remove("dark-mode");
});

document.getElementById("dark-theme-btn").addEventListener("click", function () {
    document.body.classList.add("dark-mode");
});


if (localStorage.getItem("theme") === "dark") {
    document.body.classList.add("dark-mode");
} else {
    document.body.classList.add("light-mode");
}


document.addEventListener("DOMContentLoaded", function () {
    const progressBars = document.querySelectorAll('.progress-bar');

    progressBars.forEach(bar => {
        
        const width = bar.style.width.match(/(\d+)%/)[1]; 

        
        bar.style.width = "0%";
        bar.style.transition = "none"; 

        
        void bar.offsetWidth; 

        
        setTimeout(() => {
            bar.style.transition = "width 1s ease-in-out"; 
            bar.style.width = width + "%"; 
        }, 50); 
    });
});



document.addEventListener('DOMContentLoaded', function () {
    let timeLeft = 3600; 
    const timerEl = document.getElementById('reward-timer');

    setInterval(() => {
        let hours = Math.floor(timeLeft / 3600);
        let minutes = Math.floor((timeLeft % 3600) / 60);
        let seconds = timeLeft % 60;

        timerEl.textContent = `${hours}:${minutes < 10 ? '0' + minutes : minutes}:${seconds < 10 ? '0' + seconds : seconds}`;

        if (timeLeft > 0) timeLeft--;
    }, 1000);


});