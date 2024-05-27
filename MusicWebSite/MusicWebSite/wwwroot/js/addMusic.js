function previewImage()
{
    var fileInput = document.getElementById('imageFileInput');
    var imagePreview = document.getElementById('imagePreview');

    imagePreview.style.display = 'block';

    var reader = new FileReader();
    reader.onload = function (e) {
        imagePreview.src = e.target.result;
    }

    reader.readAsDataURL(fileInput.files[0]);
}

function previewAudio() {
    var audioFileInput = document.getElementById('audioFileInput');
    var audioPreview = document.getElementById('audioPreview');

    audioPreview.style.display = 'block';

    var reader = new FileReader();
    reader.onload = function (e) {
        audioPreview.src = e.target.result;
    }

    reader.readAsDataURL(audioFileInput.files[0]);
}

function changeImage() {
    var fileInput = document.getElementById('imageFileInput');
    fileInput.style.display = 'block';
    var imagePreview = document.getElementById('imagePreview');
    imagePreview.style.display = 'none';
}

function changeAudio() {
    var audioFileInput = document.getElementById('audioFileInput');
    audioFileInput.style.display = 'block';
    var audioPreview = document.getElementById('audioPreview');
    audioPreview.style.display = 'none';
}

