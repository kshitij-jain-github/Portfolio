var words = [' Web Developer', ' Freelancer', ' ', ' Guitarist'  ],
    part,
    i = 1,
    offset = 0,
    len = words.length,
    forwards = true,
    skip_count = 0,
    skip_delay = 15,
    speed = 70;
var wordflick = function () {
    setInterval(function () {
        if (forwards) {
            if (offset >= words[i].length) {
                ++skip_count;
                if (skip_count == skip_delay) {
                    forwards = false;
                    skip_count = 0;
                }
            }
        }
        else {
            if (offset == 0) {
                forwards = true;
                i++;
                offset = 0;
                if (i >= len) {
                    i = 0;
                }
            }
        }
        part = words[i].substr(0, offset);
        if (skip_count == 0) {
            if (forwards) {
                offset++;
            }
            else {
                offset--;
            }
        }
        $('.word').text(part);
    }, speed);
};

$(document).ready(function () {
    wordflick();
});











const target = window.document.getElementsByTagName('h1')[0]

const flickerLetter = letter => `<span style="animation: text-flicker-in-glow ${Math.random() * 4}s linear both ">${letter}</span>`
const colorLetter = letter => `<span style="color: hsla(${Math.random() * 360}, 100%, 80%, 1);">${letter}</span>`;
const flickerAndColorText = text =>
    text
        .split('')
        .map(flickerLetter)
        .map(colorLetter)
        .join('');
const neonGlory = target => target.innerHTML = flickerAndColorText(target.textContent);


neonGlory(target);
target.onclick = ({ target }) => neonGlory(target);



