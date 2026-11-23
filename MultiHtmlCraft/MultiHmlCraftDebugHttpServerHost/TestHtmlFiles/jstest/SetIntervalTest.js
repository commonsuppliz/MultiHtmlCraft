let count = 0;
function funcInterval() {
    count++;
    console.log(count);
}
const timerID = setInterval(funcInterval, 1000);

console.log(timerID);
