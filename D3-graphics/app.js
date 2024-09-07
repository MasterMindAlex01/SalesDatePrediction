// Colores para las barras
const colors = ["#ff5733", "#33ff57", "#3357ff", "#ff33a8", "#a833ff"];

// Obtener referencias a los elementos del DOM
const inputField = document.getElementById('sourceData');
const updateButton = document.getElementById('updateDataBtn');
const chartDiv = document.getElementById('chart');

// Configuración inicial del gráfico
const margin = { top: 20, right: 30, bottom: 40, left: 50 };
const width = 500 - margin.left - margin.right;
const height = 300 - margin.top - margin.bottom;

// Crear el contenedor SVG para el gráfico
const svg = d3.select("#chart")
  .append("svg")
  .attr("width", width + margin.left + margin.right)
  .attr("height", height + margin.top + margin.bottom)
  .append("g")
  .attr("transform", `translate(${margin.left},${margin.top})`);

// Escalador de eje Y (para categorías)
const yScale = d3.scaleBand()
  .range([0, height])
  .padding(0.2);

// Escalador de eje X (para valores)
const xScale = d3.scaleLinear()
  .range([0, width]);

// Ejes
const xAxis = svg.append("g")
  .attr("transform", `translate(0, ${height})`);

const yAxis = svg.append("g");

// Función para actualizar el gráfico de barras horizontales
function updateChart(data) {
  // Actualizar escaladores de dominio
  yScale.domain(data.map((d, i) => i));
  xScale.domain([0, d3.max(data)]);

  // Selección de barras y su unión con los datos
  const bars = svg.selectAll(".bar")
    .data(data);

  // Remover barras viejas
  bars.exit().remove();

  // Actualizar las barras existentes
  bars
    .attr("x", 0)
    .attr("y", (d, i) => yScale(i))
    .attr("width", d => xScale(d))
    .attr("height", yScale.bandwidth())
    .attr("fill", (d, i) => colors[i % colors.length]);

  // Crear nuevas barras
  bars.enter()
    .append("rect")
    .attr("class", "bar")
    .attr("x", 0)
    .attr("y", (d, i) => yScale(i))
    .attr("width", d => xScale(d))
    .attr("height", yScale.bandwidth())
    .attr("fill", (d, i) => colors[i % colors.length]);

  // Actualizar los ejes
  xAxis.call(d3.axisBottom(xScale));
  yAxis.call(d3.axisLeft(yScale).tickFormat((d, i) => `Dato ${i + 1}`));
}

// Función para manejar el clic en el botón "Update Data"
updateButton.addEventListener('click', () => {
  const inputData = inputField.value;
  const dataArray = inputData.split(',')
    .map(d => d.trim())
    .filter(d => !isNaN(d)) // Validar que sean números
    .map(Number);

  if (dataArray.length > 0) {
    updateChart(dataArray);
  } else {
    alert("Por favor, ingresa una lista válida de números separados por coma.");
  }
});
