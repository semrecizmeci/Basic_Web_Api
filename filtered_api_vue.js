<!DOCTYPE html>
<html>
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Document</title>
    <link rel="stylesheet" href="test.css" />
    <script src="https://cdn.jsdelivr.net/npm/vue@2/dist/vue.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <style>
      table {
        border-collapse: collapse;
        width: 300px;
      }

      th,
      td {
        border: 1px solid black;
        padding: 10px;
        text-align: center;
      }
    </style>
  </head>
  <body>
    <div id="app">
      <table>
        <thead>
          <tr>
            <th>Nation</th>
            <th>Year</th>
            <th>Population</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="item in filterDatas" :key="item['ID Year']">
            <td>{{ item.Nation }}</td>
            <td>{{ item.Year }}</td>
            <td>{{ item.Population }}</td>
          </tr>
        </tbody>
      </table>
    </div>
    <script>
      new Vue({
        el: "#app",
        data() {
          return {
            apiData: [],
          };
        },
        computed: {
          filterDatas() {
            return this.apiData.filter((item) => item.Population > 318558162);
          },
        },
        mounted() {
          axios
            .get(
              "https://datausa.io/api/data?drilldowns=Nation&measures=Population"
            )
            .then((response) => {
              this.apiData = response.data.data;
            })
            .catch((error) => {
              console.log("API hatası:", error);
            });
        },
      });
    </script>
  </body>
</html>
