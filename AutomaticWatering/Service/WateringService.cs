using AutomaticWatering.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AutomaticWatering.Service
{
    public class WateringService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<Chanel> GetChanel()
        {
            using (HttpClient http = new HttpClient())
            {
                var requestUri = "http://api.thingspeak.com/channels/1385484/feed.json";
                HttpResponseMessage response = await http.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    dynamic stuff = JsonConvert.DeserializeObject(responseContent);
                    var dataChannel = stuff.channel;
                    if(dataChannel != null)
                    {
                        var channel = new Chanel() {
                            Id = dataChannel.id,
                            Name = dataChannel.name,
                            Description = dataChannel.description,
                            Created_At = DateTime.Parse((string)dataChannel.created_at),
                            Updated_At = DateTime.Parse((string)dataChannel.updated_at),
                            Last_Entry_Id = Int32.Parse((string)dataChannel.last_entry_id)
                        };
                        return channel;
                    }
                }
                return null;
            }
        }

        public static async Task<List<Feeds>> GetListFeeds()
        {
            using (HttpClient http = new HttpClient())
            {
                var requestUri = "http://api.thingspeak.com/channels/1385484/feed.json";
                HttpResponseMessage response = await http.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    dynamic stuff = JsonConvert.DeserializeObject(responseContent);
                    var dataFeeds = stuff.feeds;
                    if (dataFeeds != null)
                    {
                        var lstFeeds = new List<Feeds>();
                        foreach(var f in dataFeeds)
                        {
                            var feed = new Feeds()
                            {
                                CreateTime = DateTime.Parse((string)f.created_at),
                                EntryId = Int32.Parse((string)f.entry_id),
                                Field1 = Int32.Parse((string)f.field1),
                                Field2 = Int32.Parse((string)f.field2),
                            };
                            lstFeeds.Add(feed);
                        }
                        return lstFeeds;
                    }
                }
                return null;
            }
        }
    }
}