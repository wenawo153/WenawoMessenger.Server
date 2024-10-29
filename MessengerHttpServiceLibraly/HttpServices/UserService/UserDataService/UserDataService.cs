using Flurl;
using Flurl.Http;
using MessengerClassLibraly.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerHttpServiceLibraly.HttpServices.UserService.UserDataService
{
	public class UserDataService(HttpConfig httpConfig)
	{
		private string link = httpConfig.UserLink;

		public async Task<PersonUserGetData> GetPersonUserDataAsync(string userId)
		{
			try
			{
				var url = new Url($"{link}/data/getpersondata")
					.SetQueryParam("userId", userId);

				var response = await url.GetJsonAsync<PersonUserGetData>();

				return response;
			}
			catch { throw new Exception(); }
		}

		public async Task<UserViewData> GetViewUserDataAsync(string userId)
		{
			try
			{
				var url = new Url($"{link}/data/getviewuserdata")
					.SetQueryParam("userId", userId);

				var response = await url.GetJsonAsync<UserViewData>();

				return response;
			}
			catch { throw new Exception(); }
		}

		public async Task<PersonUserGetData> EditUserDataAsync(EditUserModel editUserModel)
		{
			try
			{
				var url = new Url($"{link}/data/edituserdata");

				var responce = await url.PostJsonAsync(editUserModel)
					.ReceiveJson<PersonUserGetData>();

				return responce;
			}
			catch { throw new Exception(); }
		}
	}
}
