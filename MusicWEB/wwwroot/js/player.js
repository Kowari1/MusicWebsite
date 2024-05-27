document.addEventListener('DOMContentLoaded', function () {
    var footerAudio = document.querySelector('.audio-element');
    var footerPlayerContainer = document.getElementById('footer-player-container');
    var playButton = document.querySelector('.play-btn');
    var pauseButton = document.querySelector('.pause-btn');
    var backButton = document.querySelector('.back-btn');
    var nextButton = document.querySelector('.next-btn');
    var volumUpButton = document.querySelector('.volum-up-btn');
    var volumOffButton = document.querySelector('.volume-off-btn');
    var currentTimeIndicator = document.querySelector('.current-time');
    var trackTitle = document.querySelector('.player-track-title');
    var totalTimeIndicator = document.querySelector('.total-time');
    var volumeSlider = document.querySelector('.volume-slider');
    var progressBar = document.querySelector('.progress-bar');
    var progressElement = document.querySelector('.progress');
    var coverTrack = document.querySelector('.cover-track');
    var currentTrack = null;
    var trackContainers = document.querySelectorAll('.track-container');
    var trackList = [];
    var isDragging = false;

    trackContainers.forEach(function (trackContainer) {

        var trackInfo = {
            id: Number(trackContainer.querySelector('.image-container').dataset.id),
            title: trackContainer.querySelector('span').textContent,
            musicUrl: trackContainer.querySelector('.image-container').dataset.musicUrl,
            playIcon: trackContainer.querySelector('.fa-play'),
            pauseIcon: trackContainer.querySelector('.fa-pause'),
            cover: trackContainer.querySelector('.image-container').dataset.imageUrl
        };
        trackList.push(trackInfo);
    });

    $('.image-container').on('click', function (event) {
        event.stopPropagation();
        var currentId = $(this).closest('.image-container').data('id');
        togglePlayPause(currentId);
    });

    function playAudio(track, currentTime = 0) {
        footerAudio.src = track.musicUrl;
        coverTrack.src = track.cover;
        coverTrack.style.display = 'inline';
        trackTitle.textContent = currentTrack.title;
        footerAudio.load();
        footerAudio.currentTime = currentTime; // Установка текущего времени             
        footerAudio.play();
        footerPlayerContainer.style.display = 'block';
    }

    backButton.addEventListener('click', function () {
        if (currentTrack == null) {
            togglePlayPause(1);
        }
        else {
            var index = trackList.indexOf(currentTrack);
            if (index <= trackList.length && index !== 0) {
                togglePlayPause(trackList[index - 1].id);
            }
            else {
                togglePlayPause(trackList[0].id);
            }
        }
    });

    nextButton.addEventListener('click', function () {
        if (currentTrack == null) {
            togglePlayPause(trackList[0].id);
        }
        else {
            var index = trackList.indexOf(currentTrack);
            if (index < trackList.length - 1) {
                togglePlayPause(trackList[index + 1].id);
            }
            else {
                togglePlayPause(trackList[trackList.length - 1].id);
            }
        }
    });

    volumUpButton.addEventListener('click', function () {
        console.log("up btn");
        this.style.display = 'none';
        volumOffButton.style.display = 'inline';
        volumeSlider.value = 0;
        footerAudio.volume = 0;
    });

    volumOffButton.addEventListener('click', function () {
        console.log("off btn");
        this.style.display = 'none';
        volumUpButton.style.display = 'inline';
        volumeSlider.value = 0.5;
        footerAudio.volume = 0.5;
    });

    playButton.addEventListener('click', function () {
        footerAudio.play();
    });

    pauseButton.addEventListener('click', function () {
        footerAudio.pause();
    });

    volumeSlider.addEventListener('input', function () {
        var volume = $(this).val();
        footerAudio.volume = volume;
    });

    progressBar.addEventListener('mousedown', function (event) {
        isDragging = true;
        updateProgressBar(event);
    });

    document.addEventListener('mousemove', function (event) {
        if (isDragging) {
            updateProgressBar(event);
        }
    });

    document.addEventListener('mouseup', function () {
        isDragging = false;
    });

    // Добавление поддержки сенсорных событий
    progressBar.addEventListener('touchstart', function (event) {
        isDragging = true;
        updateProgressBar(event.touches[0]);
    });

    document.addEventListener('touchmove', function (event) {
        if (isDragging) {
            event.preventDefault();
            updateProgressBar(event.touches[0]);
        }
    });

    document.addEventListener('touchend', function () {
        if (isDragging) {
            isDragging = false;
            footerAudio.currentTime = progressBar.value;
        }
    });

    progressBar.addEventListener('input', function (event) {
        updateProgressBar(event);
    });

    progressBar.addEventListener('change', function (event) {
        updateProgressBar(event);
    });

    footerAudio.addEventListener('loadedmetadata', function () {
        var duration = footerAudio.duration;
        progressBar.max = duration;
    });

    footerAudio.addEventListener('timeupdate', function () {
        var currentTime = footerAudio.currentTime;
        var totalTime = footerAudio.duration;
        var minutes = Math.floor(currentTime / 60);
        var seconds = Math.floor(currentTime % 60);
        var totalMinutes = Math.floor(totalTime / 60);
        var totalSeconds = Math.floor(totalTime % 60);

        currentTimeIndicator.textContent = minutes + ':' + (seconds < 10 ? '0' : '') + seconds;
        totalTimeIndicator.textContent = totalMinutes + ':' + (totalSeconds < 10 ? '0' : '') + totalSeconds;

        // Обновляем прогресс progressBar
        var progress = (currentTime / totalTime) * 100;
        progressBar.value = currentTime;
        updateProgress(progress);
    });

    function togglePlayPause(Id) {
        if (currentTrack === null) {
            currentTrack = findTrackById(Id);
            playAudio(currentTrack);
        }
        else {
            if (Id !== currentTrack.id) {
                currentTrack.playIcon.style.display = 'inline';
                currentTrack.pauseIcon.style.display = 'none';
                currentTrack = findTrackById(Id);
                playAudio(currentTrack);
            }
            else {
                if (footerAudio.paused) {
                    footerAudio.play();
                } else {
                    footerAudio.pause();
                }
            }
        }
    }

    footerAudio.addEventListener('play', function () {
        currentTrack.playIcon.style.display = 'none';
        currentTrack.pauseIcon.style.display = 'inline';
        playButton.style.display = 'none';
        pauseButton.style.display = 'inline';
    });

    footerAudio.addEventListener('pause', function () {
        currentTrack.playIcon.style.display = 'inline';
        currentTrack.pauseIcon.style.display = 'none';
        playButton.style.display = 'inline';
        pauseButton.style.display = 'none';
    });

    footerAudio.addEventListener('ended', function () {
        footerAudio.currentTime = 0;
        playButton.style.display = 'inline';
        pauseButton.style.display = 'none';
        progressBar.value = 0;
        updateProgress(0);
    });

    function findTrackById(id) {
        return trackList.find(track => track.id === id);
    }

    function updateProgressBar(event) {
        var rect = progressBar.getBoundingClientRect();
        var offsetX = event.clientX - rect.left || event.touches[0].clientX - rect.left;
        var totalWidth = rect.width;
        var newTime = (offsetX / totalWidth) * footerAudio.duration;
        footerAudio.currentTime = newTime;
        progressBar.value = newTime;
        updateProgress((newTime / footerAudio.duration) * 100);

        // Обновление прогресса в соответствии с новым значением времени
        var currentTime = footerAudio.currentTime;
        var progress = (currentTime / footerAudio.duration) * 100;
        progressBar.value = currentTime;
        updateProgress(progress);
    }

    function updateProgress(progress) {
        progressElement.style.width = progress + '%';
    }
});