using ApiAccessor.Accessors;
using ApiAccessor.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiAccessor
{
    public class PersonAccessor : IAccessor
    {
        async Task<IResponseModel> IAccessor.Load(string countryId, params string[] personNames)
        {
            countryId = countryId.Trim();

            if (personNames.Length <= 0)
            {
                return new PersonResponseModel() { Error = "Wrong data provided." };
            }

            string url;
            string baseUrl = "https://api.agify.io/";
            string contry = string.IsNullOrWhiteSpace(countryId) ? string.Empty : $"&country_id={countryId}";

            url = $"{baseUrl}?{FormatNames(personNames)}{contry}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    PersonResponseModel personResponse = await response.Content.ReadAsAsync<PersonResponseModel>();

                    return personResponse;
                }
                else
                {
                    return new PersonResponseModel() { Error = $"{response.Content}" };
                }
            }
        }

        private string FormatNames(string[] names)
        {
            string result = "";

            if (names.Length == 1)
            {
                return $"name={names[0]}";
            }

            for (int i = 0; i < names.Length; i++)
            {
                if (i + 1 == names.Length)
                {
                    result += $"name[]={names[i]}";
                }
                else
                {
                    result += $"name[]={names[i]}&";
                }
            }

            return result;
        }
    }
}
