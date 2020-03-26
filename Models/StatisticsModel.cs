namespace corona_map.Models
{

    using System;
    using System.Collections.Generic;

    public class StatisticsModel
    {

        public string? get { get; set; }
        public List<object?>? parameters { get; set; }
        public List<object?>? errors { get; set; }
        public int? results { get; set; }
        public List<Response?>? response { get; set; }

        public class Cases
        {
            public string? @new { get; set; }
            public int? active { get; set; }
            public int? critical { get; set; }
            public int? recovered { get; set; }
            public int? total { get; set; }
        }

        public class Deaths
        {
            public string? @new { get; set; }
            public int? total { get; set; }
        }

        public class Response
        {
            public string? country { get; set; }
            public Cases? cases { get; set; }
            public Deaths? deaths { get; set; }
            public string? day { get; set; }
            public DateTime? time { get; set; }
        }
    }
}