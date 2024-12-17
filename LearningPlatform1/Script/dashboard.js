document.getElementById("light-theme-btn").addEventListener("click", function () {
    document.body.classList.remove("dark-mode");
});

document.getElementById("dark-theme-btn").addEventListener("click", function () {
    document.body.classList.add("dark-mode");
});

// Set initial theme from local storage
if (localStorage.getItem("theme") === "dark") {
    document.body.classList.add("dark-mode");
} else {
    document.body.classList.add("light-mode");
}

//
document.addEventListener("DOMContentLoaded", function () {
    const progressBars = document.querySelectorAll('.progress-bar');

    progressBars.forEach(bar => {
        // Extract the target width from the inline style (e.g., "width: 75%")
        const width = bar.style.width.match(/(\d+)%/)[1]; // Extract the numeric part of width

        // Reset width to 0% and remove transition immediately
        bar.style.width = "0%";
        bar.style.transition = "none"; // Remove transition initially

        // Trigger a reflow to ensure the width reset is recognized
        void bar.offsetWidth; // This forces a reflow and ensures width reset is applied

        // Apply the transition and animate to the final width
        setTimeout(() => {
            bar.style.transition = "width 1s ease-in-out"; // Re-apply transition
            bar.style.width = width + "%"; // Animate to the target width
        }, 50); // Small delay to allow initial rendering of width as 0%
    });
});



document.addEventListener('DOMContentLoaded', function () {
    let timeLeft = 3600; // 1 hour
    const timerEl = document.getElementById('reward-timer');

    setInterval(() => {
        let hours = Math.floor(timeLeft / 3600);
        let minutes = Math.floor((timeLeft % 3600) / 60);
        let seconds = timeLeft % 60;

        timerEl.textContent = `${hours}:${minutes < 10 ? '0' + minutes : minutes}:${seconds < 10 ? '0' + seconds : seconds}`;

        if (timeLeft > 0) timeLeft--;
    }, 1000);


});