let labels = ['Almanya', 'İspanya', 'İngiltere', 'Rusya', 'Fransa', 'Türkiye'];
let data = [25, 14, 47, 73, 38, 237];
let colors = ['#dee516', '#dbb20d', '#18ba22', '#08cecb', '#1350d3', '#d30c41'];

let myChart = document.getElementById("myChart").getContext('2d');

let chart = new Chart(myChart, {
    type: 'pie',
    data: {
        labels: labels,
        datasets: [{
            data: data,
            backgroundColor: colors
        }]
    },
    options: {
        title: {
            text: "Personellerin Ülkere Göre Dağılımı",
            display: true
        }
    }
});
