using ApiAccessor.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiAccessor
{
    public class PersonAccessor
    {
        public async Task<PersonResponseModel> LoadPerson(params string[] personNames)
        {
            if (personNames.Length <= 0)
            {
                return new PersonResponseModel() { Error = "Wrong data provided." };
            }

            string url;
            if (personNames.Length == 1)
            {
                url = $"https://api.agify.io/?name={personNames[0]}";
            }
            else
            {
                url = $"https://api.agify.io/?{FormatNames(personNames)}";
            }

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

        public async Task<PersonResponseModel> LoadPerson(string countryId, params string[] personNames)
        {
            countryId = countryId.Trim();

            if (personNames.Length <= 0 || string.IsNullOrWhiteSpace(countryId))
            {
                return new PersonResponseModel() { Error = "Wrong data provided." };
            }

            string url;
            if (personNames.Length == 1)
            {
                url = $"https://api.agify.io/?name={personNames[0]}&country_id={countryId}";
            }
            else
            {
                url = $"https://api.agify.io/?{FormatNames(personNames)}&country_id={countryId}";
            }

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
