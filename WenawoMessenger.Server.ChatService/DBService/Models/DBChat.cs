﻿using MessengerClassLibraly.Chat;
using MessengerClassLibraly.Messege;
using System.ComponentModel.DataAnnotations.Schema;

namespace WenawoMessenger.Server.ChatService.DBService.Models
{
	public class DBChat
	{
		public int Id { get; set; }
		public string ChatName { get; set; } = null!;
		public string HostId { get; set; } = null!;
		public List<string> UsersId { get; set; } = null!;
		[Column(TypeName = "timestamp(6)")]
		public DateTime ChatCreatedDateTime { get; set; }

		public static DBChat ConvertOnChatFullData(ChatFullData chatFullData)
		{
			return new()
			{
				Id = chatFullData.Id,
				HostId = chatFullData.HostId,
				ChatCreatedDateTime = chatFullData.ChatCreatedDateTime,
				UsersId = chatFullData.UsersId,
				ChatName = chatFullData.ChatName
			};
		}
		public ChatFullData ConvertInChatFullData()
		{
			return new()
			{
				Id = Id,
				HostId = HostId,
				ChatCreatedDateTime = ChatCreatedDateTime,
				UsersId = UsersId,
				ChatName = ChatName
			};
		}
	}
}
