using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // Stick with one JSON library

public class ApiService
{
    public static async Task<dynamic> PostAttendancesAsync(List<Dictionary<string, dynamic>> attendances)
    {
        try
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://warehousepk.store/warehouses/public/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Using Newtonsoft.Json for serialization
            var json = JsonConvert.SerializeObject(attendances);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("employer-moves", content);
            var responseString = await response.Content.ReadAsStringAsync();

            // Option 1: Dynamic approach
            dynamic responseData = JsonConvert.DeserializeObject(responseString);
            if (response.IsSuccessStatusCode)
            {
                bool status = responseData.success; // Assuming response has

                // Assuming response has a 'status' field
                if (status)
                return "تم التحميل بنجاح ";
                else
                {
                    if (responseData.errors != null)
                        return responseData.errors[0];
                    else return responseData.message;

                }
                // Option 2: Strongly-typed approach (recommended)
                // var responseData = JsonConvert.DeserializeObject<ApiResponse>(responseString);




                // return responseData.Status;
            }else
            {
                return responseData.message;
            }
           
        }
        catch (Exception ex)
        {
            // Log error if needed
            return ex.Message;
         
        }
    }
}

// For strongly-typed approach:
public class ApiResponse
{
    [JsonProperty("status")]
    public bool Status { get; set; }
}