namespace corona_map
{
    using Microsoft.JSInterop;
    using System.Collections.Generic;
    using System.Text.Json;
    using Models;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System;

    public class CoronaMap
    {

        private readonly IJSRuntime _jsRuntime;

        private List<object> args = new List<object>{};

        private string api_key = "AIzaSyCr1ItKSMdCIetQV75sWj90-fQXhQsNoE0";

        private StatisticsModel statistics = null;

        public CoronaMap(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        private void AddArg(object arg)
        {
            this.args.Add(System.Text.Json.JsonSerializer.Serialize(arg));
        }
        
        private void ClearArgs()
        {
            this.args.Clear();
        }

        private async Task<string> GetStatistics()
        {
            string responseBody = "";
            try {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "20a0fe8dbcmshf02db372f3ef042p1d6fa4jsn83cdc1bb72f5");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "covid-193.p.rapidapi.com");
                var response = await client.GetAsync("https://covid-193.p.rapidapi.com/statistics");
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            } catch (HttpRequestException e) {
                System.Console.WriteLine(e.Message);
            }

            return responseBody;
        }

        private object[] GetDataFromStatistic(StatisticsModel.Response statistics, string selection)
        {
            object[] data = new object[2];
            statistics.country = statistics.country.Replace('-', ' ');
            switch(statistics.country)
            {
                case "USA":
                    data[0] = "United States";
                break;
                case "UK":
                    data[0] = "United Kingdom";
                break;
                case "DRC":
                    data[0] = "Democratic Republic of the Congo";
                break;
                default:
                    data[0] = statistics.country;
                break;
            }

            switch(selection)
            {
                case "active":
                    data[1] = statistics.cases.active??= 0;
                break;
                case "new":
                    data[1] = statistics.cases.@new??= "0";
                break;
                case "critical":
                     data[1] = statistics.cases.critical??= 0;
                break;
                case "total":
                    data[1] = statistics.cases.total??= 0;
                break;
                case "recovered":
                    data[1] = statistics.cases.recovered??= 0;
                break;
                case "deaths":
                    data[1] = statistics.deaths.total??= 0;
                break;
            }

            return data;
        }

        private object[][] ConvertStatisticsToRowData(StatisticsModel statistics, string selection)
        {
            
            object[][] rowData = new object[statistics.response.Count][];
            for(int i = 0; i < statistics.response.Count; ++i) {
                rowData[i] = this.GetDataFromStatistic(statistics.response[i], selection);
            }

            return rowData;
        }

        public async void InitMap(string selection)
        {
            this.AddArg(this.api_key);
            if (this.statistics == null) {
                var statisticsResponse = await this.GetStatistics();
                statistics = JsonConvert.DeserializeObject<StatisticsModel>(statisticsResponse);
            }

            var formatedData = ConvertStatisticsToRowData(statistics, selection);
            this.AddArg(formatedData);
            this.AddArg(selection);

            await _jsRuntime.InvokeVoidAsync("getMap", args);
            this.ClearArgs();
        }

        public string GetLastUpdatedDate()
        {
            if (this.statistics == null) {
                var statisticsResponse = this.GetStatistics().Result;
                statistics = JsonConvert.DeserializeObject<StatisticsModel>(statisticsResponse);
            }
            return statistics.response[0].day;
        }
    }
}