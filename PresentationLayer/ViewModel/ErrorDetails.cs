using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace PresentationLayer.ViewModel
{
    public class ErrorDetails
    {
        public int Status { get; set; }
        public string Title { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                }
            );
        }
    }
}
