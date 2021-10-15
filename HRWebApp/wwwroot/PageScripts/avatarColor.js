const setBg = () => {
    const colorR = Math.floor((Math.random() * 256));
    const colorG = Math.floor((Math.random() * 256));
    const colorB = Math.floor((Math.random() * 256));
    document.getElementById("itemAvatarColor").style.background = "linear-gradient(135deg, rgba(+255, 255, 255, 0.4), rgb(" + colorR + "," + colorB + "," + colorG + ")) rgb(" + colorR + "," + colorB + "," + colorG + ")";
}
setBg();